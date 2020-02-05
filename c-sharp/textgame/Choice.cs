using System;
using System.Collections.Generic;

namespace textgame
{
    public class Choice
    {
        public string Question { get; set; }
        public Dictionary<string, Func<Choice?>> Options { get; set; }

        public Choice() {}
        
        public Choice(string question, Dictionary<string, Func<Choice?>> options)
        {
            Question = question;
            Options = options;
        }
    }

}
