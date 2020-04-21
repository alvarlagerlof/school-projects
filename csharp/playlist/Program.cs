using System;
using System.Collections.Generic;

namespace playlist
{
    class Program
    {

        static ScrollingTable table;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Song> playlist = new List<Song> { };

            table = new ScrollingTable(
                new List<string> { "Namn", "Artist", "Genre", "Längd" },
                new Dictionary<string, Action> { }
            );

            table.AddItem(new List<string> { "Spring Of Home", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Imagine My Shadow", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Loving My Name", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Time Heart", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Pretty Machine", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Baby, Maybe Tomorrow", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Sweetie, This Love Of Mine", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "She's Crazy", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "He Thinks I Don't Care", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Date Of A Man", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Matter Of Stars", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Kiss My Way2", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Troubles Of His Music", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Man Machine", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Super Fever", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Babe, Remember Yesterday?", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "I Think I Like You", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "He Thinks I'm A Troublemaker", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "I Hope We Can't Stop", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Devil For You And I", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Angel", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Give Her Soul", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Open Up To Her Tears", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "More Romance", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Home Mind", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Honey, I'll Love You Forever", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Spring Of Home", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Imagine My Shadow", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Loving My Name", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Time Heart", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Pretty Machine", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Baby, Maybe Tomorrow", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Sweetie, This Love Of Mine", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "She's Crazy", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "He Thinks I Don't Care", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Date Of A Man", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Matter Of Stars", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Kiss My Way2", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Troubles Of His Music", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Man Machine", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Super Fever", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Babe, Remember Yesterday?", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "I Think I Like You", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "He Thinks I'm A Troublemaker", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "I Hope We Can't Stop", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Devil For You And I", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Angel", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Give Her Soul", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Open Up To Her Tears", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "More Romance", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Home Mind", "Various Artists", "Pop", "2:34" });
            table.AddItem(new List<string> { "Honey, I'll Love You Forever", "Various Artists", "Pop", "2:34" });

            table.Render();
            Loop();

        }

        static void Loop()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            table.SendKey(info.Key);
            table.Render();
            Loop();
        }
    }
}
