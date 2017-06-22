using System;

namespace Trivia.Presentation
{
    public class ConsoleUi : IQuestionUI
    {
        public void DisplayMessage(String message)
        {
            Console.WriteLine(message);
        }
    }
}