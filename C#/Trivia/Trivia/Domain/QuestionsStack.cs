using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionsStack
    {
        private readonly string _category;
        private readonly LinkedList<string> _questions = new LinkedList<string>();
        private IQuestionsRepository _questionRepository;
        public QuestionsStack(string category, IQuestionsRepository questionRepository)
        {
            _category = category;
            this._questionRepository = questionRepository;
            _questions = questionRepository.GetQuestion(_category);
        }

        public void AskQuestionAndDiscardIt()
        {
            Console.WriteLine("The category is " + _category);
            Console.WriteLine(_questions.First());
            _questions.RemoveFirst();
        }

       
    }
}