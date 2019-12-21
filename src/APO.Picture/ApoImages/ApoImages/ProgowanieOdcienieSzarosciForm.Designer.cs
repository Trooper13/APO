namespace ApoImages
{
    partial class ProgowanieOdcienieSzarosciForm
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
            this.p1NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.p2numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.negationcheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.p1NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // p1NumericUpDown
            // 
            this.p1NumericUpDown.Location = new System.Drawing.Point(15, 25);
            this.p1NumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.p1NumericUpDown.Name = "p1NumericUpDown";
            this.p1NumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.p1NumericUpDown.TabIndex = 0;
            this.p1NumericUpDown.ValueChanged += new System.EventHandler(this.p1NumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Podaj wartość p1";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Podaj wartość p2";
            // 
            // p2numericUpDown
            // 
            this.p2numericUpDown.Location = new System.Drawing.Point(15, 64);
            this.p2numericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.p2numericUpDown.Name = "p2numericUpDown";
            this.p2numericUpDown.Size = new System.Drawing.Size(120, 20);
            this.p2numericUpDown.TabIndex = 3;
            this.p2numericUpDown.ValueChanged += new System.EventHandler(this.p2numericUpDown_ValueChanged);
            // 
            // negationcheckBox
            // 
            this.negationcheckBox.AutoSize = true;
            this.negationcheckBox.Location = new System.Drawing.Point(15, 91);
            this.negationcheckBox.Name = "negationcheckBox";
            this.negationcheckBox.Size = new System.Drawing.Size(72, 17);
            this.negationcheckBox.TabIndex = 5;
            this.negationcheckBox.Text = "Negacja?";
            this.negationcheckBox.UseVisualStyleBackColor = true;
            // 
            // ProgowanieOdcienieSzarosciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 155);
            this.Controls.Add(this.negationcheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.p2numericUpDown);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p1NumericUpDown);
            this.Name = "ProgowanieOdcienieSzarosciForm";
            this.Text = "Progowanie";
            ((System.ComponentModel.ISupportInitialize)(this.p1NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown p1NumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown p2numericUpDown;
        private System.Windows.Forms.CheckBox negationcheckBox;
    }
}