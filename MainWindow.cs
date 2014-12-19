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
        
        /// <summary>
        /// Initialize a new instance of the MainWindow class. The user controls the application from within this window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            amplitudes = new double[]{ 0.3, 0.1, 0.06, 0.05 };
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

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
