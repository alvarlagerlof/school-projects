using System;
using System.Collections.Generic;

namespace playlist
{
    class Edit : IScreen
    {
        private PlaylistService _playlistService;

        public Edit(PlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        public void OnActivate(object data)
        {
            Console.WriteLine("EDIT");
            Console.ReadKey();
        }

        public ScreenResult OnInput(ConsoleKey key)
        {
            Console.WriteLine("EDIT");

            if (key == ConsoleKey.Escape)
            {
                return new ScreenResult(ScreenResult.ResultType.EditExit, new object { });
            }
            else
            {
                return new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
            }

        }
    }
}