using System;

namespace playlist
{
    public class LaunchPayload
    {

        public Type NextScreen;
        public object Payload;
        public LaunchPayload(Type nextScreen, object payload)
        {
            NextScreen = nextScreen;
            Payload = payload;
        }
    }
}