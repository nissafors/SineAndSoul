using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SineAndSoul
{
    using System;
    using System.Collections.Generic;
    using NAudio.Wave;

    /// <summary>
    /// Provides a buffer that NAudio can read from by adding sine waves. The characteristics of the
    /// waves are sent through the constructor.
    /// </summary>
    class SineSumSampleProvider : ISampleProvider
    {
        // Wave format
        private readonly WaveFormat waveFormat;

        // Number of samples into the wave
        private double time = 0;

        public double[] Frequencies { private get; set; }
        public double[] Amplitudes { private get; set; }

        /// <summary>
        /// Initializes a new instance of the Tone class, an ISampleProvider that
        /// reads fundamental tone and overtone characteristics from a file.
        /// </summary>
        /// <param name="sampleRate">Desired sample rate.</param>
        /// <param name="channel">Number of channels.</param>
        /// <param name="overtones">List of WaveCharacter objects for each overtone.</param>
        public SineSumSampleProvider(int sampleRate, int channel)
        {
            waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channel);
        }

        /// <summary>
        /// The waveformat of this WaveProvider (same as the source)
        /// </summary>
        public WaveFormat WaveFormat
        {
            get { return waveFormat; }
        }

        /// <summary>
        /// Reads from this provider.
        /// </summary>
        public int Read(float[] buffer, int offset, int count)
        {
            int i, outIndex = offset, sampleRate = waveFormat.SampleRate;
            double sample;

            // Complete the buffer
            for (int sampleCount = 0; sampleCount < count / waveFormat.Channels; sampleCount++)
            {
                sample = 0;
                i = 0;

                // Loop through the harmonics and add them together
                foreach (double frequency in Frequencies)
                {
                    sample += Amplitudes[i++] * Math.Sin(2 * Math.PI * frequency * time/sampleRate);
                    if (i >= Amplitudes.Length) i = 0;
                }
                
                time++;

                // Write to buffer
                for (i = 0; i < waveFormat.Channels; i++)
                {
                    buffer[outIndex++] = (float)sample;
                }
            }

            return count;
        }
    }
}
