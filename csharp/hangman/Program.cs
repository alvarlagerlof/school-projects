using System;
using System.Collections.Generic;
using System.Linq;

namespace hello_world {
    class Program {
        static List<KeyValuePair<string, bool>> currentWord = new List<KeyValuePair<string, bool>>();
        static List<string> wrongGuesses = new List<string>();
        static int numOfTriesLeft = 10;
        static string rightWordUnformatted = "";
       
        static void Main(string[] args) {
            // Say hello and describe the game
            Console.WriteLine("Welcome to hangman");

            // Add words from the file to the dict
            List<string> words = System.IO.File.ReadLines("./words.txt").ToList();

            // Choose a word at random
            Random random = new Random();
            rightWordUnformatted = (string) words[random.Next(words.Count)];

            foreach (char letter in rightWordUnformatted.ToCharArray()) {
                currentWord.Add(KeyValuePair.Create(letter.ToString(), false));
            }

            // Start game
            System.Threading.Thread.Sleep(1000);
            Cycle();
        }

        static string GetCurrent() {
            string current = "";
            foreach (KeyValuePair<string, bool> entry in currentWord) {
                if (entry.Value) {
                    current += entry.Key;
                } else {
                    current += "_";
                }
            }
            return current;
        }

        static bool everyValueTrue() {
            foreach (KeyValuePair<string, bool> entry in currentWord) {
                if (entry.Value == false) {
                    return false;
                }
            }
            return true;
        }

        static bool containsValue(string key) {
            foreach (KeyValuePair<string, bool> entry in currentWord) {
                if (entry.Key == key) {
                    return true;
                }
            }
            return false;
        }
        static bool alreadyGuessed(string key) {
            foreach (KeyValuePair<string, bool> entry in currentWord) {
                if (entry.Key == key && entry.Value == true) {
                    return true;
                }
            }
            return false;
        }

        static void updateValue(string key) {
            for (var i = 0; i < currentWord.Count; i++) {
                if (currentWord[i].Key == key) {
                    Console.WriteLine(currentWord[i].Key);
                    currentWord[i] = KeyValuePair.Create(currentWord[i].Key, true);
                }
            }
            
        }

        static void Cycle() {
            Console.Clear();
            if (numOfTriesLeft == 0) {
                Console.Clear();
                Console.WriteLine("GAME OVER!");
                Console.WriteLine("The right word was: " + rightWordUnformatted);
                Console.WriteLine();
                System.Environment.Exit(0);
                // TODO: Exit program
            } else if (everyValueTrue()) {
                Console.Clear();
                Console.WriteLine("You won!");
                Console.WriteLine();
                System.Environment.Exit(0);

            } else {
                Console.WriteLine("Current word " + GetCurrent());
                if (wrongGuesses.Count > 0) {
                    Console.WriteLine("Wrong guesses: " + string.Join(", ", wrongGuesses));
                }
                Console.WriteLine("Guesses left: " + numOfTriesLeft);
                Console.WriteLine();
                Console.Write("Write a letter: ");
                string letter = Console.ReadLine();

                if (letter.ToCharArray().Count() > 1 && letter != rightWordUnformatted) {
                    Console.WriteLine("Please only write one letter, or the full word");
                    System.Threading.Thread.Sleep(500);
                    Cycle();

                } else if (letter == rightWordUnformatted) {
                    Console.Clear();
                    Console.WriteLine("You won!");
                    Console.WriteLine();
                    System.Environment.Exit(0);

                } else if (alreadyGuessed(letter) || wrongGuesses.Contains(letter)) {
                    Console.WriteLine("You already guessed that!");
                    System.Threading.Thread.Sleep(500);
                    updateValue(letter);
                    Cycle();

                } else if (containsValue(letter)) {
                    Console.WriteLine("You guessed right!");
                    System.Threading.Thread.Sleep(500);
                    updateValue(letter);
                    numOfTriesLeft--;
                    Cycle();
                    
                } else {
                    Console.WriteLine("Wrong guess!");
                    wrongGuesses.Add(letter);
                    System.Threading.Thread.Sleep(500);
                    numOfTriesLeft--;
                    Cycle();
                }

            }
        }
    }
}
