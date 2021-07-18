# Laughter

A program written in C\# to facilitate analyzing decks for Tasha's Hideous Laughter.
This program is deliberately incomplete.
It needs a smart, efficient manner to analyze the cards by CMCs.

## Requisites
1. Microsoft Visual Studio (Community Edition is free)
2. MTG Card Files: https://mtgjson.com/downloads/all-files/#allprintings
3. CSV Editor
4. Deck File in .txt of choice.
5. Required Reading

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
You'll save more time by editing the file with a minimal amount of work.
Sorry.  You'll need to edit the file in something other than Google sheets.  Just doesn't like importing the large file.

### Deck File
I used decklists from MTGGoldfish.  The program parses until an empty line (ignores sideboard).

### Required Reading
There are a variety of libraries available.  I've tried a couple and the link below is suitable and applicable.
Project -> Manage NuGet Packages... then search for Combinatorics
https://www.codeproject.com/Articles/26050/Permutations-Combinations-and-Variations-using-C-G
Same for CsvHelper


#### Setup
Edit lines 20 and 21 (at the time of this writing) for AllCardsFile and Filename for your appropriate files.
Run the program.

#### Todo
1. Determine the minimum and maximum number of cards possible to exile
2. Evaluate which approach (Permutation, Combination, or Variation) suits and why
3. Iterate between the Min and Max cards (inclusive) and generate every appropriate sample set for each iteration
4. Evaluate and tally results appropriately
5. Provide the results in a meaningful fashion (Console or CSV https://stackoverflow.com/questions/18757097/writing-data-into-csv-file-in-c-sharp )
6. When producing data like this for public consumption, it's good to include the bounds (upper and lower), average, and mode.  This helps people analyze and readily digest the spread and skew of the data.  It also helps them formulate and raise questions, if they have any, and gives them a starting point for research.
7. On that note, it's probably a good idea to provide the source decklists, too, if possible.

Hope this is helpful feedback.
