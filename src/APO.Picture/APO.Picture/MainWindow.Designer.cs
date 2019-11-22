namespace APO.Picture
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rozciaganieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacjeJednopunktoweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lAB2NegacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lAB2ProgowanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lAB2PosteryzacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lAB2RozciaganieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lAB2WyrównanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metodaŚrednichToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metodaŚrednichToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.operacjeJednopunktoweToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(2020, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(228, 38);
            this.openFileToolStripMenuItem.Text = "Open file...";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(228, 38);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(228, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rozciaganieToolStripMenuItem,
            this.lAB2WyrównanieToolStripMenuItem});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(137, 36);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // rozciaganieToolStripMenuItem
            // 
            this.rozciaganieToolStripMenuItem.Name = "rozciaganieToolStripMenuItem";
            this.rozciaganieToolStripMenuItem.Size = new System.Drawing.Size(324, 38);
            this.rozciaganieToolStripMenuItem.Text = "[LAB2] Rozciaganie";
            this.rozciaganieToolStripMenuItem.Click += new System.EventHandler(this.rozciaganieToolStripMenuItem_Click);
            // 
            // operacjeJednopunktoweToolStripMenuItem
            // 
            this.operacjeJednopunktoweToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lAB2NegacjaToolStripMenuItem,
            this.lAB2ProgowanieToolStripMenuItem,
            this.lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem,
            this.lAB2PosteryzacjaToolStripMenuItem,
            this.lAB2RozciaganieToolStripMenuItem,
            this.toolStripSeparator1});
            this.operacjeJednopunktoweToolStripMenuItem.Name = "operacjeJednopunktoweToolStripMenuItem";
            this.operacjeJednopunktoweToolStripMenuItem.Size = new System.Drawing.Size(299, 36);
            this.operacjeJednopunktoweToolStripMenuItem.Text = "Operacje Jednopunktowe";
            // 
            // lAB2NegacjaToolStripMenuItem
            // 
            this.lAB2NegacjaToolStripMenuItem.Name = "lAB2NegacjaToolStripMenuItem";
            this.lAB2NegacjaToolStripMenuItem.Size = new System.Drawing.Size(666, 38);
            this.lAB2NegacjaToolStripMenuItem.Text = "[LAB2] Negacja";
            // 
            // lAB2ProgowanieToolStripMenuItem
            // 
            this.lAB2ProgowanieToolStripMenuItem.Name = "lAB2ProgowanieToolStripMenuItem";
            this.lAB2ProgowanieToolStripMenuItem.Size = new System.Drawing.Size(666, 38);
            this.lAB2ProgowanieToolStripMenuItem.Text = "[LAB2] Progowanie";
            // 
            // lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem
            // 
            this.lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem.Name = "lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem";
            this.lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem.Size = new System.Drawing.Size(666, 38);
            this.lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem.Text = "[LAB2] Progowanie (zachowanie poziomów szarości)";
            // 
            // lAB2PosteryzacjaToolStripMenuItem
            // 
            this.lAB2PosteryzacjaToolStripMenuItem.Name = "lAB2PosteryzacjaToolStripMenuItem";
            this.lAB2PosteryzacjaToolStripMenuItem.Size = new System.Drawing.Size(666, 38);
            this.lAB2PosteryzacjaToolStripMenuItem.Text = "[LAB2] Posteryzacja";
            // 
            // lAB2RozciaganieToolStripMenuItem
            // 
            this.lAB2RozciaganieToolStripMenuItem.Name = "lAB2RozciaganieToolStripMenuItem";
            this.lAB2RozciaganieToolStripMenuItem.Size = new System.Drawing.Size(666, 38);
            this.lAB2RozciaganieToolStripMenuItem.Text = "[LAB2] Rozciaganie";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(663, 6);
            // 
            // lAB2WyrównanieToolStripMenuItem
            // 
            this.lAB2WyrównanieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metodaŚrednichToolStripMenuItem,
            this.metodaŚrednichToolStripMenuItem1});
            this.lAB2WyrównanieToolStripMenuItem.Name = "lAB2WyrównanieToolStripMenuItem";
            this.lAB2WyrównanieToolStripMenuItem.Size = new System.Drawing.Size(324, 38);
            this.lAB2WyrównanieToolStripMenuItem.Text = "[LAB2] Wyrównanie";
            // 
            // metodaŚrednichToolStripMenuItem
            // 
            this.metodaŚrednichToolStripMenuItem.Name = "metodaŚrednichToolStripMenuItem";
            this.metodaŚrednichToolStripMenuItem.Size = new System.Drawing.Size(324, 38);
            this.metodaŚrednichToolStripMenuItem.Text = "Equalizacja";
            // 
            // metodaŚrednichToolStripMenuItem1
            // 
            this.metodaŚrednichToolStripMenuItem1.Name = "metodaŚrednichToolStripMenuItem1";
            this.metodaŚrednichToolStripMenuItem1.Size = new System.Drawing.Size(324, 38);
            this.metodaŚrednichToolStripMenuItem1.Text = "Metoda Średnich";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2020, 987);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "APO_Mitura_IZ07IO2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rozciaganieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacjeJednopunktoweToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lAB2NegacjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lAB2ProgowanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lAB2PosteryzacjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lAB2RozciaganieToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem lAB2WyrównanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metodaŚrednichToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metodaŚrednichToolStripMenuItem1;
    }
}

