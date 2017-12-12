using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Android
{
    [Activity(Label = "IGDDemo App")]
    public class Menu : Activity
    {
        Button buttonReadings;
        Button buttonShoppingCarg;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);
            buttonReadings = FindViewById<Button>(Resource.Id.buttonReadings);
            buttonShoppingCarg = FindViewById<Button>(Resource.Id.buttonShoppingCar);

            buttonReadings.Click += ButtonReadings_Click;
            buttonShoppingCarg.Click += ButtonShoppingCar_Click;
        }

        private void ButtonShoppingCar_Click(object sender, EventArgs e)
        {
            var shoppingCar = new Intent(this, typeof(Readings));
            StartActivity(shoppingCar);
        }

        private void ButtonReadings_Click(object sender, EventArgs e)
        {
            var readings = new Intent(this, typeof(Readings));
            StartActivity(readings);
        }
    }
}