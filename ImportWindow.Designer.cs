namespace SineAndSoul
{
    partial class ImportWindow
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
            this.ParsingGroupBox = new System.Windows.Forms.GroupBox();
            this.BaseNoteGroupBox = new System.Windows.Forms.GroupBox();
            this.ImportCancelButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FrequenciesPerLineNumeric = new System.Windows.Forms.NumericUpDown();
            this.DelimiterTextBox = new System.Windows.Forms.TextBox();
            this.DecimalMarkTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NoteComboBox = new System.Windows.Forms.ComboBox();
            this.OctaveNumeric = new System.Windows.Forms.NumericUpDown();
            this.ParsingGroupBox.SuspendLayout();
            this.BaseNoteGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrequenciesPerLineNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OctaveNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // ParsingGroupBox
            // 
            this.ParsingGroupBox.Controls.Add(this.DecimalMarkTextBox);
            this.ParsingGroupBox.Controls.Add(this.DelimiterTextBox);
            this.ParsingGroupBox.Controls.Add(this.FrequenciesPerLineNumeric);
            this.ParsingGroupBox.Controls.Add(this.label3);
            this.ParsingGroupBox.Controls.Add(this.label2);
            this.ParsingGroupBox.Controls.Add(this.label1);
            this.ParsingGroupBox.Location = new System.Drawing.Point(13, 13);
            this.ParsingGroupBox.Name = "ParsingGroupBox";
            this.ParsingGroupBox.Size = new System.Drawing.Size(200, 118);
            this.ParsingGroupBox.TabIndex = 0;
            this.ParsingGroupBox.TabStop = false;
            this.ParsingGroupBox.Text = "Parsing";
            // 
            // BaseNoteGroupBox
            // 
            this.BaseNoteGroupBox.Controls.Add(this.OctaveNumeric);
            this.BaseNoteGroupBox.Controls.Add(this.NoteComboBox);
            this.BaseNoteGroupBox.Controls.Add(this.label5);
            this.BaseNoteGroupBox.Controls.Add(this.label4);
            this.BaseNoteGroupBox.Location = new System.Drawing.Point(220, 13);
            this.BaseNoteGroupBox.Name = "BaseNoteGroupBox";
            this.BaseNoteGroupBox.Size = new System.Drawing.Size(200, 90);
            this.BaseNoteGroupBox.TabIndex = 0;
            this.BaseNoteGroupBox.TabStop = false;
            this.BaseNoteGroupBox.Text = "Base note";
            // 
            // ImportCancelButton
            // 
            this.ImportCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ImportCancelButton.Location = new System.Drawing.Point(346, 116);
            this.ImportCancelButton.Name = "ImportCancelButton";
            this.ImportCancelButton.Size = new System.Drawing.Size(75, 23);
            this.ImportCancelButton.TabIndex = 7;
            this.ImportCancelButton.Text = "Cancel";
            this.ImportCancelButton.UseVisualStyleBackColor = true;
            this.ImportCancelButton.Click += new System.EventHandler(this.ImportCancelButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportButton.Location = new System.Drawing.Point(265, 116);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(75, 23);
            this.ImportButton.TabIndex = 6;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Field delimiter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Decimal mark";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Frequencies per line";
            // 
            // FrequenciesPerLineNumeric
            // 
            this.FrequenciesPerLineNumeric.Location = new System.Drawing.Point(128, 76);
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
            // DelimiterTextBox
            // 
            this.DelimiterTextBox.Location = new System.Drawing.Point(128, 23);
            this.DelimiterTextBox.MaxLength = 1;
            this.DelimiterTextBox.Name = "DelimiterTextBox";
            this.DelimiterTextBox.Size = new System.Drawing.Size(31, 20);
            this.DelimiterTextBox.TabIndex = 1;
            // 
            // DecimalMarkTextBox
            // 
            this.DecimalMarkTextBox.Location = new System.Drawing.Point(128, 50);
            this.DecimalMarkTextBox.MaxLength = 1;
            this.DecimalMarkTextBox.Name = "DecimalMarkTextBox";
            this.DecimalMarkTextBox.Size = new System.Drawing.Size(31, 20);
            this.DecimalMarkTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Note";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Octave";
            // 
            // NoteComboBox
            // 
            this.NoteComboBox.FormattingEnabled = true;
            this.NoteComboBox.Items.AddRange(new object[] {
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
            this.NoteComboBox.Location = new System.Drawing.Point(70, 23);
            this.NoteComboBox.Name = "NoteComboBox";
            this.NoteComboBox.Size = new System.Drawing.Size(58, 21);
            this.NoteComboBox.TabIndex = 4;
            // 
            // OctaveNumeric
            // 
            this.OctaveNumeric.Location = new System.Drawing.Point(70, 51);
            this.OctaveNumeric.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.OctaveNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.OctaveNumeric.Name = "OctaveNumeric";
            this.OctaveNumeric.Size = new System.Drawing.Size(58, 20);
            this.OctaveNumeric.TabIndex = 5;
            // 
            // ImportWindow
            // 
            this.AcceptButton = this.ImportButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ImportCancelButton;
            this.ClientSize = new System.Drawing.Size(433, 151);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.ImportCancelButton);
            this.Controls.Add(this.BaseNoteGroupBox);
            this.Controls.Add(this.ParsingGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ImportWindow";
            this.Text = "Import CSV options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportWindow_FormClosing);
            this.ParsingGroupBox.ResumeLayout(false);
            this.ParsingGroupBox.PerformLayout();
            this.BaseNoteGroupBox.ResumeLayout(false);
            this.BaseNoteGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrequenciesPerLineNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OctaveNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ParsingGroupBox;
        private System.Windows.Forms.GroupBox BaseNoteGroupBox;
        private System.Windows.Forms.Button ImportCancelButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown FrequenciesPerLineNumeric;
        private System.Windows.Forms.TextBox DelimiterTextBox;
        private System.Windows.Forms.TextBox DecimalMarkTextBox;
        private System.Windows.Forms.NumericUpDown OctaveNumeric;
        private System.Windows.Forms.ComboBox NoteComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}