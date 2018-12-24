using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Task4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}