namespace Finan.View
{
    partial class SettingsView
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
            ((System.ComponentModel.ISupportInitialize)(this.nmKolonies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerdunning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTemperatuur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUren)).BeginInit();
            this.SuspendLayout();
            // 
            // bronTextBox
            // 
            this.bronTextBox.Location = new System.Drawing.Point(125, 190);
            this.bronTextBox.Name = "bronTextBox";
            this.bronTextBox.Size = new System.Drawing.Size(187, 22);
            this.bronTextBox.TabIndex = 69;
            // 
            // Bron
            // 
            this.Bron.AutoSize = true;
            this.Bron.Location = new System.Drawing.Point(3, 193);
            this.Bron.Name = "Bron";
            this.Bron.Size = new System.Drawing.Size(38, 17);
            this.Bron.TabIndex = 68;
            this.Bron.Text = "Bron";
            // 
            // nmKolonies
            // 
            this.nmKolonies.Location = new System.Drawing.Point(125, 69);
            this.nmKolonies.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmKolonies.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmKolonies.Name = "nmKolonies";
            this.nmKolonies.Size = new System.Drawing.Size(187, 22);
            this.nmKolonies.TabIndex = 67;
            // 
            // nmVerdunning
            // 
            this.nmVerdunning.Location = new System.Drawing.Point(125, 41);
            this.nmVerdunning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmVerdunning.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmVerdunning.Name = "nmVerdunning";
            this.nmVerdunning.Size = new System.Drawing.Size(187, 22);
            this.nmVerdunning.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 17);
            this.label3.TabIndex = 65;
            this.label3.Text = "ºC";
            // 
            // nmTemperatuur
            // 
            this.nmTemperatuur.Location = new System.Drawing.Point(125, 95);
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
            this.nmTemperatuur.Size = new System.Drawing.Size(159, 22);
            this.nmTemperatuur.TabIndex = 64;
            this.nmTemperatuur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmTemperatuur.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 63;
            this.label2.Text = "Dagen:";
            // 
            // nmDagen
            // 
            this.nmDagen.Location = new System.Drawing.Point(183, 220);
            this.nmDagen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmDagen.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nmDagen.Name = "nmDagen";
            this.nmDagen.Size = new System.Drawing.Size(37, 22);
            this.nmDagen.TabIndex = 62;
            // 
            // nmUren
            // 
            this.nmUren.Location = new System.Drawing.Point(275, 220);
            this.nmUren.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmUren.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nmUren.Name = "nmUren";
            this.nmUren.Size = new System.Drawing.Size(37, 22);
            this.nmUren.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 60;
            this.label1.Text = "Uren:";
            // 
            // behandelingTextBox
            // 
            this.behandelingTextBox.BackColor = System.Drawing.Color.White;
            this.behandelingTextBox.ForeColor = System.Drawing.Color.Black;
            this.behandelingTextBox.Location = new System.Drawing.Point(125, 366);
            this.behandelingTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.behandelingTextBox.Name = "behandelingTextBox";
            this.behandelingTextBox.Size = new System.Drawing.Size(187, 80);
            this.behandelingTextBox.TabIndex = 59;
            this.behandelingTextBox.Text = "";
            // 
            // behandelingLabel
            // 
            this.behandelingLabel.AutoSize = true;
            this.behandelingLabel.Location = new System.Drawing.Point(3, 370);
            this.behandelingLabel.Name = "behandelingLabel";
            this.behandelingLabel.Size = new System.Drawing.Size(91, 17);
            this.behandelingLabel.TabIndex = 58;
            this.behandelingLabel.Text = "Behandeling:";
            // 
            // mediumTextBox
            // 
            this.mediumTextBox.BackColor = System.Drawing.Color.White;
            this.mediumTextBox.ForeColor = System.Drawing.Color.Black;
            this.mediumTextBox.Location = new System.Drawing.Point(125, 285);
            this.mediumTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.mediumTextBox.Name = "mediumTextBox";
            this.mediumTextBox.Size = new System.Drawing.Size(187, 80);
            this.mediumTextBox.TabIndex = 57;
            this.mediumTextBox.Text = "";
            // 
            // mediumLabel
            // 
            this.mediumLabel.AutoSize = true;
            this.mediumLabel.Location = new System.Drawing.Point(3, 289);
            this.mediumLabel.Name = "mediumLabel";
            this.mediumLabel.Size = new System.Drawing.Size(61, 17);
            this.mediumLabel.TabIndex = 56;
            this.mediumLabel.Text = "Medium:";
            // 
            // tijdLabel
            // 
            this.tijdLabel.AutoSize = true;
            this.tijdLabel.Location = new System.Drawing.Point(3, 224);
            this.tijdLabel.Name = "tijdLabel";
            this.tijdLabel.Size = new System.Drawing.Size(71, 17);
            this.tijdLabel.TabIndex = 55;
            this.tijdLabel.Text = "Tijdsduur:";
            // 
            // strainTextBox
            // 
            this.strainTextBox.BackColor = System.Drawing.Color.White;
            this.strainTextBox.ForeColor = System.Drawing.Color.Black;
            this.strainTextBox.Location = new System.Drawing.Point(125, 158);
            this.strainTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.strainTextBox.Name = "strainTextBox";
            this.strainTextBox.Size = new System.Drawing.Size(187, 22);
            this.strainTextBox.TabIndex = 54;
            // 
            // bodemComboBox
            // 
            this.bodemComboBox.BackColor = System.Drawing.Color.White;
            this.bodemComboBox.ForeColor = System.Drawing.Color.Black;
            this.bodemComboBox.FormattingEnabled = true;
            this.bodemComboBox.Location = new System.Drawing.Point(125, 251);
            this.bodemComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bodemComboBox.Name = "bodemComboBox";
            this.bodemComboBox.Size = new System.Drawing.Size(187, 24);
            this.bodemComboBox.TabIndex = 53;
            // 
            // soortTextBox
            // 
            this.soortTextBox.BackColor = System.Drawing.Color.White;
            this.soortTextBox.ForeColor = System.Drawing.Color.Black;
            this.soortTextBox.Location = new System.Drawing.Point(125, 125);
            this.soortTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.soortTextBox.Name = "soortTextBox";
            this.soortTextBox.Size = new System.Drawing.Size(187, 22);
            this.soortTextBox.TabIndex = 52;
            // 
            // gebruikerTextBox
            // 
            this.gebruikerTextBox.BackColor = System.Drawing.Color.White;
            this.gebruikerTextBox.ForeColor = System.Drawing.Color.Black;
            this.gebruikerTextBox.Location = new System.Drawing.Point(125, 11);
            this.gebruikerTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gebruikerTextBox.Name = "gebruikerTextBox";
            this.gebruikerTextBox.Size = new System.Drawing.Size(187, 22);
            this.gebruikerTextBox.TabIndex = 50;
            // 
            // strainLabel
            // 
            this.strainLabel.AutoSize = true;
            this.strainLabel.Location = new System.Drawing.Point(3, 161);
            this.strainLabel.Name = "strainLabel";
            this.strainLabel.Size = new System.Drawing.Size(49, 17);
            this.strainLabel.TabIndex = 48;
            this.strainLabel.Text = "Strain:";
            // 
            // soortLabel
            // 
            this.soortLabel.AutoSize = true;
            this.soortLabel.Location = new System.Drawing.Point(3, 129);
            this.soortLabel.Name = "soortLabel";
            this.soortLabel.Size = new System.Drawing.Size(46, 17);
            this.soortLabel.TabIndex = 47;
            this.soortLabel.Text = "Soort:";
            // 
            // temperatuurLabel
            // 
            this.temperatuurLabel.AutoSize = true;
            this.temperatuurLabel.Location = new System.Drawing.Point(3, 100);
            this.temperatuurLabel.Name = "temperatuurLabel";
            this.temperatuurLabel.Size = new System.Drawing.Size(94, 17);
            this.temperatuurLabel.TabIndex = 46;
            this.temperatuurLabel.Text = "Temperatuur:";
            // 
            // kolonieLabel
            // 
            this.kolonieLabel.AutoSize = true;
            this.kolonieLabel.Location = new System.Drawing.Point(3, 74);
            this.kolonieLabel.Name = "kolonieLabel";
            this.kolonieLabel.Size = new System.Drawing.Size(66, 17);
            this.kolonieLabel.TabIndex = 44;
            this.kolonieLabel.Text = "Kolonies:";
            // 
            // bodemLabel
            // 
            this.bodemLabel.AutoSize = true;
            this.bodemLabel.Location = new System.Drawing.Point(3, 256);
            this.bodemLabel.Name = "bodemLabel";
            this.bodemLabel.Size = new System.Drawing.Size(114, 17);
            this.bodemLabel.TabIndex = 43;
            this.bodemLabel.Text = "Voedingsbodem:";
            // 
            // verdunningLabel
            // 
            this.verdunningLabel.AutoSize = true;
            this.verdunningLabel.Location = new System.Drawing.Point(3, 46);
            this.verdunningLabel.Name = "verdunningLabel";
            this.verdunningLabel.Size = new System.Drawing.Size(85, 17);
            this.verdunningLabel.TabIndex = 42;
            this.verdunningLabel.Text = "Verdunning:";
            // 
            // gebruikerLabel
            // 
            this.gebruikerLabel.AutoSize = true;
            this.gebruikerLabel.Location = new System.Drawing.Point(3, 15);
            this.gebruikerLabel.Name = "gebruikerLabel";
            this.gebruikerLabel.Size = new System.Drawing.Size(75, 17);
            this.gebruikerLabel.TabIndex = 41;
            this.gebruikerLabel.Text = "Gebruiker:";
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bronTextBox);
            this.Controls.Add(this.Bron);
            this.Controls.Add(this.nmKolonies);
            this.Controls.Add(this.nmVerdunning);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nmTemperatuur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nmDagen);
            this.Controls.Add(this.nmUren);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.behandelingTextBox);
            this.Controls.Add(this.behandelingLabel);
            this.Controls.Add(this.mediumTextBox);
            this.Controls.Add(this.mediumLabel);
            this.Controls.Add(this.tijdLabel);
            this.Controls.Add(this.strainTextBox);
            this.Controls.Add(this.bodemComboBox);
            this.Controls.Add(this.soortTextBox);
            this.Controls.Add(this.gebruikerTextBox);
            this.Controls.Add(this.strainLabel);
            this.Controls.Add(this.soortLabel);
            this.Controls.Add(this.temperatuurLabel);
            this.Controls.Add(this.kolonieLabel);
            this.Controls.Add(this.bodemLabel);
            this.Controls.Add(this.verdunningLabel);
            this.Controls.Add(this.gebruikerLabel);
            this.Name = "SettingsView";
            this.Size = new System.Drawing.Size(324, 456);
            ((System.ComponentModel.ISupportInitialize)(this.nmKolonies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerdunning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTemperatuur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUren)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Bron;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label behandelingLabel;
        private System.Windows.Forms.Label mediumLabel;
        private System.Windows.Forms.Label tijdLabel;
        private System.Windows.Forms.Label strainLabel;
        private System.Windows.Forms.Label soortLabel;
        private System.Windows.Forms.Label temperatuurLabel;
        private System.Windows.Forms.Label kolonieLabel;
        private System.Windows.Forms.Label bodemLabel;
        private System.Windows.Forms.Label verdunningLabel;
        private System.Windows.Forms.Label gebruikerLabel;
        public System.Windows.Forms.TextBox bronTextBox;
        public System.Windows.Forms.NumericUpDown nmKolonies;
        public System.Windows.Forms.NumericUpDown nmVerdunning;
        public System.Windows.Forms.NumericUpDown nmTemperatuur;
        public System.Windows.Forms.NumericUpDown nmDagen;
        public System.Windows.Forms.NumericUpDown nmUren;
        public System.Windows.Forms.RichTextBox behandelingTextBox;
        public System.Windows.Forms.RichTextBox mediumTextBox;
        public System.Windows.Forms.TextBox strainTextBox;
        public System.Windows.Forms.ComboBox bodemComboBox;
        public System.Windows.Forms.TextBox soortTextBox;
        public System.Windows.Forms.TextBox gebruikerTextBox;

    }
}
