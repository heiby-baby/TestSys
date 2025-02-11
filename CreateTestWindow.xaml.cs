using System.Windows;

namespace TestSys
{
    public partial class CreateTestWindow : Window
    {
        private CreateTestController _controller = new CreateTestController();

        public CreateTestWindow()
        {
            InitializeComponent();
        }

        private void AddAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.AddAnswer(AnswerTextBox.Text);
            CorrectAnswerComboBox.Items.Add(AnswerTextBox.Text);
            AnswerTextBox.Clear();
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.AddQuestion(QuestionTextBox.Text, CorrectAnswerComboBox.SelectedIndex);
            QuestionTextBox.Clear();
            CorrectAnswerComboBox.Items.Clear();
        }

        private void SaveTestButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.SaveTest(TestNameTextBox.Text);
            this.Close();
        }
    }
}