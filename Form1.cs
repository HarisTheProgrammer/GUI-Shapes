using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace GUI
{
    /// <summary>
    /// The user interface for the draw with commands tool.
    /// The form presents to user a command typing window and
    /// a drawing area, with some basic information about
    /// the pen width, color, size of draw area, the current
    /// mouse location being presented on the form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The draw area exposed to be accessible to other classes
        /// </summary>
        public Bitmap drawArea;

        /// <summary>
        /// The starting x position of the cursor on the drawing area
        /// </summary>
        public int posX = 5;

        /// <summary>
        /// The starting y position of the cursor on the drawing area
        /// </summary>
        public int posY = 5;

        /// <summary>
        /// The starting pen width
        /// </summary>
        public int width = 3;

        /// <summary>
        /// The starting pen color
        /// </summary>
        public Color color = Color.Red;

        Icon cursorIcon = new Icon("cur.ico");

        /// <summary>
        /// Form constructor to initialize the UI elements in the form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            drawArea = new Bitmap(pb_Design.Size.Width, pb_Design.Size.Height);
            pb_Design.Image = drawArea;
            Graphics graphicsObj = Graphics.FromImage(drawArea);
            graphicsObj.DrawIcon(cursorIcon, posX, posY);
        }

        /// <summary>
        /// Clears the draw area
        /// </summary>
        private void clearImageArea()
        {
            Graphics graphicsObj = Graphics.FromImage(drawArea);
            graphicsObj.Clear(Color.White);
            pb_Design.Image = drawArea;
            graphicsObj.Dispose();
        }

        /// <summary>
        /// Click action handler for the run button on the form
        /// </summary>
        /// <param name="sender"> the event generator </param>
        /// <param name="e"> the event arguments </param>
        private void btn_Run_Click(object sender, EventArgs e)
        {
            clearImageArea();

            if (tb_Commands.Text.ToLower() == "run")
            {
                List<string> commands = new List<string>();

                if (!string.IsNullOrWhiteSpace(rtb_Commands.Text))
                {
                    for (int i = 0; i < rtb_Commands.Text.Split(new string[] { "\n" }, StringSplitOptions.None).Length; i++)
                    {
                        commands.Add(rtb_Commands.Text.Split(new string[] { "\n" }, StringSplitOptions.None)[i]);
                    }

                }
                bool falseStatement = false;
                string textMessage = "";
                for (int i = 0; i < commands.Count; i++)
                {
                    string command = commands[i];
                    string values = string.Empty;
                    bool isShapeCmd = false;
                    int shapeType = 0;
                    if (!commands[i].Contains("clear") && !commands[i].Contains("reset"))
                    {
                        values = command.Split('(', ')')[1];
                        if (!checkArguments(i, values)) return;

                        if (commands[i].Contains("penWidth"))
                            command = "setWidth";
                        else if (commands[i].Contains("penColor"))
                            command = "setColor";
                        else if (commands[i].Contains("pen")) { 
                            //Move To
                            string com = commands[i].Split('(')[0];
                            string[] firstargs = com.Split(' ');

                            if (firstargs.Length == 1)
                            {
                                //pen
                                command = "moveTo";
                            }
                            else if (firstargs.Length == 2)
                            {
                                //pen draw
                                command = "drawTo";
                            }
                            //Draw to
                        }
                        else
                        if (commands[i].Contains("moveTo"))
                            command = "moveTo";
                        else if (commands[i].Contains("drawTo"))
                            command = "drawTo";
                        else if (commands[i].Contains("save"))
                        {
                            string com = commands[i].Split('(')[0];
                            command = "save";
                            if (com.ToLower() != "save")
                            {
                                falseStatement = true; textMessage = "Error: Did you try to enter save?";
                            }
                            string fileName = commands[i].Split('(',')')[1]+".txt";
                            try
                            {
                                // Check if file already exists. If yes, delete it.     
                                if (File.Exists(fileName))
                                {
                                    File.Delete(fileName);
                                }

                                // Create a new file     
                                using (FileStream fs = File.Create(fileName))
                                {
                                    // Add some text to file    
                                    for (int j = 0; j < commands.Count; j++)
                                    {
                                        Byte[] title = new UTF8Encoding(true).GetBytes(commands[j]+"\n");
                                        fs.Write(title, 0, title.Length);
                                    }
                                }

                                // Open the stream and read it back.    
                                //using (StreamReader sr = File.OpenText(fileName))
                                //{
                               //     string s = "";
                                //    while ((s = sr.ReadLine()) != null)
                                //    {
                                //        Console.WriteLine(s);
                                //    }
                               // }
                            }
                            catch (Exception Ex)
                            {
                                Console.WriteLine(Ex.ToString());
                            }
                        }
                        else if (commands[i].Contains("load"))
                        {
                            string com = commands[i].Split('(')[0];
                            command = "load";
                            if (com.ToLower() != "load")
                            {
                                falseStatement = true; textMessage = "Error: Did you try to enter load?";
                            }
                            string fileName = commands[i].Split('(', ')')[1] + ".txt";
                            try
                            {
                                // Check if file already exists. If yes, delete it. 
                                string fileText = "";
                                if (File.Exists(fileName))
                                {
                                    using (StreamReader sr = File.OpenText(fileName))
                                   {
                                         string s = "";
                                        while ((s = sr.ReadLine()) != null)
                                        {
                                           Console.WriteLine(s);
                                            fileText += s + "\n";

                                        }
                                    }
                                    rtb_Commands.Text = fileText;
                                    // 
                                }
                                else { 
                                    //File Do Not Exists
                                }
    
                               
                            }
                            catch (Exception Ex)
                            {
                                Console.WriteLine(Ex.ToString());
                            }
                        }
                        else if (commands[i].Contains("rectangle"))
                        {
                            string com = commands[i].Split('(')[0];

                            if (com.ToLower() != "rectangle")
                            {
                                falseStatement = true; textMessage = "Error: Did you try to enter rectangle?";
                            }

                            string[] args = values.Split(',');
                            if (args.Length != 2)
                            {
                                falseStatement = true;
                                textMessage = "Enter two numeric arguments for rectangle";
                            }
                            else
                            {//check for numericals
                                int myInt;
                                bool isNumerical = int.TryParse(args[0], out myInt);
                                bool isNumerical1 = int.TryParse(args[1], out myInt);
                                if (!isNumerical || !isNumerical1)
                                {
                                    falseStatement = true;
                                    textMessage = "Enter two numeric arguments for rectangle";
                                }
                                else
                                {
                                    shapeType = 1;
                                    isShapeCmd = true;
                                }
                            }
                        }
                        else if (commands[i].Contains("circle"))
                        {
                            string com = commands[i].Split('(')[0];
                            
                            if (com.ToLower() != "circle" ) {
                                falseStatement = true; textMessage = "Error: Did you try to enter circle?";
                            }
                            string[] args = values.Split(',');
                            if (args.Length != 1)
                            {
                                falseStatement = true;
                                textMessage = "Enter one numeric argument for circle";

                            }
                            else
                            {
                                //check for numericals
                                int myInt;
                                bool isNumerical = int.TryParse(args[0], out myInt);
                                if (!isNumerical)
                                {
                                    falseStatement = true;
                                    textMessage = "Enter one numeric argument for circle";
                                }
                                else
                                {
                                    shapeType = 2;
                                    isShapeCmd = true;
                                }
                            }

                        }
                        else if (commands[i].Contains("triangle"))
                        {
                            string com = commands[i].Split('(')[0];

                            if (com.ToLower() != "triangle")
                            {
                                falseStatement = true; textMessage = "Error: Did you try to enter triangle?";
                            }

                            string[] args = values.Split(',');
                            if (args.Length != 3)
                            {
                                falseStatement = true;
                                textMessage = "Enter three numeric arguments for triangle";

                            }
                            else
                            {
                                int myInt;
                                bool isNumerical = int.TryParse(args[0], out myInt);
                                bool isNumerical1 = int.TryParse(args[1], out myInt);
                                bool isNumerical2 = int.TryParse(args[2], out myInt);
                                if (!isNumerical || !isNumerical1 || !isNumerical2)
                                {
                                    falseStatement = true;
                                    textMessage = "Enter three numeric arguments for triangle";
                                }
                                else
                                {
                                    shapeType = 3;
                                    isShapeCmd = true;
                                }
                            }
                        }
                        else if (commands[i].Contains("setWidth"))
                            command = "setWidth";
                        else if (commands[i].Contains("setColor"))
                            command = "setColor";
                        
                        else if (commands[i].Contains("cir")) {
                            falseStatement = true;
                            textMessage = "Error: Did you try to enter circle?";
                        } else if (commands[i].Contains("rec")) {
                            falseStatement = true;
                            textMessage = "Error: Did you try to enter rectangle?";
                        }
                        else if (commands[i].Contains("trian"))
                        {
                            falseStatement = true;
                            textMessage = "Error: Did you try to enter triangle?";
                        }
                    }
                    if (falseStatement) handleFalseStatement(textMessage);
                    else if (isShapeCmd) drawShape(shapeType, values);
                    else 
                    {
                        switch (command)
                        {
                            case "setWidth":
                                setWidth(values);
                                break;
                            case "setColor":
                                setColor(values);
                                break;
                            case "moveTo":
                                moveTo(values);
                                break;
                            case "drawTo":
                                drawTo(values);
                                break;
                            case "clear":
                                clear();
                                break;
                            case "reset":
                                reset();
                                break;
                            case "resetPen":
                                reset();
                                break;
                            case "save":
                                save();
                                break;
                            case "load":
                                load();
                                break;
                            default:
                                txt_Status.Text = String.Format("Command {0} is Invalid", i + 1);
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Draws the given shape type with the specified arguments
        /// </summary>
        /// <param name="shapeType"> the shapetype, used to obtain the shape from factory </param>
        /// <param name="args"> the arguments for the shape </param>
        private void drawShape(int shapeType, string args)
        {
            Shape shape = ShapeFactory.GetShape(shapeType);
            bool status = shape.Draw(this, args);
            if (status)
            {
                pb_Design.Image = drawArea;
                txt_Status.Text = "Command Executed Successfully.";
            }
            else txt_Status.Text = "Invalid Input Dimensions";
        }

        private void handleFalseStatement(string message)
        {
            txt_Status.Text = message;
        }

        /// <summary>
        /// The arguments validator
        /// </summary>
        /// <param name="i"> The line number of the command </param>
        /// <param name="values"> the arguments / command entered on the line </param>
        /// <returns> true if a valid command else false </returns>
        private bool checkArguments(int i, string values)
        {
            string[] args = values.Split(',');
            bool status = true;

            if(args.Length > 1)
            {
                for (int j = 0; j < args.Length; j++)
                {
                    try
                    {
                        int argV = Convert.ToInt32(args[j]);
                        if (j % 2 == 0) {
                            if (argV < 5 || argV > (pb_Design.Size.Width - 10))
                            {
                                txt_Status.Text = String.Format("Command {0}, Invalid param {1} [{2} - {3}]", i+1, j + 1, 5, pb_Design.Size.Width - 10);
                                status = false;
                                break;
                            }
                        }
                        else if (argV < 5 || argV > (pb_Design.Size.Height - 10))
                        {
                            txt_Status.Text = String.Format("Command {0}, Invalid param {1} [{2} - {3}]", i+1, j + 1, 5, pb_Design.Size.Height - 10);
                            status = false;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        txt_Status.Text = String.Format("Command {0}, Invalid param {1}", i+1, j+1);
                        status = false;
                        break;
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// Sets the pen color for all future drawing
        /// </summary>
        /// <remarks>
        /// The color will be entered as string e.g "red" or "green"
        /// </remarks>
        /// <param name="values"> the color value entered as string </param>
        public void setColor(string values)
        {
            try
            {
                txt_Status.Text = "Pen Color Changed.";
                string vcol = "Red";
                switch (values.ToLower())
                {
                    case "red": color = Color.Red; vcol = "Red"; break;
                    case "black": color = Color.Black; vcol = "Black"; break;
                    case "blue": color = Color.Blue; vcol = "Blue"; break;
                    case "brown": color = Color.Brown; vcol = "Brown"; break;
                    case "green": color = Color.Green; vcol = "Green"; break;
                    case "yellow": color = Color.Yellow; vcol = "Yellow"; break;
                    case "cyan": color = Color.Cyan; vcol = "Cyan"; break;
                    case "magenta": color = Color.Magenta; vcol = "Magenta"; break;
                    case "purple": color = Color.Purple; vcol = "Purple"; break;
                    case "gray": color = Color.Gray; vcol = "Gray"; break;
                    default:
                        color = Color.Red;
                        txt_Status.Text = "Invalid Pen Color";
                        break;
                }
                txt_Color.Text = String.Format("Pen Color = {0}", vcol);
            }
            catch (Exception ex)
            {
                txt_Status.Text = "Invalid Pen Color";
            }
        }

        /// <summary>
        /// Sets the pen width for all future drawing
        /// </summary>
        /// <remarks>
        /// The width has to be between 1 - 5 inclusive,
        /// any other value will be invalid and error shown
        /// </remarks>
        /// <param name="values"> the width of the pen entered as string </param>
        public void setWidth(string values)
        {
            try
            {
                int w = Convert.ToInt16(values);
                if (w < 1 || w > 5)
                {
                    throw new Exception("Invalid width");
                }
                width = w;
                txt_Status.Text = "Pen width changed successfully";
                txt_Width.Text = String.Format("Pen Width = {0}", w);
            }
            catch (Exception ex)
            {
                txt_Status.Text = "Invalid Width Specified";
            }
        }

        /// <summary>
        /// Executes the command to move the current cursor position
        /// </summary>
        /// <param name="values"> the new cursor position entered as string </param>
        public void moveTo(string values)
        {
            try
            {
                int x = Convert.ToInt16(values.Split(',')[0]);
                int y = Convert.ToInt16(values.Split(',')[1]);
                Graphics graphicsObj = Graphics.FromImage(drawArea);
                //graphicsObj.DrawIcon(null, posX, posY);
                posX = x;
                posY = y;
               
                txt_Pos.Text = String.Format("Current Position = [{0},{1}]", posX, posY);
                txt_Status.Text = "Cursor Moved Successfully";
           
                graphicsObj.DrawIcon(cursorIcon, posX, posY);
            }
            catch (Exception ex)
            {
                txt_Status.Text = "Invalid Input Dimensions";
            }
        }

        /// <summary>
        /// Draws a line to the given position from the current cursor position
        /// </summary>
        /// <param name="values"> the to point location entered as string </param>
        public void drawTo(string values)
        {
            Graphics graphicsObj = Graphics.FromImage(drawArea);
            Pen myPen = new Pen(color, width);
            try
            {
                int toX = Convert.ToInt16(values.Split(',')[0]);
                int toY = Convert.ToInt16(values.Split(',')[1]);
                //graphicsObj.DrawIcon(null, posX, posY);
                graphicsObj.DrawLine(myPen, posX, posY, toX, toY);
                graphicsObj.DrawIcon(cursorIcon,toX, toY);
                posX = toX;
                posY = toY;
                pb_Design.Image = drawArea;
                txt_Status.Text = "Line drawn successfully";
            }
            catch (Exception ex)
            {
                txt_Status.Text = "Invalid input dimensions";
            }
        }

        /// <summary>
        /// Clears the fields in the form along with status and command area.
        /// </summary>
        public void clear()
        {
            txt_Status.Text = "<Command Status>";
            tb_Commands.Text = "";
            rtb_Commands.Text = "";
            clearImageArea();
        }

        /// <summary>
        /// Resets the form, the starting position, the pen width and color.
        /// </summary>
        public void reset()
        {
            txt_Status.Text = "<Command Status>";
            tb_Commands.Text = "";
            rtb_Commands.Text = "";
            txt_Pos.Text = "Current Position = [5,5]";
            posX = posY = 5;
            width = 3;
            color = Color.Red;
            txt_Color.Text = "Pen Color = Red";
            txt_Width.Text = "Pen Width = 3";
            clearImageArea();
        }


        public void save()
        {
            txt_Status.Text = "File Saved Successfully";
        }
        public void load()
        {
            txt_Status.Text = "File Loaded Successfully";
        }
        /// <summary>
        /// Event handler for the button1
        /// </summary>
        /// <param name="sender"> the event source </param>
        /// <param name="e"> the event argument </param>
        private void button1_Click(object sender, EventArgs e)
        {
            rtb_Commands.Visible = true;
            tb_Commands.Visible = true;
            btn_Run.Visible = true;
            this.Invalidate();
        }

        /// <summary>
        /// The load event execution point for the form
        /// </summary>
        /// <param name="sender"> the event information </param>
        /// <param name="e"> the event argument </param>
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(drawArea);
            g.Clear(Color.White);
            g.Dispose();
            txt_Pos.Text = "Current Position = [5,5]";
            txt_Size.Text = String.Format("Draw Area Size = [{0}, {1}]", pb_Design.Size.Width - 10, pb_Design.Size.Height - 10);
            txt_Color.Text = "Pen Color = Red";
            txt_Width.Text = "Pen Width = 3";
        }

        private void txt_Color_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtb_Commands_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Commands_TextChanged(object sender, EventArgs e)
        {

        }

        private void pb_Design_Click(object sender, EventArgs e)
        {

        }
    }
}
