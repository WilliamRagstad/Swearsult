using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Swearsult
{
    public class Interpreter
    {
        private static string[] SwearWords_Amarican = {
            // Amarican
            "shit",
            "fuck",
            "f*ck",
            "fucks",
            "f*cks",
            "fucked",
            "f*cked",
            "fucker",
            "f*cker",
            "fucking",
            "f*cking",
            "bitch",
            "b*tch",
            "douchebag",
            "darn",
            "sucker",
            "piss",
            "die",
            "dick",
            "head",
            "bastard",
            "ass",
            "asshole",
            "damn",
            "darn",
            "dumb",
            "idiot",
            "stupid",
            "retard",
            "cunt",
            "c*nt",
            "crap",
            "cock"
        };
        private static string[] SwearWords_British = {
            // British
            "bollocks",
            "bugger",
            "bloody",
            "choad",
            "crikey",
            "rubbish",
            "shag",
            "shagy",
            "wanker",
            "taking",
            "twat"
        };
        private static string[] OtherWords = {
            // Other
            "you",
            "your",
            "you're",
            "mom",
            "mother",
            "son",
            "my",
            "i",
            "i'm",
            "the",
            "are",
            "is",
            "it",
            "it's",
            "in",
            "a",
            "am",
            "of",
            "off",
            "oh",
            "so",
            "joke",
            "annoyed",
            "annoying",
            "hell",
            "hope",
            "satan",
            "god",
            "burn",
            "shame"
        };

        private static string[] AllWords = new string[
            SwearWords_Amarican.Length +
            SwearWords_British.Length +
            OtherWords.Length
            ];
        private static char EndOfLine = char.MinValue;

        private readonly string sourceFile;
        private Stack<string> stack;

        public Interpreter(string sourceFile)
        {
            this.sourceFile = sourceFile;
            stack = new Stack<string>();

            // Add all words to AllWords
            for (int i = 0; i < SwearWords_Amarican.Length; i++) AllWords[i] = SwearWords_Amarican[i];
            for (int i = 0; i < SwearWords_British.Length; i++) AllWords[i + SwearWords_Amarican.Length] = SwearWords_British[i];
            for (int i = 0; i < OtherWords.Length; i++) AllWords[i + SwearWords_Amarican.Length + SwearWords_British.Length] = OtherWords[i];
        }

        public void Interpret(bool debug)
        {
            string[] sourceLines = File.ReadAllLines(sourceFile);

            for (int i = 0; i < sourceLines.Length; i++)
            {
                string line = sourceLines[i] + EndOfLine;
                string ct = ""; // Current Token
                int operation = 0;

                for (int j = 0; j < line.Length; j++)
                {
                    char cc = line[j]; // Current Character

                    if (cc == ' ' || cc == '\t' ||                              // Space characters
                        cc == '.' || cc == ',' || cc == '!' ||                  // Other characters to ignore
                        cc == EndOfLine)                                        // Is at the end of a line
                    {
                        if (isValidInsult(ct))
                        {
                            // Add to stack
                            operation += ct.Split(' ').Length; // Ammount of words.
                            ct = string.Empty;
                        }
                        else if (ct == string.Empty) continue;
                        else if (!isPartOfInsult(ct))
                        {
                            // Invalid token
                            Console.WriteLine($"Invalid token at line {i + 1} column {j + 1 - ct.Length}:{j + 1}: '{ct}' (Expected '{GetRandom(ref SwearWords_Amarican).Split(' ')[0]}' or '{GetRandom(ref SwearWords_British).Split(' ')[0]}')");
                            ct = string.Empty;
                        }
                        continue;
                    }

                    ct += cc;
                }

                // Evaluate the stack
                if (operation == 0) continue; // return; // Stop execution
                else if (operation == 1)
                {
                    Console.WriteLine("OP:1");
                }
                else if (operation == 2)
                {
                    Console.WriteLine("OP:2");
                }
                else if (operation == 3)
                {
                    Console.WriteLine("OP:3");
                }
                else if (operation == 4)
                {
                    Console.WriteLine("OP:4");
                }
                else if (operation == 5)
                {
                    Console.WriteLine("OP:5");
                }
                else
                {
                    Console.WriteLine("OP:5+");
                }
            }
        }

        private bool isValidInsult(string sequence)
        {
            for (int i = 0; i < AllWords.Length; i++)
            {
                if (sequence.ToLower() == AllWords[i]) return true;
            }
            return false;
        }
        private bool isPartOfInsult(string sequence)    // Sequence may not include spaces!
        {
            string seq = sequence.ToLower();
            for (int i = 0; i < AllWords.Length; i++)
            {
                string[] parts = AllWords[i].Split(' ');
                for (int j = 0; j < parts.Length; j++)
                {
                    if (parts[j] == seq) return true;
                }
            }
            return false;
        }

        private string GetRandom(ref string[] array) => array[new Random().Next(array.Length)];
    }
}
 
