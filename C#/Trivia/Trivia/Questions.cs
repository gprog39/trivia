using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    class Questions
    {
        public readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        public readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        public readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
        public readonly LinkedList<string> _rockQuestions = new LinkedList<string>();
        private List<QuestionStack> _questionStack = new List<QuestionStack>();
        private readonly Dictionary<int, string> _categories = new Dictionary<int, string>() { { 0, "Pop" }, { 1, "Science" }, { 2, "Sports" }, { 3, "Rock" } };
        public string CurrentCategory(int currentPlace)
        {
            return _categories[currentPlace % 4];
        }

        public Questions()
        {
            
        }
        public void AskQuestion(int currentPlace)
        {
            if (CurrentCategory(currentPlace) == "Pop")
            {
                Console.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (CurrentCategory(currentPlace) == "Science")
            {
                Console.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory(currentPlace) == "Sports")
            {
                Console.WriteLine(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }
            if (CurrentCategory(currentPlace) == "Rock")
            {
                Console.WriteLine(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            }
        }
        public string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }


    }
}
