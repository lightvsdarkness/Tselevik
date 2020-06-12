using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Tselevik.Models;
using Tselevik.ViewModels;

namespace Tselevik.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        ItemsViewModel _itemsViewModel;


        public NewItemPage(ItemsViewModel itemsViewModel)
        {
            InitializeComponent();

            _itemsViewModel = itemsViewModel;
            int CurrentMaxId = _itemsViewModel.GetCurrentMaxId();
            Item = new Item
            {
                Id = CurrentMaxId + 1,
                Text = "Task name",
                Description = "Task description"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void DatePickerDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            //if (label != null)
            //    label.Text = "Вы выбрали " + e.NewDate.ToString("dd/MM/yyyy");
        }

        private void PickerCatergory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var picker = sender as Picker;
            //DisplayAlert("Chosen Category: ", $"{picker.SelectedItem}", "OK");

        }

    }
}