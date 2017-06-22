using System;
using System.Collections.Generic;

namespace Trivia
{
    public class GeneratedQuestionsRepository: IQuestionsRepository
    {
        private LinkedList<String> questions;

        public LinkedList<string> GetQuestion(string category)
        {
            questions = new LinkedList<string>();
            for (var i = 0; i < 50; i++)
            {
                questions.AddLast(category + " Question " + i);
            }
            return questions;
        }
    }
}