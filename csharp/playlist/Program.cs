using System;
using System.Collections.Generic;

namespace playlist
{
    class Program
    {
        private static ScreenManager manager;
        private static PlaylistService playlistService;

        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            playlistService = new PlaylistService();
            manager = new ScreenManager(
                playlistService,
                new List<Type> { typeof(Playlist), typeof(Edit), typeof(Create) }
            );

            manager.SwitchScreen(typeof(Playlist), new object { });
            Loop();

        }

        static void Loop()
        {
            manager.OnInput(Console.ReadKey().Key);
            Loop();
        }
    }
}
