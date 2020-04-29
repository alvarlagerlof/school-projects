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

        public LaunchPayload OnActivate(LaunchPayload payload)
        {
            Console.WriteLine("CREATE");
            Console.ReadKey();
            return new LaunchPayload(typeof(Playlist), new object { });
        }
    }
}