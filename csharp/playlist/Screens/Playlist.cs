using System;
using System.Collections.Generic;

namespace playlist
{
    class Playlist : IScreen
    {
        private PlaylistService _playlistService;
        private ScrollingTable _table;
        private LaunchPayload _returnPayload;
        private bool _initialized;



        public Playlist(PlaylistService playlistService)
        {
            _playlistService = playlistService;
            _returnPayload = null;
            _table = new ScrollingTable(
                new List<string> { "Namn", "Artist", "Genre", "Längd" },
                () =>
                {
                    _returnPayload = new LaunchPayload(typeof(Create), new object { });
                },
                (string id) =>
                {
                    _returnPayload = new LaunchPayload(typeof(Edit), new object { });
                },
                (List<string> ids) =>
                {
                    _playlistService.RemoveAll(id => ids.Contains(id));
                    _table.RemoveAll(s => ids.Contains(s));
                }
            );

            foreach (Song song in _playlistService.GetAll())
            {
                _table.AddItem(Guid.NewGuid().ToString(), new List<string> { song.Title, song.Artist, song.Genre, song.Playtime });
            }


        }

        public LaunchPayload OnActivate(LaunchPayload payload)
        {
            if (_returnPayload != null)
            {
                return _returnPayload;
            }

            _table.SendKey(Console.ReadKey().Key);
            Console.Clear();
            _table.Render();

            return OnActivate(payload);

        }
    }
}