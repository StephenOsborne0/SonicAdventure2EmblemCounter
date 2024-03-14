# SonicAdventure2EmblemCounter

## Supports
Sonic Adventure 2 (Steam) - x86 PCs currently atm

Xbox/Gamecube/PS3 not supported

## About
A basic emblem counter for Sonic Adventure 2.

Attaches to the SA2 process memory (read only), reads the emblem count and outputs it to a local "emblems.txt" file next to the executable.
This can then be read into Streamlabs (or your streaming program of choice) as a Text Source to display on screen.
Output is pre-formatted as "Emblems: 180"

## Prerequisites - .NET 7.0 runtime
To run it you will need to install the .NET 7.0 runtime - the app will redirect to the website to install when you first run it, if it isn't already installed.

## How to use
1) Download the .ZIP file in the "Releases" section on the right-hand side of the Github page.
2) Right-click and extract the .ZIP file.
3) Run the executable (.exe) file in the unzipped folder.
4) This may require you to install the .NET 7.0 runtime. If so, you will have to run the aforementioned .exe again afterwards.
5) On first run (you must have Sonic Adventure 2 open - "sonic2app.exe"), it will create the text file with "Emblems: 0" in it.
6) Hook the text file up in your streaming program of choice.
7) Leave the executable running (whilst you're playing) - it will update the text file in the background every time your emblem count changes!
