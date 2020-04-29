using System;

namespace playlist
{
    public class Song
    {

        //public string ID = Guid.NewGuid().ToString();
        public string ID { get; set; } = default!;
        public int Number { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Artist { get; set; } = default!;
        public string Genre { get; set; } = default!;
        public string Playtime { get; set; } = default!;

        public Song(int number, string title, string artist, string genre, string playtime)
        {
            ID = number.ToString();
            Number = number;
            Title = title;
            Artist = artist;
            Genre = genre;
            Playtime = playtime;
        }

        public override string ToString()
        {
            return Title;
        }

    }
}
