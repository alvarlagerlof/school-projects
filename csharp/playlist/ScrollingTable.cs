using System;
using System.Collections.Generic;
using System.Linq;

namespace playlist
{
    class ScrollingTable
    {
        const char HORIZONTAL_LINE = '─';
        const string VERTICAL_LINE = "│";

        public ScrollingTable(List<string> headers, Dictionary<string, Action> actions)
        {
            Headers = headers;
            Actions = actions;
        }

        public static List<string> Headers { get; set; } = default!;
        public static Dictionary<string, Action> Actions { get; set; } = default!;


        int topOffset = 0;
        int cursorIndex = 0;
        List<int> selected = new List<int> { };

        List<List<string>> items = new List<List<string>> { };

        public void SendKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    if (cursorIndex < items.Count - 1)
                    {
                        cursorIndex++;
                        if (cursorIndex - topOffset == Console.WindowHeight - 5 && topOffset + Console.WindowHeight - 4 < items.Count)
                        {
                            topOffset += 1;
                        }
                    }

                    break;
                case ConsoleKey.UpArrow:
                    if (cursorIndex > 0)
                    {
                        cursorIndex--;
                        if (cursorIndex == topOffset && topOffset > 0)
                        {
                            topOffset -= 1;
                        }
                    }

                    break;
                case ConsoleKey.Spacebar:
                    if (!selected.Contains(cursorIndex))
                    {
                        selected.Add(cursorIndex);
                    }
                    else
                    {
                        selected.RemoveAll(item => item == cursorIndex);
                    }
                    break;
            }
        }

        public void AddItem(List<string> cols)
        {
            items.Add(cols);
        }

        public void RemoveItem(int index)
        {

        }

        public void Render()
        {
            Console.Clear();


            //Console.BackgroundColor = ConsoleColor.Gray;
            //Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("  ");
            if (selected.Count > 0)
            {
                Console.Write(selected.Count + " selected");
            }
            else
            {
                foreach (string header in Headers)
                {
                    Console.Write(AlignLeft(header, Console.WindowWidth / Headers.Count));
                }
            }


            Console.WriteLine();
            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write(HORIZONTAL_LINE);
            }

            Console.WriteLine();

            for (int r = topOffset; r < items.Count() + topOffset; r++)
            {

                if (r - topOffset < Console.WindowHeight - 4)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                    if (r == cursorIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }

                    if (selected.Contains(r))
                    {

                        Console.Write("✓ ");
                    }
                    else
                    {
                        Console.Write("□ ");
                    }

                    for (int c = 0; c < items[r].Count; c++)
                    {
                        Console.Write(AlignLeft(items[r][c], Console.WindowWidth / Headers.Count));
                    }

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                }

            }
        }

        static string AlignLeft(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - Headers.Count, ' ') + VERTICAL_LINE + " ";
            }
        }
    }
}