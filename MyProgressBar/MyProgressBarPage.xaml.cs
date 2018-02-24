using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyProgressBar
{
    
    public partial class MyProgressBarPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
           

            progressBar.ProgressValue = 0;
            Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(.2), OnTimer);
        }

        private bool OnTimer()
        {
            progressBar.ProgressValue = progressBar.ProgressValue + .02;
            return true;
        }
        public MyProgressBarPage()
        {
            InitializeComponent();
        }
    }
}
