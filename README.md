# Laughter

A program written in C\# to facilitate analyzing decks for Tasha's Hideous Laughter.
This program is deliberately incomplete.
It needs a smart, efficient manner to analyze the cards by CMCs.

## Requisites
1. Microsoft Visual Studio (Community Edition is free)
2. MTG Card Files: https://mtgjson.com/downloads/all-files/#allprintings
3. CSV Editor
4. Deck File in .txt of choice.

### Microsoft Visual Studio
https://visualstudio.microsoft.com/downloads/
Community Edition is free.

### MTG Card Files
-> All Set Files

-> Zip

-> Download & Unzip

-> Edit the file in Excel or similar and delete all columns but name and convertedManaCost

### CSV Editor
Excel, Python, C#, whatever will all parse it, but you'll save some time with a good library.
You'll save my time by editing the file with a minimal amount of work.
Sorry.  You'll need to edit the file in something other than Google sheets.  Just doesn't like importing the large file.

### Deck File
I used decklists from MTGGoldfish.  The program parses until an empty line (ignores sideboard).

#### Setup
Edit lines 20 and 21 (at the time of this writing) for AllCardsFile and Filename for your appropriate files.
Run the program.
