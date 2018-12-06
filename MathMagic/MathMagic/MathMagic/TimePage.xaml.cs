using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MathMagic
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimePage : ContentPage
	{
        string time_selected;

		public TimePage ()
		{
			InitializeComponent ();
		}

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = TimeList;
            if (listView.SelectedItem != null)
            {
                GameOptions.Time = listView.SelectedItem.ToString();

                var gamePage = new GamePage();

                await Navigation.PushModalAsync(gamePage);
            }
        }
    }
}