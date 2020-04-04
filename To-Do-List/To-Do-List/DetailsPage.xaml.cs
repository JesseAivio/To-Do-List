using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace To_Do_List
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        string doneText = " - COMPLETED";
        public DetailsPage(string text)
        {
            InitializeComponent();
            if(text.Contains(doneText))
            {
                text = text.Replace(doneText, "");
                btnCheckTask.IsEnabled = false;
                btnEditTask.IsEnabled = false;
            }
            lblTask.Text = text;
        }

        private void btnDeleteTask_Clicked(object sender, EventArgs e)
        {
            if(btnCheckTask.IsEnabled == false)
            {
                lblTask.Text += doneText;
            }
            DisplayAlert("Success", "Task removed", "OK");
            MainPage mainPage = new MainPage(lblTask.Text, "Delete");
            Application.Current.MainPage = mainPage;
        }

        private void btnEditTask_Clicked(object sender, EventArgs e)
        {
            newTaskPage newTaskPage = new newTaskPage(lblTask.Text);
            Application.Current.MainPage = newTaskPage;
        }

        private void btnCheckTask_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Success", "Task Completed", "OK");
            MainPage mainPage = new MainPage(lblTask.Text, "Done");
            Application.Current.MainPage = mainPage;
        }
    }
}