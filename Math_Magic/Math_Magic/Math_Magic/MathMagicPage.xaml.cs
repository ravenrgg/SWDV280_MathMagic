using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Input;

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
        }
        private void btnAdd_Clicked(object sender, EventArgs args)
        {
            double a = Double.Parse(OneBtn.Text);
            double b = Double.Parse(TwoBtn.Text);
            Res.Text = (a + b).ToString();
        }

        private void btnSub_Clicked(object sender, EventArgs args)
        {
            double a = Double.Parse(OneBtn.Text);
            double b = Double.Parse(TwoBtn.Text);
            Res.Text = (a - b).ToString();
        }

        private void btnMult_Clicked(object sender, EventArgs args)
        {
            double a = Double.Parse(OneBtn.Text);
            double b = Double.Parse(TwoBtn.Text);
            Res.Text = (a * b).ToString();
        }

        private void btnDiv_Clicked(object sender, EventArgs args)
        {
            double a = Double.Parse(OneBtn.Text);
            double b = Double.Parse(TwoBtn.Text);
            Res.Text = (a / b).ToString();
        }

        private void btnClr_Clicked(object sender, EventArgs args)
        {
            OneBtn.Text = String.Empty;
            TwoBtn.Text = String.Empty;
            Res.Text = String.Empty;
        }
    }
}
