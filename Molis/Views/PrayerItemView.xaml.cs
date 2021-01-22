using System;
using System.Collections.Generic;
using Molis.Models;
using Xamarin.Forms;

namespace Molis.Views
{
    public partial class PrayerItemView : ContentPage
    {
        public PrayerItemView()
        {
            InitializeComponent();
        }


        async void OnSaveClicked(object sender, EventArgs e)
        {
            
            var prayerItem = (PrayerItem)BindingContext;
            var lastChecked = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            prayerItem.LastChecked = lastChecked;
            prayerItem.ColorCategory = "Green";
            await App.Database.SaveItemAsync(prayerItem);
            await Navigation.PopAsync();

        }


        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var prayerItem = (PrayerItem)BindingContext;
            await App.Database.DeleteItemAsync(prayerItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


    }
}
