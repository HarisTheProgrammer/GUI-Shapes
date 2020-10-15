using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Shape class: an abstract class to be implemented by all the concrete shapes.
    /// </summary>
    /// <remarks>
    /// Every new shape to be added to the code will have to derive from this abstract class
    /// to be able to become part of the code and being drawn with help of the appropriate command
    /// </remarks>
    public abstract class Shape
    {
        public abstract bool Draw(Form1 drawForm, String args);
    }

    /// <summary>
    /// ShapeRectangle class: inherits the abstract class Shape
    /// </summary>
    public class ShapeRectangle : Shape
    {
        /// <summary>
        /// Draws a rectangle onto the drawing area of the form with the given params
        /// </summary>
        /// <remarks>
        /// Implements the only abstract function in the base class
        /// </remarks>
        /// <param name="form"> the form from which the command was issued </param>
        /// <param name="args"> the position and size related arguments </param>
        /// <returns> true if rectanle was drawn successfully else false </returns>
        public override bool Draw(Form1 form, string args)
        {
            bool status = true;
            Graphics graphicsObj = Graphics.FromImage(form.drawArea);
            Pen myPen = new Pen(form.color, form.width);
            try
            {
                    string[] vals = args.Split(',');
                    if (vals.Length != 2) throw new Exception();
                    Rectangle myRectangle = new Rectangle(form.posX, form.posY, Convert.ToInt16(vals[0]), Convert.ToInt16(vals[1]));

                    graphicsObj.DrawRectangle(myPen, myRectangle);

             
            }
            catch (Exception ex)
            {
                status = false;
            }

            return status;
        }
    }

    /// <summary>
    /// ShapeCircle class: inherits the abstract class Shape
    /// </summary>
    public class ShapeCircle : Shape
    {
        /// <summary>
        /// Draws a cirlce onto the drawing area of the form with the given params
        /// </summary>
        /// <remarks>
        /// Implements the only abstract function in the base class
        /// </remarks>
        /// <param name="form"> the form from which the command was issued </param>
        /// <param name="args"> the position and size related arguments </param>
        /// <returns> true if circle was drawn successfully else false </returns>
        public override bool Draw(Form1 form, string args)
        {
            Console.WriteLine(args);
            bool status = true;
            Graphics graphicsObj = Graphics.FromImage(form.drawArea);
            Pen myPen = new Pen(form.color, form.width);
            try
            {
                string[] vals = args.Split(',');

                    
                        if (vals.Length != 1) throw new Exception();
                        Rectangle myRectangle = new Rectangle(form.posX, form.posY, Convert.ToInt16(vals[0]), Convert.ToInt16(vals[0]));
                        graphicsObj.DrawEllipse(myPen, myRectangle);
       
            }
            catch (Exception ex)
            {
                status = false;
            }

            return status;
        }
    }

    /// <summary>
    /// ShapeTriangle class: inherits the abstract class Shape
    /// </summary>
    public class ShapeTriangle : Shape
    {
        /// <summary>
        /// Draws a triangle onto the drawing area of the form with the given params
        /// </summary>
        /// <remarks>
        /// Implements the only abstract function in the base class
        /// </remarks>
        /// <param name="form"> the form from which the command was issued </param>
        /// <param name="args"> the position and size related arguments </param>
        /// <returns> true if triangle was drawn successfully else false </returns>
        public override bool Draw(Form1 form, string args)
        {
            bool status = true;
            Graphics graphicsObj = Graphics.FromImage(form.drawArea);
            Pen myPen = new Pen(form.color, form.width);
            try
            {
                
                    string[] vals = args.Split(',');
                    if (vals.Length != 3) throw new Exception();
                int a = Convert.ToInt16(vals[0]);
                    int b = Convert.ToInt16(vals[1]);
                    int c = Convert.ToInt16(vals[2]);
                    double x = (a * a + b * b - c * c) / (2 * a);
                    double y = Math.Sqrt(b * b - ((a * a + b * b - c * c) / (2 * a)) * ((a * a + b * b - c * c) / (2 * a)));
                Console.WriteLine(x);
                Console.WriteLine(y);
                graphicsObj.DrawLine(myPen, form.posX, form.posY, Convert.ToInt32(form.posX+x), Convert.ToInt32(form.posY +y));
                    graphicsObj.DrawLine(myPen, Convert.ToInt32(form.posX + x), Convert.ToInt32(form.posY + y), Convert.ToInt32(form.posX + x), Convert.ToInt32(form.posY- y));
                    graphicsObj.DrawLine(myPen, Convert.ToInt32(form.posX + x), Convert.ToInt32(form.posY - y), form.posX, form.posY);
    
            }
            catch (Exception ex)
            {
                status = false;
            }

            return status;
        }
    }
}
