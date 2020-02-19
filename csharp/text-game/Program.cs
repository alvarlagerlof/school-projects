using System;
using System.Collections.Generic;
using System.Threading;

namespace textgame
{
    class Program
    {

        private static bool playerHealthFull = false;
        private static bool playerHasSharpStone = false;
        private static bool playerHasBigStone = false;
        private static bool playerHasCoconuts = false;

        private static bool playerHasBrokenCoconuts = false;


        private static bool playerVisitedCliffs = false;

        private static bool playerVisitedPalmTrees = false;

        private static bool playerVisitedMountain = false;



        static void Main(string[] args)
        {

            // This is where the first part of the story is defined.
            // Depending on the user choice, it is built up to more parts
            // as the user plays.

            Choice mainStory = new Choice
            {
                Question = new string[] {
                    "Välkommen till ett textspel skapat av Alvar Lagerlöf, med insperation från Robinson Crusoe. ",
                    "Spelet kommer att presentera dig med ett antal alternativ på flera ställen. Dina val driver storyn framåt.",
                    "Du navigerar med piltangenterna på tangentbordet samt enter-knappen. För att testa att du förstår, vad är 1+2?"
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["7"] = () => IntoductionAnswerSeven(),
                    ["3"] = () => IntoductionAnswerThree(),
                }
            };

            // Basic console setup and handing the story 
            // to the "parser"
            Console.CursorVisible = true;
            GameHandler.PresentChoice(mainStory, 0, true);
        }






        static Choice Example()
        {
            return new Choice
            {
                Question = new string[] {
                    "Example",
                    "Example"
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Example"] = () => Example(),
                    ["Example"] = () => Example(),
                }
            };
        }








        static Choice IntoductionAnswerThree()
        {
            return new Choice
            {
                Question = new string[] { "Det var rätt svar! Du kommer klara detta utmärkt. Redo att starta?" },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Ja, jag är redo!"] = () => Beginning(),
                }
            };
        }

