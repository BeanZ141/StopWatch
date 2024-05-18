using System.Windows;
using System.Windows.Input;

namespace Stopwatch
{
    public partial class MainWindow : Window
    {
        int timeCs, timeS, timeMin;
        bool isActive;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            timeCs = 0;
            timeS = 0;
            timeMin = 0;

            isActive = true;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            isActive = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;

            ResetTime();
        }

        private void ResetTime()
        {
            timeCs = 0;
            timeS = 0;
            timeMin = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double padding = 10.0;

            var screen = System.Windows.SystemParameters.WorkArea;

            this.Left = screen.Right - this.Width - padding;
            this.Top = screen.Bottom - this.Height - padding;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
