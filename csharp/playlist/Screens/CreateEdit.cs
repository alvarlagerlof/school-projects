using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace playlist
{
    public class CreateEdit : IScreen
    {
        private PlaylistService _playlistService;
        private Dictionary<InputMeta, string> _form;
        private InputMeta _formFocus;
        private int _cursorPosition;
        private Song _editSong = null;

        class InputMeta
        {
            public string Title { get; set; } = default!;
            public Regex Rules { get; set; } = default!;
            public string RulesGuide { get; set; } = default!;
            public InputMeta(string title, Regex rules, string rulesGuide)
            {
                Title = title;
                Rules = rules;
                RulesGuide = rulesGuide;
            }
        }

        public CreateEdit(PlaylistService playlistService)
        {
            _cursorPosition = 0;
            _playlistService = playlistService;
            _form = new Dictionary<InputMeta, string>
            {
                [new InputMeta("Name", new Regex(@".+"), "At least 1 char")] = "",
                [new InputMeta("Artist", new Regex(@".+"), "At least 1 char")] = "",
                [new InputMeta("Genre", new Regex(@".+"), "At least 1 char")] = "",
                [new InputMeta("Length", new Regex(@"[0-9]+:[0-5][0-9]$"), "T.ex. 2:34")] = ""
            };
            _formFocus = _form.ElementAt(0).Key;

        }

        private void RenderForm()
        {
            foreach (KeyValuePair<InputMeta, string> entry in _form)
            {
                Console.Write(entry.Key.Title);
                if (!entry.Key.Rules.IsMatch(entry.Value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" - " + entry.Key.RulesGuide);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();

                if (entry.Key == _formFocus)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    CursorPrint(_cursorPosition, entry.Value);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(entry.Value);

                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 1);

            Console.Write("[Esc] Cancel");
            Console.Write("  [Enter] Save");

        }

        private void CursorPrint(int position, string s)
        {
            for (int i = 0; i <= s.Length; i++)
            {
                if (i == _cursorPosition)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }

                if (i == s.Length)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(s[i]);
                }

                Console.BackgroundColor = ConsoleColor.Black;

            }



            Console.WriteLine();
        }

        public void OnActivate(object data)
        {

            _cursorPosition = 0;
            _formFocus = _form.ElementAt(0).Key;
            _editSong = null;

            if (data.GetType() != typeof(string))
            {
                _form[(InputMeta)_form.ElementAt(0).Key] = "";
                _form[(InputMeta)_form.ElementAt(1).Key] = "";
                _form[(InputMeta)_form.ElementAt(2).Key] = "";
                _form[(InputMeta)_form.ElementAt(3).Key] = "";
            }
            else
            {
                _editSong = (Song)_playlistService.FindByID(data.ToString());
                _form[(InputMeta)_form.ElementAt(0).Key] = _editSong.Title.Replace("\0", "");
                _form[(InputMeta)_form.ElementAt(1).Key] = _editSong.Artist.Replace("\0", "");
                _form[(InputMeta)_form.ElementAt(2).Key] = _editSong.Genre.Replace("\0", "");
                _form[(InputMeta)_form.ElementAt(3).Key] = _editSong.Playtime.Replace("\0", "");
            }

        }

        public ScreenResult OnInput(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Escape)
            {
                return new ScreenResult(ScreenResult.ResultType.CreateExit, new object { });
            }

            int currIndex = _form.Keys.ToList().IndexOf(_formFocus);

            ScreenResult result;

            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    result = new ScreenResult(ScreenResult.ResultType.CreateExit, new object { });
                    break;

                case ConsoleKey.Enter:
                    bool fail = false;

                    foreach (KeyValuePair<InputMeta, string> entry in _form)
                    {
                        if (!entry.Key.Rules.IsMatch(entry.Value))
                        {
                            fail = true;
                        }
                    }

                    if (!fail)
                    {
                        if (_editSong == null)
                        {
                            _playlistService.Add(new Song(
                                _playlistService.GetNextTrack(),
                                _form.ElementAt(0).Value.Replace("\0", ""),
                                _form.ElementAt(1).Value.Replace("\0", ""),
                                _form.ElementAt(2).Value.Replace("\0", ""),
                                _form.ElementAt(3).Value.Replace("\0", "")
                            ));
                        }
                        else
                        {
                            _editSong.Title = _form.ElementAt(0).Value.Replace("\0", "");
                            _editSong.Artist = _form.ElementAt(1).Value.Replace("\0", "");
                            _editSong.Genre = _form.ElementAt(2).Value.Replace("\0", "");
                            _editSong.Playtime = _form.ElementAt(3).Value.Replace("\0", "");
                            _playlistService.Update(_editSong);
                        }
                        result = new ScreenResult(ScreenResult.ResultType.CreateExit, new object { });
                    }
                    else
                    {
                        result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    }

                    break;

                case ConsoleKey.UpArrow:
                    if (currIndex != 0)
                    {
                        _formFocus = _form.ElementAt(currIndex - 1).Key;
                    }
                    _cursorPosition = _form[_formFocus].Length;
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;

                case ConsoleKey.DownArrow:

                    if (currIndex != _form.Count - 1)
                    {
                        _formFocus = _form.ElementAt(currIndex + 1).Key;
                    }

                    _cursorPosition = _form[_formFocus].Length;
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;

                case ConsoleKey.Tab:
                    if (currIndex != _form.Count - 1)
                    {
                        _formFocus = _form.ElementAt(currIndex + 1).Key;
                    }

                    _cursorPosition = _form[_formFocus].Length;
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;

                case ConsoleKey.LeftArrow:
                    if (_cursorPosition > 0)
                    {
                        _cursorPosition--;
                    }
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;

                case ConsoleKey.RightArrow:

                    if (_cursorPosition < _form[_formFocus].Length)
                    {
                        _cursorPosition++;
                    }
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;

                case ConsoleKey.Backspace:
                    if (_form[_formFocus].Length > 0 && _cursorPosition != 0 && _cursorPosition - 1 > 0)
                    {
                        _form[_formFocus] = _form[_formFocus].Remove(_cursorPosition - 1, 1);
                        _cursorPosition--;
                    }

                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;

                default:
                    _form[_formFocus] = _form[_formFocus].Insert(_cursorPosition, key.KeyChar.ToString());
                    _cursorPosition++;
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;
            }


            RenderForm();

            return result;
        }
    }
}


