// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace playlist
// {
//     class ScreenManagerOLD
//     {
//         List<Screen> Screens;
//         Type currentScreenType;

//         public ScreenManagerOLD(List<Type> screens, Action onCreate, Action<string> onEdit, Action<List<string>> onDelete)
//         {
//             Action<Type, object> changeScreen = (Type screen, object payload) =>
//             {
//                 currentScreenType = screen;
//                 Screen currentScreen = Screens.Find(screen => screen.GetType().Equals(currentScreenType));
//                 currentScreen.Payload(payload);
//             };

//             foreach (Type type in screens)
//             {
//                 Screens.Add((Screen)Activator.CreateInstance(type, changeScreen, onCreate, onEdit, onDelete));
//             }
//         }

//         public void Loop()
//         {
//             Screen currentScreen = Screens.Find(screen => screen.GetType().Equals(currentScreenType));
//             ConsoleKeyInfo info = Console.ReadKey();
//             currentScreen.KeyInput(Console.ReadKey().Key);
//             Console.Clear();
//             currentScreen.Render();
//             Loop();
//         }

//     }
// }