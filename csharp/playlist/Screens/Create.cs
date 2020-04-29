using System;
using System.Collections.Generic;
using System.Linq;

namespace playlist
{
    class Create : IScreen
    {
        private PlaylistService _playlistService;
        private Dictionary<string, string> _form;
        private string _formFocus;

        public Create(PlaylistService playlistService)
        {
            _playlistService = playlistService;
            _form = new Dictionary<string, string>
            {
                ["Name"] = "",
                ["Title"] = "",
                ["Genre"] = "",
                ["Length"] = ""
            };

            _formFocus = _form.ElementAt(0).Key;
        }

        private void RenderForm()
        {
            foreach (KeyValuePair<string, string> entry in _form)
            {

                if (entry.Key == _formFocus)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }

                Console.WriteLine(entry.Key);
                Console.WriteLine(entry.Value);

                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void OnActivate(object data)
        {
            // Reload stuff
        }

        public ScreenResult OnInput(ConsoleKey key)
        {
            if (key == ConsoleKey.Escape)
            {
                return new ScreenResult(ScreenResult.ResultType.CreateExit, new object { });
            }

            int currIndex = _form.Values.ToList().IndexOf(_formFocus);

            Console.WriteLine(currIndex);

            ScreenResult result;

            switch (key)
            {
                case ConsoleKey.Escape:
                    result = new ScreenResult(ScreenResult.ResultType.CreateExit, new object { });
                    break;

                case ConsoleKey.UpArrow:
                    //if (currIndex != 0) _formFocus = _form.ElementAt(currIndex - 1).Key;
                    Console.WriteLine(_form.ElementAt(currIndex + 1).Key);
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;

                case ConsoleKey.DownArrow:
                    //if (currIndex != _form.Count - 1) _formFocus = _form.ElementAt(currIndex + 1).Key;
                    Console.WriteLine(_form.ElementAt(currIndex + 1).Key);
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;

                default:
                    Console.WriteLine("Lägg till låt");
                    //_form[_formFocus] += key.ToString();
                    result = new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
                    break;
            }

            RenderForm();

            return result;
        }
    }
}