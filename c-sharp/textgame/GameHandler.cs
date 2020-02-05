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

                if (currentChoosen == i) 
                {
                    System.Console.WriteLine("> " + item.Key);
                } else {
                    System.Console.WriteLine("  " + item.Key);
                }
            }

            // TODO: Set type to var
            var choosenItem = choice.Options.ElementAt(currentChoosen);
            var choosenValue = choosenItem.Value;

            switch (Console.ReadKey(true).Key) 
            {
                case ConsoleKey.Enter:
                    Choice? choosenValueExcecuted = choosenValue();

                    if (choosenValueExcecuted != null) 
                    {
                        PresentChoice(0, true, choosenValueExcecuted);
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

                default: 
                    PresentChoice(currentChoosen, false, choice);
                    break;
            }
        }
    }
}
