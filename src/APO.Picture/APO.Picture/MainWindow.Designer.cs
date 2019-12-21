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
            this.lAB2WyrównanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metodaŚrednichToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacjeJednopunktoweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lAB2NegacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lAB2ProgowanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lAB2PosteryzacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lAB2RozciaganieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lAB2UniwersalnyOperatorJednopunktowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacjeLinioweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wygładzanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maska1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maska2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maska3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maska4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyostrzanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mask1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mask2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mask3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyostrzanieToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.maska1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.maska2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.maska3ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrowanieMedianoweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.operacjeJednopunktoweToolStripMenuItem,
            this.operacjeLinioweToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1010, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.openFileToolStripMenuItem.Text = "Open file...";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rozciaganieToolStripMenuItem,
            this.lAB2WyrównanieToolStripMenuItem});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(75, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // rozciaganieToolStripMenuItem
            // 
            this.rozciaganieToolStripMenuItem.Name = "rozciaganieToolStripMenuItem";
            this.rozciaganieToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.rozciaganieToolStripMenuItem.Text = "[LAB2] Rozciaganie";
            this.rozciaganieToolStripMenuItem.Click += new System.EventHandler(this.rozciaganieToolStripMenuItem_Click);
            // 
            // lAB2WyrównanieToolStripMenuItem
            // 
            this.lAB2WyrównanieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metodaŚrednichToolStripMenuItem});
            this.lAB2WyrównanieToolStripMenuItem.Name = "lAB2WyrównanieToolStripMenuItem";
            this.lAB2WyrównanieToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.lAB2WyrównanieToolStripMenuItem.Text = "[LAB2] Wyrównanie";
            // 
            // metodaŚrednichToolStripMenuItem
            // 
            this.metodaŚrednichToolStripMenuItem.Name = "metodaŚrednichToolStripMenuItem";
            this.metodaŚrednichToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.metodaŚrednichToolStripMenuItem.Text = "Equalizacja";
            this.metodaŚrednichToolStripMenuItem.Click += new System.EventHandler(this.metodaŚrednichToolStripMenuItem_Click);
            // 
            // operacjeJednopunktoweToolStripMenuItem
            // 
            this.operacjeJednopunktoweToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lAB2NegacjaToolStripMenuItem,
            this.lAB2ProgowanieToolStripMenuItem,
            this.lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem,
            this.lAB2PosteryzacjaToolStripMenuItem,
            this.lAB2RozciaganieToolStripMenuItem,
            this.lAB2UniwersalnyOperatorJednopunktowyToolStripMenuItem});
            this.operacjeJednopunktoweToolStripMenuItem.Name = "operacjeJednopunktoweToolStripMenuItem";
            this.operacjeJednopunktoweToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.operacjeJednopunktoweToolStripMenuItem.Text = "Operacje Jednopunktowe";
            // 
            // lAB2NegacjaToolStripMenuItem
            // 
            this.lAB2NegacjaToolStripMenuItem.Name = "lAB2NegacjaToolStripMenuItem";
            this.lAB2NegacjaToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.lAB2NegacjaToolStripMenuItem.Text = "[LAB2] Negacja";
            this.lAB2NegacjaToolStripMenuItem.Click += new System.EventHandler(this.lAB2NegacjaToolStripMenuItem_Click);
            // 
            // lAB2ProgowanieToolStripMenuItem
            // 
            this.lAB2ProgowanieToolStripMenuItem.Name = "lAB2ProgowanieToolStripMenuItem";
            this.lAB2ProgowanieToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.lAB2ProgowanieToolStripMenuItem.Text = "[LAB2] Progowanie";
            this.lAB2ProgowanieToolStripMenuItem.Click += new System.EventHandler(this.lAB2ProgowanieToolStripMenuItem_Click);
            // 
            // lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem
            // 
            this.lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem.Name = "lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem";
            this.lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem.Text = "[LAB2] Progowanie (zachowanie poziomów szarości)";
            this.lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem.Click += new System.EventHandler(this.lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem_Click);
            // 
            // lAB2PosteryzacjaToolStripMenuItem
            // 
            this.lAB2PosteryzacjaToolStripMenuItem.Name = "lAB2PosteryzacjaToolStripMenuItem";
            this.lAB2PosteryzacjaToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.lAB2PosteryzacjaToolStripMenuItem.Text = "[LAB2] Posteryzacja";
            this.lAB2PosteryzacjaToolStripMenuItem.Click += new System.EventHandler(this.lAB2PosteryzacjaToolStripMenuItem_Click);
            // 
            // lAB2RozciaganieToolStripMenuItem
            // 
            this.lAB2RozciaganieToolStripMenuItem.Name = "lAB2RozciaganieToolStripMenuItem";
            this.lAB2RozciaganieToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.lAB2RozciaganieToolStripMenuItem.Text = "[LAB2] Rozciaganie";
            this.lAB2RozciaganieToolStripMenuItem.Click += new System.EventHandler(this.lAB2RozciaganieToolStripMenuItem_Click);
            // 
            // lAB2UniwersalnyOperatorJednopunktowyToolStripMenuItem
            // 
            this.lAB2UniwersalnyOperatorJednopunktowyToolStripMenuItem.Name = "lAB2UniwersalnyOperatorJednopunktowyToolStripMenuItem";
            this.lAB2UniwersalnyOperatorJednopunktowyToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.lAB2UniwersalnyOperatorJednopunktowyToolStripMenuItem.Text = "[LAB2] Uniwersalny operator jednopunktowy";
            this.lAB2UniwersalnyOperatorJednopunktowyToolStripMenuItem.Click += new System.EventHandler(this.lAB2UniwersalnyOperatorJednopunktowyToolStripMenuItem_Click);
            // 
            // operacjeLinioweToolStripMenuItem
            // 
            this.operacjeLinioweToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wygładzanieToolStripMenuItem,
            this.wyostrzanieToolStripMenuItem,
            this.wyostrzanieToolStripMenuItem1,
            this.filtrowanieMedianoweToolStripMenuItem,
            this.sobelToolStripMenuItem});
            this.operacjeLinioweToolStripMenuItem.Name = "operacjeLinioweToolStripMenuItem";
            this.operacjeLinioweToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.operacjeLinioweToolStripMenuItem.Text = "Operacje liniowe";
            // 
            // wygładzanieToolStripMenuItem
            // 
            this.wygładzanieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maska1ToolStripMenuItem,
            this.maska2ToolStripMenuItem,
            this.maska3ToolStripMenuItem,
            this.maska4ToolStripMenuItem});
            this.wygładzanieToolStripMenuItem.Name = "wygładzanieToolStripMenuItem";
            this.wygładzanieToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wygładzanieToolStripMenuItem.Text = "Wygładzanie";
            // 
            // maska1ToolStripMenuItem
            // 
            this.maska1ToolStripMenuItem.Name = "maska1ToolStripMenuItem";
            this.maska1ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.maska1ToolStripMenuItem.Text = "Maska 1";
            this.maska1ToolStripMenuItem.Click += new System.EventHandler(this.maska1ToolStripMenuItem_Click);
            // 
            // maska2ToolStripMenuItem
            // 
            this.maska2ToolStripMenuItem.Name = "maska2ToolStripMenuItem";
            this.maska2ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.maska2ToolStripMenuItem.Text = "Maska 2";
            this.maska2ToolStripMenuItem.Click += new System.EventHandler(this.maska2ToolStripMenuItem_Click);
            // 
            // maska3ToolStripMenuItem
            // 
            this.maska3ToolStripMenuItem.Name = "maska3ToolStripMenuItem";
            this.maska3ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.maska3ToolStripMenuItem.Text = "Maska 3";
            this.maska3ToolStripMenuItem.Click += new System.EventHandler(this.maska3ToolStripMenuItem_Click);
            // 
            // maska4ToolStripMenuItem
            // 
            this.maska4ToolStripMenuItem.Name = "maska4ToolStripMenuItem";
            this.maska4ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.maska4ToolStripMenuItem.Text = "Maska 4";
            this.maska4ToolStripMenuItem.Click += new System.EventHandler(this.maska4ToolStripMenuItem_Click);
            // 
            // wyostrzanieToolStripMenuItem
            // 
            this.wyostrzanieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mask1ToolStripMenuItem,
            this.mask2ToolStripMenuItem,
            this.mask3ToolStripMenuItem});
            this.wyostrzanieToolStripMenuItem.Name = "wyostrzanieToolStripMenuItem";
            this.wyostrzanieToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wyostrzanieToolStripMenuItem.Text = "Detekcja Krawędzi";
            // 
            // mask1ToolStripMenuItem
            // 
            this.mask1ToolStripMenuItem.Name = "mask1ToolStripMenuItem";
            this.mask1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mask1ToolStripMenuItem.Text = "Maska 1";
            this.mask1ToolStripMenuItem.Click += new System.EventHandler(this.mask1ToolStripMenuItem_Click);
            // 
            // mask2ToolStripMenuItem
            // 
            this.mask2ToolStripMenuItem.Name = "mask2ToolStripMenuItem";
            this.mask2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mask2ToolStripMenuItem.Text = "Mask 2";
            this.mask2ToolStripMenuItem.Click += new System.EventHandler(this.mask2ToolStripMenuItem_Click);
            // 
            // mask3ToolStripMenuItem
            // 
            this.mask3ToolStripMenuItem.Name = "mask3ToolStripMenuItem";
            this.mask3ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mask3ToolStripMenuItem.Text = "Mask 3";
            this.mask3ToolStripMenuItem.Click += new System.EventHandler(this.mask3ToolStripMenuItem_Click);
            // 
            // wyostrzanieToolStripMenuItem1
            // 
            this.wyostrzanieToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maska1ToolStripMenuItem1,
            this.maska2ToolStripMenuItem1,
            this.maska3ToolStripMenuItem1});
            this.wyostrzanieToolStripMenuItem1.Name = "wyostrzanieToolStripMenuItem1";
            this.wyostrzanieToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.wyostrzanieToolStripMenuItem1.Text = "Wyostrzanie";
            // 
            // maska1ToolStripMenuItem1
            // 
            this.maska1ToolStripMenuItem1.Name = "maska1ToolStripMenuItem1";
            this.maska1ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.maska1ToolStripMenuItem1.Text = "Maska 1";
            this.maska1ToolStripMenuItem1.Click += new System.EventHandler(this.maska1ToolStripMenuItem1_Click);
            // 
            // maska2ToolStripMenuItem1
            // 
            this.maska2ToolStripMenuItem1.Name = "maska2ToolStripMenuItem1";
            this.maska2ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.maska2ToolStripMenuItem1.Text = "Maska 2";
            this.maska2ToolStripMenuItem1.Click += new System.EventHandler(this.maska2ToolStripMenuItem1_Click);
            // 
            // maska3ToolStripMenuItem1
            // 
            this.maska3ToolStripMenuItem1.Name = "maska3ToolStripMenuItem1";
            this.maska3ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.maska3ToolStripMenuItem1.Text = "Maska 3";
            this.maska3ToolStripMenuItem1.Click += new System.EventHandler(this.maska3ToolStripMenuItem1_Click);
            // 
            // filtrowanieMedianoweToolStripMenuItem
            // 
            this.filtrowanieMedianoweToolStripMenuItem.Name = "filtrowanieMedianoweToolStripMenuItem";
            this.filtrowanieMedianoweToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.filtrowanieMedianoweToolStripMenuItem.Text = "Filtrowanie Medianowe";
            this.filtrowanieMedianoweToolStripMenuItem.Click += new System.EventHandler(this.filtrowanieMedianoweToolStripMenuItem_Click);
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.sobelToolStripMenuItem.Text = "Sobel";
            this.sobelToolStripMenuItem.Click += new System.EventHandler(this.sobelToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 513);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.ToolStripMenuItem lAB2WyrównanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metodaŚrednichToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lAB2UniwersalnyOperatorJednopunktowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacjeLinioweToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wygładzanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maska1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maska2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maska3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maska4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyostrzanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mask1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mask2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mask3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyostrzanieToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem maska1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem maska2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem maska3ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem filtrowanieMedianoweToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
    }
}

