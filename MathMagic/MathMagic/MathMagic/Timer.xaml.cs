using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MathMagic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Timer : ContentPage
    {
        static readonly TimeSpan duration = TimeSpan.FromSeconds(1);
        Random random = new Random();
        Point startPoint;
        Point animationVector;
        DateTime startTime;
        
        public Timer(int v)
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromMilliseconds(16), OnTimerTick);
        }

        private bool OnTimerTick()
        {
            throw new NotImplementedException();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            Timer MainTimer;
            int TimeLeft = 300; // 5 minutes

            MainTimer = new Timer(100);
            MainTimer.Elapsed += (sender, e) += {
                TimeLeft--;
                // is going to format the remaining time for the label
                TimeSpan time = TimeSpan.FromSeconds(TimeLeft);
                string timeString = time.ToString(@"mm\:ss");
                InvokeOnMainThread( ++ 
                    //interact with the UI from a different thread,
                    //must invoke this change on the main thread
                    TimerLabel.TimeStringValue = timeString
                );

                // If 25 minutes have passed
                if (TimeLeft == 0)
                {
                    // Stop the timer and reset
                    MainTimer.Stop();
                    TimeLeft = 300;
                    TimeLeft = 60;
                    InvokeOnMainThread(++
                        // Reset
                        TimerLabel.TimeStringValue = "5:00", "1:00";
                    StartStopButton.Title = "Start";
                    Alert alert = new Alert();
                    //style and message text
                    alert.AlertStyle = AlertStyle.Alert;
                    alert.MessageText = "5 Minutes or 1 Minute elapsed! Restart or Quit the game.";
                    // Display the Alert from the current view
                    alert.BeginSheet(View.Window);
                    );
                }
            };
    void InvokeOnMainThread(Func<object> p)
        {
            throw new NotImplementedException();
        }

        partial void StartStopButtonClicked(Object sender)
        {
            if (MainTimer.Enabled)
            {
                MainTimer.Stop();
                StartStopButton.Title = "Start";
            }
            else
            {
                MainTimer.Start();
                StartStopButton.Title = "Stop";
            }
        }
    }
}
