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
    public partial class newTaskPage : ContentPage
    {
        string oldValue { get; set; }
        public newTaskPage(string value = null)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(value))
            {
                txtTaskName.Text = value;
                oldValue = value;
                btnAddTask.Text = "Save";
            }
        }

        private void btnAddTask_Clicked(object sender, EventArgs e)
        {
            if(btnAddTask.Text == "Add")
            {
                if (string.IsNullOrWhiteSpace(txtTaskName.Text))
                {
                    DisplayAlert("Error", "Input was null", "OK");
                    return;
                }
                DisplayAlert("Success", "Task added", "OK");
                MainPage mainPage = new MainPage(txtTaskName.Text, "Add");
                Application.Current.MainPage = mainPage;
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTaskName.Text))
            {
                DisplayAlert("Error", "Input was null", "OK");
                return;
            }
            DisplayAlert("Success", "Task updated", "OK");
            MainPage mainPage2 = new MainPage(txtTaskName.Text, "Edit", oldValue);
            Application.Current.MainPage = mainPage2;
        }
    }
}