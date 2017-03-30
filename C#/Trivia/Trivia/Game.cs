using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly List<Player> _players = new List<Player>();
        private readonly Dictionary<int, string> _categories = new Dictionary<int, string>() {{0, "Pop"}, {1, "Science"}, {2, "Sports"}, {3, "Rock"}};

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();

        int _currentPlayer = 0;
        bool _isGettingOutOfPenaltyBox;

        public Game()
        {
            for (var i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast(createRockQuestion(i));
            }
        }

        public string createRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool isPlayable()
        {
            return (howManyPlayers() >= 2);
        }

        public bool add(string playerName)
        {
            _players.Add(new Player(playerName));

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public int howManyPlayers()
        {
            return _players.Count;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players[_currentPlayer].Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_players[_currentPlayer].InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_players[_currentPlayer].Name + " is getting out of the penalty box");
                    _players[_currentPlayer].Move(roll);

                    Console.WriteLine(_players[_currentPlayer].Name
                            + "'s new location is "
                            + _players[_currentPlayer].Place);
                    Console.WriteLine("The category is " + currentCategory());
                    askQuestion();
                }
                else
                {
                    Console.WriteLine(_players[_currentPlayer].Name + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                _players[_currentPlayer].Move(roll);

                Console.WriteLine(_players[_currentPlayer].Name
                        + "'s new location is "
                        + _players[_currentPlayer].Place);
                Console.WriteLine("The category is " + currentCategory());
                askQuestion();
            }

        }

        private void askQuestion()
        {
            if (currentCategory() == "Pop")
            {
                Console.WriteLine(popQuestions.First());
                popQuestions.RemoveFirst();
            }
            if (currentCategory() == "Science")
            {
                Console.WriteLine(scienceQuestions.First());
                scienceQuestions.RemoveFirst();
            }
            if (currentCategory() == "Sports")
            {
                Console.WriteLine(sportsQuestions.First());
                sportsQuestions.RemoveFirst();
            }
            if (currentCategory() == "Rock")
            {
                Console.WriteLine(rockQuestions.First());
                rockQuestions.RemoveFirst();
            }
        }


        private string currentCategory()
        {
            return _categories[_players[_currentPlayer].Place % 4];
        }

        public bool wasCorrectlyAnswered()
        {
            bool winner;
            if (_players[_currentPlayer].InPenaltyBox)
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _players[_currentPlayer].WinAGoldCoin();

                    winner = didPlayerWin();
                    changePlayer();

                    return winner;
                }

               changePlayer();
                return true;
            }

            Console.WriteLine("Answer was corrent!!!!");
            _players[_currentPlayer].WinAGoldCoin();

            winner = didPlayerWin();
            changePlayer();

            return winner;
        }

        private void changePlayer()
        {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }

        public bool wrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players[_currentPlayer].Name + " was sent to the penalty box");
            _players[_currentPlayer].GoToPenaltyBox();

            changePlayer();
            return true;
        }


        private bool didPlayerWin()
        {
            return _players[_currentPlayer].GoldCoins != 6;
        }
    }
}
