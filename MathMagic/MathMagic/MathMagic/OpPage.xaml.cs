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
	public partial class OpPage : ContentPage
	{

        public OpPage ()
		{
			InitializeComponent ();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = OpList;
            if (listView.SelectedItem != null)
            {
                GameOptions.Op = listView.SelectedItem.ToString();

                var timePage = new TimePage();

                await Navigation.PushModalAsync(timePage);
            }
        }
    }
}