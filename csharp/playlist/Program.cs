using System;
using System.Collections.Generic;

namespace playlist
{
    class Program
    {

        // static ScrollingTable table;
        // static List<Song> playlist = new List<Song> { };


        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var playlistService = new PlaylistService();
            var manager = new ScreenManager(
                playlistService,
                new List<Type> { typeof(Playlist), typeof(Edit), typeof(Create) }
            );
        }


    }
}
