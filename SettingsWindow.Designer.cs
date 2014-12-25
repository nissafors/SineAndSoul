namespace SineAndSoul
{
    partial class SettingsWindow
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
            this.SettingsCancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.ImportCSVGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FrequenciesPerLineNumeric = new System.Windows.Forms.NumericUpDown();
            this.DecimalMarkTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DelimiterTextBox = new System.Windows.Forms.TextBox();
            this.AudioGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LatencyNumeric = new System.Windows.Forms.NumericUpDown();
            this.ResetButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BaseOctaveNumeric = new System.Windows.Forms.NumericUpDown();
            this.BaseNoteComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ImportCSVGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrequenciesPerLineNumeric)).BeginInit();
            this.AudioGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LatencyNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaseOctaveNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsCancelButton
            // 
            this.SettingsCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SettingsCancelButton.Location = new System.Drawing.Point(345, 236);
            this.SettingsCancelButton.Name = "SettingsCancelButton";
            this.SettingsCancelButton.Size = new System.Drawing.Size(75, 23);
            this.SettingsCancelButton.TabIndex = 7;
            this.SettingsCancelButton.Text = "Cancel";
            this.SettingsCancelButton.UseVisualStyleBackColor = true;
            this.SettingsCancelButton.Click += new System.EventHandler(this.SettingsCancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(264, 236);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "Save";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ImportCSVGroupBox
            // 
            this.ImportCSVGroupBox.Controls.Add(this.label3);
            this.ImportCSVGroupBox.Controls.Add(this.FrequenciesPerLineNumeric);
            this.ImportCSVGroupBox.Controls.Add(this.DecimalMarkTextBox);
            this.ImportCSVGroupBox.Controls.Add(this.label2);
            this.ImportCSVGroupBox.Controls.Add(this.label1);
            this.ImportCSVGroupBox.Controls.Add(this.DelimiterTextBox);
            this.ImportCSVGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ImportCSVGroupBox.Name = "ImportCSVGroupBox";
            this.ImportCSVGroupBox.Size = new System.Drawing.Size(200, 114);
            this.ImportCSVGroupBox.TabIndex = 0;
            this.ImportCSVGroupBox.TabStop = false;
            this.ImportCSVGroupBox.Text = "Import CSV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Frequencies per line";
            // 
            // FrequenciesPerLineNumeric
            // 
            this.FrequenciesPerLineNumeric.Location = new System.Drawing.Point(129, 78);
            this.FrequenciesPerLineNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FrequenciesPerLineNumeric.Name = "FrequenciesPerLineNumeric";
            this.FrequenciesPerLineNumeric.Size = new System.Drawing.Size(56, 20);
            this.FrequenciesPerLineNumeric.TabIndex = 3;
            this.FrequenciesPerLineNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // DecimalMarkTextBox
            // 
            this.DecimalMarkTextBox.Location = new System.Drawing.Point(129, 50);
            this.DecimalMarkTextBox.MaxLength = 1;
            this.DecimalMarkTextBox.Name = "DecimalMarkTextBox";
            this.DecimalMarkTextBox.Size = new System.Drawing.Size(31, 20);
            this.DecimalMarkTextBox.TabIndex = 2;
            this.DecimalMarkTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Decimal mark";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Field delimiter";
            // 
            // DelimiterTextBox
            // 
            this.DelimiterTextBox.Location = new System.Drawing.Point(129, 24);
            this.DelimiterTextBox.MaxLength = 1;
            this.DelimiterTextBox.Name = "DelimiterTextBox";
            this.DelimiterTextBox.Size = new System.Drawing.Size(31, 20);
            this.DelimiterTextBox.TabIndex = 1;
            this.DelimiterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AudioGroupBox
            // 
            this.AudioGroupBox.Controls.Add(this.label4);
            this.AudioGroupBox.Controls.Add(this.LatencyNumeric);
            this.AudioGroupBox.Location = new System.Drawing.Point(220, 12);
            this.AudioGroupBox.Name = "AudioGroupBox";
            this.AudioGroupBox.Size = new System.Drawing.Size(200, 66);
            this.AudioGroupBox.TabIndex = 0;
            this.AudioGroupBox.TabStop = false;
            this.AudioGroupBox.Text = "Audio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Latency (ms)";
            // 
            // LatencyNumeric
            // 
            this.LatencyNumeric.Location = new System.Drawing.Point(94, 25);
            this.LatencyNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.LatencyNumeric.Name = "LatencyNumeric";
            this.LatencyNumeric.Size = new System.Drawing.Size(91, 20);
            this.LatencyNumeric.TabIndex = 4;
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResetButton.Location = new System.Drawing.Point(12, 235);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(110, 23);
            this.ResetButton.TabIndex = 5;
            this.ResetButton.Text = "Restore default";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.BaseOctaveNumeric);
            this.groupBox1.Controls.Add(this.BaseNoteComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base note";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Octave";
            // 
            // BaseOctaveNumeric
            // 
            this.BaseOctaveNumeric.Location = new System.Drawing.Point(72, 50);
            this.BaseOctaveNumeric.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.BaseOctaveNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.BaseOctaveNumeric.Name = "BaseOctaveNumeric";
            this.BaseOctaveNumeric.Size = new System.Drawing.Size(58, 20);
            this.BaseOctaveNumeric.TabIndex = 2;
            // 
            // BaseNoteComboBox
            // 
            this.BaseNoteComboBox.FormattingEnabled = true;
            this.BaseNoteComboBox.Items.AddRange(new object[] {
            "C",
            "C#",
            "D",
            "Eb",
            "E",
            "F",
            "F#",
            "G",
            "G#",
            "A",
            "Bb",
            "B"});
            this.BaseNoteComboBox.Location = new System.Drawing.Point(72, 22);
            this.BaseNoteComboBox.Name = "BaseNoteComboBox";
            this.BaseNoteComboBox.Size = new System.Drawing.Size(58, 21);
            this.BaseNoteComboBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Note";
            // 
            // SettingsWindow
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.SettingsCancelButton;
            this.ClientSize = new System.Drawing.Size(432, 271);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.AudioGroupBox);
            this.Controls.Add(this.ImportCSVGroupBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.SettingsCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsWindow";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsWindow_FormClosed);
            this.ImportCSVGroupBox.ResumeLayout(false);
            this.ImportCSVGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrequenciesPerLineNumeric)).EndInit();
            this.AudioGroupBox.ResumeLayout(false);
            this.AudioGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LatencyNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaseOctaveNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SettingsCancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.GroupBox ImportCSVGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DelimiterTextBox;
        private System.Windows.Forms.TextBox DecimalMarkTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown FrequenciesPerLineNumeric;
        private System.Windows.Forms.GroupBox AudioGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown LatencyNumeric;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox BaseNoteComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown BaseOctaveNumeric;
    }
}