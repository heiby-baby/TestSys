using Microsoft.Win32;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace TestSys
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void createTest_Click(object sender, RoutedEventArgs e)
        {
            new CreateTestWindow().ShowDialog();
        }

        private void goTest_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json"
            };

            if (openDialog.ShowDialog() == true)
            {
                string json = File.ReadAllText(openDialog.FileName);
                if (string.IsNullOrWhiteSpace(json))
                {
                    MessageBox.Show("Файл пуст или содержит только пробельные символы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Test test;
                try
                {
                     test = JsonSerializer.Deserialize<Test>(json);
                    if (test.TestName == null) throw new Exception();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при десериализации файла", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                new TakeTestWindow(test).ShowDialog();
            }
        }
    }
}