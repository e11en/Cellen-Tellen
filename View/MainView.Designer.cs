using Finan.View;

namespace Finan
{
    partial class MainView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fotoOpenenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selecteerStandaardMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standaardMapInladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beheerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inloggenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uitloggenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPanels = new System.Windows.Forms.TabControl();
            this.tabInlezen = new System.Windows.Forms.TabPage();
            this.tabResultaat = new System.Windows.Forms.TabPage();
            this.tabStatistiek = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tabPanels.SuspendLayout();
            this.tabStatistiek.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.beheerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(776, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fotoOpenenMenuItem,
            this.selecteerStandaardMapToolStripMenuItem,
            this.standaardMapInladenToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.fileToolStripMenuItem.Text = "Bestand";
            // 
            // fotoOpenenMenuItem
            // 
            this.fotoOpenenMenuItem.Name = "fotoOpenenMenuItem";
            this.fotoOpenenMenuItem.Size = new System.Drawing.Size(203, 22);
            this.fotoOpenenMenuItem.Text = "Foto Openen";
            this.fotoOpenenMenuItem.Click += new System.EventHandler(this.openenToolStripMenuItem_Click);
            // 
            // selecteerStandaardMapToolStripMenuItem
            // 
            this.selecteerStandaardMapToolStripMenuItem.Name = "selecteerStandaardMapToolStripMenuItem";
            this.selecteerStandaardMapToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.selecteerStandaardMapToolStripMenuItem.Text = "Selecteer standaard map";
            this.selecteerStandaardMapToolStripMenuItem.Click += new System.EventHandler(this.selecteerStandaardMapToolStripMenuItem_Click);
            // 
            // standaardMapInladenToolStripMenuItem
            // 
            this.standaardMapInladenToolStripMenuItem.Name = "standaardMapInladenToolStripMenuItem";
            this.standaardMapInladenToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.standaardMapInladenToolStripMenuItem.Text = "Standaard map inladen";
            this.standaardMapInladenToolStripMenuItem.Click += new System.EventHandler(this.standaardMapInladenToolStripMenuItem_Click);
            // 
            // beheerToolStripMenuItem
            // 
            this.beheerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inloggenToolStripMenuItem,
            this.uitloggenToolStripMenuItem});
            this.beheerToolStripMenuItem.Name = "beheerToolStripMenuItem";
            this.beheerToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.beheerToolStripMenuItem.Text = "Beheer";
            // 
            // inloggenToolStripMenuItem
            // 
            this.inloggenToolStripMenuItem.Name = "inloggenToolStripMenuItem";
            this.inloggenToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.inloggenToolStripMenuItem.Text = "Inloggen";
            this.inloggenToolStripMenuItem.Click += new System.EventHandler(this.inloggenToolStripMenuItem_Click);
            // 
            // uitloggenToolStripMenuItem
            // 
            this.uitloggenToolStripMenuItem.Enabled = false;
            this.uitloggenToolStripMenuItem.Name = "uitloggenToolStripMenuItem";
            this.uitloggenToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.uitloggenToolStripMenuItem.Text = "Uitloggen";
            this.uitloggenToolStripMenuItem.Click += new System.EventHandler(this.uitloggenToolStripMenuItem_Click);
            // 
            // tabPanels
            // 
            this.tabPanels.Controls.Add(this.tabInlezen);
            this.tabPanels.Controls.Add(this.tabResultaat);
            this.tabPanels.Controls.Add(this.tabStatistiek);
            this.tabPanels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanels.ItemSize = new System.Drawing.Size(46, 18);
            this.tabPanels.Location = new System.Drawing.Point(0, 24);
            this.tabPanels.Name = "tabPanels";
            this.tabPanels.Padding = new System.Drawing.Point(30, 3);
            this.tabPanels.SelectedIndex = 0;
            this.tabPanels.Size = new System.Drawing.Size(776, 593);
            this.tabPanels.TabIndex = 1;
            this.tabPanels.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabPanels_Selected);
            // 
            // tabInlezen
            // 
            this.tabInlezen.Location = new System.Drawing.Point(4, 22);
            this.tabInlezen.Name = "tabInlezen";
            this.tabInlezen.Padding = new System.Windows.Forms.Padding(3);
            this.tabInlezen.Size = new System.Drawing.Size(768, 567);
            this.tabInlezen.TabIndex = 0;
            this.tabInlezen.Text = "Inlezen";
            this.tabInlezen.UseVisualStyleBackColor = true;
            // 
            // tabResultaat
            // 
            this.tabResultaat.Location = new System.Drawing.Point(4, 22);
            this.tabResultaat.Name = "tabResultaat";
            this.tabResultaat.Padding = new System.Windows.Forms.Padding(3);
            this.tabResultaat.Size = new System.Drawing.Size(768, 567);
            this.tabResultaat.TabIndex = 1;
            this.tabResultaat.Text = "Resultaat";
            this.tabResultaat.UseVisualStyleBackColor = true;
            // 
            // tabStatistiek
            // 
            //this.tabStatistiek.Controls.Add(this.statisticView1);
            this.tabStatistiek.Location = new System.Drawing.Point(4, 22);
            this.tabStatistiek.Name = "tabStatistiek";
            this.tabStatistiek.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatistiek.Size = new System.Drawing.Size(768, 567);
            this.tabStatistiek.TabIndex = 2;
            this.tabStatistiek.Text = "Statistiek";
            this.tabStatistiek.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPanels);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(776, 617);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPanels.ResumeLayout(false);
            this.tabStatistiek.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fotoOpenenMenuItem;
        public System.Windows.Forms.TabControl tabPanels;
        private System.Windows.Forms.TabPage tabInlezen;
        private System.Windows.Forms.TabPage tabResultaat;
        private System.Windows.Forms.ToolStripMenuItem selecteerStandaardMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standaardMapInladenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beheerToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem inloggenToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem uitloggenToolStripMenuItem;
        private System.Windows.Forms.TabPage tabStatistiek;
        private StatisticView statisticView1;
    }
}
