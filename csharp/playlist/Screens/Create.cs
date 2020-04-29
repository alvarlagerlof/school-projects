using System;
using System.Collections.Generic;

namespace playlist
{
    class Create : IScreen
    {
        private PlaylistService _playlistService;

        public Create(PlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        public void OnActivate()
        {
            // Reload stuff
        }

        public ScreenResult OnInput(ConsoleKey key)
        {
            Console.WriteLine("CREATE");

            if (key == ConsoleKey.Escape)
            {
                return new ScreenResult(ScreenResult.ResultType.CreateExit, new object { });
            }
            else
            {
                return new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
            }
        }
    }
}