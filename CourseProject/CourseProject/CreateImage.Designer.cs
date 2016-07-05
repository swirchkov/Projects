namespace CourseProject
{
    partial class CreateImage
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
            this.label1 = new System.Windows.Forms.Label();
            this.listFigures = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rhombus_Button = new System.Windows.Forms.Button();
            this.pyramid_Button = new System.Windows.Forms.Button();
            this.point_button = new System.Windows.Forms.Button();
            this.figure_button = new System.Windows.Forms.Button();
            this.parallelipiped_Button = new System.Windows.Forms.Button();
            this.trapezien_Button = new System.Windows.Forms.Button();
            this.section_Button = new System.Windows.Forms.Button();
            this.paralelogram_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "List of available figures";
            // 
            // listFigures
            // 
            this.listFigures.FormattingEnabled = true;
            this.listFigures.Location = new System.Drawing.Point(33, 36);
            this.listFigures.Name = "listFigures";
            this.listFigures.Size = new System.Drawing.Size(173, 212);
            this.listFigures.TabIndex = 1;
            this.listFigures.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listFigures_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rhombus_Button
            // 
            this.rhombus_Button.Location = new System.Drawing.Point(218, 187);
            this.rhombus_Button.Name = "rhombus_Button";
            this.rhombus_Button.Size = new System.Drawing.Size(108, 38);
            this.rhombus_Button.TabIndex = 31;
            this.rhombus_Button.Text = "Rhombus";
            this.rhombus_Button.UseVisualStyleBackColor = true;
            this.rhombus_Button.Click += new System.EventHandler(this.rhombus_Button_Click);
            // 
            // pyramid_Button
            // 
            this.pyramid_Button.Location = new System.Drawing.Point(332, 187);
            this.pyramid_Button.Name = "pyramid_Button";
            this.pyramid_Button.Size = new System.Drawing.Size(94, 38);
            this.pyramid_Button.TabIndex = 30;
            this.pyramid_Button.Text = "Rhombus Shaded";
            this.pyramid_Button.UseVisualStyleBackColor = true;
            this.pyramid_Button.Click += new System.EventHandler(this.pyramid_Button_Click);
            // 
            // point_button
            // 
            this.point_button.Location = new System.Drawing.Point(332, 55);
            this.point_button.Name = "point_button";
            this.point_button.Size = new System.Drawing.Size(94, 38);
            this.point_button.TabIndex = 29;
            this.point_button.Text = "Point";
            this.point_button.UseVisualStyleBackColor = true;
            this.point_button.Click += new System.EventHandler(this.point_button_Click);
            // 
            // figure_button
            // 
            this.figure_button.Location = new System.Drawing.Point(215, 55);
            this.figure_button.Name = "figure_button";
            this.figure_button.Size = new System.Drawing.Size(111, 38);
            this.figure_button.TabIndex = 28;
            this.figure_button.Text = "Figure";
            this.figure_button.UseVisualStyleBackColor = true;
            this.figure_button.Click += new System.EventHandler(this.figure_button_Click);
            // 
            // parallelipiped_Button
            // 
            this.parallelipiped_Button.Location = new System.Drawing.Point(218, 143);
            this.parallelipiped_Button.Name = "parallelipiped_Button";
            this.parallelipiped_Button.Size = new System.Drawing.Size(108, 38);
            this.parallelipiped_Button.TabIndex = 27;
            this.parallelipiped_Button.Text = "Parallelipiped";
            this.parallelipiped_Button.UseVisualStyleBackColor = true;
            this.parallelipiped_Button.Click += new System.EventHandler(this.parallelipiped_Button_Click);
            // 
            // trapezien_Button
            // 
            this.trapezien_Button.Location = new System.Drawing.Point(332, 143);
            this.trapezien_Button.Name = "trapezien_Button";
            this.trapezien_Button.Size = new System.Drawing.Size(94, 38);
            this.trapezien_Button.TabIndex = 26;
            this.trapezien_Button.Text = "Trapezien";
            this.trapezien_Button.UseVisualStyleBackColor = true;
            this.trapezien_Button.Click += new System.EventHandler(this.trapezien_Button_Click);
            // 
            // section_Button
            // 
            this.section_Button.Location = new System.Drawing.Point(332, 99);
            this.section_Button.Name = "section_Button";
            this.section_Button.Size = new System.Drawing.Size(94, 38);
            this.section_Button.TabIndex = 25;
            this.section_Button.Text = "Section";
            this.section_Button.UseVisualStyleBackColor = true;
            this.section_Button.Click += new System.EventHandler(this.section_Button_Click);
            // 
            // paralelogram_Button
            // 
            this.paralelogram_Button.Location = new System.Drawing.Point(218, 99);
            this.paralelogram_Button.Name = "paralelogram_Button";
            this.paralelogram_Button.Size = new System.Drawing.Size(108, 38);
            this.paralelogram_Button.TabIndex = 24;
            this.paralelogram_Button.Text = "Paralelogram";
            this.paralelogram_Button.UseVisualStyleBackColor = true;
            this.paralelogram_Button.Click += new System.EventHandler(this.paralelogram_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "CreateFigure";
            // 
            // CreateImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(493, 319);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rhombus_Button);
            this.Controls.Add(this.pyramid_Button);
            this.Controls.Add(this.point_button);
            this.Controls.Add(this.figure_button);
            this.Controls.Add(this.parallelipiped_Button);
            this.Controls.Add(this.trapezien_Button);
            this.Controls.Add(this.section_Button);
            this.Controls.Add(this.paralelogram_Button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listFigures);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "CreateImage";
            this.Text = "CreateImage";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CreateImage_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listFigures;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button rhombus_Button;
        private System.Windows.Forms.Button pyramid_Button;
        private System.Windows.Forms.Button point_button;
        private System.Windows.Forms.Button figure_button;
        private System.Windows.Forms.Button parallelipiped_Button;
        private System.Windows.Forms.Button trapezien_Button;
        private System.Windows.Forms.Button section_Button;
        private System.Windows.Forms.Button paralelogram_Button;
        private System.Windows.Forms.Label label2;
    }
}