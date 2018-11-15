using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Math_Magic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MathMagicPage : ContentPage
    {
        public MathMagicPage()
        {
            InitializeComponent();

			// Initial Setup
			OneButtonZ.IsVisible = false;
			TwoButtonZ.IsVisible = false;
			ThreeButtonZ.IsVisible = false;
			FourButtonZ.IsVisible = false;
			FiveButtonZ.IsVisible = false;
			SixButtonZ.IsVisible = false;
			SevenButtonZ.IsVisible = false;
			EightButtonZ.IsVisible = false;
			NineButtonZ.IsVisible = false;
			ZeroButton.IsVisible = false;

			AdditionButton.IsVisible = false;
			SubtractionButton.IsVisible = false;
			MultiplyButton.IsVisible = false;
			DivideButton.IsVisible = false;

			OneMinuteButton.IsVisible = false;
			FiveMinutesButton.IsVisible = false;
			StartButton.IsVisible = false;
			SubmitButton.IsVisible = false;
			RestartButton.IsVisible = false;

			// Settings Array
			string[] settings;

			// Collects Settings (called by game)
			void Settings_Collector(settings)
			{
				string number = settings[0];
				string arithmetic = settings[1];
				string time = settings[2];
			};

			/* 
			 * Retrieves Settings
			 * Called by Button's Clicked method
			 * Also highlights the selected Button
			*/
			void Settings_Listener(object sender, EventArgs e)
			{
				Button button = (Button)sender;
				string name = nameof(button);

				string[] numbers = ["OneB", "TwoB", "ThreeB", "FourB", "FiveB", "SixB", "SevenB", "EightB", "NineB", "TenB", "ElevenB", "TwelveB"];
				string[] operations = ["Addition", "Subtraction", "Multiply", "Divide"];
				string[] times = ["OneMinute", "FiveMinutes"];

				string number;
				string arithmetic;
				string time;
			};
		}
    }
}