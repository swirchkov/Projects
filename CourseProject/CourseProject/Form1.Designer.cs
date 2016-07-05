namespace CourseProject
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.paralelogram_Button = new System.Windows.Forms.Button();
            this.section_Button = new System.Windows.Forms.Button();
            this.trapezien_Button = new System.Windows.Forms.Button();
            this.parallelipiped_Button = new System.Windows.Forms.Button();
            this.figure_button = new System.Windows.Forms.Button();
            this.listFigures = new System.Windows.Forms.ListBox();
            this.Move = new System.Windows.Forms.Button();
            this.Scale = new System.Windows.Forms.Button();
            this.P = new System.Windows.Forms.Button();
            this.S = new System.Windows.Forms.Button();
            this.toString = new System.Windows.Forms.Button();
            this.point_button = new System.Windows.Forms.Button();
            this.pyramid_Button = new System.Windows.Forms.Button();
            this.rhombus_Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(271, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(451, 387);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Peru;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(309, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Displaying figures";
            // 
            // paralelogram_Button
            // 
            this.paralelogram_Button.Location = new System.Drawing.Point(12, 49);
            this.paralelogram_Button.Name = "paralelogram_Button";
            this.paralelogram_Button.Size = new System.Drawing.Size(108, 38);
            this.paralelogram_Button.TabIndex = 4;
            this.paralelogram_Button.Text = "Paralelogram";
            this.paralelogram_Button.UseVisualStyleBackColor = true;
            this.paralelogram_Button.Click += new System.EventHandler(this.paralelogram_Button_Click);
            // 
            // section_Button
            // 
            this.section_Button.Location = new System.Drawing.Point(126, 49);
            this.section_Button.Name = "section_Button";
            this.section_Button.Size = new System.Drawing.Size(94, 38);
            this.section_Button.TabIndex = 7;
            this.section_Button.Text = "Section";
            this.section_Button.UseVisualStyleBackColor = true;
            this.section_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // trapezien_Button
            // 
            this.trapezien_Button.Location = new System.Drawing.Point(126, 93);
            this.trapezien_Button.Name = "trapezien_Button";
            this.trapezien_Button.Size = new System.Drawing.Size(94, 38);
            this.trapezien_Button.TabIndex = 9;
            this.trapezien_Button.Text = "Trapezien";
            this.trapezien_Button.UseVisualStyleBackColor = true;
            this.trapezien_Button.Click += new System.EventHandler(this.trapezien_Button_Click);
            // 
            // parallelipiped_Button
            // 
            this.parallelipiped_Button.Location = new System.Drawing.Point(12, 93);
            this.parallelipiped_Button.Name = "parallelipiped_Button";
            this.parallelipiped_Button.Size = new System.Drawing.Size(108, 38);
            this.parallelipiped_Button.TabIndex = 11;
            this.parallelipiped_Button.Text = "Parallelipiped";
            this.parallelipiped_Button.UseVisualStyleBackColor = true;
            this.parallelipiped_Button.Click += new System.EventHandler(this.parallelipiped_Button_Click);
            // 
            // figure_button
            // 
            this.figure_button.Location = new System.Drawing.Point(9, 5);
            this.figure_button.Name = "figure_button";
            this.figure_button.Size = new System.Drawing.Size(111, 38);
            this.figure_button.TabIndex = 12;
            this.figure_button.Text = "Figure";
            this.figure_button.UseVisualStyleBackColor = true;
            this.figure_button.Click += new System.EventHandler(this.button6_Click);
            // 
            // listFigures
            // 
            this.listFigures.FormattingEnabled = true;
            this.listFigures.Location = new System.Drawing.Point(12, 190);
            this.listFigures.Name = "listFigures";
            this.listFigures.Size = new System.Drawing.Size(208, 290);
            this.listFigures.TabIndex = 13;
            this.listFigures.SelectedIndexChanged += new System.EventHandler(this.listFigures_SelectedIndexChanged);
            // 
            // Move
            // 
            this.Move.Location = new System.Drawing.Point(8, 520);
            this.Move.Name = "Move";
            this.Move.Size = new System.Drawing.Size(94, 38);
            this.Move.TabIndex = 14;
            this.Move.Text = "Move";
            this.Move.UseVisualStyleBackColor = true;
            this.Move.Click += new System.EventHandler(this.Move_Click);
            // 
            // Scale
            // 
            this.Scale.Location = new System.Drawing.Point(208, 520);
            this.Scale.Name = "Scale";
            this.Scale.Size = new System.Drawing.Size(94, 38);
            this.Scale.TabIndex = 15;
            this.Scale.Text = "Scale";
            this.Scale.UseVisualStyleBackColor = true;
            this.Scale.Click += new System.EventHandler(this.Scale_Click);
            // 
            // P
            // 
            this.P.Location = new System.Drawing.Point(308, 520);
            this.P.Name = "P";
            this.P.Size = new System.Drawing.Size(94, 38);
            this.P.TabIndex = 16;
            this.P.Text = "P()";
            this.P.UseVisualStyleBackColor = true;
            this.P.Click += new System.EventHandler(this.P_Click);
            // 
            // S
            // 
            this.S.Location = new System.Drawing.Point(408, 520);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(94, 38);
            this.S.TabIndex = 17;
            this.S.Text = "S()";
            this.S.UseVisualStyleBackColor = true;
            this.S.Click += new System.EventHandler(this.S_Click);
            // 
            // toString
            // 
            this.toString.Location = new System.Drawing.Point(508, 520);
            this.toString.Name = "toString";
            this.toString.Size = new System.Drawing.Size(94, 38);
            this.toString.TabIndex = 18;
            this.toString.Text = "ToString";
            this.toString.UseVisualStyleBackColor = true;
            this.toString.Click += new System.EventHandler(this.toString_Click);
            // 
            // point_button
            // 
            this.point_button.Location = new System.Drawing.Point(126, 5);
            this.point_button.Name = "point_button";
            this.point_button.Size = new System.Drawing.Size(94, 38);
            this.point_button.TabIndex = 19;
            this.point_button.Text = "Point";
            this.point_button.UseVisualStyleBackColor = true;
            this.point_button.Click += new System.EventHandler(this.point_button_Click);
            // 
            // pyramid_Button
            // 
            this.pyramid_Button.Location = new System.Drawing.Point(126, 137);
            this.pyramid_Button.Name = "pyramid_Button";
            this.pyramid_Button.Size = new System.Drawing.Size(94, 38);
            this.pyramid_Button.TabIndex = 22;
            this.pyramid_Button.Text = "Rhombus Shaded";
            this.pyramid_Button.UseVisualStyleBackColor = true;
            this.pyramid_Button.Click += new System.EventHandler(this.filled_Rhombus_Button_Click);
            // 
            // rhombus_Button
            // 
            this.rhombus_Button.Location = new System.Drawing.Point(12, 137);
            this.rhombus_Button.Name = "rhombus_Button";
            this.rhombus_Button.Size = new System.Drawing.Size(108, 38);
            this.rhombus_Button.TabIndex = 23;
            this.rhombus_Button.Text = "Rhombus";
            this.rhombus_Button.UseVisualStyleBackColor = true;
            this.rhombus_Button.Click += new System.EventHandler(this.rhombus_Button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 520);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 38);
            this.button1.TabIndex = 24;
            this.button1.Text = "Move Into Position";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(48, 486);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 28);
            this.button2.TabIndex = 25;
            this.button2.Text = "Create Image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.create_Image_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(271, 486);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(131, 24);
            this.Save.TabIndex = 26;
            this.Save.Text = "Save Image";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(421, 486);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(131, 24);
            this.Load.TabIndex = 27;
            this.Load.Text = "Load Image";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(570, 486);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 24);
            this.button3.TabIndex = 28;
            this.button3.Text = "Concat Image";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(767, 583);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rhombus_Button);
            this.Controls.Add(this.pyramid_Button);
            this.Controls.Add(this.point_button);
            this.Controls.Add(this.toString);
            this.Controls.Add(this.S);
            this.Controls.Add(this.P);
            this.Controls.Add(this.Scale);
            this.Controls.Add(this.Move);
            this.Controls.Add(this.listFigures);
            this.Controls.Add(this.figure_button);
            this.Controls.Add(this.parallelipiped_Button);
            this.Controls.Add(this.trapezien_Button);
            this.Controls.Add(this.section_Button);
            this.Controls.Add(this.paralelogram_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button paralelogram_Button;
        private System.Windows.Forms.Button section_Button;
        private System.Windows.Forms.Button trapezien_Button;
        private System.Windows.Forms.Button parallelipiped_Button;
        private System.Windows.Forms.Button figure_button;
        private System.Windows.Forms.ListBox listFigures;
        private new System.Windows.Forms.Button Move;
        private new System.Windows.Forms.Button Scale;
        private System.Windows.Forms.Button P;
        private System.Windows.Forms.Button S;
        private System.Windows.Forms.Button toString;
        private System.Windows.Forms.Button point_button;
        private System.Windows.Forms.Button pyramid_Button;
        private System.Windows.Forms.Button rhombus_Button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Button button3;
    }
}

