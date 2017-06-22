using System;
using System.Collections.Generic;

namespace Trivia
{
    public interface IQuestionsRepository
    {
         LinkedList<String> GetQuestion(String category); 
    }

    class QuestionsRepositoryFromFile : IQuestionsRepository
    {
        public LinkedList<string> GetQuestion(string category)
        {
            throw new NotImplementedException();
        }
    }

    class QuestionsRepositorySql : IQuestionsRepository
    {
        public LinkedList<string> GetQuestion(string category)
        {
            throw new NotImplementedException();
        }

        
    }
}