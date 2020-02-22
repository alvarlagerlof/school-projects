using System;
using System.Collections.Generic;
using System.Threading;

namespace textgame
{
    class Program
    {
        private static bool playerHealthFull = false;
        private static bool playerBrokenCoconuts = false;

        private static bool playerHasSharpStone = false;
        private static bool playerHasBigStone = false;
        private static bool playerHasCoconuts = false;

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
                    "Välkommen till ett textspel skapat av Alvar Lagerlöf, med insperation från Robinson Crusoe.",
                    "Spelet kommer att presentera dig för ett antal alternativ på i olika delar av berättelsen. Dina val driver handlingen framåt.",
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
                Question = new string[] { "Det var inte riktigt rätt svar. Prova att klicka på pil ned (vänstra sidan av tangentbordet) och sedan på enter (knappen för ny rad) för att prova igen." },
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
                    "Stormen dånar med ett hiskeligt oljud som nästan spränger ditt huvud. Detta är icke en vanlig storm. Ty vanliga stormar kan ej sänka skepp som Royal William. Dessa mått av vågor hade ingen man eller kvinna sett i Europa på årtionden, kanske århundranden.",
                    "En våg slår dig i bakhuvudet och du är plötsligt under ytan. Totalt mörker råder i infernot i nedan himlen. Du var inte beredd och hann inte ta det djupa andetag du så väl hade behövt. Du simmar mot ytan och kommer upp efter vad som kändes som en en evighet i havsmonstrens djup.",
                    "Du får ingen vila, för cirka 30 meter bakom dig tornar en en mur av vatten upp sig, hög som Sankt Paulskatedralens valv. Inte ens horisonten är synlig. Om du ens hade kunnat se horisonten utan vågen, ty mörkret från åskmolnen och vattendropparna förda med vinden skapar ett mörkt dis som omfamnar hela verkligheten runtomkring dig.",
                    "Att begrava sig i mörket under stunder som dessa är dock ingen väg framåt och du bestämmer dig isället för att försöka överleva efter bästa förmåga. En ny våg nalkas och du måste göra något för att bryta denna eviga cykel av nästintil drunknande. \nVad gör du?"
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
                    "Med krafttag börjar du simma framåt, i samma riktning som vidundret bakom dig. Trots att du kämpar för livet tar vågen in på dig.",
                    "Även denna slår dig i bakhuvudet och du är tillbaka i havets inferno.",
                    "Virvarna är ännu värre den här gången. Ett evigt tummlande håller dig fast i det blöta mörkret. Till slut är du åter vid ytan. En till monstruös våg är på väg. \nVad gör du?"
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
            GameHandler.WriteSlowly("Du får ännu en våg i huvudet och du inser att livet har nått sin ände.");
            return GameOver();
        }

