using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace To_Do_List
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        
        public MainPage(string task = null, string type = null, string oldTask = null)
        {
            InitializeComponent();
            
            if (!string.IsNullOrEmpty(task) && type == "Add")
            {
                Tasks.tasks.Add(task);
            }
            else if(!string.IsNullOrEmpty(task) && type == "Delete")
            {
                Tasks.tasks.Remove(task);
            }
            else if (!string.IsNullOrEmpty(task) && type == "Edit")
            {
                Tasks.tasks.Remove(oldTask);
                Tasks.tasks.Add(task);
            }
            else if(!string.IsNullOrEmpty(task) && type == "Done")
            {
                Tasks.tasks.Remove(task);
                task = task + " - COMPLETED";
                Tasks.tasks.Add(task);
            }
            tasksList.ItemsSource = Tasks.tasks;
        }

        private void tasksList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DetailsPage detailsPage = new DetailsPage(tasksList.SelectedItem.ToString());
            Application.Current.MainPage = detailsPage;
        }

        private void btnNewTask_Clicked(object sender, EventArgs e)
        {
            newTaskPage newTaskPage = new newTaskPage();
            Application.Current.MainPage = newTaskPage;
        }

        private void btnClearComletedTasks_Clicked(object sender, EventArgs e)
        {
            List<string> list = Tasks.tasks.ToList();
            foreach (var task in list)
            {
                if (task.Contains(" - COMPLETED"))
                {
                    Tasks.tasks.Remove(task);
                }
            }
            tasksList.ItemsSource = null;
            tasksList.ItemsSource = Tasks.tasks;
            DisplayAlert("Success", "Completed tasks removed", "OK");
        }
    }
}
