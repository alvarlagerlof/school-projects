using System;
using System.Collections.Generic;

namespace textgame
{
    public class Choice
    {
        // I don't like commenting in classes, but this code
        // stores each part of the story

        // I used a Func to enable the story to have 
        // loopbacks. (returning to a place)
        // It is evaluated in GameHandler.cs as the code runs, 
        // meaning I do not get call stack full errors.
        // Choice is nullable to easily enable quiting the story

        public Choice() { }

        public Choice(string[] question, Dictionary<string, Func<Choice?>> options)
        {
            Question = question;
            Options = options;
        }

        public string[] Question { get; set; } = default!;
        public Dictionary<string, Func<Choice?>> Options { get; set; } = default!;
    }
}