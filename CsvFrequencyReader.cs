//-----------------------------------------------------------------------
// SineAndSoul: CsvFrequencyReader.cs
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
    using System.IO;

    /// <summary>
    /// Reads frequencies from a CSV (comma separated values) file.
    /// </summary>
    class CsvFrequencyReader
    {
        // All tones and it's overtone frequencies read by ReadFrequenciesFromFile()
        private List<double[]> tones;

        /// <summary>
        /// The char that separates values in the file. Default is ','.
        /// Warning! ReadFrequenciesFromFile() can't read the file if DecimalMark == Delimiter.
        /// </summary>
        public char Delimiter { get; set; }

        /// <summary>
        /// The decimal mark used in this file. Default is '.';
        /// Warning! ReadFrequenciesFromFile() can't read the file if DecimalMark == Delimiter.
        /// </summary>
        public char DecimalMark { get; set; }

        /// <summary>
        /// Path to a CSV file containing fundamental frequency and overtone frequencies for a collection of tones.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The number of values per line to read from the CSV file. Default is 12.
        /// </summary>
        public int FrequenciesPerTone { get; set; }

        /// <summary>
        /// Initializes a new instance of the CsvFrequencyReader class.
        /// </summary>
        public CsvFrequencyReader()
            : this(string.Empty, ',', '.', 12)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CsvFrequencyReader class.
        /// </summary>
        public CsvFrequencyReader(string path)
            : this(path, ',', '.', 12)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CsvFrequencyReader class.
        /// </summary>
        /// <param name="path">Path to CSV file.</param>
        public CsvFrequencyReader(string path, char separator, char decimalMark, int frequenciesPerTone)
        {
            this.Path = path;
            this.Delimiter = separator;
            this.DecimalMark = decimalMark;
            this.FrequenciesPerTone = frequenciesPerTone;
            tones = new List<double[]>();
        }

        /// <summary>
        /// Convert to an array of tones represented by double arrays containing frequencies for each overtone.
        /// </summary>
        /// <returns>Returns an array of arrays with overtone frequency values for each tone.</returns>
        public double[][] ToArray()
        {
            double[][] returnArray = new double[tones.Count][];
            
            for (int i = 0; i < tones.Count; i++)
            {
                returnArray[i] = new double[FrequenciesPerTone];
                tones[i].CopyTo(returnArray[i], 0);
            }

            return returnArray;
        }

        /// <summary>
        /// Read comma (or other char) separated frequency values from Path. These can later be accessed through the ToArray() method.
        /// </summary>
        /// <returns>Returns true if file was read ok and false otherwise.</returns>
        public bool Read()
        {
            // Do nothing if properties are bad
            if (this.Path == string.Empty || this.Delimiter == this.DecimalMark) return false;

            using (StreamReader textReader = new StreamReader(Path))
            {
                while (!textReader.EndOfStream)
                {
                    // Read comma separated values (or rather semicolon separated values) into a string array
                    string line = textReader.ReadLine();
                    string[] values = line.Split(this.Delimiter);
                    
                    double[] tone = new double[this.FrequenciesPerTone];
                    int toneIndex = 0;
                    int valuesIndex = 0;
                    bool lastTryFailed = false;

                    // Extract values. First row may be a header. If more than one row on a line can't be converted to double, skip that line
                    while(toneIndex < this.FrequenciesPerTone)
                    {
                        if (DecimalMark != '.' && valuesIndex < values.Length)
                        {
                            values[valuesIndex] = values[valuesIndex].Replace(DecimalMark, '.');
                        }

                        try
                        {
                            tone[toneIndex] = Convert.ToDouble(values[valuesIndex]);
                            lastTryFailed = false;
                            toneIndex++;
                        }
                        catch
                        {
                            if (lastTryFailed) break;
                            lastTryFailed = true;
                        }

                        valuesIndex++;
                    }

                    // If we managed to read all values, add them to the list
                    if (!lastTryFailed)
                    {
                        this.tones.Add((double[])tone.Clone());
                    }
                }
            }

            return (tones.Count == 0) ? false : true;
        }
    }
}
