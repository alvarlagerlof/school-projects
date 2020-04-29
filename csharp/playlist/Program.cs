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

            // table = new ScrollingTable(
            //     new List<string> { "Namn", "Artist", "Genre", "Längd" },
            //     () =>
            //     {
            //         // TODO: Screen create
            //     },
            //     (string id) =>
            //     {
            //         // TODO: Screen edit
            //     },
            //     (List<string> ids) =>
            //     {
            //         playlist.RemoveAll(song => ids.Contains(song.ID));
            //         table.RemoveAll(s => ids.Contains(s));
            //     }
            // );

            // playlist.Add(new Song("Spring Of Home", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Spring Of Home", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Imagine My Shadow", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Loving My Name", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Time Heart", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Pretty Machine", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Baby, Maybe Tomorrow", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Sweetie, This Love Of Mine", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("She's Crazy", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("He Thinks I Don't Care", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Date Of A Man", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Matter Of Stars", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Kiss My Way2", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Troubles Of His Music", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Man Machine", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Super Fever", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Babe, Remember Yesterday?", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("I Think I Like You", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("He Thinks I'm A Troublemaker", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("I Hope We Can't Stop", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Devil For You And I", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Angel", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Give Her Soul", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Open Up To Her Tears", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("More Romance", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Home Mind", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Honey, I'll Love You Forever", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Spring Of Home", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Imagine My Shadow", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Loving My Name", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Time Heart", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Pretty Machine", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Baby, Maybe Tomorrow", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Sweetie, This Love Of Mine", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("She's Crazy", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("He Thinks I Don't Care", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Date Of A Man", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Matter Of Stars", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Kiss My Way2", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Troubles Of His Music", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Man Machine", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Super Fever", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Babe, Remember Yesterday?", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("I Think I Like You", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("He Thinks I'm A Troublemaker", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("I Hope We Can't Stop", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Devil For You And I", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Angel", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Give Her Soul", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Open Up To Her Tears", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("More Romance", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Home Mind", "Various Artists", "Pop", "2:34"));
            // playlist.Add(new Song("Honey, I'll Love You Forever", "Various Artists", "Pop", "2:34"));

            // foreach (Song song in playlist)
            // {
            //     table.AddItem(Guid.NewGuid().ToString(), new List<string> { song.Title, song.Artist, song.Genre, song.Playtime });
            // }

            // //table.Render();
            // screenManager.Loop();

        }


    }
}
