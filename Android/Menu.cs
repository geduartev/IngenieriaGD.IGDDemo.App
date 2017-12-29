using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using static IngenieriaGD.IGDDemo.App.AndroidApp.Resource;

namespace IngenieriaGD.IGDDemo.App.AndroidApp
{
    [Activity(Label = "Menu - IGDDemo App")]
    public class Menu : Activity
    {
        Button buttonReadings;
        Button buttonOrders;
        private int sellerId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Layout.Menu);

            sellerId = Intent.GetIntExtra("sellerId", 0);

            buttonReadings = FindViewById<Button>(Id.buttonClients);
            buttonOrders = FindViewById<Button>(Id.buttonOrders);

            buttonReadings.Click += ButtonReadings_Click;
            buttonOrders.Click += ButtonOrders_Click;
        }

        private void ButtonOrders_Click(object sender, EventArgs e)
        {
            var shoppingCar = new Intent(this, typeof(Orders));

            shoppingCar.PutExtra("sellerId", true);

            StartActivity(shoppingCar);
        }

        private void ButtonReadings_Click(object sender, EventArgs e)
        {
            var clients = new Intent(this, typeof(Clients));
            StartActivity(clients);
        }
    }
}