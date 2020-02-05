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
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Äta ett äpple"] = () => { Die(); return null; },
                    ["Gå någonstans"] = () => { return FoundHouse(); }
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
                    Options = new Dictionary<string, Func<Choice?>>()
                    {
                        ["Går in i huset"] = () => { return InsideHouse(); },
                        ["Flyr från monstret i huset"] = () => { Die(); return null; },
                    }
                };
        }

        static Choice InsideHouse() 
        {
            return new Choice
                {
                    Question = "Det är ett monster i huset.\nVad gör du?",
                    Options = new Dictionary<string, Func<Choice?>>()
                    {
                        ["Flyr"] = () => { Die(); return null; },
                        ["Kramar monstret"] = () => { return new Choice
                            {
                                Question = "Monstret blir din bästa vän och vill inte att du lämnar någonsin.\nVad gör du?",
                                Options = new Dictionary<string, Func<Choice?>>()
                                {
                                    ["Flyr"] = () => { Die(); return null; },
                                    ["Stannar där för evigt"] = () => { return new Choice
                                        {
                                            Question = "Monstret är nu trött på dig.\nVad gör du?",
                                            Options = new Dictionary<string, Func<Choice?>>()
                                            {
                                                ["Stannar med i huset och försöker lösa konflikten"] = () => { Die(); return null; },
                                                ["Flyr"] = () => { return Path(); }
                                            }
                                        };
                                    },
                                    ["Ringer polisen"] = () => { Die(); return null; }
                                }
                            };
                        },
                        ["Skriker på hjälp"] = () => { Die(); return null; },
                    }
                };
        }

        static Choice Path() 
        {
            return new Choice
                {
                    Question = "Du kom ut ur huset. I skogen ser du en liten stig. Du går dit.\nPlötsligt hör du ett ljud! PANG!\nVad gör du?",
                    Options = new Dictionary<string, Func<Choice?>>()
                    {
                        ["Flyr från skottet"] = () => { Die(); return null; },
                        ["Går långsamt mot ljudkällan"] = () => { return new Choice
                                {
                                    Question = "Det visar sig vara en kokosnöt.\nVad gör du?",
                                    Options = new Dictionary<string, Func<Choice?>>()
                                    {
                                        ["Går vidare"] = () => { return Garden(); },
                                    }
                                };
                        },
                        ["Flyr från bomben"] = () => { Die(); return null; },
                    }
                };
        }

        static Choice Garden() 
        {
            return new Choice
                {
                    Question = "Du ser nu en stor trädgråd. På en skylt finns det tre texter med varsin knapp.\nÖver detta står det 'Enligt alternativ mattematik, vilken beräkning är rätt?'",
                    Options = new Dictionary<string, Func<Choice?>>()
                    {
                        ["16 + 55 = 71 "] = () => { Die(); return null; },
                        ["32 / 4 = 8"] = () => { Die(); return null; },
                        ["2 * 3 + 4 = 64"] = () => { Win(); return null; },
                        ["2^3 = 8"] = () => { Die(); return null; },
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
