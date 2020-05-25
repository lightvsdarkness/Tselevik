using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tselevik.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tselevik.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        public ObservableCollection<Category> Categories { get; set; }

        public CategoriesPage()
        {
            InitializeComponent();

            Categories = new ObservableCollection<Category> { 
                new Category {Id=0, Title="Work", Description="Means of going by", SuccessRate=50 },
                new Category {Id=1, Title="Social", Description="Social Description", SuccessRate=50 },
                new Category {Id=2, Title="Hobby", Description="Hobby Description", SuccessRate=50 },
                new Category {Id=3, Title="Learning", Description="Learning Description", SuccessRate=50 },
                };

            this.BindingContext = this;
        }


        private void CategoriesListTitle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            CategoriesListComplete.SelectedItem = e.Item;
        }
        //    private void CategoriesListTitle_ItemTapped(object sender, ItemTappedEventArgs e)
        //    {
        //        if (e.Item != null)
        //        {
        //            DisplayAlert("Tapped: ", e.Item.ToString(), "OK");
        //        }

        //((ListView)sender).SelectedItem = null;
        //    }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            var category = Categories.FirstOrDefault();
            if (category != null)
                category.SuccessRate += 1;
        }

        private void AddItem(object sender, EventArgs e)
        {
            var lastElement = Categories.OrderByDescending(i => i.Id).FirstOrDefault();
            if(lastElement != null)
            {
                Categories.Add(new Category { Id = lastElement.Id +1, Title = "New Task", Description = "New Task Description", SuccessRate = 50 });

            }

        }
        // удаление выделенного объекта
        private void RemoveItem(object sender, EventArgs e)
        {
            Category category = CategoriesListTitle.SelectedItem as Category;
            if (category != null)
            {
                Categories.Remove(category);
                CategoriesListTitle.SelectedItem = null;
            }

            category = CategoriesListComplete.SelectedItem as Category;
            if (category != null)
            {
                Categories.Remove(category);
                CategoriesListComplete.SelectedItem = null;
            }
        }
    }
}