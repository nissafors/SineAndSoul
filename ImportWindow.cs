//-----------------------------------------------------------------------
// SineAndSoul: ImportWindow.cs
//
// Copyright (c) 2014 Andreas Andersson
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
//-----------------------------------------------------------------------

namespace SineAndSoul
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Window for selecting options when importing CSV file. Displayed after file is chosen.
    /// </summary>
    public partial class ImportWindow : Form
    {
        /// <summary>
        /// Field delimter for CSV import.
        /// </summary>
        public char Delimiter { get; private set; }

        /// <summary>
        /// Decimal mark for CSV import.
        /// </summary>
        public char DecimalMark { get; private set; }

        /// <summary>
        /// Frequencies per line to read from csv file.
        /// </summary>
        public int FrequenciesPerLine { get; private set; }

        /// <summary>
        /// Set to true if the form was closed by the import button.
        /// </summary>
        public bool Import { get; set; }

        /// <summary>
        /// Lowest note's MIDI number.
        /// </summary>
        public int BaseMidiNumber { get; private set; }

        /// <summary>
        /// Initialize a new instance of the ImportWindow class.
        /// </summary>
        public ImportWindow()
        {
            InitializeComponent();

            this.Import = false;

            // Use program settings as default values
            this.DelimiterTextBox.Text = Properties.Settings.Default.ImportDelimiter.ToString();
            this.DecimalMarkTextBox.Text = Properties.Settings.Default.ImportDecimalMark.ToString();
            this.FrequenciesPerLineNumeric.Value = Properties.Settings.Default.FrequenciesPerLine;
            this.NoteComboBox.SelectedItem = Properties.Settings.Default.BaseNote;
            this.OctaveNumeric.Value = Properties.Settings.Default.BaseOctave;
        }

        /// <summary>
        /// Occurs when the user clicks the cancel button.
        /// </summary>
        /// <param name="sender">Calling object.</param>
        /// <param name="e">Arguments passed.</param>
        private void ImportCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Occurs when the user clicks the Import button. Set properties and close window.
        /// </summary>
        /// <param name="sender">Calling object.</param>
        /// <param name="e">Arguments passed.</param>
        private void ImportButton_Click(object sender, EventArgs e)
        {
            // Set properties and close form
            this.Delimiter = Convert.ToChar(this.DelimiterTextBox.Text);
            this.DecimalMark = Convert.ToChar(this.DecimalMarkTextBox.Text);
            this.FrequenciesPerLine = (int)FrequenciesPerLineNumeric.Value;
            this.BaseMidiNumber = this.NoteComboBox.SelectedIndex + (((int)this.OctaveNumeric.Value + 1) * 12);
            this.Import = true;

            this.Close();
        }

        /// <summary>
        /// Occurs when the form is closing.
        /// </summary>
        /// <param name="sender">Calling object.</param>
        /// <param name="e">Arguments passed.</param>
        private void ImportWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
