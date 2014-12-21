//-----------------------------------------------------------------------
// SineAndSoul: SettingsWindow.cs
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
    /// The settings window.
    /// </summary>
    public partial class SettingsWindow : Form
    {
        // A reference to the MainWindow object opening this window
        private MainWindow caller;

        /// <summary>
        /// Initializes a new instance of the SettingsWindow class.
        /// </summary>
        /// <param name="caller">A reference to the MainWindow object opening this window.</param>
        public SettingsWindow(MainWindow caller)
        {
            InitializeComponent();

            this.caller = caller;

            // Get current settings from MainWindow
            this.DelimiterTextBox.Text = caller.ImportDelimiter.ToString();
            this.DecimalMarkTextBox.Text = caller.ImportDecimalMark.ToString();
            this.FrequenciesPerLineNumeric.Value = caller.ImportFrequenciesPerLine;
            this.LatencyNumeric.Value = caller.Latency;
            this.SaveStateCheckBox.Checked = caller.SaveState;
            this.SaveSettingsCheckBox.Checked = caller.SaveSettings;
        }

        /// <summary>
        /// Occurs when the user clicks the OK button. Write settings back to calling MainWindow and close this window.
        /// </summary>
        /// <param name="sender">Calling control.</param>
        /// <param name="e">Arguments passed.</param>
        private void OKButton_Click(object sender, System.EventArgs e)
        {
            if (DelimiterTextBox.Text == DecimalMarkTextBox.Text)
            {
                MessageBox.Show("Delimiter and decimal mark must be different characters!",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Set properties in MainWindow
            caller.ImportDelimiter = Convert.ToChar(this.DelimiterTextBox.Text);
            caller.ImportDecimalMark = Convert.ToChar(this.DecimalMarkTextBox.Text);
            caller.ImportFrequenciesPerLine = (int)this.FrequenciesPerLineNumeric.Value;
            caller.Latency = (int)this.LatencyNumeric.Value;
            caller.SaveSettings = this.SaveSettingsCheckBox.Checked;
            caller.SaveState = this.SaveStateCheckBox.Checked;

            this.Dispose();
            this.Close();
        }

        /// <summary>
        /// Occurs when the user clicks the Cancel button. Close window without writing back changes.
        /// </summary>
        /// <param name="sender">Calling control.</param>
        /// <param name="e">Arguments passed.</param>
        private void SettingsCancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
