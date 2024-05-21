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
        private System.Timers.Timer timer;
        private Timestamp currentTimestamp;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
        }

        public class Timestamp
        {
            public int StartMinutes { get; set; }
            public int StartSeconds { get; set; }
            public int StartCentiseconds { get; set; }
            public int EndMinutes { get; set; }
            public int EndSeconds { get; set; }
            public int EndCentiseconds { get; set; }

            public override string ToString()
            {
                return $"{StartMinutes:0} {StartSeconds:00}.{StartCentiseconds:00}    {EndMinutes:0} {EndSeconds:00}.{EndCentiseconds:00}";
            }
        }

        private void BtnAddTimestamp_Click(object sender, RoutedEventArgs e)
        {
            var endTimestamp = new Timestamp
            {
                StartMinutes = currentTimestamp?.StartMinutes ?? 0,
                StartSeconds = currentTimestamp?.StartSeconds ?? 0,
                StartCentiseconds = currentTimestamp?.StartCentiseconds ?? 0,
                EndMinutes = timeMin,
                EndSeconds = timeSec,
                EndCentiseconds = timeCs
            };

            int index = lstTimestamps.Items.Count + 1;
            lstTimestamps.Items.Insert(0, $"# {index,-3}   {endTimestamp}");
            currentTimestamp = new Timestamp
            {
                StartMinutes = timeMin,
                StartSeconds = timeSec,
                StartCentiseconds = timeCs
            };
        }

        private void InitializeTimer()
        {
            timer = new System.Timers.Timer(10);
            timer.Elapsed += Timer_Tick;
        }

        private void Timer_Tick(object? sender, System.Timers.ElapsedEventArgs e)
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
                Dispatcher.BeginInvoke(new Action(DrawTime));
            }
        }

        private void DrawTime()
        {
            lblCs.Content = timeCs.ToString("00");
            lblSec.Content = timeSec.ToString("00");
            lblMin.Content = timeMin.ToString("00");
        }

        private void BtnStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (isActive)
            {
                isActive = false;
                timer.Stop();
                BtnStartStopIcon.Data = Geometry.Parse("M0,0 L50,25 L0,50 Z");
                BtnAddTimestamp.Visibility = Visibility.Collapsed; // Hide Add Timestamp button
            }
            else
            {
                currentTimestamp ??= new Timestamp
                {
                    StartMinutes = timeMin,
                    StartSeconds = timeSec,
                    StartCentiseconds = timeCs
                };
                isActive = true;
                timer.Start();
                BtnStartStopIcon.Data = Geometry.Parse("M0,0 H50 V50 H0 Z");
                BtnAddTimestamp.Visibility = Visibility.Visible;
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
            timer.Stop();
            ResetTime();
            DrawTime();
            BtnStartStopIcon.Data = Geometry.Parse("M0,0 L50,25 L0,50 Z");
            lstTimestamps.Items.Clear();
            #pragma warning disable CS8625
            currentTimestamp = null;
            #pragma warning restore CS8625
            BtnAddTimestamp.Visibility = Visibility.Collapsed;
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

            this.Left = screen.Left - this.Width - padding;
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
