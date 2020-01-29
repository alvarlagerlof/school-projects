using System;
using System.Collections.Generic;
using System.Threading;

namespace textgame
{
    class Program
    {
        static void Main(string[] args)
        {
            Choice mainStory = new Choice
            {
                Question = "Vad vill du göra?",
                Options = new Dictionary<string, object>()
                {
                    ["Äta ett äpple"] = new Action(() => Die()),
                    ["Gå någonstans"] = FoundHouse()
                }
            };

            Console.CursorVisible = true;
            GameHandler.PresentChoice(0, true, mainStory);
        }


        static Choice FoundHouse() 
        {
            return new Choice
                {
                    Question = "Du hittade ett hus.\nVad gör du nu?",
                    Options = new Dictionary<string, object>()
                    {
                        ["Går in i huset"] = InsideHouse(),
                        ["Flyr från monstret i huset"] = new Action(() => Die()),
                    }
                };
        }

        static Choice InsideHouse() 
        {
            return new Choice
                {
                    Question = "Det är ett monster i huset.\nVad gör du?",
                    Options = new Dictionary<string, object>()
                    {
                        ["Flyr"] = new Action(() => Die()),
                        ["Kramar monstret"] = new Choice
                            {
                                Question = "Monstret blir din bästa vän och vill inte att du lämnar någonsin.\nVad gör du?",
                                Options = new Dictionary<string, object>()
                                {
                                    ["Flyr"] = new Action(() => Die()),
                                    ["Stannar där för evigt"] = new Choice
                                        {
                                            Question = "Monstret är nu trött på dig.\nVad gör du?",
                                            Options = new Dictionary<string, object>()
                                            {
                                                ["Stannar med i huset och försöker lösa konflikten"] = new Action(() => Die()),
                                                ["Flyr"] = Path(),
                                            }
                                        },
                                    ["Ringer polisen"] = new Action(() => Die()),
                                }
                            },
                        ["Skriker på hjälp"] = new Action(() => Die()),
                    }
                };
        }

        static Choice Path() 
        {
            return new Choice
                {
                    Question = "Du kom ut ur huset. I skogen ser du en liten stig. Du går dit.\nPlötsligt hör du ett ljud! PANG!\nVad gör du?",
                    Options = new Dictionary<string, object>()
                    {
                        ["Flyr från skottet"] = new Action(() => Die()),
                        ["Går långsamt mot ljudkällan"] = new Choice
                                {
                                    Question = "Det visar sig vara en kokosnöt.\nVad gör du?",
                                    Options = new Dictionary<string, object>()
                                    {
                                        ["Går vidare"] = Garden(),
                                    }
                                }, 
                        ["Flyr från bomben"] = new Action(() => Die()),
                    }
                };
        }

        static Choice Garden() 
        {
            return new Choice
                {
                    Question = "Du ser nu en stor trädgråd. På en skylt finns det tre texter med varsin knapp.\nÖver detta står det 'Enligt alternativ mattematik, vilken beräkning är rätt?'",
                    Options = new Dictionary<string, object>()
                    {
                        ["16 + 55 = 71 "] = new Action(() => Die()),
                        ["32 / 4 = 8"] = new Action(() => Die()),
                        ["2 * 3 + 4 = 64"] =  new Action(() => Win()),
                        ["2^3 = 8"] = new Action(() => Die()),
                    }
                };
        }


        public static void Die() 
        {
            GameHandler.WriteSlowly("DU DOG");
            Thread.Sleep(500);
            Console.Clear();
            Environment.Exit(0);
        }

        public static void Win() 
        {
            GameHandler.WriteSlowly("GRATTIS!");
            GameHandler.WriteSlowly("Du klarade spelet");
            Thread.Sleep(2000);
            Console.Clear();
            GameHandler.WriteSlowly("Din vinst: System.IndexOutOfRangeException: 'Index was outside the bounds of...'");
            GameHandler.WriteSlowly("Just kidding");
            Thread.Sleep(50);
            Console.Clear();
            GameHandler.WriteSlowly("Bye");
            Thread.Sleep(50);
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
