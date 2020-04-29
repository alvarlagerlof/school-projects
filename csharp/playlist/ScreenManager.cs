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

        public void SwitchScreen(Type type)
        {
            _activeScreen = _screens[type];
            _activeScreen.OnActivate();
        }

        public void OnInput(ConsoleKey key)
        {
            ScreenResult result = _activeScreen.OnInput(key);

            switch (result.Type)
            {
                case ScreenResult.ResultType.GlobalExit:
                    Environment.Exit(0);
                    break;
                case ScreenResult.ResultType.CreateExit:
                    SwitchScreen(typeof(Playlist));
                    break;
                case ScreenResult.ResultType.EditExit:
                    SwitchScreen(typeof(Playlist));
                    break;
                case ScreenResult.ResultType.Neutral:
                    break;
            }

        }


    }
}