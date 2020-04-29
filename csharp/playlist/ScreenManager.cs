using System;
using System.Collections.Generic;

namespace playlist
{
    class ScreenManager
    {
        private IScreen _activeScreen;
        private Dictionary<Type, IScreen> _screens = new Dictionary<Type, IScreen> { };

        public ScreenManager(PlaylistService playlistService, List<Type> screens)
        {
            foreach (Type type in screens)
            {
                _screens.Add(type, (IScreen)Activator.CreateInstance(type, playlistService));
            }
        }

        public void SwitchScreen(Type type, object data)
        {
            Console.Clear();
            _activeScreen = _screens[type];
            _activeScreen.OnActivate(data);
            _activeScreen.OnInput(new ConsoleKeyInfo());
        }

        public void OnInput(ConsoleKeyInfo key)
        {
            Console.Clear();
            ScreenResult result = _activeScreen.OnInput(key);

            switch (result.Type)
            {
                case ScreenResult.ResultType.GlobalExit:
                    Environment.Exit(0);
                    break;
                case ScreenResult.ResultType.CreateExit:
                    SwitchScreen(typeof(Playlist), new object { });
                    break;
                case ScreenResult.ResultType.EditExit:
                    SwitchScreen(typeof(Playlist), new object { });
                    break;
                case ScreenResult.ResultType.CreateOpen:
                    SwitchScreen(typeof(CreateEdit), new object { });
                    break;
                case ScreenResult.ResultType.EditOpen:
                    SwitchScreen(typeof(CreateEdit), result.Data);
                    break;
                case ScreenResult.ResultType.Neutral:
                    break;
            }
        }
    }
}