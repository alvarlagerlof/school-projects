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
                _playlistService,
                new List<string> { "Name", "Artist", "Genre", "Length" }
            );

            foreach (Song song in _playlistService.GetAll())
            {
                _table.AddItem(Guid.NewGuid().ToString(), new List<string> { song.Title, song.Artist, song.Genre, song.Playtime });
            }
        }

        public void OnActivate(object data)
        {

        }

        public ScreenResult OnInput(ConsoleKey key)
        {
            if (key == ConsoleKey.Escape)
            {
                return new ScreenResult(ScreenResult.ResultType.GlobalExit, new object { });
            }

            return _table.OnInput(key);
        }
    }
}