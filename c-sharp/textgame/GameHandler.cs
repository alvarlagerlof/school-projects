using System;
using System.Linq;
using System.Threading;

namespace textgame
{
    public class GameHandler
    {

        public static void WriteSlowly(string text) 
        {
            Random rand = new Random();

            foreach (char c in text)
            {
                Console.Write(c);

                if (c.ToString() == "." || c.ToString() == "," || c.ToString() == "?") 
                {
                    Thread.Sleep(rand.Next(700, 1500));
                } else {
                    Thread.Sleep(rand.Next(20, 100));
                }
            }

            Thread.Sleep(rand.Next(150, 300));
            System.Console.WriteLine();
        }

        public static void PresentChoice(int currentChoosen, bool isFirstDraw, Choice choice) 
        {
            Console.Clear();
            if (isFirstDraw) 
            {
                WriteSlowly(choice.Question);
            } else {
                Console.WriteLine(choice.Question);
            }

            Console.WriteLine();
            

            for (int i = 0; i < choice.Options.Count; i++) 
            {
                var item = choice.Options.ElementAt(i);
                var key = item.Key;
                var value = item.Value;

                if (currentChoosen == i) 
                {
                    System.Console.WriteLine("> " + key);
                } else {
                    System.Console.WriteLine("  " + key);
                }
            }

            // TODO: Remove duplication
            var choosenItem = choice.Options.ElementAt(currentChoosen);
            var choosenKey = choosenItem.Key;
            var choosenValue = choosenItem.Value;

            switch (Console.ReadKey(true).Key) 
            {
                case ConsoleKey.Enter:
                    if (choosenValue is Choice) 
                    {
                        PresentChoice(0, true, (Choice) choosenValue);

                    } else if (choosenValue is Action) {
                        Console.Clear();
                        Action action = (Action) choosenValue;
                        action();
                    } else {
                        System.Console.WriteLine("No type match");
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (currentChoosen > 0) 
                    {
                        PresentChoice(currentChoosen - 1, false, choice);
                    }
                    PresentChoice(currentChoosen, false, choice);
                    break;

                case ConsoleKey.DownArrow:
                    if (currentChoosen < choice.Options.Count - 1) 
                    {
                        PresentChoice(currentChoosen + 1, false, choice);
                    }
                    PresentChoice(currentChoosen, false, choice);
                    break;
            }
        }
    }
}
