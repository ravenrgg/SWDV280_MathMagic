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
    public partial class NumberPage : ContentPage
    {
        int number_selected;

        public NumberPage()
        {
            InitializeComponent();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = NumberList;
            if (listView.SelectedItem != null)
            {
                GameOptions.Number = Convert.ToInt16(listView.SelectedItem);

                var operationPage = new OpPage();

                await Navigation.PushModalAsync(operationPage);
            }
        }
    }
}