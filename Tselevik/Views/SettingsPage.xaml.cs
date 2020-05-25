using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tselevik.ViewModels;
using Tselevik.Models;

namespace Tselevik.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private SettingsViewModel settingsViewModel;
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = settingsViewModel = new SettingsViewModel();
        }

        void OnPickerSelectionChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            Settings.Themes theme = (Settings.Themes)picker.SelectedItem;

            settingsViewModel.SelectTheme(theme);
        }
    }
}