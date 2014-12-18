using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace SineAndSoul
{
    public partial class MainWindow : Form
    {
        private WaveOut audioOut;
        private SineSumSampleProvider sinePlayer;
        private double[] freq;
        private double[] amp;
        
        public MainWindow()
        {
            InitializeComponent();

            amp = new double[]{ 0.3, 0.1, 0.06, 0.05 };
            freq = new double[] { 293.66, 293.66 * 2, 293.66 * 3, 293.66 * 4, 369.99, 369.99 * 2, 369.99 * 3, 369.99 * 4 };

            sinePlayer = new SineSumSampleProvider(44100, 1);
            sinePlayer.Amplitudes = amp;
            sinePlayer.Frequencies = freq;

            audioOut = new WaveOut();
            audioOut.Init(sinePlayer);

            audioOut.Play();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
