using Fambda;

namespace WorldOfFambda.Domain
{
    public class Quiz
    {
        public Question Question { get; }
        public Option<Answer> Answer { get; }

        public Quiz(Question question, Option<Answer> answer)
        {
            Question = question;
            Answer = answer;
        }
    }
}
