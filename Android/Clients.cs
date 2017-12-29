using System;

using Android.App;
using Android.OS;
using Android.Widget;
using static IngenieriaGD.IGDDemo.App.AndroidApp.Resource;

namespace IngenieriaGD.IGDDemo.App.AndroidApp
{
    [Activity(Label = "Clients - IGDDemo App")]
    public class Clients : Activity
    {
        #region Declaration Controls

        TextView textViewMessage;
        EditText editTextClientId;
        EditText editTextPhone;
        EditText editTextLastReading;
        TextView editTextNewReading;
        Button buttonConsult;
        Button buttonUpdate;

        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Layout.Clients);

            textViewMessage = FindViewById<TextView>(Id.textViewMessage);
            editTextClientId = FindViewById<EditText>(Id.editTextClientId);
            editTextPhone = FindViewById<EditText>(Id.editTextPhone);
            editTextLastReading = FindViewById<EditText>(Id.editTextLastReading);
            editTextNewReading = FindViewById<TextView>(Id.editTextNewReading);
            buttonConsult = FindViewById<Button>(Id.buttonConsult);
            buttonUpdate = FindViewById<Button>(Id.buttonUpdate);

            buttonConsult.Click += ButtonConsult_Click;
            buttonUpdate.Click += ButtonUpdate_Click;
        }

        private void ButtonConsult_Click(object sender, EventArgs e)
        {
            if (editTextClientId.Text == string.Empty)
            {
                textViewMessage.Text = ResourceMessages.ClientIdEmpty;
                return;
            }

            WS.ServiceSAL service = new WS.ServiceSAL();
            service.GetClientCompleted += Service_GetClientCompleted;
            service.GetClientAsync(int.Parse(editTextClientId.Text), true);
            textViewMessage.Text = ResourceMessages.Waiting;
            buttonConsult.Enabled = false;
        }

        private void Service_GetClientCompleted(object sender, WS.GetClientCompletedEventArgs e)
        {
            buttonConsult.Enabled = true;

            if (e == null)
            {
                textViewMessage.Text = ResourceMessages.ArgumentsNull;
                return;
            }

            if (e.Error != null)
            {
                textViewMessage.Text = e.Error.Message;
                return;
            }

            if (e.Cancelled)
            {
                textViewMessage.Text = ResourceMessages.RequestCancelled;
                return;
            }

            if (e.Result == null)
            {
                textViewMessage.Text = ResourceMessages.ItemDoesntExist;
                return;
            }

            editTextPhone.Text = e.Result.Phone;
            editTextLastReading.Text = e.Result.LastReading.ToString();

            if (e.Result.Readed)
            {
                textViewMessage.Text = ResourceMessages.ClientRead;
                editTextNewReading.Enabled = false;
                buttonUpdate.Enabled = false;
                return;
            }

            editTextNewReading.Enabled = true;
            buttonUpdate.Enabled = true;
            textViewMessage.Text = ResourceMessages.ClientReadingMsg;
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (editTextNewReading.Text == string.Empty)
            {
                textViewMessage.Text = ResourceMessages.ClientReadingMsg;
                return;
            }

            int lastReading = int.Parse(editTextLastReading.Text);
            int newReading = int.Parse(editTextNewReading.Text);

            if (newReading <= lastReading)
            {
                textViewMessage.Text = ResourceMessages.ClientNewReadingLessThanLastReading;
                return;
            }

            WS.ServiceSAL service = new WS.ServiceSAL();
            service.UpdateClientReadingCompleted += Service_UpdateClientReadingCompleted;
            service.UpdateClientReadingAsync(int.Parse(editTextClientId.Text), true, int.Parse(editTextNewReading.Text), true);
            textViewMessage.Text = ResourceMessages.ItemUpdating;
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
                textViewMessage.Text = ResourceMessages.RequestCancelled;
            }

            if (!e.UpdateClientReadingResult)
            {
                textViewMessage.Text = ResourceMessages.ItemCantUpdate;
                return;
            }

            textViewMessage.Text = ResourceMessages.ClientUpdated;

            editTextClientId.Text = string.Empty;
            editTextPhone.Text = string.Empty;
            editTextLastReading.Text = string.Empty;
            editTextNewReading.Text = string.Empty;
            editTextNewReading.Enabled = false;
        }
    }
}