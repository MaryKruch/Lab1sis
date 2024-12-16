using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab1sis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartProcessButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "notepad.exe", // Пример дочернего процесса
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                if (WaitForExitRadioButton.IsChecked == true)
                {
                    // Ожидание завершения дочернего процесса
                    process.WaitForExit();
                    ResultTextBlock.Text = $"Дочерний процесс завершился с кодом: {process.ExitCode}";
                }
                else if (KillProcessRadioButton.IsChecked == true)
                {
                    // Принудительное завершение дочернего процесса
                    Thread.Sleep(2000); // Подождем 2 секунды перед завершением
                    process.Kill();
                    process.WaitForExit();
                    ResultTextBlock.Text = "Дочерний процесс был принудительно завершен.";
                }
                else
                {
                    ResultTextBlock.Text = "Неверный выбор.";
                }
            }
        }
    }
}