﻿using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool winner;
        private static IQuestionsRepository _questionRepository;
        public static void Main(String[] args)
        {
            _questionRepository = new GeneratedQuestionsRepository();
            for (var i = 0; i < 10; i++)
            {
                var players = new Players();
                players.Add("Chet");
                players.Add("Pat");
                players.Add("Sue");

                var questions = new Questions(new[] {"Pop", "Science", "Sports", "Rock"}, _questionRepository);

                var aGame = new Game(players, questions);

                Random rand = new Random(i);

                do
                {
                    aGame.Roll(rand.Next(5) + 1);

                    if (rand.Next(9) == 7)
                    {
                        winner = aGame.WrongAnswer();
                    }
                    else
                    {
                        winner = aGame.WasCorrectlyAnswered();
                    }
                } while (!winner);
            }
        }
    }
}

