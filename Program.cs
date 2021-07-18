using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;

namespace Laughter
{
    class Program
    {
        // Battle of Wits runs 250+.  Not sure what the actual max is.  Whatever.
        public static int[] results = new int[500];

        public static string AllCardsFile = @"D:\cards.csv";
        public static string Filename = @"D:\Deck - Amulet Titan.txt";
        public static int MaxCMC = 30;

        public class SimpleCard 
        {
            [Name("name")]
            public string name { get; set; }

            [Name("convertedManaCost")]
            public int convertedManaCost { get; set; }

            public SimpleCard(string name, int convertedManaCost) 
            {
                this.name = name;
                this.convertedManaCost = convertedManaCost;
            }
        }

        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            
            Dictionary<string, int> allCards = LoadCards();
            int[] Quantities = new int[MaxCMC];
            
            IList<SimpleCard> decklist = new List<SimpleCard>();
            
            using (StreamReader sr = new StreamReader(@Filename))
            {
                try
                {
                    string line = "";

                    while ((line = sr.ReadLine()) != "")
                    {
                        var pieces = line.Split(new[] { ' ' }, 2);
                        int qty = Int32.Parse(pieces[0]);
                        string cardname = pieces[1];

                        for (int i = 1; i <= qty; i++)
                        { 
                            decklist.Add(new SimpleCard(cardname, allCards[cardname]));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                foreach (SimpleCard card in decklist)
                {
                    if (card.convertedManaCost >= 0 && card.convertedManaCost <= MaxCMC)
                    {
                        Quantities[card.convertedManaCost]++;
                    }
                }

                for(int i = 0; i < Quantities.Length; i++)
                {
                    if(Quantities[i] > 0) 
                    { 
                        Console.WriteLine("{0}, {1}", i, Quantities[i]);
                    }
                }

                // add permutations here based on CMC, Quantity KV pairs
                // Then print
            }

            DateTime end = DateTime.Now;
            Console.WriteLine("End: {0}", end);
            Console.WriteLine("Runtime: {0}", (end - start));
        }

        public static Dictionary<string, int> LoadCards()
        {
            Dictionary<string, int> allCards = new Dictionary<string, int>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,
                MissingFieldFound = null
            };

            using (var reader = new StreamReader(AllCardsFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<SimpleCard>();

                csv.Read();
                csv.ReadHeader();
                while(csv.Read())
                {
                    try
                    {
                        allCards.Add(csv.GetField("name"), Int32.Parse(csv.GetField("convertedManaCost")));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
            }

            return allCards;
        }
    }
}
