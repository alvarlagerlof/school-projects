using System;
using System.Collections.Generic;


namespace playlist
{
    public interface IScreen
    {
        LaunchPayload OnActivate(LaunchPayload data);
    }
}