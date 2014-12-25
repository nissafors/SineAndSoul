# Sine & Soul

## Features
Sine & Soul is an overtone mixer and player intended as an ear training tool for piano tuners. Import
frequencies for fundamental tones and overtones from CSV files. Mix and mute overtones much like using
drawbars on an organ. Play back by pressing the computer keys zsxdcvgbhnjm.

## Wishlist
This program is still in an early stage of development. Here's a few wishes for the future:
* MIDI keyboard playback
* Native open & save.
* UI improvements:
  * Display currently playing notes and frequencies
  * Mute all-button

## Development
Sine & Soul is written in C# using Visual Studio. It uses the NAudio library which can be installed
with the NuGet package manager, or you can reference it manually. Follow the instructions on the NAudio
web site at http://naudio.codeplex.com/.

## Example CSV files
There are two example CSV files included in the Example CSV files folder:
* c1b1_6.csv - One octave with 6 overtones starting at C4. Delimiter: ',' and decimal mark: '.'.
* piano_swedish.csv - A full range piano starting at A0. Delimiter: ';' and decimal mark: ','.

## Setup
A setup file can be found SineAndSoul.zip. This version will not be updated with every commit, so
it may lag behind the repository quite a lot. On the other hand it will probably be more reliable.
To install: Unzip the folder and run setup.