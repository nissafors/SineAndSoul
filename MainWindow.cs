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
    using NAudio.Midi;

    /// <summary>
    /// The main GUI window form.
    /// </summary>
    public partial class MainWindow : Form
    {
        // NAudio driver
        private WaveOut audioOut;

        // MIDI monitor
        private MidiMonitor midiInMonitor;

        // This is at the heart of the program, providing samples for NAudio's buffer by adding sine waves.
        private SineSumSampleProvider sinePlayer;

        // The tones avaiblable for playing
        private double[][] tonesAvailable;

        // The midi number of the lowest tone available.
        private int baseMidiNumber;

        // The overtones amplitudes
        private double[] amplitudes;
        private double[] savedAmplitudes;

        // Overtone mixer controls
        private TrackBar[] mixerFaders;
        private CheckBox[] mixerMutes;

        private bool[] midiNumbersPlaying = new bool[128];

        /// <summary>
        /// Initialize a new instance of the MainWindow class. The user controls the application from within this window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // If a device is found, begin listening for incoming MIDI messages.
            midiInMonitor = new MidiMonitor();
            if (midiInMonitor.SelectedDevice != null)
            {
                Properties.Settings.Default.MidiDeviceNumber = (int)midiInMonitor.SelectedDevice;
                this.midiInMonitor.MidiInDevice.MessageReceived += new EventHandler<MidiInMessageEventArgs>(MidiInDevice_messageHandler);
                this.midiInMonitor.StartMidiMonitoring();
            }
            else
            {
                Properties.Settings.Default.MidiDeviceNumber = -1;
            }

            // Init audio
            this.sinePlayer = new SineSumSampleProvider(44100, 1);
            this.InitializeAudio();
        }

        /// <summary>
        /// Indicates wether a tone should start or stop playing.
        /// </summary>
        private enum Toggle { Play, Stop }

        /// <summary>
        /// Reset and initialize the audio driver.
        /// </summary>
        private void InitializeAudio()
        {
            this.audioOut = null;
            this.audioOut = new WaveOut();
            this.audioOut.DesiredLatency = Properties.Settings.Default.Latency;
            this.audioOut.Init(sinePlayer);
        }

        /// <summary>
        /// Draw the mixer controls.
        /// </summary>
        /// <param name="fadersCount">The number of overtones to mix.</param>
        private void InitializeMixer(int fadersCount)
        {
            const int FADER_WIDTH = 50;
            const int FADER_HEIGHT = 300;
            const int FADER_MARGIN = 30;
            const int MUTE_WIDTH = FADER_WIDTH;
            const int MUTE_HEIGHT = 30;
            const int MUTE_MARGIN = 15;
            const int MUTE_DISTANCE = 340;
            const int GROUPBOX_MARGIN = 10;

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
                this.mixerFaders[i].Location = new System.Drawing.Point(FADER_MARGIN + FADER_WIDTH * i, FADER_MARGIN);
                this.mixerFaders[i].Name = Convert.ToString(i);
                this.mixerFaders[i].Size = new System.Drawing.Size(FADER_WIDTH, FADER_HEIGHT);
                this.mixerFaders[i].TabIndex = i * 2;
                this.mixerFaders[i].Orientation = Orientation.Vertical;
                this.mixerFaders[i].Maximum = 100;
                this.mixerFaders[i].Value = (int)(amplitudes[i] * 100);
                this.mixerFaders[i].TickFrequency = 10;
                this.mixerFaders[i].ValueChanged += new EventHandler(this.MixerFader_ValueChanged);

                // Mute buttons
                this.mixerMutes[i] = new CheckBox();
                this.mixerMutes[i].Appearance = Appearance.Button;
                this.mixerMutes[i].Location = new System.Drawing.Point(MUTE_MARGIN + MUTE_WIDTH * i, MUTE_DISTANCE);
                this.mixerMutes[i].Name = Convert.ToString(i);
                this.mixerMutes[i].Size = new System.Drawing.Size(MUTE_WIDTH, MUTE_HEIGHT);
                this.mixerMutes[i].Text = "Mute";
                this.mixerMutes[i].ForeColor = System.Drawing.Color.Black;
                this.mixerMutes[i].TabIndex = 1 + i * 2;
                this.mixerMutes[i].Click += new EventHandler(this.MixerMute_Click);
            }

            // Add controls to parent
            this.MixerGroupBox.Controls.AddRange(this.mixerFaders);
            this.MixerGroupBox.Controls.AddRange(this.mixerMutes);

            // Change window size to fit mixer
            this.MixerGroupBox.Width = FADER_MARGIN + FADER_WIDTH * fadersCount;
            this.Width = FADER_MARGIN * 2 + FADER_WIDTH * fadersCount + GROUPBOX_MARGIN;
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
        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
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

            // Let the user adjust import settings
            ImportWindow options = new ImportWindow();
            options.ShowDialog();
            if (!options.Import)
            {
                // The user clicked cancel.
                audioOut.Play();
                return;
            }

            // Do import
            CsvFrequencyReader reader = new CsvFrequencyReader(
                open.FileName,
                options.Delimiter,
                options.DecimalMark,
                options.FrequenciesPerLine);

            if (!reader.Read())
            {
                // Read failed
                MessageBox.Show(
                    "Import failed! Make sure settings are compatible with csv format.",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                audioOut.Play();
                return;
            }

            // Load new tones
            this.tonesAvailable = reader.ToArray();
            this.baseMidiNumber = options.BaseMidiNumber;

            // Calculate default initial amplitudes
            amplitudes = new double[options.FrequenciesPerLine];
            double nextAmplitude = 0.8;
            for (int i = 0; i < options.FrequenciesPerLine; i++)
            {
                amplitudes[i] = nextAmplitude;
                nextAmplitude /= 1.5;
            }

            savedAmplitudes = new double[options.FrequenciesPerLine];
            sinePlayer.Amplitudes = amplitudes;

            // Fix user interface
            InitializeMixer(options.FrequenciesPerLine);
            int highestNote = this.baseMidiNumber + this.tonesAvailable.Length - 1;
            this.ComputerKeyboardOctaveNumeric.Value = ((highestNote - ((highestNote - this.baseMidiNumber) / 2)) / 12) - 1;

            audioOut.Play();
        }

        /// <summary>
        /// Occurs when the user selects Quit in the file menu.
        /// </summary>
        /// <param name="sender">Calling object.</param>
        /// <param name="e">Arguments passed.</param>
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Used by the MIDI event handler to make thread safe calls to ToggleTone.
        /// </summary>
        /// <param name="midiNoteNumber">See the ToggleTone() method.</param>
        /// <param name="state">See the ToggleTone() method.</param>
        private delegate void ToggleToneDelegate(int midiNoteNumber, Toggle state);

        /// <summary>
        /// MIDI in event handler.
        /// </summary>
        /// <param name="sender">Calling object.</param>
        /// <param name="e">Arguments passed.</param>
        private void MidiInDevice_messageHandler(object sender, MidiInMessageEventArgs e)
        {
            // Do nothing if we don't have any tones to play
            if (tonesAvailable == null || tonesAvailable.Length == 0) return;

            // Call ToggleTone on the UI thread using Invoke
            ToggleToneDelegate ttd = new ToggleToneDelegate(ToggleTone);
            Object[] args = new Object[2];

            if (MidiEvent.IsNoteOn(e.MidiEvent))
            {
                args[0] = ((NoteOnEvent)e.MidiEvent).NoteNumber;
                args[1] = Toggle.Play;
                Invoke(ttd, args);
            }
            else if (MidiEvent.IsNoteOff(e.MidiEvent))
            {
                args[0] = ((NoteEvent)e.MidiEvent).NoteNumber;
                args[1] = Toggle.Stop;
                Invoke(ttd, args);
            }
        }

        /// <summary>
        /// Add or remove a tone from the list of playing tones using it's MIDI note number.
        /// </summary>
        /// <param name="midiNoteNumber">The MIDI note number corresponding to the tone.</param>
        /// <param name="state">If Toggle.Play, sound the tone. If Toggle.Stop, make it silent.</param>
        private void ToggleTone(int midiNoteNumber, Toggle state)
        {
            int lowestNoteNumber = this.baseMidiNumber;
            int highestNoteNumber = lowestNoteNumber + tonesAvailable.Length - 1;

            if (midiNoteNumber < lowestNoteNumber || midiNoteNumber > highestNoteNumber)
            {
                // Out of range
                return;
            }
            else if (state == Toggle.Play && !this.midiNumbersPlaying[midiNoteNumber])
            {
                // Add the corresponding tone to the list of currently playing tones
                this.sinePlayer.Tones.Add(tonesAvailable[midiNoteNumber - lowestNoteNumber]);
                this.midiNumbersPlaying[midiNoteNumber] = true;
            }
            else if (state == Toggle.Stop && this.midiNumbersPlaying[midiNoteNumber])
            {
                // Remove the corresponding tone from the list of currently playing tones
                this.sinePlayer.Tones.Remove(tonesAvailable[midiNoteNumber - lowestNoteNumber]);
                this.midiNumbersPlaying[midiNoteNumber] = false;
            }
        }

        /// <summary>
        /// Occurs when the user press a key on the computer keyboard. Some keys may be used to play notes and
        /// this method starts playback of the note played.
        /// </summary>
        /// <param name="sender">Calling object.</param>
        /// <param name="e">Arguments passed.</param>
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            ComputerKeyboardPiano(e, Toggle.Play);
        }

        /// <summary>
        /// Occurs when the user release a key on the computer keyboard. This method removes a note from the
        /// currently playing notes list.
        /// </summary>
        /// <param name="sender">Calling object.</param>
        /// <param name="e">Arguments passed.</param>
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            ComputerKeyboardPiano(e, Toggle.Stop);
        }

        /// <summary>
        /// Evaluates key up and down events and plays or stops tones accordingly.
        /// </summary>
        /// <param name="e">Key event arguments sent from KeyUp or KeyDown event handler.</param>
        /// <param name="state">Wether to play or to stop the tone.</param>
        private void ComputerKeyboardPiano(KeyEventArgs e, Toggle state) 
        {
            // Do nothing if we don't have any tones to play
            if (tonesAvailable == null || tonesAvailable.Length == 0) return;

            int noteNumber;

            switch (e.KeyCode)
            {
                case Keys.Z:
                    noteNumber = 0;
                    break;
                case Keys.S:
                    noteNumber = 1;
                    break;
                case Keys.X:
                    noteNumber = 2;
                    break;
                case Keys.D:
                    noteNumber = 3;
                    break;
                case Keys.C:
                    noteNumber = 4;
                    break;
                case Keys.V:
                    noteNumber = 5;
                    break;
                case Keys.G:
                    noteNumber = 6;
                    break;
                case Keys.B:
                    noteNumber = 7;
                    break;
                case Keys.H:
                    noteNumber = 8;
                    break;
                case Keys.N:
                    noteNumber = 9;
                    break;
                case Keys.J:
                    noteNumber = 10;
                    break;
                case Keys.M:
                    noteNumber = 11;
                    break;
                default:
                    return;
            }

            // Adjust for chosen octave and play back
            noteNumber += ((int)this.ComputerKeyboardOctaveNumeric.Value + 1) * 12;
            this.ToggleTone(noteNumber, state);
        }
        
        /// <summary>
        /// Occurs when the user selects Settings in the File menu. Opens the settings dialog.
        /// </summary>
        /// <param name="sender">Calling control.</param>
        /// <param name="e">Arguments passed.</param>
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kill audio
            this.audioOut.Stop();

            // Open settings dialog
            SettingsWindow settings = new SettingsWindow();
            settings.ShowDialog();

            // Re-initialize audio to reflect latency changes
            this.InitializeAudio();
            this.audioOut.Play();
        }

        /// <summary>
        /// Occurs when this form is closing. Save settings and dispose.
        /// </summary>
        /// <param name="sender">Calling object.</param>
        /// <param name="e">Arguments passed.</param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.audioOut.Dispose();
            this.Dispose();
        }

        /// <summary>
        /// Occurs when the user changes the computer keyboard piano playback octave. Clear the list of currently playing tones.
        /// </summary>
        /// <param name="sender">Calling object.</param>
        /// <param name="e">Arguments passed.</param>
        private void ComputerKeyboardOctaveNumeric_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.midiNumbersPlaying.Length; i++)
            {
                this.midiNumbersPlaying[i] = false;
            }
                
            this.sinePlayer.Tones.Clear();
        }
    }
}
