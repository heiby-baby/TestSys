using System.Collections.Generic;

namespace TestSys
{
    public class Test
    {
        public string TestName { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }

    public class Question
    {
        public string QuestionText { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
        public int CorrectAnswerIndex { get; set; }
    }
}