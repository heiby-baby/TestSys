using System.Windows;

namespace TestSys
{
    public class TakeTestController
    {
        private Test _test;
        private int _correctAnswers = 0;
        private int _currentQuestionIndex = 0;

        public TakeTestController(Test test)
        {
            _test = test;
        }

        public string GetCurrentQuestion()
        {
            if (_currentQuestionIndex < _test.Questions.Count)
            {
                return _test.Questions[_currentQuestionIndex].QuestionText;
            }
            return null;
        }

        public List<string> GetCurrentAnswers()
        {
            if (_currentQuestionIndex < _test.Questions.Count)
            {
                return _test.Questions[_currentQuestionIndex].Answers;
            }
            return null;
        }

        public void CheckAnswer(int selectedAnswerIndex)
        {
            if (selectedAnswerIndex == _test.Questions[_currentQuestionIndex].CorrectAnswerIndex)
            {
                _correctAnswers++;
            }

            _currentQuestionIndex++;
        }

        public string GetTestResult()
        {
            return $"Тест завершен! Правильных ответов: {_correctAnswers} из {_test.Questions.Count}";
        }

        public bool IsTestFinished()
        {
            return _currentQuestionIndex >= _test.Questions.Count;
        }
        public string GetTestName()
        {
            return _test.TestName;
        }
    }
}