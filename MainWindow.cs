//-----------------------------------------------------------------------
// SineAndSoul: MainWindow.cs
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

        // The tones avaiblable for playing
        private double[][] tonesAvailable;

        // The overtones amplitudes
        private double[] amplitudes;
        private double[] savedAmplitudes;

        // Overtone mixer controls
        private TrackBar[] mixerFaders;
        private CheckBox[] mixerMutes;

        // Tracking the state of the computer keyboard keys that can be used to play tones instead of MIDI keyboard
        private PianoKeys keysState;

        /// <summary>
        /// Gets or sets the value delimiter when importing CSV files. Default is ','.
        /// </summary>
        public char ImportDelimiter { get; set; }

        /// <summary>
        /// Gets or sets the decimal mark when importing CSV files. Default is '.'.
        /// </summary>
        public char ImportDecimalMark { get; set; }

        /// <summary>
        /// Number of frequencies per line to read from CSV file.
        /// </summary>
        public int ImportFrequenciesPerLine { get; set; }

        /// <summary>
        /// Gets or sets the boolean value indicating wether to auto save program state on exit.
        /// </summary>
        public bool SaveState { get; set; }

        /// <summary>
        /// Gets or sets the boolean value indicating wether to auto save settings on exit.
        /// </summary>
        public bool SaveSettings { get; set; }

        /// <summary>
        /// Desired audio latency in milliseconds.
        /// </summary>
        public int Latency { get; set; }

        /// <summary>
        /// Initialize a new instance of the MainWindow class. The user controls the application from within this window.
        /// </summary>
        public MainWindow()
        {
            // Draw designer controls
            InitializeComponent();

            // Default values
            this.ImportDelimiter = ';';
            this.ImportDecimalMark = ',';
            this.ImportFrequenciesPerLine = 12;
            this.Latency = 300;
            this.SaveState = true;
            this.SaveSettings = true;

            // Init audio
            this.sinePlayer = new SineSumSampleProvider(44100, 1);
            this.InitializeAudio();
        }

        private void InitializeAudio()
        {
            this.audioOut = null;
            this.audioOut = new WaveOut();
            this.audioOut.DesiredLatency = this.Latency;
            this.audioOut.Init(sinePlayer);
        }

        /// <summary>
        /// Draw the mixer controls.
        /// </summary>
        /// <param name="fadersCount">The number of overtones to mix.</param>
        private void InitializeMixer(int fadersCount)
        {
            if (this.mixerFaders != null)
            {
                // Remove old mixer controls
                this.MixerGroupBox.Controls.Clear();
                this.mixerFaders = null;
                this.mixerMutes = null;
            }

            // Add new controls
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

            // Add controls to parent
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

        /// <summary>
        /// Occurs when the user selects Import frequencies in the File menu.
        /// </summary>
        /// <param name="sender">Calling object.</param>
        /// <param name="e">Arguments passed.</param>
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kill audio
            audioOut.Stop();
            sinePlayer.Tones.Clear();

            // Let the user select file for import
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (open.ShowDialog() != DialogResult.OK)
            {
                audioOut.Play();
                return;
            }

            // Show import settings window
            
            // Do import
            CsvFrequencyReader read = new CsvFrequencyReader(open.FileName, ';', ',', ImportFrequenciesPerLine);
            read.Read();
            tonesAvailable = read.ToArray();

            // Calculate default initial amplitudes
            amplitudes = new double[ImportFrequenciesPerLine];
            double nextAmplitude = 0.8;
            for (int i = 0; i < ImportFrequenciesPerLine; i++)
            {
                amplitudes[i] = nextAmplitude;
                nextAmplitude /= 1.5;
            }

            savedAmplitudes = new double[ImportFrequenciesPerLine];
            sinePlayer.Amplitudes = amplitudes;
            InitializeMixer(ImportFrequenciesPerLine);

            audioOut.Play();
        }

        /// <summary>
        /// Occurs when the user selects Quit in the file menu.
        /// </summary>
        /// <param name="sender">Calling object.</param>
        /// <param name="e">Arguments passed.</param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        /// <summary>
        /// Occurs when the user press a key on the computer keyboard. Some keys may be used to play notes and
        /// this method starts playback of the note played.
        /// </summary>
        /// <param name="sender">Calling object.</param>
        /// <param name="e">Arguments passed.</param>
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Z:
                    if ((keysState & PianoKeys.Z) == 0)
                    {
                        sinePlayer.Tones.Add(tonesAvailable[27]);
                        keysState = keysState | PianoKeys.Z;
                    }
                    break;
                case Keys.S:
                    if ((keysState & PianoKeys.S) == 0)
                    {
                        sinePlayer.Tones.Add(tonesAvailable[28]);
                        keysState = keysState | PianoKeys.S;
                    }
                    break;
                case Keys.X:
                    if ((keysState & PianoKeys.X) == 0)
                    {
                        sinePlayer.Tones.Add(tonesAvailable[29]);
                        keysState = keysState | PianoKeys.X;
                    }
                    break;
                case Keys.D:
                    if ((keysState & PianoKeys.D) == 0)
                    {
                        sinePlayer.Tones.Add(tonesAvailable[30]);
                        keysState = keysState | PianoKeys.D;
                    }
                    break;
                case Keys.C:
                    if ((keysState & PianoKeys.C) == 0)
                    {
                        sinePlayer.Tones.Add(tonesAvailable[31]);
                        keysState = keysState | PianoKeys.C;
                    }
                    break;
                case Keys.V:
                    if ((keysState & PianoKeys.V) == 0)
                    {
                        sinePlayer.Tones.Add(tonesAvailable[32]);
                        keysState = keysState | PianoKeys.V;
                    }
                    break;
                case Keys.G:
                    if ((keysState & PianoKeys.G) == 0)
                    {
                        sinePlayer.Tones.Add(tonesAvailable[33]);
                        keysState = keysState | PianoKeys.G;
                    }
                    break;
                case Keys.B:
                    if ((keysState & PianoKeys.B) == 0)
                    {
                        sinePlayer.Tones.Add(tonesAvailable[34]);
                        keysState = keysState | PianoKeys.B;
                    }
                    break;
                case Keys.H:
                    if ((keysState & PianoKeys.H) == 0)
                    {
                        sinePlayer.Tones.Add(tonesAvailable[35]);
                        keysState = keysState | PianoKeys.H;
                    }
                    break;
                case Keys.N:
                    if ((keysState & PianoKeys.N) == 0)
                    {
                        sinePlayer.Tones.Add(tonesAvailable[36]);
                        keysState = keysState | PianoKeys.N;
                    }
                    break;
                case Keys.J:
                    if ((keysState & PianoKeys.J) == 0)
                    {
                        sinePlayer.Tones.Add(tonesAvailable[37]);
                        keysState = keysState | PianoKeys.J;
                    }
                    break;
                case Keys.M:
                    if ((keysState & PianoKeys.M) == 0)
                    {
                        sinePlayer.Tones.Add(tonesAvailable[38]);
                        keysState = keysState | PianoKeys.M;
                    }
                    break;
            }
        }

        /// <summary>
        /// Occurs when the user release a key on the computer keyboard. This method removes a note from the
        /// currently playing notes list.
        /// </summary>
        /// <param name="sender">Calling object.</param>
        /// <param name="e">Arguments passed.</param>
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Z:
                    sinePlayer.Tones.Remove(tonesAvailable[27]);
                    keysState = keysState & ~PianoKeys.Z;
                    break;
                case Keys.S:
                    sinePlayer.Tones.Remove(tonesAvailable[28]);
                    keysState = keysState & ~PianoKeys.S;
                    break;
                case Keys.X:
                    sinePlayer.Tones.Remove(tonesAvailable[29]);
                    keysState = keysState & ~PianoKeys.X;
                    break;
                case Keys.D:
                    sinePlayer.Tones.Remove(tonesAvailable[30]);
                    keysState = keysState & ~PianoKeys.D;
                    break;
                case Keys.C:
                    sinePlayer.Tones.Remove(tonesAvailable[31]);
                    keysState = keysState & ~PianoKeys.C;
                    break;
                case Keys.V:
                    sinePlayer.Tones.Remove(tonesAvailable[32]);
                    keysState = keysState & ~PianoKeys.V;
                    break;
                case Keys.G:
                    sinePlayer.Tones.Remove(tonesAvailable[33]);
                    keysState = keysState & ~PianoKeys.G;
                    break;
                case Keys.B:
                    sinePlayer.Tones.Remove(tonesAvailable[34]);
                    keysState = keysState & ~PianoKeys.B;
                    break;
                case Keys.H:
                    sinePlayer.Tones.Remove(tonesAvailable[35]);
                    keysState = keysState & ~PianoKeys.H;
                    break;
                case Keys.N:
                    sinePlayer.Tones.Remove(tonesAvailable[36]);
                    keysState = keysState & ~PianoKeys.N;
                    break;
                case Keys.J:
                    sinePlayer.Tones.Remove(tonesAvailable[37]);
                    keysState = keysState & ~PianoKeys.J;
                    break;
                case Keys.M:
                    sinePlayer.Tones.Remove(tonesAvailable[38]);
                    keysState = keysState & ~PianoKeys.M;
                    break;
            }
        }

        [Flags]
        enum PianoKeys
        {
            None = 0x0,
            Z = 0x1,
            S = 0x2,
            X = 0x4,
            D = 0x8,
            C = 0x10,
            V = 0x20,
            G = 0x40,
            B = 0x80,
            H = 0x100,
            N = 0x200,
            J = 0x400,
            M = 0x800
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kill audio
            this.audioOut.Stop();

            // Open settings dialog
            SettingsWindow settings = new SettingsWindow(this);
            settings.ShowDialog();

            // Re-initialize audio to reflect latency changes
            this.InitializeAudio();
            this.audioOut.Play();
        }
    }
}
