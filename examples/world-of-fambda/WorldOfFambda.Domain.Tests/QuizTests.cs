using Fambda;
using static Fambda.F;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace WorldOfFambda.Domain.Tests
{
    [TestClass]
    public class QuizTests
    {
        [TestMethod]
        public void QuizAnswerShouldBeTrue()
        {
            // Arrange
            var question = new Question("2+2=?");
            Option<Answer> answer = Some(new Answer("4"));
            var quiz = new Quiz(question, answer);

            // Act
            var result = quiz.Answer.Match(
                    Some: (a) => $"Quiz answer: '{a.Value=="4"}'",
                    None: () => "Quiz answer: 'Not given'"
                    );

            // Assert
            result.Should().Be("Quiz answer: 'True'");
        }

        [TestMethod]
        public void QuizAnswerShouldBeFalse()
        {
            // Arrange
            var question = new Question("2+2=?");
            Option<Answer> answer = Some(new Answer("3"));
            var quiz = new Quiz(question, answer);

            // Act
            var result = quiz.Answer.Match(
                    Some: (a) => $"Quiz answer: '{a.Value == "4"}'",
                    None: () => "Quiz answer: 'Not given'"
                    );

            // Assert
            result.Should().Be("Quiz answer: 'False'");
        }

        [TestMethod]
        public void QuizAnswerShouldBeNotGiven()
        {
            // Arrange
            var question = new Question("2+2=?");
            Option<Answer> answer = None;
            var quiz = new Quiz(question, answer);

            // Act
            var result = quiz.Answer.Match(
                    Some: (a) => $"The answer is: '{a.Value == "4"}'",
                    None: () => "Quiz answer: 'Not given'"
                    );

            // Assert
            result.Should().Be("Quiz answer: 'Not given'");
        }
    }
}
