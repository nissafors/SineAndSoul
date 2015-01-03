//-----------------------------------------------------------------------
// SineAndSoul: MidiMonitor.cs
//
// Copyright (c) 2015 Andreas Andersson
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
//-----------------------------------------------------------------------

namespace SineAndSoul
{
    using System;
    using NAudio.Midi;

    /// <summary>
    /// Class to make it easier to track MIDI in messages.
    /// </summary>
    class MidiMonitor : IDisposable
    {
        // Used by the SelectedDevice property (see below).
        private int? selectedDevice = null;

        /// <summary>
        /// Indicates wether we're currently monitoring MIDI in messages or not.
        /// </summary>
        public bool Monitoring { get; private set; }

        /// <summary>
        /// Get the NAudio representation of the MIDI device we are currently monitoring.
        /// </summary>
        public MidiIn MidiInDevice { get; private set; }

        /// <summary>
        /// Gets or sets the MIDI device to monitor by its device number.
        /// </summary>
        public int? SelectedDevice
        {
            get
            {
                return selectedDevice;
            }
            set
            {
                selectedDevice = value;

                // Dispose of old MidiIn instance
                if (MidiInDevice != null)
                {
                    MidiInDevice.Dispose();
                    MidiInDevice = null;
                }

                // Watch for device number out of range
                if (selectedDevice != null && (selectedDevice < 0 || selectedDevice >= MidiIn.NumberOfDevices))
                {
                    selectedDevice = null;
                    Monitoring = false;
                    throw new InvalidOperationException("No such device.");
                }

                // Select new device to monitor
                if (selectedDevice != null)
                {
                    MidiInDevice = new MidiIn((int)selectedDevice);
                    if (Monitoring) MidiInDevice.Start();
                }

                if (SelectedDevice == null)
                {
                    Monitoring = false;
                }
            }
        }

        /// <summary>
        /// Initialize a new instance of the MidiMonitor class. Auto select the first available MIDI device, if any.
        /// </summary>
        public MidiMonitor()
        {
            if (MidiIn.NumberOfDevices > 0)
            {
                SelectedDevice = 0;
            }
            else
            {
                SelectedDevice = null;
            }
        }

        /// <summary>
        /// Get the product names of all available MIDI devices.
        /// </summary>
        /// <returns>Returns a string array with product names of all available MIDI devices, or null.</returns>
        public static string[] GetMidiDevices()
        {
            string[] devices;

            devices = new string[MidiIn.NumberOfDevices];

            for (int device = 0; device < MidiIn.NumberOfDevices; device++)
            {
                devices[device] = MidiIn.DeviceInfo(device).ProductName;
            }

            if (devices.Length == 0) devices = null;
            return devices;
        }

        /// <summary>
        /// Begin monitoring MIDI messages. You must implement the handler manually.
        /// Before this method is called, add your handler with:
        /// [InstanceOfMidiMonitor].MidiInDevice.MessageReceived += new EventHandler<MidiInMessageEventArgs>([HandlerMethod]);
        /// </summary>
        public void StartMidiMonitoring()
        {
            if (MidiInDevice == null)
            {
                throw new InvalidOperationException("No MIDI device selected.");
            }

            MidiInDevice.Start();
            Monitoring = true;
        }

        /// <summary>
        /// Stop monitoring MIDI messages. Before calling this method, remove your handler method with:
        /// [InstanceOfMidiMonitor].MidiInDevice.MessageReceived -= EventHandler<MidiInMessageEventArgs>([HandlerMethod]);
        /// </summary>
        public void StopMidiMonitoring()
        {
            try
            {
                MidiInDevice.Stop();
            }
            catch
            {
                SelectedDevice = null;
            }
            finally
            {
                Monitoring = false;
            }
        }

        /// <summary>
        /// Dispose of an instance of this class.
        /// </summary>
        public void Dispose()
        {
            if (MidiInDevice != null)
            {
                StopMidiMonitoring();
                try
                {
                    MidiInDevice.Dispose();
                }
                finally
                {
                    MidiInDevice = null;
                }
            }
        }
    }
}
