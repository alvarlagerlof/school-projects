using System;
using System.Collections.Generic;
using System.Linq;

namespace playlist
{
    class ScreenManager
    {

        private List<IScreen> _screens = new List<IScreen> { };

        public ScreenManager(PlaylistService playlistService, List<Type> screens)
        {
            foreach (Type type in screens)
            {
                _screens.Add((IScreen)Activator.CreateInstance(type, playlistService));
            }


            Loop(new LaunchPayload(screens[0], new object { }));
        }

        public void Loop(LaunchPayload prevData)
        {
            IScreen currentScreen = _screens.Find(screen => screen.GetType().Equals(prevData.NextScreen));
            LaunchPayload newData = currentScreen.OnActivate(prevData);
            Loop(newData);
        }
    }
}