using System.Windows.Forms;
namespace Finan
{
    partial class InleesView
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
            this.components = new System.ComponentModel.Container();
            this.btnVoegToe = new System.Windows.Forms.Button();
            this.btnBereken = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.bronTextBox = new System.Windows.Forms.TextBox();
            this.Bron = new System.Windows.Forms.Label();
            this.nmKolonies = new System.Windows.Forms.NumericUpDown();
            this.nmVerdunning = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nmTemperatuur = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nmDagen = new System.Windows.Forms.NumericUpDown();
            this.nmUren = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.behandelingTextBox = new System.Windows.Forms.RichTextBox();
            this.behandelingLabel = new System.Windows.Forms.Label();
            this.mediumTextBox = new System.Windows.Forms.RichTextBox();
            this.mediumLabel = new System.Windows.Forms.Label();
            this.tijdLabel = new System.Windows.Forms.Label();
            this.strainTextBox = new System.Windows.Forms.TextBox();
            this.bodemComboBox = new System.Windows.Forms.ComboBox();
            this.soortTextBox = new System.Windows.Forms.TextBox();
            this.gebruikerTextBox = new System.Windows.Forms.TextBox();
            this.strainLabel = new System.Windows.Forms.Label();
            this.soortLabel = new System.Windows.Forms.Label();
            this.temperatuurLabel = new System.Windows.Forms.Label();
            this.kolonieLabel = new System.Windows.Forms.Label();
            this.bodemLabel = new System.Windows.Forms.Label();
            this.verdunningLabel = new System.Windows.Forms.Label();
            this.gebruikerLabel = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblSelect = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.AchtergrondPanelKleur = new System.Windows.Forms.Panel();
            this.KoloniePanelKleur = new System.Windows.Forms.Panel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.inleesImageListView = new Finan.CustomPanelView();
            this.inleesImageView = new Finan.CustomPanelView();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.erp = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nmKolonies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerdunning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTemperatuur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUren)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.inleesImageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoegToe
            // 
            this.btnVoegToe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnVoegToe.AutoSize = true;
            this.btnVoegToe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnVoegToe.Location = new System.Drawing.Point(3, 35);
            this.btnVoegToe.Name = "btnVoegToe";
            this.btnVoegToe.Size = new System.Drawing.Size(75, 26);
            this.btnVoegToe.TabIndex = 13;
            this.btnVoegToe.Text = "Voeg toe";
            this.btnVoegToe.UseVisualStyleBackColor = true;
            this.btnVoegToe.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBereken
            // 
            this.btnBereken.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBereken.AutoSize = true;
            this.btnBereken.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBereken.Location = new System.Drawing.Point(3, 3);
            this.btnBereken.Name = "btnBereken";
            this.btnBereken.Size = new System.Drawing.Size(71, 26);
            this.btnBereken.TabIndex = 12;
            this.btnBereken.Text = "Bereken";
            this.btnBereken.UseVisualStyleBackColor = true;
            this.btnBereken.Click += new System.EventHandler(this.btnBereken_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnReset.AutoSize = true;
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(97, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(55, 26);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // bronTextBox
            // 
            this.bronTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bronTextBox.Location = new System.Drawing.Point(126, 197);
            this.bronTextBox.Name = "bronTextBox";
            this.bronTextBox.Size = new System.Drawing.Size(182, 22);
            this.bronTextBox.TabIndex = 6;
            // 
            // Bron
            // 
            this.Bron.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Bron.AutoSize = true;
            this.Bron.Location = new System.Drawing.Point(3, 199);
            this.Bron.Name = "Bron";
            this.Bron.Size = new System.Drawing.Size(38, 17);
            this.Bron.TabIndex = 94;
            this.Bron.Text = "Bron";
            // 
            // nmKolonies
            // 
            this.nmKolonies.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nmKolonies.Location = new System.Drawing.Point(126, 69);
            this.nmKolonies.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmKolonies.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmKolonies.Name = "nmKolonies";
            this.nmKolonies.Size = new System.Drawing.Size(182, 22);
            this.nmKolonies.TabIndex = 2;
            // 
            // nmVerdunning
            // 
            this.nmVerdunning.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nmVerdunning.Location = new System.Drawing.Point(126, 37);
            this.nmVerdunning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmVerdunning.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmVerdunning.Name = "nmVerdunning";
            this.nmVerdunning.Size = new System.Drawing.Size(182, 22);
            this.nmVerdunning.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 17);
            this.label3.TabIndex = 91;
            this.label3.Text = "ºC";
            // 
            // nmTemperatuur
            // 
            this.nmTemperatuur.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nmTemperatuur.Location = new System.Drawing.Point(3, 2);
            this.nmTemperatuur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmTemperatuur.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmTemperatuur.Minimum = new decimal(new int[] {
            274,
            0,
            0,
            -2147483648});
            this.nmTemperatuur.Name = "nmTemperatuur";
            this.nmTemperatuur.Size = new System.Drawing.Size(148, 22);
            this.nmTemperatuur.TabIndex = 3;
            this.nmTemperatuur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmTemperatuur.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 89;
            this.label2.Text = "Dagen:";
            // 
            // nmDagen
            // 
            this.nmDagen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nmDagen.Location = new System.Drawing.Point(57, 2);
            this.nmDagen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmDagen.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nmDagen.Name = "nmDagen";
            this.nmDagen.Size = new System.Drawing.Size(36, 22);
            this.nmDagen.TabIndex = 7;
            // 
            // nmUren
            // 
            this.nmUren.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nmUren.Location = new System.Drawing.Point(143, 2);
            this.nmUren.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmUren.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nmUren.Name = "nmUren";
            this.nmUren.Size = new System.Drawing.Size(36, 22);
            this.nmUren.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 86;
            this.label1.Text = "Uren:";
            // 
            // behandelingTextBox
            // 
            this.behandelingTextBox.BackColor = System.Drawing.Color.White;
            this.behandelingTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.behandelingTextBox.ForeColor = System.Drawing.Color.Black;
            this.behandelingTextBox.Location = new System.Drawing.Point(126, 44);
            this.behandelingTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.behandelingTextBox.Name = "behandelingTextBox";
            this.behandelingTextBox.Size = new System.Drawing.Size(181, 32);
            this.behandelingTextBox.TabIndex = 11;
            this.behandelingTextBox.Text = "";
            // 
            // behandelingLabel
            // 
            this.behandelingLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.behandelingLabel.AutoSize = true;
            this.behandelingLabel.Location = new System.Drawing.Point(3, 51);
            this.behandelingLabel.Name = "behandelingLabel";
            this.behandelingLabel.Size = new System.Drawing.Size(91, 17);
            this.behandelingLabel.TabIndex = 84;
            this.behandelingLabel.Text = "Behandeling:";
            // 
            // mediumTextBox
            // 
            this.mediumTextBox.BackColor = System.Drawing.Color.White;
            this.mediumTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediumTextBox.ForeColor = System.Drawing.Color.Black;
            this.mediumTextBox.Location = new System.Drawing.Point(126, 4);
            this.mediumTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.mediumTextBox.Name = "mediumTextBox";
            this.mediumTextBox.Size = new System.Drawing.Size(181, 32);
            this.mediumTextBox.TabIndex = 10;
            this.mediumTextBox.Text = "";
            // 
            // mediumLabel
            // 
            this.mediumLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mediumLabel.AutoSize = true;
            this.mediumLabel.Location = new System.Drawing.Point(3, 11);
            this.mediumLabel.Name = "mediumLabel";
            this.mediumLabel.Size = new System.Drawing.Size(61, 17);
            this.mediumLabel.TabIndex = 82;
            this.mediumLabel.Text = "Medium:";
            // 
            // tijdLabel
            // 
            this.tijdLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tijdLabel.AutoSize = true;
            this.tijdLabel.Location = new System.Drawing.Point(3, 232);
            this.tijdLabel.Name = "tijdLabel";
            this.tijdLabel.Size = new System.Drawing.Size(71, 17);
            this.tijdLabel.TabIndex = 81;
            this.tijdLabel.Text = "Tijdsduur:";
            // 
            // strainTextBox
            // 
            this.strainTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.strainTextBox.BackColor = System.Drawing.Color.White;
            this.strainTextBox.ForeColor = System.Drawing.Color.Black;
            this.strainTextBox.Location = new System.Drawing.Point(126, 165);
            this.strainTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.strainTextBox.Name = "strainTextBox";
            this.strainTextBox.Size = new System.Drawing.Size(182, 22);
            this.strainTextBox.TabIndex = 5;
            // 
            // bodemComboBox
            // 
            this.bodemComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bodemComboBox.BackColor = System.Drawing.Color.White;
            this.bodemComboBox.ForeColor = System.Drawing.Color.Black;
            this.bodemComboBox.FormattingEnabled = true;
            this.bodemComboBox.Location = new System.Drawing.Point(126, 264);
            this.bodemComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bodemComboBox.Name = "bodemComboBox";
            this.bodemComboBox.Size = new System.Drawing.Size(182, 24);
            this.bodemComboBox.TabIndex = 9;
            // 
            // soortTextBox
            // 
            this.soortTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.soortTextBox.BackColor = System.Drawing.Color.White;
            this.soortTextBox.ForeColor = System.Drawing.Color.Black;
            this.soortTextBox.Location = new System.Drawing.Point(126, 133);
            this.soortTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.soortTextBox.Name = "soortTextBox";
            this.soortTextBox.Size = new System.Drawing.Size(182, 22);
            this.soortTextBox.TabIndex = 4;
            // 
            // gebruikerTextBox
            // 
            this.gebruikerTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.gebruikerTextBox.BackColor = System.Drawing.Color.White;
            this.gebruikerTextBox.ForeColor = System.Drawing.Color.Black;
            this.gebruikerTextBox.Location = new System.Drawing.Point(126, 5);
            this.gebruikerTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gebruikerTextBox.Name = "gebruikerTextBox";
            this.gebruikerTextBox.Size = new System.Drawing.Size(182, 22);
            this.gebruikerTextBox.TabIndex = 0;
            // 
            // strainLabel
            // 
            this.strainLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.strainLabel.AutoSize = true;
            this.strainLabel.Location = new System.Drawing.Point(3, 167);
            this.strainLabel.Name = "strainLabel";
            this.strainLabel.Size = new System.Drawing.Size(49, 17);
            this.strainLabel.TabIndex = 76;
            this.strainLabel.Text = "Strain:";
            // 
            // soortLabel
            // 
            this.soortLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.soortLabel.AutoSize = true;
            this.soortLabel.Location = new System.Drawing.Point(3, 135);
            this.soortLabel.Name = "soortLabel";
            this.soortLabel.Size = new System.Drawing.Size(46, 17);
            this.soortLabel.TabIndex = 75;
            this.soortLabel.Text = "Soort:";
            // 
            // temperatuurLabel
            // 
            this.temperatuurLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.temperatuurLabel.AutoSize = true;
            this.temperatuurLabel.Location = new System.Drawing.Point(3, 103);
            this.temperatuurLabel.Name = "temperatuurLabel";
            this.temperatuurLabel.Size = new System.Drawing.Size(94, 17);
            this.temperatuurLabel.TabIndex = 74;
            this.temperatuurLabel.Text = "Temperatuur:";
            // 
            // kolonieLabel
            // 
            this.kolonieLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kolonieLabel.AutoSize = true;
            this.kolonieLabel.Location = new System.Drawing.Point(3, 71);
            this.kolonieLabel.Name = "kolonieLabel";
            this.kolonieLabel.Size = new System.Drawing.Size(66, 17);
            this.kolonieLabel.TabIndex = 73;
            this.kolonieLabel.Text = "Kolonies:";
            // 
            // bodemLabel
            // 
            this.bodemLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bodemLabel.AutoSize = true;
            this.bodemLabel.Location = new System.Drawing.Point(3, 268);
            this.bodemLabel.Name = "bodemLabel";
            this.bodemLabel.Size = new System.Drawing.Size(114, 17);
            this.bodemLabel.TabIndex = 72;
            this.bodemLabel.Text = "Voedingsbodem:";
            // 
            // verdunningLabel
            // 
            this.verdunningLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.verdunningLabel.AutoSize = true;
            this.verdunningLabel.Location = new System.Drawing.Point(3, 39);
            this.verdunningLabel.Name = "verdunningLabel";
            this.verdunningLabel.Size = new System.Drawing.Size(85, 17);
            this.verdunningLabel.TabIndex = 71;
            this.verdunningLabel.Text = "Verdunning:";
            // 
            // gebruikerLabel
            // 
            this.gebruikerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gebruikerLabel.AutoSize = true;
            this.gebruikerLabel.Location = new System.Drawing.Point(3, 7);
            this.gebruikerLabel.Name = "gebruikerLabel";
            this.gebruikerLabel.Size = new System.Drawing.Size(75, 17);
            this.gebruikerLabel.TabIndex = 70;
            this.gebruikerLabel.Text = "Gebruiker:";
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(32, 16);
            this.lblFilter.TabIndex = 98;
            this.lblFilter.Text = "BG:";
            // 
            // lblSelect
            // 
            this.lblSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelect.AutoSize = true;
            this.lblSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect.ForeColor = System.Drawing.Color.Red;
            this.lblSelect.Location = new System.Drawing.Point(969, 456);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(178, 20);
            this.lblSelect.TabIndex = 99;
            this.lblSelect.Text = "Selecteer een kleur!";
            this.lblSelect.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.86486F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.13514F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.gebruikerLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gebruikerTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.verdunningLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nmVerdunning, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.bronTextBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.kolonieLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Bron, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.bodemComboBox, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.nmKolonies, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.bodemLabel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.temperatuurLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.soortLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.soortTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.strainLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.strainTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tijdLabel, 0, 7);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(848, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.1137F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.1137F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(311, 297);
            this.tableLayoutPanel1.TabIndex = 100;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.67033F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.17583F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.52747F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.nmUren, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.nmDagen, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(126, 227);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(182, 26);
            this.tableLayoutPanel3.TabIndex = 101;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.61539F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanel2.Controls.Add(this.nmTemperatuur, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(123, 99);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(182, 26);
            this.tableLayoutPanel2.TabIndex = 101;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.54984F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.45016F));
            this.tableLayoutPanel4.Controls.Add(this.mediumLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.mediumTextBox, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.behandelingTextBox, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.behandelingLabel, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(848, 306);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(311, 80);
            this.tableLayoutPanel4.TabIndex = 101;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.lblFilter, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.AchtergrondPanelKleur, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.KoloniePanelKleur, 1, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(848, 389);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.73171F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.2683F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(117, 82);
            this.tableLayoutPanel5.TabIndex = 102;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 99;
            this.label4.Text = "KLN:";
            // 
            // AchtergrondPanelKleur
            // 
            this.AchtergrondPanelKleur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AchtergrondPanelKleur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AchtergrondPanelKleur.Location = new System.Drawing.Point(3, 19);
            this.AchtergrondPanelKleur.Name = "AchtergrondPanelKleur";
            this.AchtergrondPanelKleur.Size = new System.Drawing.Size(52, 60);
            this.AchtergrondPanelKleur.TabIndex = 100;
            // 
            // KoloniePanelKleur
            // 
            this.KoloniePanelKleur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KoloniePanelKleur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KoloniePanelKleur.Location = new System.Drawing.Point(61, 19);
            this.KoloniePanelKleur.Name = "KoloniePanelKleur";
            this.KoloniePanelKleur.Size = new System.Drawing.Size(53, 60);
            this.KoloniePanelKleur.TabIndex = 101;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.btnBereken, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnVoegToe, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.btnReset, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(970, 389);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(189, 64);
            this.tableLayoutPanel6.TabIndex = 103;
            // 
            // inleesImageListView
            // 
            this.inleesImageListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inleesImageListView.AutoScroll = true;
            this.inleesImageListView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.inleesImageListView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inleesImageListView.Location = new System.Drawing.Point(4, 508);
            this.inleesImageListView.Name = "inleesImageListView";
            this.inleesImageListView.Size = new System.Drawing.Size(1152, 139);
            this.inleesImageListView.TabIndex = 11;
            this.inleesImageListView.MouseEnter += new System.EventHandler(this.inleesImageListView_MouseEnter);
            this.inleesImageListView.Resize += new System.EventHandler(this.inleesImageListView_Resize);
            // 
            // inleesImageView
            // 
            this.inleesImageView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inleesImageView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.inleesImageView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inleesImageView.Controls.Add(this.pictureBox);
            this.inleesImageView.Location = new System.Drawing.Point(3, 17);
            this.inleesImageView.Name = "inleesImageView";
            this.inleesImageView.Size = new System.Drawing.Size(826, 485);
            this.inleesImageView.TabIndex = 10;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(822, 481);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // erp
            // 
            this.erp.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erp.ContainerControl = this;
            // 
            // InleesView
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel6);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.inleesImageListView);
            this.Controls.Add(this.inleesImageView);
            this.MinimumSize = new System.Drawing.Size(622, 555);
            this.Name = "InleesView";
            this.Size = new System.Drawing.Size(1162, 660);
            ((System.ComponentModel.ISupportInitialize)(this.nmKolonies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerdunning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTemperatuur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUren)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.inleesImageView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public CustomPanelView inleesImageListView;
        public CustomPanelView inleesImageView;
        public PictureBox pictureBox;
        private Button btnVoegToe;
        private Button btnBereken;
        private Button btnReset;
        public TextBox bronTextBox;
        private Label Bron;
        public NumericUpDown nmKolonies;
        public NumericUpDown nmVerdunning;
        private Label label3;
        public NumericUpDown nmTemperatuur;
        public Label label2;
        public NumericUpDown nmDagen;
        public NumericUpDown nmUren;
        public Label label1;
        public RichTextBox behandelingTextBox;
        private Label behandelingLabel;
        public RichTextBox mediumTextBox;
        private Label mediumLabel;
        private Label tijdLabel;
        public TextBox strainTextBox;
        public ComboBox bodemComboBox;
        public TextBox soortTextBox;
        public TextBox gebruikerTextBox;
        private Label strainLabel;
        private Label soortLabel;
        private Label temperatuurLabel;
        private Label kolonieLabel;
        private Label bodemLabel;
        private Label verdunningLabel;
        private Label gebruikerLabel;
        private Label lblFilter;
        private Label lblSelect;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label4;
        public Panel KoloniePanelKleur;
        public Panel AchtergrondPanelKleur;
        public ErrorProvider erp;
    }
}
