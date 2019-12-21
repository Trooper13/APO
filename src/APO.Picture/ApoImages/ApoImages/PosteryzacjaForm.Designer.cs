namespace ApoImages
{
    partial class PosteryzacjaForm
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
            this.nNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nNumericUpDown
            // 
            this.nNumericUpDown.Location = new System.Drawing.Point(15, 25);
            this.nNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nNumericUpDown.Name = "nNumericUpDown";
            this.nNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.nNumericUpDown.TabIndex = 0;
            this.nNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Podaj wartość N ";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(134, 120);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // PosteryzacjaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 155);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nNumericUpDown);
            this.Name = "PosteryzacjaForm";
            this.Text = "Progowanie";
            ((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
    }
}