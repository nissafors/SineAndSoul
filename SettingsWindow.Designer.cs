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
            this.AutoSaveGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveSettingsCheckBox = new System.Windows.Forms.CheckBox();
            this.SaveStateCheckBox = new System.Windows.Forms.CheckBox();
            this.AudioGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LatencyNumeric = new System.Windows.Forms.NumericUpDown();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ImportCSVGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrequenciesPerLineNumeric)).BeginInit();
            this.AutoSaveGroupBox.SuspendLayout();
            this.AudioGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LatencyNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsCancelButton
            // 
            this.SettingsCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SettingsCancelButton.Location = new System.Drawing.Point(345, 205);
            this.SettingsCancelButton.Name = "SettingsCancelButton";
            this.SettingsCancelButton.Size = new System.Drawing.Size(75, 23);
            this.SettingsCancelButton.TabIndex = 9;
            this.SettingsCancelButton.Text = "Cancel";
            this.SettingsCancelButton.UseVisualStyleBackColor = true;
            this.SettingsCancelButton.Click += new System.EventHandler(this.SettingsCancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(264, 205);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 8;
            this.OKButton.Text = "OK";
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
            // AutoSaveGroupBox
            // 
            this.AutoSaveGroupBox.Controls.Add(this.SaveSettingsCheckBox);
            this.AutoSaveGroupBox.Controls.Add(this.SaveStateCheckBox);
            this.AutoSaveGroupBox.Location = new System.Drawing.Point(218, 12);
            this.AutoSaveGroupBox.Name = "AutoSaveGroupBox";
            this.AutoSaveGroupBox.Size = new System.Drawing.Size(200, 90);
            this.AutoSaveGroupBox.TabIndex = 0;
            this.AutoSaveGroupBox.TabStop = false;
            this.AutoSaveGroupBox.Text = "Auto save";
            // 
            // SaveSettingsCheckBox
            // 
            this.SaveSettingsCheckBox.AutoSize = true;
            this.SaveSettingsCheckBox.Location = new System.Drawing.Point(21, 52);
            this.SaveSettingsCheckBox.Name = "SaveSettingsCheckBox";
            this.SaveSettingsCheckBox.Size = new System.Drawing.Size(124, 17);
            this.SaveSettingsCheckBox.TabIndex = 6;
            this.SaveSettingsCheckBox.Text = "Save settings on exit";
            this.SaveSettingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // SaveStateCheckBox
            // 
            this.SaveStateCheckBox.AutoSize = true;
            this.SaveStateCheckBox.Location = new System.Drawing.Point(21, 26);
            this.SaveStateCheckBox.Name = "SaveStateCheckBox";
            this.SaveStateCheckBox.Size = new System.Drawing.Size(111, 17);
            this.SaveStateCheckBox.TabIndex = 5;
            this.SaveStateCheckBox.Text = "Save state on exit";
            this.SaveStateCheckBox.UseVisualStyleBackColor = true;
            // 
            // AudioGroupBox
            // 
            this.AudioGroupBox.Controls.Add(this.label4);
            this.AudioGroupBox.Controls.Add(this.LatencyNumeric);
            this.AudioGroupBox.Location = new System.Drawing.Point(12, 133);
            this.AudioGroupBox.Name = "AudioGroupBox";
            this.AudioGroupBox.Size = new System.Drawing.Size(200, 62);
            this.AudioGroupBox.TabIndex = 8;
            this.AudioGroupBox.TabStop = false;
            this.AudioGroupBox.Text = "Audio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Latency (ms)";
            // 
            // LatencyNumeric
            // 
            this.LatencyNumeric.Location = new System.Drawing.Point(94, 20);
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
            this.ResetButton.Location = new System.Drawing.Point(12, 204);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(110, 23);
            this.ResetButton.TabIndex = 7;
            this.ResetButton.Text = "Restore default";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SettingsWindow
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.SettingsCancelButton;
            this.ClientSize = new System.Drawing.Size(432, 240);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.AudioGroupBox);
            this.Controls.Add(this.AutoSaveGroupBox);
            this.Controls.Add(this.ImportCSVGroupBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.SettingsCancelButton);
            this.Name = "SettingsWindow";
            this.Text = "Settings";
            this.ImportCSVGroupBox.ResumeLayout(false);
            this.ImportCSVGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrequenciesPerLineNumeric)).EndInit();
            this.AutoSaveGroupBox.ResumeLayout(false);
            this.AutoSaveGroupBox.PerformLayout();
            this.AudioGroupBox.ResumeLayout(false);
            this.AudioGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LatencyNumeric)).EndInit();
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
        private System.Windows.Forms.GroupBox AutoSaveGroupBox;
        private System.Windows.Forms.CheckBox SaveSettingsCheckBox;
        private System.Windows.Forms.CheckBox SaveStateCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown FrequenciesPerLineNumeric;
        private System.Windows.Forms.GroupBox AudioGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown LatencyNumeric;
        private System.Windows.Forms.Button ResetButton;
    }
}