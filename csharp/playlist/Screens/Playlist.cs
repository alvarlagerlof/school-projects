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
                new List<string> { "#", "Name", "Artist", "Genre", "Length" }
            );

            AddSongsToTableAll();

        }

        private void AddSongsToTableAll()
        {
            foreach (Song song in _playlistService.GetAll())
            {
                _table.AddItem(song.ID.ToString(), new List<object> { song.Number, song.Title, song.Artist, song.Genre, song.Playtime });
            }
        }

        public void OnActivate(object data)
        {
            _table.RemoveAll(s => s != null);
            _table.ClearSelections();
            AddSongsToTableAll();

        }

        public ScreenResult OnInput(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Escape)
            {
                return new ScreenResult(ScreenResult.ResultType.GlobalExit, new object { });
            }

            return _table.OnInput(key);
        }
    }
}