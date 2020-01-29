using System;
using System.Collections.Generic;

namespace textgame
{
    public class Choice
    {
        public string Question { get; set; }
        public Dictionary<string, object> Options { get; set; }

        public Choice() {}
        
        public Choice(string question, Dictionary<string, object> options)
        {
            Question = question;
            Options = options;
        }
    }

}
