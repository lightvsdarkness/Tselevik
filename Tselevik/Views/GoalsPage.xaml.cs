using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tselevik.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalsPage : ContentPage
    {
        public GoalsPage()
        {
            InitializeComponent();
        }

        private async void GoToGoal(object sender, EventArgs e)
        {
            GoalDetailPage page = new GoalDetailPage();
            await Navigation.PushAsync(page);
            page.DisplayGoalPageStack();
        }


    }
}