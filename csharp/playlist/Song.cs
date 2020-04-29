using System;

namespace playlist
{
    class Song
    {

        public string ID = Guid.NewGuid().ToString();
        public string Title { get; set; } = default!;
        public string Artist { get; set; } = default!;
        public string Genre { get; set; } = default!;
        public string Playtime { get; set; } = default!;

        public Song(string title, string artist, string genre, string playtime)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            Playtime = playtime;
        }

    }
}
