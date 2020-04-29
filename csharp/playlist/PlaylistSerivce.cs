using System;
using System.Collections.Generic;

namespace _playlist
{
    public class _playlistService
    {
        private readonly List<Song> _playlist = new List<Song>();

        public _playlistService()
        {
            _playlist.Add(new Song("Spring Of Home", "Various Artists", "Pop", "2:34"));
            _playlist.Add(new Song("Spring Of Home", "Various Artists", "Pop", "2:34"));
            _playlist.Add(new Song("Imagine My Shadow", "Various Artists", "Pop", "2:34"));
            _playlist.Add(new Song("Loving My Name", "Various Artists", "Pop", "2:34"));
        }


        public List<Song> GetAll()
        {
            return _playlist;
        }


        // public void Add(Song song)
        // {
        //     __playlist.Add(song);
        // }

        // public void Edit(string id, Song newData)
        // {
        //     // __playlist.Remove(originalName);
        //     // __playlist.Add(newName);
        // }

        // public void Delete(Song song)
        // {
        //     __playlist.Remove(song);
        // }


        //   _playlist.Add(new Song("Time Heart", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Pretty Machine", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Baby, Maybe Tomorrow", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Sweetie, This Love Of Mine", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("She's Crazy", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("He Thinks I Don't Care", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Date Of A Man", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Matter Of Stars", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Kiss My Way2", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Troubles Of His Music", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Man Machine", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Super Fever", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Babe, Remember Yesterday?", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("I Think I Like You", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("He Thinks I'm A Troublemaker", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("I Hope We Can't Stop", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Devil For You And I", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Angel", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Give Her Soul", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Open Up To Her Tears", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("More Romance", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Home Mind", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Honey, I'll Love You Forever", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Spring Of Home", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Imagine My Shadow", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Loving My Name", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Time Heart", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Pretty Machine", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Baby, Maybe Tomorrow", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Sweetie, This Love Of Mine", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("She's Crazy", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("He Thinks I Don't Care", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Date Of A Man", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Matter Of Stars", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Kiss My Way2", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Troubles Of His Music", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Man Machine", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Super Fever", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Babe, Remember Yesterday?", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("I Think I Like You", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("He Thinks I'm A Troublemaker", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("I Hope We Can't Stop", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Devil For You And I", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Angel", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Give Her Soul", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Open Up To Her Tears", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("More Romance", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Home Mind", "Various Artists", "Pop", "2:34"));
        //     _playlist.Add(new Song("Honey, I'll Love You Forever", "Various Artists", "Pop", "2:34"));
    }
}


