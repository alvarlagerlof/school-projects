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

        public LaunchPayload OnActivate(LaunchPayload payload)
        {
            Console.WriteLine("EDIT");
            Console.ReadKey();
            return new LaunchPayload(typeof(Playlist), new object { });
        }
    }
}