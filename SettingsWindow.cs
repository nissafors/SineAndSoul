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
        //private MainWindow caller;

        /// <summary>
        /// Initializes a new instance of the SettingsWindow class.
        /// </summary>
        /// <param name="caller">A reference to the MainWindow object opening this window.</param>
        public SettingsWindow()
        {
            InitializeComponent();

            this.UpdateControls();
        }

        private void UpdateControls()
        {
            this.DelimiterTextBox.Text = Properties.Settings.Default.ImportDelimiter.ToString();
            this.DecimalMarkTextBox.Text = Properties.Settings.Default.ImportDecimalMark.ToString();
            this.FrequenciesPerLineNumeric.Value = Properties.Settings.Default.FrequenciesPerLine;
            this.LatencyNumeric.Value = Properties.Settings.Default.Latency;
            this.SaveSettingsCheckBox.Checked = Properties.Settings.Default.SaveSettingsOnExit;
            this.SaveStateCheckBox.Checked = Properties.Settings.Default.SaveStateOnExit;
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

            // Save settings
            Properties.Settings.Default.ImportDelimiter = Convert.ToChar(this.DelimiterTextBox.Text);
            Properties.Settings.Default.ImportDecimalMark = Convert.ToChar(this.DecimalMarkTextBox.Text);
            Properties.Settings.Default.FrequenciesPerLine = (int)this.FrequenciesPerLineNumeric.Value;
            Properties.Settings.Default.Latency = (int)this.LatencyNumeric.Value;
            Properties.Settings.Default.SaveSettingsOnExit = this.SaveSettingsCheckBox.Checked;
            Properties.Settings.Default.SaveStateOnExit = this.SaveStateCheckBox.Checked;

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

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            this.UpdateControls();
        }
    }
}
