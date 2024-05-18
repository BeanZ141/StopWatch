using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
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

        // Add Timestamp class to hold timestamp data
        public class Timestamp
        {
            public DateTime Time { get; set; }

            public override string ToString()
            {
                return Time.ToString("HH:mm:ss.ff");
            }
        }

        // Implement functionality for Add Timestamp button
        private void btnAddTimestamp_Click(object sender, RoutedEventArgs e)
        {
            lstTimestamps.Items.Add(new Timestamp { Time = DateTime.Now });
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

        private void btnStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (isActive)
            {
                isActive = false;
                timer.Stop();
                btnStartStopIcon.Data = Geometry.Parse("M0,0 L50,25 L0,50 Z");
            }
            else
            {
                isActive = true;
                timer.Start();
                btnStartStopIcon.Data = Geometry.Parse("M0,0 H50 V50 H0 Z");
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
            timer.Stop();
            ResetTime();
            DrawTime();
            btnStartStopIcon.Data = Geometry.Parse("M0,0 L50,25 L0,50 Z");
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

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
