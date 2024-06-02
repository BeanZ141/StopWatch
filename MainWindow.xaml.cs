using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Stopwatch
{
    public partial class MainWindow : Window
    {
        private int timeCs, timeSec, timeMin;
        private bool isActive;
        private DispatcherTimer timer;
        private Timestamp currentTimestamp;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            this.KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    BtnStartStop_Click(BtnStartStop, new RoutedEventArgs());
                    e.Handled = true;
                    break;
                case Key.R:
                    BtnReset_Click(BtnReset, new RoutedEventArgs());
                    e.Handled = true;
                    break;
                case Key.T:
                    if (isActive)
                    {
                        BtnAddTimestamp_Click(BtnAddTimestamp, new RoutedEventArgs());
                    }
                    e.Handled = true;
                    break;
                case Key.P:
                    this.Topmost = !this.Topmost;
                    AlwaysOnTopIndicator.Visibility = this.Topmost ? Visibility.Visible : Visibility.Collapsed;
                    e.Handled = true;
                    break;
            }
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
            this.Focus();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(10)
            };
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
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
                DrawTime();
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

                var icon = (Path)FindName("BtnStartStopIcon");
                if (icon != null)
                {
                    icon.Data = Geometry.Parse("M0,0 L50,25 L0,50 Z");
                }
                BtnAddTimestamp.Visibility = Visibility.Collapsed;
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

                var icon = (Path)FindName("BtnStartStopIcon");
                if (icon != null)
                {
                    icon.Data = Geometry.Parse("M0,0 H50 V50 H0 Z");
                }
                BtnAddTimestamp.Visibility = Visibility.Visible;
            }
            this.Focus();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
            timer.Stop();
            ResetTime();
            DrawTime();

            var icon = (Path)FindName("BtnStartStopIcon");
            if (icon != null)
            {
                icon.Data = Geometry.Parse("M0,0 L50,25 L0,50 Z");
            }
            lstTimestamps.Items.Clear();
            BtnAddTimestamp.Visibility = Visibility.Collapsed;
            Focus();
        }

        private void ResetTime()
        {
            timeCs = 0;
            timeSec = 0;
            timeMin = 0;
        }

        private void LightThemeClick(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Themes/LightTheme.xaml", UriKind.Relative));
        }

        private void DarkThemeClick(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Themes/DarkTheme.xaml", UriKind.Relative));
        }

        private void AmoledThemeClick(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Themes/AmoledTheme.xaml", UriKind.Relative));
        }

        private void RedThemeClick(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Themes/RedTheme.xaml", UriKind.Relative));
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
