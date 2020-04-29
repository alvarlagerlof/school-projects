using System;
using System.Collections.Generic;

namespace playlist
{
    class Playlist : IScreen
    {
        private PlaylistService _playlistService;
        private ScrollingTable _table;


        public Playlist(PlaylistService playlistService)
        {
            _playlistService = playlistService;
            _table = new ScrollingTable(
                new List<string> { "Namn", "Artist", "Genre", "Längd" }
            );

            foreach (Song song in _playlistService.GetAll())
            {
                _table.AddItem(Guid.NewGuid().ToString(), new List<string> { song.Title, song.Artist, song.Genre, song.Playtime });
            }


        }

        public void OnActivate()
        {

        }

        public ScreenResult OnInput(ConsoleKey key)
        {
            Console.WriteLine("PLAYLIST");

            // Console.Clear();
            // _table.Render();

            if (key == ConsoleKey.C)
            {
                return new ScreenResult(ScreenResult.ResultType.CreateOpen, new object { });
            }
            else if (key == ConsoleKey.E)
            {
                return new ScreenResult(ScreenResult.ResultType.EditOpen, new object { });
            }
            else
            {
                return new ScreenResult(ScreenResult.ResultType.Neutral, new object { });
            }
        }
    }
}