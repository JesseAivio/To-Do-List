using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace To_Do_List
{
    public partial class App : Application
    {
        ObservableCollection<string> tasks = new ObservableCollection<string>();
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
            
        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {
        }
    }
}
