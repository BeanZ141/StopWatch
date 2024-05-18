using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Stopwatch
{
    public partial class MainWindow : Window
    {
        private int timeCs, timeSec, timeMin;
        private bool isActive;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isActive)
            {
                timeCs++;

                if (timeCs >= 100)
                {
                    timeSec++;
                    timeCs = 0;

                    if (timeSec >= 60)
                    {
                        timeMin++;
                        timeSec = 0;
                    }
                }
            }

            DrawTime();
        }

        private void DrawTime()
        {
            lblCs.Content = timeCs.ToString("00");
            lblSec.Content = timeSec.ToString("00");
            lblMin.Content = timeMin.ToString("00");
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            isActive = true;
            timer.Start();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
            timer.Stop();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
            timer.Stop();
            ResetTime();
            DrawTime();
        }

        private void ResetTime()
        {
            timeCs = 0;
            timeSec = 0;
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
