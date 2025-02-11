using System.Windows;

namespace TestSys
{
    public partial class TakeTestWindow : Window
    {
        private TakeTestController _controller;

        public TakeTestWindow(Test test)
        {
            InitializeComponent();
            _controller = new TakeTestController(test);
            TestNameTextBlock.Text = _controller.GetTestName();
            LoadNextQuestion();
        }

        private void LoadNextQuestion()
        {
            if (_controller.IsTestFinished())
            {
                MessageBox.Show(_controller.GetTestResult());
                this.Close();
            }
            else
            {
                QuestionTextBlock.Text = _controller.GetCurrentQuestion();
                AnswersListBox.ItemsSource = _controller.GetCurrentAnswers();
                AnswersListBox.SelectedIndex = -1;
            }
        }

        private void ConfirmAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnswersListBox.SelectedIndex != -1)
            {
                _controller.CheckAnswer(AnswersListBox.SelectedIndex);
                LoadNextQuestion();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите ответ перед подтверждением.");
            }
        }
    }
}