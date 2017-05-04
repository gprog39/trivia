using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionsStack
    {
        private readonly string _category;
        private readonly LinkedList<string> questions = new LinkedList<string>();
        private IQuestionsRepository QuestionRepository;
        public QuestionsStack(string category, IQuestionsRepository QuestionRepository)
        {
            _category = category;
            this.QuestionRepository = QuestionRepository;
            questions = QuestionRepository.GetQuestion(_category);
        }

        public void AskQuestionAndDiscardIt()
        {
            Console.WriteLine("The category is " + _category);
            Console.WriteLine(questions.First());
            questions.RemoveFirst();
        }

       
    }
}