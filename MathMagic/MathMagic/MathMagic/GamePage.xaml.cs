using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MathMagic
{ 
    public class GameOptions
    {
        public static int Number { get; set; }
        public static string Op { get; set; }
        public static string Time { get; set; }
    }

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
    {
        private static System.Timers.Timer aTimer;
        Label displayLabel;
        Label randomNumber;
        Label responseLabel;
        Button backspaceButton;
        int randNumber;

        public GamePage()
        {
            InitializeComponent();

            SetTimer();

            // Create a vertical stack for the entire keypad.
            StackLayout mainStack = new StackLayout
            {
                Padding = 25,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            string op = GameOptions.Op;
            switch (op)
            {
                case "Addition":
                    op = "+";
                    break;
                case "Subtraction":
                    op = "-";
                    break;
                case "Multiplication":
                    op = "*";
                    break;
                case "Division":
                    op = "/";
                    break;
            }

            responseLabel = new Label
            {
                Text="Begin!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            mainStack.Children.Add(responseLabel);

            StackLayout quizStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            mainStack.Children.Add(quizStack);

            Label selectedNumber = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Text = GameOptions.Number.ToString()
            };
            quizStack.Children.Add(selectedNumber);

            Label selectedOp = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Text = op
            };
            quizStack.Children.Add(selectedOp);

            Random rand = new Random();
            randNumber = rand.Next(1, 12);
            randomNumber = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Text = randNumber.ToString()
            };
            quizStack.Children.Add(randomNumber);

            /* Keypad stuff */
            // First row is the Label.
            displayLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.End
            };
            mainStack.Children.Add(displayLabel);

            // Second row is the backspace Button.
            backspaceButton = new Button
            {
                Text = "\u21E6",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                IsEnabled = false
            };
            backspaceButton.Clicked += OnBackspaceButtonClicked;
            mainStack.Children.Add(backspaceButton);

            // Now do the 10 number keys.
            StackLayout rowStack = null;

            for (int num = 1; num <= 10; num++)
            {
                if ((num - 1) % 3 == 0)
                {
                    rowStack = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal
                    };
                    mainStack.Children.Add(rowStack);
                }

                Button digitButton = new Button
                {
                    Text = (num % 10).ToString(),
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                    StyleId = (num % 10).ToString()
                };
                digitButton.Clicked += OnDigitButtonClicked;

                // For the zero button, expand to fill horizontally.
                if (num == 10)
                {
                    digitButton.HorizontalOptions = LayoutOptions.FillAndExpand;
                }
                rowStack.Children.Add(digitButton);
            }

            Button enterButton = new Button
            {
                Text = "Enter",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button))
            };
            enterButton.Clicked += OnEnterButtonClicked;
            mainStack.Children.Add(enterButton);

            this.Content = mainStack;

            void SetTimer()
            {
                string time = GameOptions.Time;

                if (time == "One Minute")
                {
                    aTimer = new System.Timers.Timer(60000);
                }
                else
                {
                    aTimer = new System.Timers.Timer(300000);
                }
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
            }

            void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                aTimer.Stop();
                resultRedirect();
            }

            async void resultRedirect()
            {
                var resultsPage = new ResultsPage();

                GameOptions.Number = 0;
                GameOptions.Op = "";
                GameOptions.Time = "";

                await Navigation.PushModalAsync(resultsPage);
            }
        }

        void OnDigitButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            displayLabel.Text += (string)button.StyleId;
            backspaceButton.IsEnabled = true;
        }

        void OnEnterButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            int answer = 0;
            string op = GameOptions.Op;
            int attempt;
            try
            {
                attempt = Convert.ToInt16(displayLabel.Text);
            }
            catch
            {
                attempt = 0;
            }
            
            switch (op)
            {
                case "Addition":
                    answer = GameOptions.Number + randNumber;
                    break;
                case "Subtraction":
                    answer = GameOptions.Number - randNumber;
                    break;
                case "Multiplication":
                    answer = GameOptions.Number * randNumber;
                    break;
                case "Division":
                    answer = GameOptions.Number / randNumber;
                    break;
            }

            if (attempt == answer)
            {
                responseLabel.Text = "Correct!";
                displayLabel.Text = "";
                Random rand = new Random();
                randNumber = rand.Next(1, 12);
                randomNumber.Text = randNumber.ToString();
            }
            else
            {
                responseLabel.Text = "Incorrect";
                displayLabel.Text = "";
            }

            backspaceButton.IsEnabled = true;
        }

        void OnBackspaceButtonClicked(object sender, EventArgs args)
        {
            string text = displayLabel.Text;
            displayLabel.Text = text.Substring(0, text.Length - 1);
            backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
        }
    }
}