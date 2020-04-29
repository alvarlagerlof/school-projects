using System;
using System.Collections.Generic;
using System.Linq;

namespace playlist
{
    public class PlaylistService
    {
        private List<Song> _playlist = new List<Song>();

        public PlaylistService()
        {
            _playlist.Add(new Song(1, "Spring Of Home", "Various Artists", "Rock", "4:23"));
            _playlist.Add(new Song(2, "Spring Of Spring", "Various Artists", "Rock", "4:23"));
            _playlist.Add(new Song(3, "Imagine My Shadow", "Various Artists", "Rock", "1:56"));
            _playlist.Add(new Song(4, "Loving My Name", "Various Artists", "Rock", "1:56"));
            _playlist.Add(new Song(5, "Time Heart", "Various Artists", "Rock", "1:56"));
            _playlist.Add(new Song(6, "Pretty Machine", "Various Artists", "Rock", "1:56"));
            _playlist.Add(new Song(7, "Baby, Maybe Tomorrow", "Various Artists", "Rock", "1:56"));
            _playlist.Add(new Song(8, "Sweetie, This Love Of Mine", "Various Artists", "Rap", "1:56"));
            _playlist.Add(new Song(9, "She's Crazy", "Various Artists", "Rap", "1:56"));
            _playlist.Add(new Song(10, "He Thinks I Don't Care", "Various Artists", "Guitar", "1:56"));
            _playlist.Add(new Song(11, "Date Of A Man", "Various Artists", "Guitar", "1:56"));
            _playlist.Add(new Song(12, "Matter Of Stars", "Various Artists", "Guitar", "1:56"));
            _playlist.Add(new Song(13, "Kiss My Way2", "Various Artists", "Guitar", "4:06"));
            _playlist.Add(new Song(14, "Troubles Of His Music", "Various Artists", "Guitar", "4:06"));
            _playlist.Add(new Song(15, "Man Machine", "Various Artists", "Guitar", "4:06"));
            _playlist.Add(new Song(16, "Super Fever", "Various Artists", "Classic", "4:06"));
            _playlist.Add(new Song(17, "Babe, Remember Yesterday?", "Various Artists", "Classic", "4:06"));
            _playlist.Add(new Song(18, "I Think I Like You", "Various Artists", "Classic", "4:06"));
            _playlist.Add(new Song(19, "He Thinks I'm A Troublemaker", "Various Artists", "Classic", "4:06"));
            _playlist.Add(new Song(20, "I Hope We Can't Stop", "Various Artists", "Classic", "4:06"));
            _playlist.Add(new Song(21, "Devil For You And I", "Various Artists", "Classic", "4:06"));
            _playlist.Add(new Song(22, "Angel", "Various Artists", "Classic", "4:06"));
            _playlist.Add(new Song(23, "Give Her Soul", "Various Artists", "Classic", "4:06"));
            _playlist.Add(new Song(24, "Open Up To Her Tears", "Various Artists", "Classic", "4:06"));
            _playlist.Add(new Song(25, "More Romance", "Various Artists", "Classic", "4:06"));
            _playlist.Add(new Song(26, "Home Mind", "Various Artists", "Classic", "4:06"));
            _playlist.Add(new Song(27, "Honey, I'll Love You Forever", "Popular Arist", "Pop", "4:06"));
            _playlist.Add(new Song(28, "Spring Of Home", "Popular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(29, "Imagine My Shadow", "Popular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(30, "Loving My Name", "Popular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(31, "Time Heart", "Popular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(32, "Pretty Machine", "Popular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(33, "Baby, Maybe Tomorrow", "Popular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(34, "Sweetie, This Love Of Mine", "Popular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(35, "She's Crazy", "Popular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(36, "He Thinks I Don't Care", "Popular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(37, "Date Of A Man", "Popular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(38, "Matter Of Stars", "Popular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(39, "Kiss My Way2", "Popular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(40, "Troubles Of His Music", "Unopular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(41, "Man Machine", "Unopular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(42, "Super Fever", "Unopular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(43, "Babe, Remember Yesterday?", "Unopular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(44, "I Think I Like You", "Unopular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(45, "He Thinks I'm A Troublemaker", "Unopular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(46, "I Hope We Can't Stop", "Unopular Arist", "Pop", "2:34"));
            _playlist.Add(new Song(47, "Devil For You And I", "Unopular Arist", "Pop", "4:23"));
            _playlist.Add(new Song(48, "Angel", "Various Artists", "Pop", "4:23"));
            _playlist.Add(new Song(49, "Give Her Soul", "Various Artists", "Pop", "4:23"));
            _playlist.Add(new Song(50, "Open Up To Her Tears", "Various Artists", "Pop", "4:23"));
            _playlist.Add(new Song(51, "More Romance", "Various Artists", "Pop", "4:23"));
            _playlist.Add(new Song(52, "Home Mind", "Various Artists", "Pop", "4:23"));
            _playlist.Add(new Song(53, "Honey, I'll Love You Forever", "Various Artists", "Pop", "4:23"));
        }

        public List<Song> GetAll()
        {
            return _playlist;
        }

        public void RemoveAll(Predicate<string> predicate)
        {
            foreach (Song song in _playlist)
            {
                if (predicate(song.ID))
                {
                    _playlist.Remove(song);
                }
            }
        }

        public int GetNextTrack()
        {
            return _playlist.Max(song => song.Number) + 1;
        }

        public void Add(Song song)
        {
            _playlist.Add(song);
        }

        public Song FindByID(String id)
        {
            return _playlist.Find(song => song.ID == id);
        }

        public void Update(Song updatedSong)
        {
            Song originalSong = _playlist.Find(song => song.ID == updatedSong.ID);
            originalSong.Title = updatedSong.Title;
            originalSong.Artist = updatedSong.Artist;
            originalSong.Genre = updatedSong.Genre;
            originalSong.Playtime = updatedSong.Playtime;
        }
    }
}


