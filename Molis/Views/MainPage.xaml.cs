using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Molis.Data;
using Molis.Models;
using Molis.Views;
using Xamarin.Forms;

namespace Molis
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            PrayerList.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PrayerItemView
            {
                BindingContext = new PrayerItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new PrayerItemView
                {
                    BindingContext = e.SelectedItem as PrayerItem
                });
            }
        }

        void PrayerList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
        }

        void Button_Pressed(System.Object sender, System.EventArgs e)
        {
        }
    }
}
