using System;
using System.Linq;
using System.Threading;

namespace textgame
{
    public class GameHandler
    {
        private static Random rand = new Random();

        public static void WriteSlowly(string text)
        {
            bool sleep = true;

            // To allow the user to press ENTER to skip 
            // the typing effect on a long text
            void sleepWithInterrupt(int sleepTime)
            {
                if (Console.KeyAvailable &&
                   (Console.ReadKey(true).Key == ConsoleKey.Enter))
                {
                    sleep = false;
                }
                else if (sleep)
                {
                    Thread.Sleep(sleepTime);
                }
            }

            Console.Clear();
            foreach (char c in text)
            {
                Console.Write(c);

                // Longer pauses between sentances
                if (c.ToString() == "." || c.ToString() == "," ||
                    c.ToString() == "?" || c.ToString() == "?")
                {
                    sleepWithInterrupt(rand.Next(200, 400));
                }
                else
                {
                    sleepWithInterrupt(rand.Next(50, 100));
                    //sleepWithInterrupt(rand.Next(0, 5));
                }
            }

            Console.WriteLine();
            Thread.Sleep(1000);
        }

        public static void PrintQuestion(string[] question, bool isFirstPrint)
        {
            // Print slowly the first time, following times instant, and 
            // only the last part (for when the users steps beteen alternatives)
            if (isFirstPrint)
            {
                for (int i = 0; i < question.Length; i++)
                {
                    WriteSlowly(question[i]);
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine(question[question.Length - 1]);
            }
        }

        public static void PresentChoice(Choice choice, int currentChoosen, bool isFirstPrint)
        {
            Console.Clear();
            PrintQuestion(choice.Question, isFirstPrint);
            Console.WriteLine();


            // First just print the list, when the current one prefixed with "> "
            for (int i = 0; i < choice.Options.Count; i++)
            {
                var item = choice.Options.ElementAt(i);

                if (currentChoosen == i)
                {
                    System.Console.WriteLine("> " + item.Key);
                }
                else
                {
                    System.Console.WriteLine("  " + item.Key);
                }
            }

            // Get the func that is the value of the Dictionary in Choice.cs
            Func<Choice?> choosenValue = choice.Options.ElementAt(currentChoosen).Value;

            // This part listens for user input and responds accordingly
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Enter:
                    // Here, the Func is executed to either get 
                    // a Choice or null
                    Choice? choosenValueExcecuted = choosenValue();

                    // If the Choice turns out to be null, then the story
                    // has ended and no other choice should be presented
                    // See more in Choice.cs
                    if (choosenValueExcecuted != null)
                    {
                        PresentChoice(choosenValueExcecuted, 0, true);
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (currentChoosen > 0)
                    {
                        PresentChoice(choice, currentChoosen - 1, false);
                    }
                    PresentChoice(choice, currentChoosen, false);
                    break;

                case ConsoleKey.DownArrow:
                    if (currentChoosen < choice.Options.Count - 1)
                    {
                        PresentChoice(choice, currentChoosen + 1, false);
                    }
                    PresentChoice(choice, currentChoosen, false);
                    break;

                default:
                    PresentChoice(choice, currentChoosen, false);
                    break;
            }
        }
    }
}