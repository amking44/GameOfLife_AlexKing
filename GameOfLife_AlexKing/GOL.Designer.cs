
namespace GameOfLife_AlexKing
{
    partial class GOLForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GOLForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bySeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byCurrentSeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tenGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neighborCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hUDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tenGridColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.GridClear = new System.Windows.Forms.ToolStripButton();
            this.Pause = new System.Windows.Forms.ToolStripButton();
            this.Play = new System.Windows.Forms.ToolStripButton();
            this.NextGen = new System.Windows.Forms.ToolStripButton();
            this.doubleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelGenerations = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelcellsAlive = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTorodial = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cellColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicsPanel1 = new GameOfLife_AlexKing.GraphicsPanel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.randomizeToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(724, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveToolStripMenuItem.Text = "&Save As";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // randomizeToolStripMenuItem
            // 
            this.randomizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bySeedToolStripMenuItem,
            this.byCurrentSeedToolStripMenuItem,
            this.byTimeToolStripMenuItem});
            this.randomizeToolStripMenuItem.Name = "randomizeToolStripMenuItem";
            this.randomizeToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.randomizeToolStripMenuItem.Text = "Randomize";
            // 
            // bySeedToolStripMenuItem
            // 
            this.bySeedToolStripMenuItem.Name = "bySeedToolStripMenuItem";
            this.bySeedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bySeedToolStripMenuItem.Text = "By New Seed";
            this.bySeedToolStripMenuItem.Click += new System.EventHandler(this.bySeedToolStripMenuItem_Click);
            // 
            // byCurrentSeedToolStripMenuItem
            // 
            this.byCurrentSeedToolStripMenuItem.Name = "byCurrentSeedToolStripMenuItem";
            this.byCurrentSeedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.byCurrentSeedToolStripMenuItem.Text = "By Current Seed";
            this.byCurrentSeedToolStripMenuItem.Click += new System.EventHandler(this.byCurrentSeedToolStripMenuItem_Click);
            // 
            // byTimeToolStripMenuItem
            // 
            this.byTimeToolStripMenuItem.Name = "byTimeToolStripMenuItem";
            this.byTimeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.byTimeToolStripMenuItem.Text = "By Time";
            this.byTimeToolStripMenuItem.Click += new System.EventHandler(this.byTimeToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridToolStripMenuItem,
            this.tenGridToolStripMenuItem,
            this.neighborCountToolStripMenuItem,
            this.hUDToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Checked = true;
            this.gridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gridToolStripMenuItem.Text = "Grid";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // tenGridToolStripMenuItem
            // 
            this.tenGridToolStripMenuItem.Checked = true;
            this.tenGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tenGridToolStripMenuItem.Name = "tenGridToolStripMenuItem";
            this.tenGridToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tenGridToolStripMenuItem.Text = "x10 Grid";
            this.tenGridToolStripMenuItem.Click += new System.EventHandler(this.tenGridToolStripMenuItem_Click);
            // 
            // neighborCountToolStripMenuItem
            // 
            this.neighborCountToolStripMenuItem.Checked = true;
            this.neighborCountToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.neighborCountToolStripMenuItem.Name = "neighborCountToolStripMenuItem";
            this.neighborCountToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.neighborCountToolStripMenuItem.Text = "Neighbor Count";
            this.neighborCountToolStripMenuItem.Click += new System.EventHandler(this.neighborCountToolStripMenuItem_Click);
            // 
            // hUDToolStripMenuItem
            // 
            this.hUDToolStripMenuItem.Checked = true;
            this.hUDToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hUDToolStripMenuItem.Name = "hUDToolStripMenuItem";
            this.hUDToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hUDToolStripMenuItem.Text = "HUD";
            this.hUDToolStripMenuItem.Click += new System.EventHandler(this.hUDToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem2
            // 
            this.settingsToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundColorToolStripMenuItem,
            this.cellColorToolStripMenuItem1,
            this.gridColorToolStripMenuItem,
            this.tenGridColorToolStripMenuItem,
            this.toolStripSeparator1,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator2,
            this.resetToolStripMenuItem,
            this.reloadToolStripMenuItem});
            this.settingsToolStripMenuItem2.Name = "settingsToolStripMenuItem2";
            this.settingsToolStripMenuItem2.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem2.Text = "Settings";
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.backgroundColorToolStripMenuItem.Text = "Background Color";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click_1);
            // 
            // cellColorToolStripMenuItem1
            // 
            this.cellColorToolStripMenuItem1.Name = "cellColorToolStripMenuItem1";
            this.cellColorToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.cellColorToolStripMenuItem1.Text = "Cell Color";
            this.cellColorToolStripMenuItem1.Click += new System.EventHandler(this.cellColorToolStripMenuItem1_Click_1);
            // 
            // gridColorToolStripMenuItem
            // 
            this.gridColorToolStripMenuItem.Name = "gridColorToolStripMenuItem";
            this.gridColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gridColorToolStripMenuItem.Text = "Grid Color";
            this.gridColorToolStripMenuItem.Click += new System.EventHandler(this.gridColorToolStripMenuItem_Click_1);
            // 
            // tenGridColorToolStripMenuItem
            // 
            this.tenGridColorToolStripMenuItem.Name = "tenGridColorToolStripMenuItem";
            this.tenGridColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tenGridColorToolStripMenuItem.Text = "x10 Grid Color";
            this.tenGridColorToolStripMenuItem.Click += new System.EventHandler(this.tenGridColorToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GridClear,
            this.Pause,
            this.Play,
            this.NextGen,
            this.doubleSpeedButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(724, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // GridClear
            // 
            this.GridClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GridClear.Image = ((System.Drawing.Image)(resources.GetObject("GridClear.Image")));
            this.GridClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GridClear.Name = "GridClear";
            this.GridClear.Size = new System.Drawing.Size(23, 22);
            this.GridClear.Text = "ClearGrid";
            this.GridClear.ToolTipText = "Clear Grid";
            this.GridClear.Click += new System.EventHandler(this.GridClear_Click);
            // 
            // Pause
            // 
            this.Pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Pause.Image = ((System.Drawing.Image)(resources.GetObject("Pause.Image")));
            this.Pause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(23, 22);
            this.Pause.Text = "toolStripButton3";
            this.Pause.ToolTipText = "Pause";
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Play
            // 
            this.Play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Play.Image = ((System.Drawing.Image)(resources.GetObject("Play.Image")));
            this.Play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(23, 22);
            this.Play.Text = "toolStripButton2";
            this.Play.ToolTipText = "Play";
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // NextGen
            // 
            this.NextGen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NextGen.Image = ((System.Drawing.Image)(resources.GetObject("NextGen.Image")));
            this.NextGen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NextGen.Name = "NextGen";
            this.NextGen.Size = new System.Drawing.Size(23, 22);
            this.NextGen.Text = "toolStripButton4";
            this.NextGen.ToolTipText = "Next Generation";
            this.NextGen.Click += new System.EventHandler(this.NextGen_Click);
            // 
            // doubleSpeedButton
            // 
            this.doubleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.doubleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("doubleSpeedButton.Image")));
            this.doubleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.doubleSpeedButton.Name = "doubleSpeedButton";
            this.doubleSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.doubleSpeedButton.Text = "Double Speed";
            this.doubleSpeedButton.Click += new System.EventHandler(this.doubleSpeedButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelGenerations,
            this.toolStripStatusLabelcellsAlive,
            this.toolStripStatusLabelTorodial,
            this.toolStripStatusLabelSeed});
            this.statusStrip1.Location = new System.Drawing.Point(0, 679);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(724, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelGenerations
            // 
            this.toolStripStatusLabelGenerations.Name = "toolStripStatusLabelGenerations";
            this.toolStripStatusLabelGenerations.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabelGenerations.Text = "Generations = 0";
            // 
            // toolStripStatusLabelcellsAlive
            // 
            this.toolStripStatusLabelcellsAlive.Name = "toolStripStatusLabelcellsAlive";
            this.toolStripStatusLabelcellsAlive.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabelcellsAlive.Text = "Cells Alive = 0";
            // 
            // toolStripStatusLabelTorodial
            // 
            this.toolStripStatusLabelTorodial.Name = "toolStripStatusLabelTorodial";
            this.toolStripStatusLabelTorodial.Size = new System.Drawing.Size(133, 17);
            this.toolStripStatusLabelTorodial.Text = "Torodial Universe = True";
            // 
            // toolStripStatusLabelSeed
            // 
            this.toolStripStatusLabelSeed.Name = "toolStripStatusLabelSeed";
            this.toolStripStatusLabelSeed.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabelSeed.Text = "Seed = 44";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundColorToolStripMenuItem1,
            this.cellColorToolStripMenuItem,
            this.gridColorToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(171, 70);
            // 
            // backgroundColorToolStripMenuItem1
            // 
            this.backgroundColorToolStripMenuItem1.Name = "backgroundColorToolStripMenuItem1";
            this.backgroundColorToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.backgroundColorToolStripMenuItem1.Text = "Background Color";
            this.backgroundColorToolStripMenuItem1.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem1_Click);
            // 
            // cellColorToolStripMenuItem
            // 
            this.cellColorToolStripMenuItem.Name = "cellColorToolStripMenuItem";
            this.cellColorToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.cellColorToolStripMenuItem.Text = "Cell Color";
            this.cellColorToolStripMenuItem.Click += new System.EventHandler(this.cellColorToolStripMenuItem_Click);
            // 
            // gridColorToolStripMenuItem1
            // 
            this.gridColorToolStripMenuItem1.Name = "gridColorToolStripMenuItem1";
            this.gridColorToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.gridColorToolStripMenuItem1.Text = "Grid Color";
            this.gridColorToolStripMenuItem1.Click += new System.EventHandler(this.gridColorToolStripMenuItem1_Click);
            // 
            // graphicsPanel1
            // 
            this.graphicsPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.graphicsPanel1.ContextMenuStrip = this.contextMenuStrip1;
            this.graphicsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsPanel1.Location = new System.Drawing.Point(0, 49);
            this.graphicsPanel1.Name = "graphicsPanel1";
            this.graphicsPanel1.Size = new System.Drawing.Size(724, 630);
            this.graphicsPanel1.TabIndex = 3;
            this.graphicsPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsPanel1_Paint);
            this.graphicsPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel1_MouseClick);
            // 
            // GOLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 701);
            this.Controls.Add(this.graphicsPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GOLForm";
            this.Text = "Game of Life";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GOLForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private GraphicsPanel graphicsPanel1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGenerations;
        private System.Windows.Forms.ToolStripButton GridClear;
        private System.Windows.Forms.ToolStripButton Pause;
        private System.Windows.Forms.ToolStripButton Play;
        private System.Windows.Forms.ToolStripButton NextGen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelcellsAlive;
        private System.Windows.Forms.ToolStripButton doubleSpeedButton;
        private System.Windows.Forms.ToolStripMenuItem randomizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bySeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTorodial;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neighborCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hUDToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSeed;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byCurrentSeedToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gridColorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cellColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cellColorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gridColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tenGridColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tenGridToolStripMenuItem;
    }
}

