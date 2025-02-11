using System.Collections.Generic;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace TestSys
{
    public class CreateTestController
    {
        private Test _test = new Test();
        private List<string> _currentAnswers = new List<string>();

        public void AddAnswer(string answer)
        {
            if (!string.IsNullOrWhiteSpace(answer))
            {
                _currentAnswers.Add(answer);
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите текст ответа.");
            }
        }

        public void AddQuestion(string questionText, int correctAnswerIndex)
        {
            if (string.IsNullOrWhiteSpace(questionText))
            {
                MessageBox.Show("Пожалуйста, введите текст вопроса.");
                return;
            }

            if (_currentAnswers.Count < 2)
            {
                MessageBox.Show("Добавьте как минимум два ответа.");
                return;
            }

            if (correctAnswerIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите правильный ответ.");
                return;
            }

            var question = new Question
            {
                QuestionText = questionText,
                Answers = new List<string>(_currentAnswers),
                CorrectAnswerIndex = correctAnswerIndex
            };

            _test.Questions.Add(question);

            _currentAnswers.Clear();
            MessageBox.Show("Вопрос добавлен!");
        }

        public void SaveTest(string testName)
        {
            if (string.IsNullOrWhiteSpace(testName))
            {
                MessageBox.Show("Пожалуйста, введите название теста.");
                return;
            }

            if (_test.Questions.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы один вопрос.");
                return;
            }

            _test.TestName = testName;

            string json = JsonConvert.SerializeObject(_test, Formatting.Indented);
            string filePath = Path.Combine(Environment.CurrentDirectory, $"{_test.TestName}.json");
            File.WriteAllText(filePath, json);

            MessageBox.Show($"Тест сохранен в файл: {filePath}");
        }
    }
}