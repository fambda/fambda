using System;
using Fambda;
using FluentAssertions;
using Xunit;
using static Fambda.F;

namespace WorldOfFambda.Domain.Tests
{
    public class QuizTests
    {
        [Fact]
        public void QuizAnswerShouldBeTrue()
        {
            // Arrange
            var question = new Question("2+2=?");
            Option<Answer> answer = Some(new Answer("4"));
            var quiz = new Quiz(question, answer);

            // Act
            var result = quiz.Answer.Match(
                        None: () => "Quiz answer: 'Not given'",
                        Some: (a) => $"Quiz answer: '{a.Value == "4"}'"
                    );

            // Assert
            result.Should().Be("Quiz answer: 'True'");
        }

        [Fact]
        public void QuizAnswerShouldBeFalse()
        {
            // Arrange
            var question = new Question("2+2=?");
            Option<Answer> answer = Some(new Answer("3"));
            var quiz = new Quiz(question, answer);

            // Act
            var result = quiz.Answer.Match(
                        None: () => "Quiz answer: 'Not given'",
                        Some: (a) => $"Quiz answer: '{a.Value == "4"}'"
                    );

            // Assert
            result.Should().Be("Quiz answer: 'False'");
        }

        [Fact]
        public void QuizAnswerShouldBeNotGiven()
        {
            // Arrange
            var question = new Question("2+2=?");
            Option<Answer> answer = None;
            var quiz = new Quiz(question, answer);

            // Act
            var result = quiz.Answer.Match(
                        None: () => "Quiz answer: 'Not given'",
                        Some: (a) => $"The answer is: '{a.Value == "4"}'"
                    );

            // Assert
            result.Should().Be("Quiz answer: 'Not given'");
        }

        [Fact]
        public void QuizAnswerMapShouldBeNone()
        {
            // Arrange
            Option<string> expected = None;
            var question = new Question("2+2=?");
            Option<Answer> answer = None;
            var quiz = new Quiz(question, answer);
            Func<Answer, string> func = x => $"Quiz answer: '{x.Value}'";

            // Act
            var result = quiz.Answer.Map(func);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void QuizAnswerMapShouldBeSome()
        {
            // Arrange
            Option<string> expected = Some("Quiz answer: '4'");
            var question = new Question("2+2=?");
            Option<Answer> answer = Some(new Answer("4"));
            var quiz = new Quiz(question, answer);
            Func<Answer, string> func = x => $"Quiz answer: '{x.Value}'";

            // Act
            var result = quiz.Answer.Map(func);

            // Assert
            result.Should().Be(expected);
        }
    }
}
