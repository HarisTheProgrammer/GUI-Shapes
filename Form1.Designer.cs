namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb_Commands = new System.Windows.Forms.RichTextBox();
            this.tb_Commands = new System.Windows.Forms.TextBox();
            this.pb_Design = new System.Windows.Forms.PictureBox();
            this.btn_Run = new System.Windows.Forms.Button();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.txt_Pos = new System.Windows.Forms.TextBox();
            this.txt_Size = new System.Windows.Forms.TextBox();
            this.txt_Width = new System.Windows.Forms.TextBox();
            this.txt_Color = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Design)).BeginInit();
            this.SuspendLayout();
            // 
            // rtb_Commands
            // 
            this.rtb_Commands.BackColor = System.Drawing.Color.Yellow;
            this.rtb_Commands.Location = new System.Drawing.Point(29, 48);
            this.rtb_Commands.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtb_Commands.Name = "rtb_Commands";
            this.rtb_Commands.Size = new System.Drawing.Size(343, 296);
            this.rtb_Commands.TabIndex = 0;
            this.rtb_Commands.Text = "";
            this.rtb_Commands.TextChanged += new System.EventHandler(this.rtb_Commands_TextChanged);
            // 
            // tb_Commands
            // 
            this.tb_Commands.BackColor = System.Drawing.Color.Black;
            this.tb_Commands.ForeColor = System.Drawing.Color.White;
            this.tb_Commands.Location = new System.Drawing.Point(29, 363);
            this.tb_Commands.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_Commands.Name = "tb_Commands";
            this.tb_Commands.Size = new System.Drawing.Size(343, 22);
            this.tb_Commands.TabIndex = 1;
            this.tb_Commands.TextChanged += new System.EventHandler(this.tb_Commands_TextChanged);
            // 
            // pb_Design
            // 
            this.pb_Design.BackColor = System.Drawing.Color.AliceBlue;
            this.pb_Design.Location = new System.Drawing.Point(427, 48);
            this.pb_Design.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_Design.Name = "pb_Design";
            this.pb_Design.Size = new System.Drawing.Size(467, 391);
            this.pb_Design.TabIndex = 2;
            this.pb_Design.TabStop = false;
            this.pb_Design.Click += new System.EventHandler(this.pb_Design_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.BackColor = System.Drawing.Color.Green;
            this.btn_Run.ForeColor = System.Drawing.Color.White;
            this.btn_Run.Location = new System.Drawing.Point(29, 414);
            this.btn_Run.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(83, 28);
            this.btn_Run.TabIndex = 3;
            this.btn_Run.Text = "Run";
            this.btn_Run.UseVisualStyleBackColor = false;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // txt_Status
            // 
            this.txt_Status.Enabled = false;
            this.txt_Status.Location = new System.Drawing.Point(119, 415);
            this.txt_Status.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.Size = new System.Drawing.Size(253, 22);
            this.txt_Status.TabIndex = 4;
            this.txt_Status.Text = "<Command Status>";
            // 
            // txt_Pos
            // 
            this.txt_Pos.BackColor = System.Drawing.Color.AliceBlue;
            this.txt_Pos.Enabled = false;
            this.txt_Pos.Location = new System.Drawing.Point(427, 15);
            this.txt_Pos.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Pos.Name = "txt_Pos";
            this.txt_Pos.Size = new System.Drawing.Size(227, 22);
            this.txt_Pos.TabIndex = 5;
            this.txt_Pos.Text = "<Current Position>";
            // 
            // txt_Size
            // 
            this.txt_Size.BackColor = System.Drawing.Color.AliceBlue;
            this.txt_Size.Enabled = false;
            this.txt_Size.Location = new System.Drawing.Point(665, 15);
            this.txt_Size.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Size.Name = "txt_Size";
            this.txt_Size.Size = new System.Drawing.Size(227, 22);
            this.txt_Size.TabIndex = 6;
            this.txt_Size.Text = "<Draw Area Size>";
            // 
            // txt_Width
            // 
            this.txt_Width.BackColor = System.Drawing.Color.AliceBlue;
            this.txt_Width.Enabled = false;
            this.txt_Width.Location = new System.Drawing.Point(29, 15);
            this.txt_Width.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Width.Name = "txt_Width";
            this.txt_Width.Size = new System.Drawing.Size(165, 22);
            this.txt_Width.TabIndex = 7;
            this.txt_Width.Text = "<Pen Width>";
            // 
            // txt_Color
            // 
            this.txt_Color.BackColor = System.Drawing.Color.AliceBlue;
            this.txt_Color.Enabled = false;
            this.txt_Color.Location = new System.Drawing.Point(207, 15);
            this.txt_Color.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Color.Name = "txt_Color";
            this.txt_Color.Size = new System.Drawing.Size(165, 22);
            this.txt_Color.TabIndex = 8;
            this.txt_Color.Text = "<Pen Color>";
            this.txt_Color.TextChanged += new System.EventHandler(this.txt_Color_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 457);
            this.Controls.Add(this.txt_Color);
            this.Controls.Add(this.txt_Width);
            this.Controls.Add(this.txt_Size);
            this.Controls.Add(this.txt_Pos);
            this.Controls.Add(this.txt_Status);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.tb_Commands);
            this.Controls.Add(this.rtb_Commands);
            this.Controls.Add(this.pb_Design);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Graphics Programming Language";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Design)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_Commands;
        private System.Windows.Forms.TextBox tb_Commands;
        private System.Windows.Forms.PictureBox pb_Design;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.TextBox txt_Pos;
        private System.Windows.Forms.TextBox txt_Size;
        private System.Windows.Forms.TextBox txt_Width;
        private System.Windows.Forms.TextBox txt_Color;
    }
}

