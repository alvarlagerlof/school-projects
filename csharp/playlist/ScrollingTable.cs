using System;
using System.Collections.Generic;
using System.Linq;

namespace playlist
{
    class ScrollingTable
    {
        const char HorizontalLine = '─';
        const string VerticalLine = "│";

        int topOffset = 0;
        int cursorIndex = 0;
        List<string> selected = new List<string> { };
        Dictionary<string, List<string>> items = new Dictionary<string, List<string>> { };

        private List<string> _headers;
        private Action _onCreate;

        private Action<string> _onEdit;

        private Action<List<string>> _onDelete;

        public ScrollingTable(List<string> headers, Action onCreate, Action<string> onEdit, Action<List<string>> onDelete)
        {
            _headers = headers;
            _onCreate = onCreate;
            _onEdit = onEdit;
            _onDelete = onDelete; hej

        }



        public void SendKey(ConsoleKey key)
        {

            Console.WriteLine(key.ToString());


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
                    if (!selected.Contains(items.ElementAt(cursorIndex).Key))
                    {
                        selected.Add(items.ElementAt(cursorIndex).Key);
                    }
                    else
                    {
                        selected.Remove(items.ElementAt(cursorIndex).Key);
                    }
                    break;

                case ConsoleKey.C:

                    if (selected.Count == 0)
                    {
                        OnCreate();
                    }

                    break;

                case ConsoleKey.E:

                    if (selected.Count <= 1)
                    {
                        if (selected.Count == 0)
                        {
                            selected.Add(items.ElementAt(cursorIndex).Key);
                        }

                        OnEdit(selected[0]);

                    }

                    break;

                case ConsoleKey.D:

                    if (selected.Count == 0)
                    {
                        selected.Add(items.ElementAt(cursorIndex).Key);
                    }

                    OnDelete(selected);

                    // Fix cursor
                    cursorIndex -= selected.Count;
                    if (cursorIndex < 0) cursorIndex = 0;

                    // Fix offset
                    if (items.Count - (topOffset + Console.WindowHeight - 4) < 0)
                    {
                        topOffset += items.Count - (topOffset + Console.WindowHeight - 4);
                        if (topOffset < 0) topOffset = 0;
                    }

                    selected.Clear();
                    break;


            }
        }

        public void AddItem(String id, List<string> cols)
        {
            items.Add(id, cols);
        }

        public void RemoveAll(Predicate<string> predicate)
        {
            foreach (KeyValuePair<string, List<string>> item in items)
            {
                if (predicate(item.Key))
                {
                    items.Remove(item.Key);
                }
            }
        }

        public void Render()
        {

            // Headers and status
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

            // Line
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write(HorizontalLine);
            }
            Console.WriteLine();

            // List
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

                    if (selected.Contains(items.ElementAt(r).Key))
                    {
                        Console.Write("✓ ");
                    }
                    else
                    {
                        Console.Write("□ ");
                    }

                    for (int c = 0; c < items.ElementAt(r).Value.Count; c++)
                    {
                        Console.Write(AlignLeft(items.ElementAt(r).Value[c], Console.WindowWidth / Headers.Count));
                    }

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                }

            }

            // Bottom Menu
            Console.WriteLine();
            if (selected.Count == 0)
            {
                Console.Write("[C] Create new");
                Console.Write("  [E] Edit current");
                Console.Write("  [D] Delete current");
            }
            else if (selected.Count == 1)
            {
                Console.Write("[E] Edit current");
                Console.Write("  [D] Delete current");
            }
            else
            {
                Console.Write("[D] Delete selected");
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
                return text.PadRight(width - Headers.Count, ' ') + VerticalLine + " ";
            }
        }
    }
}