        static Choice BeginningDive()
        {
            return new Choice
            {
                Question = new string[] {
                    "Vågen närmar sig och vattenytan började nu resa sig framför dig till vad som kommer att bli en rysligt, nej fasanfullt, brant backe.",
                    "Du tar ett djupt andetag, ty du vet att du icke kommer att ha en sådan möjlighet under de tiotal mödosamma sekunder som du vet att du behöver vara i havets grepp. Med ett kraftigt simtag är du under. Var det mörkt förut så är det än mörkare nu. Med stor ansträngning kämpar du dig mot den mäktiga strömmen. Du strävar uppåt och framåt, osäker på om du någonsin kommer upp igen. Så, plötsligt är du vid ytan.",
                    "Nästa våg närmar sig, men vattenmassorna lyfter dig högre upp och du ser något alldeles speciellt."
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Nästa"] = () => new Choice
                    {
                        Question = new string[] {
                            "Ett svagt vitt ljus uppenbarade sig. När molnen tillfälligt separerar sig  strålar en strimma av månsken ned. Du beundrar den enorma skönheten och låter blicken följa silverstrålen nedåt. Där var inte de våldsamma dalar och toppar som de kraftiga vindarna givit upphov till, isället uppenbarar sig en svart siluett. Efter några sekunders blinkande börjar du urskilja ytterligare former längs kanten av silutten. Du anar stammar höga som kolonner med avlånga blad på toppen. Det måste vara palmer!",
                            "Du börjar simma mot det som du anar är en ö med förnyat hopp. Du stöter på något i vattnet. Trevandes hittar du en stel hand. En överlevande från skeppet tänker du, men det visar sig vara allt för sent. Du undrar hur många från Royal William som ännu är vid livet.",
                            "Plötsligt uppfattar du ett gnisslande brak alldeles bakom dig. Det är skrovet på båten som med oroande fart, snabbt som den snabbaste droska,  färdas mot dig. Plötsligt känner du en slag i huvudet och allt blir svart.. Plötsligt känner du en smäll i huvudet och allt blir svart. "
                        },
                        Options = new Dictionary<string, Func<Choice?>>()
                        {
                            ["Nästa"] = () => new Choice
                            {
                                Question = new string[] {
                                    "Värmen är outhärlig. Du finner att du ligger i sand. Du slår upp ögonbrynen och din blick möts av en vit strand. Den är helt tom på levande varelser förutom en krabba som går förbi fullkomligt ostört. Med en hunger som du aldrig tidigare har upplevt, kanske en sådan som trashankarna i slummen lider av, reser du dig tungt upp och tittar runt. Till höger ser du ett väldigt berg täckt av grönska och till vänster, bredvid några klippor en tät skog av palmer.\nVart ska du bege dig?",
                                },
                                Options = new Dictionary<string, Func<Choice?>>()
                                {
                                    ["Till palmerna"] = () => PalmTrees(),
                                    ["Till klipporna vid stranden"] = () => Cliffs(),
                                    ["Till berget"] = () => Mountain(),
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
                "Du går fram till berget. Det är det högsta berg du någonsin har sett. Du anar en svag rök på toppen och misstänker att berget i själva verket är en vulkan. Det är emellertid svårt att avgöra ty hela ytan är täckt av ymmnig grönska.\nVad gör du?",
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
                    "Du börjar marschen upp för berget men allt eftersom du kommer högre upp känner du dig svagare, nej snarare närmare döden. Du inser att du är för trött och bestämmer dig för att gå tillbaka och leta efter någon form av proviant.\nVad gör du?",
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
            GameHandler.WriteSlowly("Du börjar gå den långa vägen upp för berget. Det är brant och luften är fuktig, men du känner dig stark efter den näringsrika kokosmjölken. Du måste ständigt vara på din vakt, ty block hörs rasa genom skogen runtomkring dig. Efter timmar, nej evigheter, är du äntligen uppe på toppen och mycket riktigt är berget en vulkan, ty rök stiger från kratern.");
            GameHandler.WriteSlowly("Du ser nu öns väldighet och stranden du vakande på långt nere. Det rasande havet som fört dig från Royal William till denna gudsförgätna ö är nu stilla och blankt som en spegel. För att se även norra sidan av ön går du över till andra sidan kratern. Från en glänta i skogen långt där nere ser du röken från en eld och hör svaga hammarslag. Det finns människor på ön! Du är räddad!");
            return Win();
        }

        static Choice PalmTrees()
        {
            var questionFirstTime = new string[] {
                " Du beger dig i riktning mot palmerna. När du når fram svalkar skuggan skönt din brända rygg. Du sätter dig ned vid en stam för att vila. En bit bort på marken upptäcker du en kokosnöt. Du tittar upp och ser flera ovanför dig.\nVad gör du?",
            };

            var questionFollowingTime = new string[] {
                "Tillbaka vid palmerna. \nVad gör du?",
            };

            var options = new Dictionary<string, Func<Choice?>>()
            {
                ["Går till klipporna vid stranden"] = () => Cliffs(),
                ["Går till berget"] = () => Mountain(),
            };

            if (!playerHasCoconuts && !playerBrokenCoconuts)
            {
                options.Add("Försök ta ned kokosnötter", () => PalmTreesTakeDownFirst());
            }

            if (!playerHasCoconuts && playerBrokenCoconuts)
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
            var options = new Dictionary<string, Func<Choice?>>()
            {
                ["Går till klipporna vid stranden"] = () => Cliffs(),
                ["Går till berget"] = () => Mountain(),
            };


            if (playerHasSharpStone)
            {
                options.Add("Skär ned kokosnötter med din vassa sten", () => PalmTreesTakeDownFirstSucess());
            }

            return new Choice
            {
                Question = new string[] {
                    "Du börjar klätta upp längs stammen på en palm och det går förvånansvärt bra. Väl uppe går det dock sämre. Hur du än gör kan du inte få ned någon kokosnöt. Du behöver något vasst.\nVad gör du?",
                },
                Options = options
            };
        }

        static Choice PalmTreesTakeDownFirstSucess()
        {
            playerHasCoconuts = true;

            return new Choice
            {
                Question = new string[] {
                    "Med din vassa sten är det lätt att skära ned kokosnötter från trädet. Du lyckas få ned två stycken. Men då slår det dig att du inte kan komma åt innehållet. Du behöver något tungt att öppna dem med.\nVad gör du?",
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
                    "Det går lättare nu. Du är van. Du har nu två kokosnötter till. \nVad gör du?",
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
                "Du går till klipporna. De är stora som elefanter och varma som plåttak en solig dag. Men värmen förvånar dig inte ty den sol man kan få på dessa breddgrader är ofattbart mycket starkare än på Londons gator. Det nu nästan stilla havets vågor skvalpar mjukt runt klipporna.\nVad gör du nu?",
            };

            var questionFollowingTime = new string[] {
                "Tillbaka vid klipporna.\nVad gör du?",
            };

            var options = new Dictionary<string, Func<Choice?>>()
            {
                ["Går till palmerna"] = () => PalmTrees(),
                ["Går till berget"] = () => Mountain(),
            };

            if (!playerHasSharpStone)
                options.Add("Utforskar klipporna mer", () => CliffFindSharpStone());

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
                    "På toppen av klipporna ligger en helt vit sten, vit som den renaste marmor. Du plockar upp den och beundrar dess skönhet. Du känner plötsligt ett sting  i handen och märker att du blöder. Stenen är visst vass som en knivsegg. Den måste ha legat där i århundraden, ostörd av havets  stormar.\nVart beger du dig med din nya upptäckt?\nVad gör du?",
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
                    "Du går vandrar runt bland stenarna, letandes efter en lämplig sten. I en skreva bakom ett block finner du den perfekta stenen.\nVad gör du nu?",
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Bär stenen till kokosnötterna"] = () => CliffsTransportCoconutsAndBreak(),
                }
            };
        }

        static Choice CliffsUseSharpStone()
        {
            playerHealthFull = true;

            return new Choice
            {
                Question = new string[] {
                    "Du håller din vassa sten mot kokosnöten och släpper den tunga ovanpå. Ett litet hål öppnas och du anar ett fantastiskt innehåll. Du dricker girigt från nöten.",
                    "Du blir genast piggare av den utsökta kokosmjölken.\nVad gör du med dina nya krafter?"
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
            return new Choice
            {
                Question = new string[] {
                    "Du försöker bära stenen, men inser att den har allt för stor tyngd för att du ska kunna bära den en längre sträcka, så du går istället tillbaka och hämtar dina två kokosnötter. Sedan släpper du stenen på kokosnöten. Kokosnöten spricker isär och all kokosmjölk rinner ut.\nHur går du tillväga nu?",
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Försöker igen på samma sätt"] = () => CliffsBreakCoconutAgain(),
                    ["Använder din vassa sten"] = () => CliffsUseSharpStone(),
                }
            };
        }

        static Choice CliffsBreakCoconutAgain()
        {
            playerHasCoconuts = false;
            playerBrokenCoconuts = true;

            return new Choice
            {
                Question = new string[] {
                    "Även denna kokosnöt brister och all kokosmjölk går förlorad. Du har nu slut på kokosnötter.\nVad gör du nu?",
                },
                Options = new Dictionary<string, Func<Choice?>>()
                {
                    ["Går tillbaka till palmerna"] = () => PalmTrees(),
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