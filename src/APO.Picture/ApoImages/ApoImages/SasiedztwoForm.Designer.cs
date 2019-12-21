namespace ApoImages
{
    partial class SasiedztwoForm
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
            this.diamondRadioButton = new System.Windows.Forms.RadioButton();
            this.rectangleRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // diamondRadioButton
            // 
            this.diamondRadioButton.AutoSize = true;
            this.diamondRadioButton.Checked = true;
            this.diamondRadioButton.Location = new System.Drawing.Point(13, 13);
            this.diamondRadioButton.Name = "diamondRadioButton";
            this.diamondRadioButton.Size = new System.Drawing.Size(115, 17);
            this.diamondRadioButton.TabIndex = 0;
            this.diamondRadioButton.TabStop = true;
            this.diamondRadioButton.Text = "Romb (4 sąsiadów)";
            this.diamondRadioButton.UseVisualStyleBackColor = true;
            // 
            // rectangleRadioButton
            // 
            this.rectangleRadioButton.AutoSize = true;
            this.rectangleRadioButton.Location = new System.Drawing.Point(13, 37);
            this.rectangleRadioButton.Name = "rectangleRadioButton";
            this.rectangleRadioButton.Size = new System.Drawing.Size(126, 17);
            this.rectangleRadioButton.TabIndex = 1;
            this.rectangleRadioButton.Text = "Kwadrat (8 sąsiadów)";
            this.rectangleRadioButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SasiedztwoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 104);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rectangleRadioButton);
            this.Controls.Add(this.diamondRadioButton);
            this.Name = "SasiedztwoForm";
            this.Text = "SasiedztwoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton diamondRadioButton;
        private System.Windows.Forms.RadioButton rectangleRadioButton;
        private System.Windows.Forms.Button button1;
    }
}