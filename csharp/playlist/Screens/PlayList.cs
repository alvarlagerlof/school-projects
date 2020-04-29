using System;

namespace playlist
{
    class Playlist : IScreen
    {
        PlaylistService _playlistService;

        public Playlist(PlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        public LaunchPayload OnActivate(LaunchPayload payload)
        {
            Console.WriteLine("Hello from the playlist screen");
            Console.ReadKey();
            return new LaunchPayload(typeof(Edit), new object { });
        }
    }
}