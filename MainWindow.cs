//-----------------------------------------------------------------------
// SineAndSoul: SineSumSampleProvider.cs
//
// Copyright (c) 2014 Andreas Andersson
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
//-----------------------------------------------------------------------

namespace SineAndSoul
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using NAudio.Wave;

    /// <summary>
    /// The main GUI window form.
    /// </summary>
    public partial class MainWindow : Form
    {
        // NAudio driver
        private WaveOut audioOut;

        // This is at the heart of the program, providing samples for NAudio's buffer by adding sine waves.
        private SineSumSampleProvider sinePlayer;

        // The tones currently playing
        private List<double[]> tonesPlaying;

        // The tones avaiblable for playing
        private double[][] tonesAvailable;

        // The overtones amplitudes
        private double[] amplitudes;
        private double[] savedAmplitudes;

        private TrackBar[] mixerFaders;
        private CheckBox[] mixerMutes;
        
        /// <summary>
        /// Initialize a new instance of the MainWindow class. The user controls the application from within this window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            amplitudes = new double[]{ 0.3, 0.1, 0.06, 0.05 };
            savedAmplitudes = new double[amplitudes.Length];
            InitializeMixer(amplitudes.Length);

            tonesAvailable = new double[3][];
            tonesAvailable[0] = new double[] { 293.66, 293.66 * 2, 293.66 * 3, 293.66 * 4 };
            tonesAvailable[2] = new double[] { 369.99, 369.99 * 2, 369.99 * 3, 369.99 * 4 };

            tonesPlaying = new List<double[]>();
            tonesPlaying.Add(tonesAvailable[0]);
            tonesPlaying.Add(tonesAvailable[2]);

            sinePlayer = new SineSumSampleProvider(44100, 1);
            sinePlayer.Amplitudes = amplitudes;
            sinePlayer.Tones = tonesPlaying;

            audioOut = new WaveOut();
            audioOut.Init(sinePlayer);

            audioOut.Play();
        }

        private void InitializeMixer(int fadersCount)
        {
            this.mixerFaders = new TrackBar[fadersCount];
            this.mixerMutes = new CheckBox[fadersCount];
            for (int i = 0; i < fadersCount; i++)
            {
                // Faders
                this.mixerFaders[i] = new TrackBar();
                this.mixerFaders[i].Location = new System.Drawing.Point(30 + 50 * i, 30);
                this.mixerFaders[i].Name = Convert.ToString(i);
                this.mixerFaders[i].Size = new System.Drawing.Size(50, 300);
                this.mixerFaders[i].TabIndex = i * 2;
                this.mixerFaders[i].Orientation = Orientation.Vertical;
                this.mixerFaders[i].Maximum = 100;
                this.mixerFaders[i].Value = (int)(amplitudes[i] * 100);
                this.mixerFaders[i].TickFrequency = 10;
                this.mixerFaders[i].ValueChanged += new EventHandler(this.MixerFader_ValueChanged);

                // Mute buttons
                this.mixerMutes[i] = new CheckBox();
                this.mixerMutes[i].Appearance = Appearance.Button;
                this.mixerMutes[i].Location = new System.Drawing.Point(15 + 50 * i, 340);
                this.mixerMutes[i].Name = Convert.ToString(i);
                this.mixerMutes[i].Size = new System.Drawing.Size(50, 30);
                this.mixerMutes[i].Text = "Mute";
                this.mixerMutes[i].ForeColor = System.Drawing.Color.Black;
                this.mixerMutes[i].TabIndex = 1 + i * 2;
                this.mixerMutes[i].Click += new EventHandler(this.MixerMute_Click);
            }
            this.MixerGroupBox.Controls.AddRange(this.mixerFaders);
            this.MixerGroupBox.Controls.AddRange(this.mixerMutes);
        }

        /// <summary>
        /// Occurs when a mute button on the mixer is pressed.
        /// </summary>
        /// <param name="sender">The mute button that was clicked.</param>
        /// <param name="e">Arguments passed.</param>
        private void MixerMute_Click(object sender, EventArgs e)
        {
            CheckBox mute = (CheckBox)sender;
            int muteIndex = Convert.ToInt32(mute.Name);

            if (mute.ForeColor == System.Drawing.Color.Black)
            {
                mute.ForeColor = System.Drawing.Color.Red;
                savedAmplitudes[muteIndex] = amplitudes[muteIndex];
                amplitudes[muteIndex] = 0.0;
            }
            else
            {
                mute.ForeColor = System.Drawing.Color.Black;
                amplitudes[muteIndex] = savedAmplitudes[muteIndex];
            }
        }

        /// <summary>
        /// Occurs when a mixer fader is moved
        /// </summary>
        /// <param name="sender">The fader that moved.</param>
        /// <param name="e">Arguments passed.</param>
        private void MixerFader_ValueChanged(object sender, EventArgs e)
        {
            // Which fader moved?
            TrackBar fader = (TrackBar)sender;
            int faderIndex = Convert.ToInt32(fader.Name);

            // Update amplitudes
            savedAmplitudes[faderIndex] = (double)fader.Value / 100.0;
            if (!mixerMutes[faderIndex].Checked) amplitudes[faderIndex] = (double)fader.Value / 100.0;
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            audioOut.Stop();
            tonesPlaying.Clear();

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (open.ShowDialog() != DialogResult.OK)
            {
                audioOut.Play();
                return;
            }

            // Import file
            CsvFrequencyReader read = new CsvFrequencyReader(open.FileName, ';', ',', 4);
            read.Read();
            tonesAvailable = read.ToArray();

            audioOut.Play();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
