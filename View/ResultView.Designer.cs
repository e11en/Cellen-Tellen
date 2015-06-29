using Finan.View;
namespace Finan
{
    partial class ResultView
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
            this.Wijzig = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Inzien = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Kolonies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Verdunning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bodem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gebruiker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customPanelView1 = new Finan.CustomPanelView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataView = new Finan.View.CustomDataGridView();
            this.topPanel = new System.Windows.Forms.Panel();
            this.statisticButton = new System.Windows.Forms.Button();
            this.verwijderButton = new System.Windows.Forms.Button();
            this.paginaGrootteNumberBox = new System.Windows.Forms.NumericUpDown();
            this.grootteLabel = new System.Windows.Forms.Label();
            this.currentPageLabel = new System.Windows.Forms.Label();
            this.previousPageButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.lastPageButton = new System.Windows.Forms.Button();
            this.firstPageButton = new System.Windows.Forms.Button();
            this.radioButtonNummer = new System.Windows.Forms.RadioButton();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.radioButtonDatum = new System.Windows.Forms.RadioButton();
            this.radioButtonGebruiker = new System.Windows.Forms.RadioButton();
            this.customPanelView1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paginaGrootteNumberBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Wijzig
            // 
            this.Wijzig.HeaderText = "Wijzig";
            this.Wijzig.Name = "Wijzig";
            this.Wijzig.ReadOnly = true;
            // 
            // Inzien
            // 
            this.Inzien.HeaderText = "Inzien";
            this.Inzien.Name = "Inzien";
            this.Inzien.ReadOnly = true;
            // 
            // Kolonies
            // 
            this.Kolonies.HeaderText = "Kolonies";
            this.Kolonies.Name = "Kolonies";
            this.Kolonies.ReadOnly = true;
            // 
            // Verdunning
            // 
            this.Verdunning.HeaderText = "Verdunning";
            this.Verdunning.Name = "Verdunning";
            this.Verdunning.ReadOnly = true;
            // 
            // Bodem
            // 
            this.Bodem.HeaderText = "Bodem";
            this.Bodem.Name = "Bodem";
            this.Bodem.ReadOnly = true;
            this.Bodem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // Gebruiker
            // 
            this.Gebruiker.HeaderText = "Gebruiker";
            this.Gebruiker.Name = "Gebruiker";
            this.Gebruiker.ReadOnly = true;
            // 
            // Nummer
            // 
            this.Nummer.HeaderText = "Nummer";
            this.Nummer.Name = "Nummer";
            this.Nummer.ReadOnly = true;
            // 
            // customPanelView1
            // 
            this.customPanelView1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.customPanelView1.Controls.Add(this.tableLayoutPanel1);
            this.customPanelView1.Controls.Add(this.topPanel);
            this.customPanelView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanelView1.Location = new System.Drawing.Point(0, 0);
            this.customPanelView1.Margin = new System.Windows.Forms.Padding(2);
            this.customPanelView1.Name = "customPanelView1";
            this.customPanelView1.Size = new System.Drawing.Size(872, 422);
            this.customPanelView1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataView, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 34);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 388F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(872, 388);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataView.Location = new System.Drawing.Point(2, 2);
            this.dataView.Margin = new System.Windows.Forms.Padding(2);
            this.dataView.Name = "dataView";
            this.dataView.RowTemplate.Height = 27;
            this.dataView.Size = new System.Drawing.Size(868, 384);
            this.dataView.TabIndex = 4;
            this.dataView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_onCellClick);
            this.dataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataView_On_Content_Click);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.statisticButton);
            this.topPanel.Controls.Add(this.verwijderButton);
            this.topPanel.Controls.Add(this.paginaGrootteNumberBox);
            this.topPanel.Controls.Add(this.grootteLabel);
            this.topPanel.Controls.Add(this.currentPageLabel);
            this.topPanel.Controls.Add(this.previousPageButton);
            this.topPanel.Controls.Add(this.nextPageButton);
            this.topPanel.Controls.Add(this.lastPageButton);
            this.topPanel.Controls.Add(this.firstPageButton);
            this.topPanel.Controls.Add(this.radioButtonNummer);
            this.topPanel.Controls.Add(this.searchBox);
            this.topPanel.Controls.Add(this.radioButtonDatum);
            this.topPanel.Controls.Add(this.radioButtonGebruiker);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(872, 34);
            this.topPanel.TabIndex = 7;
            // 
            // statisticButton
            // 
            this.statisticButton.Location = new System.Drawing.Point(719, 6);
            this.statisticButton.Name = "statisticButton";
            this.statisticButton.Size = new System.Drawing.Size(66, 24);
            this.statisticButton.TabIndex = 12;
            this.statisticButton.Text = "Statistiek";
            this.statisticButton.UseVisualStyleBackColor = true;
            this.statisticButton.Click += new System.EventHandler(this.statisticButton_Click);
            // 
            // verwijderButton
            // 
            this.verwijderButton.Location = new System.Drawing.Point(789, 6);
            this.verwijderButton.Name = "verwijderButton";
            this.verwijderButton.Size = new System.Drawing.Size(65, 24);
            this.verwijderButton.TabIndex = 11;
            this.verwijderButton.Text = "Verwijder";
            this.verwijderButton.UseVisualStyleBackColor = true;
            this.verwijderButton.Click += new System.EventHandler(this.VerwijderButton_Click);
            // 
            // paginaGrootteNumberBox
            // 
            this.paginaGrootteNumberBox.Location = new System.Drawing.Point(458, 10);
            this.paginaGrootteNumberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.paginaGrootteNumberBox.Name = "paginaGrootteNumberBox";
            this.paginaGrootteNumberBox.Size = new System.Drawing.Size(47, 20);
            this.paginaGrootteNumberBox.TabIndex = 10;
            this.paginaGrootteNumberBox.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.paginaGrootteNumberBox.ValueChanged += new System.EventHandler(this.paginaGrootteNumberBox_ValueChanged);
            // 
            // grootteLabel
            // 
            this.grootteLabel.AutoSize = true;
            this.grootteLabel.Location = new System.Drawing.Point(376, 14);
            this.grootteLabel.Name = "grootteLabel";
            this.grootteLabel.Size = new System.Drawing.Size(79, 13);
            this.grootteLabel.TabIndex = 9;
            this.grootteLabel.Text = "Pagina grootte:";
            // 
            // currentPageLabel
            // 
            this.currentPageLabel.Location = new System.Drawing.Point(571, 11);
            this.currentPageLabel.Name = "currentPageLabel";
            this.currentPageLabel.Size = new System.Drawing.Size(50, 19);
            this.currentPageLabel.TabIndex = 8;
            this.currentPageLabel.Text = "100/100";
            // 
            // previousPageButton
            // 
            this.previousPageButton.Location = new System.Drawing.Point(552, 6);
            this.previousPageButton.Name = "previousPageButton";
            this.previousPageButton.Size = new System.Drawing.Size(18, 25);
            this.previousPageButton.TabIndex = 7;
            this.previousPageButton.Text = "<";
            this.previousPageButton.UseVisualStyleBackColor = true;
            this.previousPageButton.Click += new System.EventHandler(this.previousPageButton_Click);
            // 
            // nextPageButton
            // 
            this.nextPageButton.Location = new System.Drawing.Point(620, 6);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(18, 25);
            this.nextPageButton.TabIndex = 6;
            this.nextPageButton.Text = ">";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // lastPageButton
            // 
            this.lastPageButton.Location = new System.Drawing.Point(644, 6);
            this.lastPageButton.Name = "lastPageButton";
            this.lastPageButton.Size = new System.Drawing.Size(27, 25);
            this.lastPageButton.TabIndex = 5;
            this.lastPageButton.Text = "> |";
            this.lastPageButton.UseVisualStyleBackColor = true;
            this.lastPageButton.Click += new System.EventHandler(this.lastPageButton_Click);
            // 
            // firstPageButton
            // 
            this.firstPageButton.Location = new System.Drawing.Point(519, 6);
            this.firstPageButton.Name = "firstPageButton";
            this.firstPageButton.Size = new System.Drawing.Size(27, 25);
            this.firstPageButton.TabIndex = 4;
            this.firstPageButton.Text = "| <";
            this.firstPageButton.UseVisualStyleBackColor = true;
            this.firstPageButton.Click += new System.EventHandler(this.firstPageButton_Click);
            // 
            // radioButtonNummer
            // 
            this.radioButtonNummer.AutoSize = true;
            this.radioButtonNummer.Location = new System.Drawing.Point(146, 11);
            this.radioButtonNummer.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonNummer.Name = "radioButtonNummer";
            this.radioButtonNummer.Size = new System.Drawing.Size(64, 17);
            this.radioButtonNummer.TabIndex = 3;
            this.radioButtonNummer.TabStop = true;
            this.radioButtonNummer.Text = "Nummer";
            this.radioButtonNummer.UseVisualStyleBackColor = true;
            // 
            // searchBox
            // 
            this.searchBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.searchBox.Location = new System.Drawing.Point(3, 11);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(139, 20);
            this.searchBox.TabIndex = 0;
            this.searchBox.Enter += new System.EventHandler(this.searchBox_Enter);
            this.searchBox.Leave += new System.EventHandler(this.searchBox_Leave);
            // 
            // radioButtonDatum
            // 
            this.radioButtonDatum.AutoSize = true;
            this.radioButtonDatum.Location = new System.Drawing.Point(286, 11);
            this.radioButtonDatum.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonDatum.Name = "radioButtonDatum";
            this.radioButtonDatum.Size = new System.Drawing.Size(56, 17);
            this.radioButtonDatum.TabIndex = 1;
            this.radioButtonDatum.TabStop = true;
            this.radioButtonDatum.Text = "Datum";
            this.radioButtonDatum.UseVisualStyleBackColor = true;
            // 
            // radioButtonGebruiker
            // 
            this.radioButtonGebruiker.AutoSize = true;
            this.radioButtonGebruiker.Location = new System.Drawing.Point(213, 11);
            this.radioButtonGebruiker.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonGebruiker.Name = "radioButtonGebruiker";
            this.radioButtonGebruiker.Size = new System.Drawing.Size(71, 17);
            this.radioButtonGebruiker.TabIndex = 2;
            this.radioButtonGebruiker.TabStop = true;
            this.radioButtonGebruiker.Text = "Gebruiker";
            this.radioButtonGebruiker.UseVisualStyleBackColor = true;
            // 
            // ResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customPanelView1);
            this.Name = "ResultView";
            this.Size = new System.Drawing.Size(872, 422);
            this.customPanelView1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paginaGrootteNumberBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPanelView customPanelView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public CustomDataGridView dataView;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button statisticButton;
        public System.Windows.Forms.Button verwijderButton;
        public System.Windows.Forms.NumericUpDown paginaGrootteNumberBox;
        private System.Windows.Forms.Label grootteLabel;
        public System.Windows.Forms.Label currentPageLabel;
        private System.Windows.Forms.Button previousPageButton;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.Button lastPageButton;
        private System.Windows.Forms.Button firstPageButton;
        public System.Windows.Forms.RadioButton radioButtonNummer;
        public System.Windows.Forms.TextBox searchBox;
        public System.Windows.Forms.RadioButton radioButtonDatum;
        public System.Windows.Forms.RadioButton radioButtonGebruiker;
        private System.Windows.Forms.DataGridViewButtonColumn Wijzig;
        private System.Windows.Forms.DataGridViewButtonColumn Inzien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolonies;
        private System.Windows.Forms.DataGridViewTextBoxColumn Verdunning;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bodem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gebruiker;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nummer;


    }
}
