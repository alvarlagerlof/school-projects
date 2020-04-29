using System;
using System.Collections.Generic;

namespace playlist
{
    class Edit : IScreen
    {
        PlaylistService _playlistService;

        public Edit(PlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        public LaunchPayload OnActivate(LaunchPayload payload)
        {
            Console.WriteLine("Hello from the edit screen");
            Console.ReadKey();
            return new LaunchPayload(typeof(Playlist), new object { });
        }
    }
}