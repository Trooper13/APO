namespace APO.Picture
{
    partial class ImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageForm));
            this.histogramGroup = new System.Windows.Forms.GroupBox();
            this.tabControlHistogram = new System.Windows.Forms.TabControl();
            this.tabPageGrey = new System.Windows.Forms.TabPage();
            this.histogramViewGrey = new Accord.Controls.HistogramView();
            this.tabPageRed = new System.Windows.Forms.TabPage();
            this.histogramViewRed = new Accord.Controls.HistogramView();
            this.tabPageGreen = new System.Windows.Forms.TabPage();
            this.histogramViewGreen = new Accord.Controls.HistogramView();
            this.tabPageBlue = new System.Windows.Forms.TabPage();
            this.histogramViewBlue = new Accord.Controls.HistogramView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.histogramGroup.SuspendLayout();
            this.tabControlHistogram.SuspendLayout();
            this.tabPageGrey.SuspendLayout();
            this.tabPageRed.SuspendLayout();
            this.tabPageGreen.SuspendLayout();
            this.tabPageBlue.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // histogramGroup
            // 
            this.histogramGroup.Controls.Add(this.tabControlHistogram);
            this.histogramGroup.Location = new System.Drawing.Point(988, 64);
            this.histogramGroup.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.histogramGroup.Name = "histogramGroup";
            this.histogramGroup.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.histogramGroup.Size = new System.Drawing.Size(993, 993);
            this.histogramGroup.TabIndex = 1;
            this.histogramGroup.TabStop = false;
            this.histogramGroup.Text = "Histogram";
            // 
            // tabControlHistogram
            // 
            this.tabControlHistogram.Controls.Add(this.tabPageGrey);
            this.tabControlHistogram.Controls.Add(this.tabPageRed);
            this.tabControlHistogram.Controls.Add(this.tabPageGreen);
            this.tabControlHistogram.Controls.Add(this.tabPageBlue);
            this.tabControlHistogram.Location = new System.Drawing.Point(14, 38);
            this.tabControlHistogram.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControlHistogram.Name = "tabControlHistogram";
            this.tabControlHistogram.SelectedIndex = 0;
            this.tabControlHistogram.Size = new System.Drawing.Size(1066, 1158);
            this.tabControlHistogram.TabIndex = 0;
            // 
            // tabPageGrey
            // 
            this.tabPageGrey.Controls.Add(this.histogramViewGrey);
            this.tabPageGrey.Location = new System.Drawing.Point(8, 39);
            this.tabPageGrey.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPageGrey.Name = "tabPageGrey";
            this.tabPageGrey.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPageGrey.Size = new System.Drawing.Size(1050, 1111);
            this.tabPageGrey.TabIndex = 0;
            this.tabPageGrey.Text = "Greyscale";
            this.tabPageGrey.UseVisualStyleBackColor = true;
            // 
            // histogramViewGrey
            // 
            this.histogramViewGrey.BinWidth = null;
            this.histogramViewGrey.DataSource = ((object)(resources.GetObject("histogramViewGrey.DataSource")));
            this.histogramViewGrey.Histogram = ((Accord.Statistics.Visualizations.Histogram)(resources.GetObject("histogramViewGrey.Histogram")));
            this.histogramViewGrey.Location = new System.Drawing.Point(6, 6);
            this.histogramViewGrey.Margin = new System.Windows.Forms.Padding(10, 13, 10, 13);
            this.histogramViewGrey.Name = "histogramViewGrey";
            this.histogramViewGrey.NumberOfBins = null;
            this.histogramViewGrey.Size = new System.Drawing.Size(1038, 737);
            this.histogramViewGrey.TabIndex = 0;
            // 
            // tabPageRed
            // 
            this.tabPageRed.Controls.Add(this.histogramViewRed);
            this.tabPageRed.Location = new System.Drawing.Point(8, 39);
            this.tabPageRed.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPageRed.Name = "tabPageRed";
            this.tabPageRed.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPageRed.Size = new System.Drawing.Size(1050, 1111);
            this.tabPageRed.TabIndex = 1;
            this.tabPageRed.Text = "Red";
            this.tabPageRed.UseVisualStyleBackColor = true;
            // 
            // histogramViewRed
            // 
            this.histogramViewRed.BinWidth = null;
            this.histogramViewRed.DataSource = ((object)(resources.GetObject("histogramViewRed.DataSource")));
            this.histogramViewRed.Histogram = ((Accord.Statistics.Visualizations.Histogram)(resources.GetObject("histogramViewRed.Histogram")));
            this.histogramViewRed.Location = new System.Drawing.Point(6, 6);
            this.histogramViewRed.Margin = new System.Windows.Forms.Padding(10, 13, 10, 13);
            this.histogramViewRed.Name = "histogramViewRed";
            this.histogramViewRed.NumberOfBins = null;
            this.histogramViewRed.Size = new System.Drawing.Size(1038, 746);
            this.histogramViewRed.TabIndex = 0;
            // 
            // tabPageGreen
            // 
            this.tabPageGreen.Controls.Add(this.histogramViewGreen);
            this.tabPageGreen.Location = new System.Drawing.Point(8, 39);
            this.tabPageGreen.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPageGreen.Name = "tabPageGreen";
            this.tabPageGreen.Size = new System.Drawing.Size(1050, 1111);
            this.tabPageGreen.TabIndex = 2;
            this.tabPageGreen.Text = "Green";
            this.tabPageGreen.UseVisualStyleBackColor = true;
            // 
            // histogramViewGreen
            // 
            this.histogramViewGreen.BinWidth = null;
            this.histogramViewGreen.DataSource = ((object)(resources.GetObject("histogramViewGreen.DataSource")));
            this.histogramViewGreen.Histogram = ((Accord.Statistics.Visualizations.Histogram)(resources.GetObject("histogramViewGreen.Histogram")));
            this.histogramViewGreen.Location = new System.Drawing.Point(0, 0);
            this.histogramViewGreen.Margin = new System.Windows.Forms.Padding(10, 13, 10, 13);
            this.histogramViewGreen.Name = "histogramViewGreen";
            this.histogramViewGreen.NumberOfBins = null;
            this.histogramViewGreen.Size = new System.Drawing.Size(1038, 746);
            this.histogramViewGreen.TabIndex = 1;
            // 
            // tabPageBlue
            // 
            this.tabPageBlue.Controls.Add(this.histogramViewBlue);
            this.tabPageBlue.Location = new System.Drawing.Point(8, 39);
            this.tabPageBlue.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPageBlue.Name = "tabPageBlue";
            this.tabPageBlue.Size = new System.Drawing.Size(1050, 1111);
            this.tabPageBlue.TabIndex = 3;
            this.tabPageBlue.Text = "Blue";
            this.tabPageBlue.UseVisualStyleBackColor = true;
            // 
            // histogramViewBlue
            // 
            this.histogramViewBlue.BinWidth = null;
            this.histogramViewBlue.DataSource = ((object)(resources.GetObject("histogramViewBlue.DataSource")));
            this.histogramViewBlue.Histogram = ((Accord.Statistics.Visualizations.Histogram)(resources.GetObject("histogramViewBlue.Histogram")));
            this.histogramViewBlue.Location = new System.Drawing.Point(0, 0);
            this.histogramViewBlue.Margin = new System.Windows.Forms.Padding(10, 13, 10, 13);
            this.histogramViewBlue.Name = "histogramViewBlue";
            this.histogramViewBlue.NumberOfBins = null;
            this.histogramViewBlue.Size = new System.Drawing.Size(1038, 746);
            this.histogramViewBlue.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBoxImage);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage1.Size = new System.Drawing.Size(892, 728);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Obraz";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(6, 6);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(1198, 1198);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(26, 25);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(908, 775);
            this.tabControl1.TabIndex = 0;
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2059, 1242);
            this.Controls.Add(this.histogramGroup);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ImageForm";
            this.Text = "ImageForm";
            this.Load += new System.EventHandler(this.ImageForm_Load);
            this.histogramGroup.ResumeLayout(false);
            this.tabControlHistogram.ResumeLayout(false);
            this.tabPageGrey.ResumeLayout(false);
            this.tabPageRed.ResumeLayout(false);
            this.tabPageGreen.ResumeLayout(false);
            this.tabPageBlue.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox histogramGroup;
        private System.Windows.Forms.TabControl tabControlHistogram;
        private System.Windows.Forms.TabPage tabPageGrey;
        private Accord.Controls.HistogramView histogramViewGrey;
        private System.Windows.Forms.TabPage tabPageRed;
        private Accord.Controls.HistogramView histogramViewRed;
        private System.Windows.Forms.TabPage tabPageGreen;
        private Accord.Controls.HistogramView histogramViewGreen;
        private System.Windows.Forms.TabPage tabPageBlue;
        private Accord.Controls.HistogramView histogramViewBlue;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.TabControl tabControl1;
    }
}