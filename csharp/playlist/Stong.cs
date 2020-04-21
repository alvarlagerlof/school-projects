using System;

namespace playlist
{
    class Song
    {
        public Song(string title, string artist, string genre, int playtime)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            Playtime = playtime;
        }

        public string Title { get; set; } = default!;
        public string Artist { get; set; } = default!;
        public string Genre { get; set; } = default!;
        public int Playtime { get; set; } = default!;
    }
}
