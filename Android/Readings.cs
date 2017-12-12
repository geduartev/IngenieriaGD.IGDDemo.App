using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Android
{
    [Activity(Label = "IGDDemo App")]
    public class Readings : Activity
    {
        TextView textViewMessage;
        EditText editTextClientId;
        EditText editTextPhone;
        EditText editTextLastReading;
        TextView editTextNewReading;
        Button buttonConsult;
        Button buttonUpdate;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Readings);

            textViewMessage = FindViewById<TextView>(Resource.Id.textViewMessage);
            editTextClientId = FindViewById<EditText>(Resource.Id.editTextClientId);
            editTextPhone = FindViewById<EditText>(Resource.Id.editTextPhone);
            editTextLastReading = FindViewById<EditText>(Resource.Id.editTextLastReading);
            editTextNewReading = FindViewById<TextView>(Resource.Id.editTextNewReading);
            buttonConsult = FindViewById<Button>(Resource.Id.buttonConsult);
            buttonUpdate = FindViewById<Button>(Resource.Id.buttonUpdate);

            buttonConsult.Click += ButtonConsult_Click;
            buttonUpdate.Click += ButtonUpdate_Click;
        }

        private void ButtonConsult_Click(object sender, EventArgs e)
        {
            if (editTextClientId.Text == string.Empty)
            {
                textViewMessage.Text = "Debe ingresar el ID de un cliente.";
                return;
            }

            WS.ServiceSAL service = new WS.ServiceSAL();
            service.GetClientCompleted += Service_GetClientCompleted;
            service.GetClientAsync(int.Parse(editTextClientId.Text), true);
            textViewMessage.Text = "Consultado, por favor espere...";
            buttonConsult.Enabled = false;
        }

        private void Service_GetClientCompleted(object sender, WS.GetClientCompletedEventArgs e)
        {
            buttonConsult.Enabled = true;

            if (e.Error != null)
            {
                textViewMessage.Text = e.Error.Message;
            }

            if (e.Cancelled)
            {
                textViewMessage.Text = "Request was cancelled.";
            }

            if (e.Result == null)
            {
                textViewMessage.Text = "Client doesn't exist.";
                return;
            }

            if (e.Result.Id == 0)
            {
                textViewMessage.Text = "Client doesn't exist.";
                return;
            }

            editTextPhone.Text = e.Result.Phone;
            editTextLastReading.Text = e.Result.LastReading.ToString();

            if (e.Result.Readed)
            {
                textViewMessage.Text = "All ready reading.";
                editTextNewReading.Enabled = false;
                buttonUpdate.Enabled = false;
                return;
            }

            editTextNewReading.Enabled = true;
            buttonUpdate.Enabled = true;
            textViewMessage.Text = "Ingrese nueva lectura y presione el botón Actualizar.";
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (editTextNewReading.Text == string.Empty)
            {
                textViewMessage.Text = "Please, can you put a new reading?";
                return;
            }

            int lastReading = int.Parse(editTextLastReading.Text);
            int newReading = int.Parse(editTextNewReading.Text);

            if (newReading <= lastReading)
            {
                textViewMessage.Text = "The new reading should less or equal than the last reading.";
                return;
            }

            WS.ServiceSAL service = new WS.ServiceSAL();
            service.UpdateClientReadingCompleted += Service_UpdateClientReadingCompleted;
            service.UpdateClientReadingAsync(int.Parse(editTextClientId.Text), true, int.Parse(editTextNewReading.Text), true);
            textViewMessage.Text = "Updating...";
            buttonUpdate.Enabled = false;
        }

        private void Service_UpdateClientReadingCompleted(object sender, WS.UpdateClientReadingCompletedEventArgs e)
        {
            buttonUpdate.Enabled = true;

            if (e.Error != null)
            {
                textViewMessage.Text = e.Error.Message;
            }

            if (e.Cancelled)
            {
                textViewMessage.Text = "Request was cancelled.";
            }

            if (!e.UpdateClientReadingResult)
            {
                textViewMessage.Text = "The new reading can't update. Please, try again.";
                return;
            }

            textViewMessage.Text = "El cliente: " + editTextClientId.Text + ", fue actualizado"
                + "correctamente. Puede realizar otra lectura";

            editTextClientId.Text = string.Empty;
            editTextPhone.Text = string.Empty;
            editTextLastReading.Text = string.Empty;
            editTextNewReading.Text = string.Empty;
            editTextNewReading.Enabled = false;
        }
    }
}