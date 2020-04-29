using System;
using System.Collections.Generic;


namespace playlist
{
    public interface IScreen
    {
        void OnActivate(object data);

        ScreenResult OnInput(ConsoleKey key);

    }
}