        static Choice IntoductionAnswerSeven()
        {
            return new Choice
            {
                Question = new string[] { "Det var inte riktigt rätt svar. Prova att klicka på pil ned (vänstra sidan av tangentbordet) och sedan på enter (knappen för ny rad)." },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Prova igen"] = () => IntoductionAnswerTryAgain(),
                }
            };
        }

        static Choice IntoductionAnswerTryAgain()
        {
            return new Choice
            {
                Question = new string[] { "Okej, vad är 1+2?" },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["7"] = () => IntoductionAnswerSeven(),
                    ["3"] = () => IntoductionAnswerThree(),
                }
            };
        }

        static Choice Beginning()
        {
            return new Choice
            {
                Question = new string[] {
                    "Stormen dånade med en hiskeligt oljud. Detta är icke en vanlig strom. Ty vanliga stormar kan ej sänka skepp som Royal William. Dessa mått av vågor hade ingen man eller kvinna sett i Europa på årtionden.",
                    "En våg slår dig i bakhuvudet och du är återigen under ytan. Denna gång var du så oberädd att du inte han ta djupt andetag innan. Du simmar åter mot ytan och kommer upp efter vad som kändes som en halv minut under ytan.",
                    "Cirka 30 meter bakom dig tornar en en mur av vatten hög som Sank Paulskatedralesn valv upp sig; inte ens horisonten är synlig. Om du ens hade sett horisonten utan vågen, ty mörkret från åskmolnen och vattendropparna förda med vinden skapade ett mörkt dis som omfamnande hela verkligheten runt omkring dig.",
                    "Att reflektera över mörket i tider som dessa är dock inte smart, och du bestämmer dig isället för att försöka överleva på bästa sätt du kan. På väg är en ny våg och något måste göras för att bryta denna eviga cykel av nästintil drunknande. \nVad gör du?"
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Simmar framåt"] = () => BeginningSwimForward(),
                    ["Dyker under vågen"] = () => BeginningDive(),
                }
            };
        }


        static Choice BeginningSwimForward()
        {
            return new Choice
            {
                Question = new string[] {
                    "Med krafttag börjar du simma framåt, i samma riktning som vidundret bakom dig. Trots att du kämpar för livet tar vågen in på dig. Även denna kommer att så dig i bakhuvudet och du är åter under. ",
                    "Virvarna är ännu värre den här gången. Ett evigt tummlande håller dig fast i det blöta mörkret. ",
                    "Nu är du åter vid ytan. En till våg är på väg. Det funkade inte. \nVad gör du nu?"
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Provar igen"] = () => BeginningSwimForwardAgain(),
                    ["Dyker under nästa våg"] = () => BeginningDive(),
                }
            };
        }

        static Choice? BeginningSwimForwardAgain()
        {
            GameHandler.WriteSlowly("Du får ännu en våg i huvudet och dör");
            return GameOver();
        }

        static Choice BeginningDive()
        {
            return new Choice
            {
                Question = new string[] {
                    "Vågen närmar sig och vattenytan började nu resa framför dig till vad som kom att bli en hiskeligt brant backe. ",
                    "Med ett kraftift simtag är du under. Var det mörkt förut så är är det mörkare nu. Med stor ansträngning kämpar du dig emot den väldiga strömmen. Uppåt och framåt. Så, plötsligt är du vid ytan. ",
                    "Nästa väg är på väg, men du är nu i högre altitud än tidigare och du ser något alldeless speciellt."
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Nästa"] = () => new Choice
                    {
                        Question = new string[] {
                            "Ett svagt vitt ljud uppenbarade sig. Molnens tillfälliga separation lät en strimma av månsken stråla ned. Du beundrar dig över den enorma sköneheten och låter blicken följa strålen ned. Inte var där de våldsamma dalar och toppar som de kraftiga vidrarna gett upphov till, isället uppenbarar sig en svart silhouette. Efter några sekunders blinkande börjar du urskillja ytterligare former längs kanten av silhoetten. Stammar långa som girraffer med avlånga blad på toppen. Det måste vara, palmer!",
                            "Du börjar simma mot ön med förnyat hopp. Du stöter på något i vattnet. Trevandes hittar du en hand. En överlevande från skeppet tänker du, men det visar sig vara allt för sent. Du undrar hur många från Royal William som ännu är vid livet.",
                            "Plötsligt uppfattar du ett gnisslande brak alldeles bakom dig. Det är skrovet på båten som är med oroande fart färdas mot dig. Plötsligt känner du en smäll i huvudet och allt blir svart. "
                        },
                        Options = new Dictionary<string, Func<Choice?>>()
                        {
                            ["Nästa"] = () => new Choice
                            {
                                Question = new string[] {
                                    "Värmen är outhärlig. Du finner att du ligger i sand. Du slår upp ögonbrynen och din blick möts av en vit strand. En krabba går förbi fullkomligt ostört på väg mot några klippor en bit bort. Du reser dig upp och tittat runt. Ett väldigt berg täckt av grönska. \nVad gör du?",
                                },
                                Options = new Dictionary<string, Func<Choice?>>()
                                {
                                    ["Går till palmerna"] = () => PalmTrees(),
                                    ["Går till klipporna vid stranden"] = () => Cliffs(),
                                    ["Går till berget"] = () => Mountain(),
                                }
                            }
                        }
                    },
                }
            };
        }


        static Choice Mountain()
        {
            var firstTime = new string[] {
                "Du går fram till berget. Det är högt som inget annat. Totalt täckt av grönska. \nVad gör du?",
            };

            var followingTime = new string[] {
                "Tillbaka vid berget. \nVad gör du?",
            };

            var question = playerVisitedMountain ? followingTime : firstTime;
            playerVisitedMountain = true;

            return new Choice
            {
                Question = question,
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Klättar upp för berget"] = () => playerHealthFull ? MountainClimbSuccess() : MountainClimbFailure(),
                    ["Går till palmerna"] = () => PalmTrees(),
                    ["Går till klipporna vid stranden"] = () => Cliffs(),
                }
            };
        }

        static Choice MountainClimbFailure()
        {
            return new Choice
            {
                Question = new string[] {
                    "Du är för trött och törstig för att gå upp här. Leta efter något att äta. \nVad gör du?",
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Går till palmerna"] = () => PalmTrees(),
                    ["Går till klipporna vid stranden"] = () => Cliffs(),
                }
            };
        }

        static Choice? MountainClimbSuccess()
        {
            GameHandler.WriteSlowly("Du börjar gå upp den långa vägen upp för berget. Det är tungt men efter en timme är du uppe. Där uppe ser du en båt. Du är räddad!");
            return Win();
        }



        static Choice PalmTrees()
        {
            var questionFirstTime = new string[] {
                "Du beger dig i riktning mot palmerna. Skuggan är skönt svalkande. Du sätter dig ned vid en stam för att vila. Då ser du en bit bort en kokosnöt. Du tittar upp och ser flera stycken övanför dig. \nVad gör du?",
            };

            var questionFollowingTime = new string[] {
                "Tillbaka till palmerna. \nVad gör du?",
            };

            var options = new Dictionary<string, Func<Choice?>>()
            {
                ["Går till klipporna vid stranden"] = () => Cliffs(),
                ["Går till berget"] = () => Mountain(),
            };

            if (!playerHasCoconuts && !playerHasBrokenCoconuts)
            {
                options.Add("Försök ta ned kokosnötter", () => PalmTreesTakeDownFirst());
            }

            if (!playerHasCoconuts && playerHasBrokenCoconuts)
            {
                options.Add("Ta ned fler kokosnötter", () => PalmTreesTakeDownFollowing());
            }

            var toReturn = new Choice
            {
                Question = playerVisitedPalmTrees ? questionFollowingTime : questionFirstTime,
                Options = options
            };

            playerVisitedPalmTrees = true;

            return toReturn;
        }

        static Choice PalmTreesTakeDownFirst()
        {
            var noSharpStone = new string[] {
                "Palmerna är alla höga. Du börjar klätta upp på dem, och det går förvånadsvärt bra. Väl uppe går det dock sämre. Hur du än gör kan du inte få ned dem. Du behöver något vasst. Vad för du?",
            };

            var sharpStone = new string[] {
                "Palmerna är alla höga. Du börjar klätta upp på dem, och det går förvånadsvärt bra. Här kan du anväda din vassa sten. Vad för du?",
            };

            var optionsBase = new Dictionary<string, Func<Choice?>>()
            {
                ["Går till klipporna vid stranden"] = () => Cliffs(),
                ["Går till berget"] = () => Mountain(),
            };

            var optionsSharpStone = new Dictionary<string, Func<Choice?>>()
            {
                ["Skär ned kokosnötter med din vassa sten"] = () => PalmTreesTakeDownFirstSucess(),
                ["Går till klipporna vid stranden"] = () => Cliffs(),
                ["Går till berget"] = () => Mountain(),
            };

            return new Choice
            {
                Question = new string[] {
                    "Palmerna är alla höga. Du börjar klätta upp på dem, och det går förvånadsvärt bra. Väl uppe går det dock sämre. Hur du än gör kan du inte få ned dem hur du än gör. Du behöver något vasst. Vad för du?",
                },
                Options = playerHasSharpStone ? optionsSharpStone : optionsBase
            };
        }

        static Choice PalmTreesTakeDownFirstSucess()
        {
            playerHasCoconuts = true;

            return new Choice
            {
                Question = new string[] {
                    "Med din vassa sten är det lätt att skära ned flera kokosnötter från trädet. Du klättar ned för att äntligen få dricka något. Men då slår det dig att du inte kan öppna kokosnötterna. Du behöver något tungt att mosa dem med. \nVad gör du?",
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Går till klipporna vid stranden"] = () => Cliffs(),
                    ["Går till berget"] = () => Mountain(),
                }
            };
        }

        static Choice PalmTreesTakeDownFollowing()
        {
            playerHasCoconuts = true;

            return new Choice
            {
                Question = new string[] {
                    "Det går lättare nu. Du är van. Du har nu fler kokosnötter. Du bär bort den till stranden där din stora sten är. \nVad gör du?",
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Använd din vassa sten den här gången"] = () => CliffsUseSharpStone(),
                }
            };
        }



        static Choice Cliffs()
        {
            var questionFirstTime = new string[] {
                "Klipporna var stora. Vattnet skvalpade stilla runt dem. Runtomrking ligger lite stenar. \nVad gör du?",
            };

            var questionFollowingTime = new string[] {
                "Tillbaka till klipporna. \nVad gör du?",
            };

            var options = new Dictionary<string, Func<Choice?>>()
            {
                ["Går till palmerna"] = () => PalmTrees(),
                ["Går till berget"] = () => Mountain(),
            };

            if (!playerHasSharpStone)
                options.Add("Utforska klippor mer", () => CliffFindSharpStone());

            if (playerHasCoconuts && playerHasSharpStone && !playerHasBigStone)
                options.Add("Leta efter stora stenar för att öppna kokosnöterna", () => CliffFindBigStone());

            playerVisitedCliffs = true;

            return new Choice
            {
                Question = playerVisitedCliffs ? questionFollowingTime : questionFirstTime,
                Options = options
            };
        }

        static Choice CliffFindSharpStone()
        {
            playerHasSharpStone = true;

            return new Choice
            {
                Question = new string[] {
                    "Du vandrar runt lite och ser plötsigt en sak. På toppen av en a stenarna låg en helt vit sten. Du plockar upp den och granskar den. Du kände plötsligt sting i handen och märker att du blöder. Stenen var vass. Den måste ha legat där i århundraden, ostörd av havets stormar. Du plockar upp den. \nVad gör du?",
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Går till palmerna"] = () => PalmTrees(),
                    ["Går till berget"] = () => Mountain(),
                }
            };
        }

        static Choice CliffFindBigStone()
        {
            playerHasBigStone = true;

            return new Choice
            {
                Question = new string[] {
                    "Du går runt lite bland stenarna. Du hittar till slut en som är lagom stor. \nVad gör du?",
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Bär kokosnötter till stenen"] = () => CliffsTransportCoconutsAndBreak(),
                }
            };
        }

        static Choice CliffsUseSharpStone()
        {
            playerHealthFull = true;

            return new Choice
            {
                Question = new string[] {
                    "Du håller din vassa sten mot kokosnöten och släpper den tunga stenen övanpå. Ett litet hål öppnas och du kan nu änligen dricka. Du blir genast piggare av den goda kokosmjölken. \nVad gör du med dina nya krafter?",
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Går till palmerna"] = () => PalmTrees(),
                    ["Går till berget"] = () => Mountain(),
                }
            };
        }

        static Choice CliffsTransportCoconutsAndBreak()
        {
            playerHealthFull = true;

            return new Choice
            {
                Question = new string[] {
                    "Stenen är för tung för att bära en längre sträcka så du går tillbaka och hämtar dina två kokosnötter. Sedan släpper du den på kokosnöten. Hela kokosnöten spricker och all kokosmjölk rinner ut. \nVad gör du?",
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Försöker igen"] = () => CliffsBreakCoconutAgain(),
                    ["Använder din vassa sten"] = () => CliffsUseSharpStone(),
                }
            };
        }

        static Choice CliffsBreakCoconutAgain()
        {
            playerHasCoconuts = false;
            playerHasBrokenCoconuts = true;

            return new Choice
            {
                Question = new string[] {
                    "Även denna kokosnöt spricker och all kokosmjölk rinner ut. Du har nu slut på kokosnötter. \nVad gör du?",
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Går till palmerna och hämtar fler"] = () => PalmTrees(),
                }
            };
        }






        public static Choice? GameOver()
        {
            Thread.Sleep(500);
            GameHandler.WriteSlowly("GAME OVER");
            return Exit();
        }

        public static Choice? Win()
        {
            Thread.Sleep(500);
            GameHandler.WriteSlowly("GRATTIS! Du klarade spelet!");
            return Exit();
        }

        public static Choice? Exit()
        {
            Thread.Sleep(500);
            Console.Clear();
            Environment.Exit(0);
            return null;
        }
    }
}