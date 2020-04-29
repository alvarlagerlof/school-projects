using System;
using System.Collections.Generic;
using System.Linq;

namespace playlist
{
    class ScrollingTable
    {
        private const char _HorizontalLine = '─';
        private const string _VerticalLine = "│";
        private int _topOffset = 0;
        private int _cursorIndex = 0;
        private readonly List<string> selected = new List<string> { };
        private readonly Dictionary<string, List<string>> items = new Dictionary<string, List<string>> { };
        private PlaylistService _playlistService;


        private List<string> _headers;

        public ScrollingTable(PlaylistService playlistService, List<string> headers)
        {
            _playlistService = playlistService;
            _headers = headers;
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

        private void Render()
        {
            // Headers and status
            Console.Write("  ");
            if (selected.Count > 0)
            {
                Console.Write(selected.Count + " selected");
            }
            else
            {
                foreach (string header in _headers)
                {
                    Console.Write(AlignLeft(header, Console.WindowWidth / _headers.Count));
                }
            }
            Console.WriteLine();

            // Line
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write(_HorizontalLine);
            }
            Console.WriteLine();

            if (items.Count > 0)
            {
                // List
                for (int r = _topOffset; r < items.Count() + _topOffset; r++)
                {

                    if (r - _topOffset < Console.WindowHeight - 4 && r < items.Count)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;

                        if (r == _cursorIndex)
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
                            Console.Write(AlignLeft(items.ElementAt(r).Value[c], Console.WindowWidth / _headers.Count));
                        }

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine();
                    }

                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                String message = "No songs, press C to add one";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2);
                Console.WriteLine(message);
            }


            // Bottom Menu
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            if (items.Count > 0)
            {
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
            else
            {
                Console.Write("[C] Create new");
            }



        }

        private string AlignLeft(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - _headers.Count, ' ') + _VerticalLine + " ";
            }
        }


        public ScreenResult OnInput(ConsoleKey key)
        {
            ScreenResult result;

            switch (key)
            {

                case ConsoleKey.UpArrow:
                    if (_cursorIndex > 0)
                    {
                        _cursorIndex--;
                        if (_cursorIndex == _topOffset && _topOffset > 0)
                        {
                            _topOffset -= 1;
                        }
                    }
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;

                case ConsoleKey.DownArrow:
                    if (_cursorIndex < items.Count - 1)
                    {
                        _cursorIndex++;
                        if (_cursorIndex - _topOffset == Console.WindowHeight - 5 && _topOffset + Console.WindowHeight - 4 < items.Count)
                        {
                            _topOffset += 1;
                        }
                    }
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;

                case ConsoleKey.Spacebar:
                    if (!selected.Contains(items.ElementAt(_cursorIndex).Key))
                    {
                        selected.Add(items.ElementAt(_cursorIndex).Key);
                    }
                    else
                    {
                        selected.Remove(items.ElementAt(_cursorIndex).Key);
                    }
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;

                case ConsoleKey.C:
                    if (selected.Count == 0)
                    {
                        result = new ScreenResult(ScreenResult.ResultType.CreateOpen, new object { });
                    }
                    else
                    {
                        result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    }
                    break;

                case ConsoleKey.E:
                    if (selected.Count <= 1)
                    {
                        if (selected.Count == 0)
                        {
                            selected.Add(items.ElementAt(_cursorIndex).Key);
                        }

                        result = new ScreenResult(ScreenResult.ResultType.EditOpen, selected[0]);

                    }
                    else
                    {
                        result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    }
                    break;

                case ConsoleKey.D:
                    if (selected.Count == 0)
                    {
                        selected.Add(items.ElementAt(_cursorIndex).Key);
                    }

                    // Fix cursor
                    _cursorIndex -= selected.Count;
                    if (_cursorIndex < 0) _cursorIndex = 0;

                    // Fix offset
                    if (items.Count - (_topOffset + Console.WindowHeight - 4) < 0)
                    {
                        _topOffset += items.Count - (_topOffset + Console.WindowHeight - 4);
                        if (_topOffset < 0) _topOffset = 0;
                    }

                    _playlistService.RemoveAll(s => selected.Contains(s));
                    RemoveAll(s => selected.Contains(s));

                    selected.Clear();
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;

                default:
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;
            }
            Render();
            return result;
        }
    }
}

