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


        public LaunchPayload OnActivate(LaunchPayload data)
        {
            Console.WriteLine("PLAYLIST");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.C:
                    return new LaunchPayload(typeof(Create), new object { });
                case ConsoleKey.E:
                    return new LaunchPayload(typeof(Edit), new object { });
                default:
                    return OnActivate(data);
            }

        }
    }
}