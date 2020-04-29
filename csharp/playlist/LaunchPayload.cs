using System;

namespace playlist
{
    public class LaunchPayload
    {

        public Type NextScreen;
        public object Data;
        public LaunchPayload(Type nextScreen, object data)
        {
            NextScreen = nextScreen;
            Data = data;
        }
    }
}