using System;
using System.IO;
using NUnit.Framework;

namespace Trivia.Tests
{
    public class QuestionShould
    {
        [Test]
        public void AllowToUse5Categories()
        {
            //Arrange actors
            var stringWriter = new StringWriter();
            var previousConsoleOut = Console.Out;
            Console.Out(StringWriter);
            
        }
    }
}