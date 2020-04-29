namespace playlist
{


    public class ScreenResult
    {
        public enum ResultType
        {
            GlobalExit,
            Neutral,
            EditExit,
            EditOpen,
            CreateExit,
            CreateOpen
        }

        public ResultType Type { get; set; } = default!;
        public object Data { get; set; } = default!;

        public ScreenResult(ResultType type, object data)
        {
            Type = type;
            Data = data;
        }
    }
}