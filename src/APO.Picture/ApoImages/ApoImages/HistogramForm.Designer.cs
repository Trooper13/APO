namespace ApoImages
{
    partial class HistogramForm
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
            this.pictureBoxR = new System.Windows.Forms.PictureBox();
            this.pictureBoxG = new System.Windows.Forms.PictureBox();
            this.pictureBoxB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxB)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxR
            // 
            this.pictureBoxR.Location = new System.Drawing.Point(12, 23);
            this.pictureBoxR.Name = "pictureBoxR";
            this.pictureBoxR.Size = new System.Drawing.Size(256, 150);
            this.pictureBoxR.TabIndex = 0;
            this.pictureBoxR.TabStop = false;
            // 
            // pictureBoxG
            // 
            this.pictureBoxG.Location = new System.Drawing.Point(291, 25);
            this.pictureBoxG.Name = "pictureBoxG";
            this.pictureBoxG.Size = new System.Drawing.Size(256, 150);
            this.pictureBoxG.TabIndex = 1;
            this.pictureBoxG.TabStop = false;
            // 
            // pictureBoxB
            // 
            this.pictureBoxB.Location = new System.Drawing.Point(571, 25);
            this.pictureBoxB.Name = "pictureBoxB";
            this.pictureBoxB.Size = new System.Drawing.Size(256, 150);
            this.pictureBoxB.TabIndex = 2;
            this.pictureBoxB.TabStop = false;
            // 
            // HistogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 201);
            this.Controls.Add(this.pictureBoxB);
            this.Controls.Add(this.pictureBoxG);
            this.Controls.Add(this.pictureBoxR);
            this.Name = "HistogramForm";
            this.Text = "Histogram";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxR;
        private System.Windows.Forms.PictureBox pictureBoxG;
        private System.Windows.Forms.PictureBox pictureBoxB;
    }
}