namespace APO.Picture
{
    partial class UopForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UopForm));
            this.histogramGroup = new System.Windows.Forms.GroupBox();
            this.tabControlHistogram = new System.Windows.Forms.TabControl();
            this.tabPageGrey = new System.Windows.Forms.TabPage();
            this.histogramViewGrey = new Accord.Controls.HistogramView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new Accord.Controls.PictureBox();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panelOrg = new APO.Picture.BufferedPanel();
            this.histogramGroup.SuspendLayout();
            this.tabControlHistogram.SuspendLayout();
            this.tabPageGrey.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // histogramGroup
            // 
            this.histogramGroup.Controls.Add(this.tabControlHistogram);
            this.histogramGroup.Location = new System.Drawing.Point(746, 34);
            this.histogramGroup.Name = "histogramGroup";
            this.histogramGroup.Size = new System.Drawing.Size(679, 330);
            this.histogramGroup.TabIndex = 3;
            this.histogramGroup.TabStop = false;
            this.histogramGroup.Text = "Histogram";
            // 
            // tabControlHistogram
            // 
            this.tabControlHistogram.Controls.Add(this.tabPageGrey);
            this.tabControlHistogram.Location = new System.Drawing.Point(7, 20);
            this.tabControlHistogram.Name = "tabControlHistogram";
            this.tabControlHistogram.SelectedIndex = 0;
            this.tabControlHistogram.Size = new System.Drawing.Size(666, 303);
            this.tabControlHistogram.TabIndex = 0;
            // 
            // tabPageGrey
            // 
            this.tabPageGrey.Controls.Add(this.histogramViewGrey);
            this.tabPageGrey.Location = new System.Drawing.Point(4, 22);
            this.tabPageGrey.Name = "tabPageGrey";
            this.tabPageGrey.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGrey.Size = new System.Drawing.Size(658, 277);
            this.tabPageGrey.TabIndex = 0;
            this.tabPageGrey.Text = "Greyscale";
            this.tabPageGrey.UseVisualStyleBackColor = true;
            // 
            // histogramViewGrey
            // 
            this.histogramViewGrey.BinWidth = null;
            this.histogramViewGrey.DataSource = ((object)(resources.GetObject("histogramViewGrey.DataSource")));
            this.histogramViewGrey.Histogram = ((Accord.Statistics.Visualizations.Histogram)(resources.GetObject("histogramViewGrey.Histogram")));
            this.histogramViewGrey.Location = new System.Drawing.Point(5, 7);
            this.histogramViewGrey.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.histogramViewGrey.Name = "histogramViewGrey";
            this.histogramViewGrey.NumberOfBins = null;
            this.histogramViewGrey.Size = new System.Drawing.Size(641, 246);
            this.histogramViewGrey.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(728, 635);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelOrg);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(720, 609);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Obraz";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Image = null;
            this.pictureBox1.Location = new System.Drawing.Point(782, 370);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(278, 251);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(759, 608);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(13, 13);
            this.yLabel.TabIndex = 5;
            this.yLabel.Text = "0";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(779, 634);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(13, 13);
            this.xLabel.TabIndex = 6;
            this.xLabel.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1079, 598);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Resetuj";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1244, 598);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Zatwierdź";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1326, 598);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Anuluj";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panelOrg
            // 
            this.panelOrg.AutoScroll = true;
            this.panelOrg.BackColor = System.Drawing.Color.Black;
            this.panelOrg.Location = new System.Drawing.Point(7, 7);
            this.panelOrg.Name = "panelOrg";
            this.panelOrg.Size = new System.Drawing.Size(707, 596);
            this.panelOrg.TabIndex = 0;
            // 
            // UopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1496, 705);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.histogramGroup);
            this.Controls.Add(this.tabControl1);
            this.Name = "UopForm";
            this.Text = "UopForm";
            this.histogramGroup.ResumeLayout(false);
            this.tabControlHistogram.ResumeLayout(false);
            this.tabPageGrey.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox histogramGroup;
        private System.Windows.Forms.TabControl tabControlHistogram;
        private System.Windows.Forms.TabPage tabPageGrey;
        private Accord.Controls.HistogramView histogramViewGrey;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Accord.Controls.PictureBox pictureBox1;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private BufferedPanel panelOrg;
    }
}