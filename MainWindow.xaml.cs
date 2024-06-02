using Stopwatch;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace StopwatchApp
{
    public partial class MainWindow : Window
    {
        private System.Diagnostics.Stopwatch stopwatch;
        private DispatcherTimer uiTimer;
        private bool isActive;
        private Timestamp currentTimestamp;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimers();
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
            public TimeSpan StartTime { get; set; }
            public TimeSpan EndTime { get; set; }

            public override string ToString()
            {
                return $"{StartTime.Minutes:0} {StartTime.Seconds:00}.{StartTime.Milliseconds / 10:00}    {EndTime.Minutes:0} {EndTime.Seconds:00}.{EndTime.Milliseconds / 10:00}";
            }
        }

        private void BtnAddTimestamp_Click(object sender, RoutedEventArgs e)
        {
            var endTimestamp = new Timestamp
            {
                StartTime = currentTimestamp?.StartTime ?? TimeSpan.Zero,
                EndTime = stopwatch.Elapsed
            };

            int index = lstTimestamps.Items.Count + 1;
            lstTimestamps.Items.Insert(0, $"# {index,-3}   {endTimestamp}");
            currentTimestamp = new Timestamp
            {
                StartTime = stopwatch.Elapsed
            };
            this.Focus();
        }

        private void InitializeTimers()
        {
            stopwatch = new System.Diagnostics.Stopwatch();
            uiTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(5)
            };
            uiTimer.Tick += UiTimer_Tick;
        }

        private void UiTimer_Tick(object? sender, EventArgs e)
        {
            if (isActive)
            {
                DrawTime();
            }
        }

        private void DrawTime()
        {
            TimeSpan elapsed = stopwatch.Elapsed;
            lblCs.Content = (elapsed.Milliseconds / 10).ToString("00");
            lblSec.Content = elapsed.Seconds.ToString("00");
            lblMin.Content = elapsed.Minutes.ToString("00");
        }

        private void BtnStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (isActive)
            {
                isActive = false;
                stopwatch.Stop();
                uiTimer.Stop();

                var icon = (Path)FindName("BtnStartStopIcon");
                if (icon != null)
                {
                    icon.Data = Geometry.Parse("M0,0 L50,25 L0,50 Z");
                }
                BtnAddTimestamp.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (currentTimestamp == null)
                {
                    currentTimestamp = new Timestamp
                    {
                        StartTime = stopwatch.Elapsed
                    };
                }
                isActive = true;
                stopwatch.Start();
                uiTimer.Start();

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
            stopwatch.Reset();
            uiTimer.Stop();
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
