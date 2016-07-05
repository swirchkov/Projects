namespace CourseProject
{
    partial class FormMod
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
            this.MethodButton = new System.Windows.Forms.Button();
            this.Propertiebutton = new System.Windows.Forms.Button();
            this.Fieldbutton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(138, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modifiing Object";
            // 
            // MethodButton
            // 
            this.MethodButton.Location = new System.Drawing.Point(26, 48);
            this.MethodButton.Name = "MethodButton";
            this.MethodButton.Size = new System.Drawing.Size(121, 35);
            this.MethodButton.TabIndex = 1;
            this.MethodButton.Text = "Methods";
            this.MethodButton.UseVisualStyleBackColor = true;
            this.MethodButton.Click += new System.EventHandler(this.MethodButton_Click);
            // 
            // Propertiebutton
            // 
            this.Propertiebutton.Location = new System.Drawing.Point(184, 48);
            this.Propertiebutton.Name = "Propertiebutton";
            this.Propertiebutton.Size = new System.Drawing.Size(121, 35);
            this.Propertiebutton.TabIndex = 2;
            this.Propertiebutton.Text = "Properties";
            this.Propertiebutton.UseVisualStyleBackColor = true;
            this.Propertiebutton.Click += new System.EventHandler(this.Propertiebutton_Click);
            // 
            // Fieldbutton
            // 
            this.Fieldbutton.Location = new System.Drawing.Point(350, 48);
            this.Fieldbutton.Name = "Fieldbutton";
            this.Fieldbutton.Size = new System.Drawing.Size(121, 35);
            this.Fieldbutton.TabIndex = 3;
            this.Fieldbutton.Text = "Fields";
            this.Fieldbutton.UseVisualStyleBackColor = true;
            this.Fieldbutton.Click += new System.EventHandler(this.Fieldbutton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(44, 114);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(166, 199);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(68, 343);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "Modify";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(306, 343);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 35);
            this.button5.TabIndex = 6;
            this.button5.Text = "Exit";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FormMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 401);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Fieldbutton);
            this.Controls.Add(this.Propertiebutton);
            this.Controls.Add(this.MethodButton);
            this.Controls.Add(this.label1);
            this.Name = "FormMod";
            this.Text = "FormMod";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MethodButton;
        private System.Windows.Forms.Button Propertiebutton;
        private System.Windows.Forms.Button Fieldbutton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}