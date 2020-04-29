using System;
using System.Collections.Generic;


namespace playlist
{
    public interface IScreen
    {
        void OnActivate();

        ScreenResult OnInput(ConsoleKey key);

    }
}