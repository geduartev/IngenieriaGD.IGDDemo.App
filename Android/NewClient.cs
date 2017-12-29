using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using IngenieriaGD.IGDDemo.App.AndroidApp.WS;
using static IngenieriaGD.IGDDemo.App.AndroidApp.Resource;

namespace IngenieriaGD.IGDDemo.App.AndroidApp
{
    [Activity(Label = "New Client - IGDDemo App")]
    public class NewClient : Activity
    {
        #region Fields

        private int sellerId;
        private List<int> idsDocumentTypes;
        private List<string> titlesDocumentTypes;
        private List<string> codesDocumentTypes;
        private int position;

        #endregion

        #region Declaration Controls

        TextView textViewMessage;
        ListView listViewDocumentTypes;
        EditText editTextDocumentNumber;
        EditText editTextFirstName;
        EditText editTextSecondName;
        EditText editTextPhone;
        EditText editTextAnniversary;
        EditText editTextEmail;
        EditText editTextAddress;
        Button buttonNewClient;
        
        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Layout.NewClient);

            sellerId = Intent.GetIntExtra("sellerId", 0);

            #region Find Controls

            textViewMessage = FindViewById<TextView>(Id.textViewMessage);
            listViewDocumentTypes = FindViewById<ListView>(Id.listViewDocumentTypes);
            editTextDocumentNumber = FindViewById<EditText>(Id.editTextDocumentNumber);
            editTextFirstName = FindViewById<EditText>(Id.editTextFirstName);
            editTextSecondName = FindViewById<EditText>(Id.editTextSecondName);
            editTextPhone = FindViewById<EditText>(Id.editTextPhone);
            editTextAnniversary = FindViewById<EditText>(Id.editTextAnniversary);
            editTextEmail = FindViewById<EditText>(Id.editTextEmail);
            editTextAddress = FindViewById<EditText>(Id.editTextAddress);
            buttonNewClient = FindViewById<Button>(Id.buttonNewClient);

            #endregion

            #region Event Controls

            buttonNewClient.Click += ButtonNewClient_Click;
            listViewDocumentTypes.ItemClick += ListViewDocumentTypes_ItemClick;

            #endregion

            WS.ServiceSAL service = new WS.ServiceSAL();
            service.GetAllDocumentTypesCompleted += Service_GetAllDocumentTypesCompleted;
            service.GetAllDocumentTypesAsync();
        }

        private void Service_GetAllDocumentTypesCompleted(object sender, WS.GetAllDocumentTypesCompletedEventArgs e)
        {
            idsDocumentTypes = new List<int>();
            titlesDocumentTypes = new List<string>();
            codesDocumentTypes = new List<string>();
            position = -1;

            foreach (var item in e.Result)
            {
                idsDocumentTypes.Add(item.Id);
                titlesDocumentTypes.Add(item.Title);
                codesDocumentTypes.Add(item.Code);
            }

            listViewDocumentTypes.Adapter = new ArrayAdapter(context: this, resource: Android.Resource.Layout.SimpleListItemSingleChoice, objects: titlesDocumentTypes);
            listViewDocumentTypes.ChoiceMode = ChoiceMode.Single;
        }

        private void ListViewDocumentTypes_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            position = e.Position;
        }

        private void ButtonNewClient_Click(object sender, EventArgs e)
        {
            if (position <= -1)
            {
                textViewMessage.Text = ResourceMessages.ChoiceNoSelect;
                return;
            }

            if (string.IsNullOrWhiteSpace(editTextDocumentNumber.Text))
            {
                textViewMessage.Text = ResourceMessages.DocumentNumberEmpty;
                return;
            }

            if (string.IsNullOrWhiteSpace(editTextFirstName.Text))
            {
                textViewMessage.Text = ResourceMessages.FirstNameEmpty;
                return;
            }

            if (string.IsNullOrWhiteSpace(editTextSecondName.Text))
            {
                textViewMessage.Text = ResourceMessages.SecondNameEmpty;
                return;
            }

            if (string.IsNullOrWhiteSpace(editTextPhone.Text))
            {
                textViewMessage.Text = ResourceMessages.PhoneEmpty;
                return;
            }

            if (string.IsNullOrWhiteSpace(editTextAnniversary.Text))
            {
                textViewMessage.Text = ResourceMessages.AnniversaryEmpty;
                return;
            }

            if (string.IsNullOrWhiteSpace(editTextEmail.Text))
            {
                textViewMessage.Text = ResourceMessages.EmailEmpty;
                return;
            }

            if (string.IsNullOrWhiteSpace(editTextAddress.Text))
            {
                textViewMessage.Text = ResourceMessages.AddressEmpty;
                return;
            }

            ClientInfo clientInfo = new ClientInfo();

            clientInfo.IdSpecified = false;
            clientInfo.Id = 0;
            clientInfo.DocumentTypeId = idsDocumentTypes[position];
            clientInfo.DocumentTypeIdSpecified = true;
            clientInfo.DocumentNumber = editTextDocumentNumber.Text;

            clientInfo.FirstName = editTextFirstName.Text;
            clientInfo.SecondName = editTextSecondName.Text;

            
            clientInfo.Phone = editTextPhone.Text;
            clientInfo.Readed = false;
            clientInfo.LastReading = 0;
            clientInfo.Address = editTextAddress.Text;
            clientInfo.Anniversary = DateTime.Parse(editTextAnniversary.Text);
            clientInfo.Email = editTextEmail.Text;

            WS.ServiceSAL service = new WS.ServiceSAL();
            service.InsertClientCompleted += Service_InsertClientCompleted;
            service.InsertClientAsync(clientInfo, true);
            textViewMessage.Text = ResourceMessages.Waiting;
            buttonNewClient.Enabled = false;
        }

        private void Service_InsertClientCompleted(object sender, InsertClientCompletedEventArgs e)
        {
            buttonNewClient.Enabled = true;

            if (e == null)
            {
                textViewMessage.Text = ResourceMessages.ArgumentsNull;
                return;
            }

            if (e.Error != null)
            {
                //// TODO: Escribir todas las excepciones para verlas a través de MongoDB.
                textViewMessage.Text = e.Error.Message;
                return;
            }

            if (e.Cancelled)
            {
                textViewMessage.Text = ResourceMessages.RequestCancelled;
                return;
            }
            
            if (!e.InsertClientResult)
            {
                textViewMessage.Text = ResourceMessages.ItemCantUpdate;
            }

            AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
            alertDialog.SetTitle("New Client");
            alertDialog.SetMessage("Client has been created correctly.");
            alertDialog.SetCancelable(false);
            alertDialog.SetPositiveButton("Ok", (object sende, DialogClickEventArgs args) =>
            {
                var orders = new Intent(this, typeof(Orders));
                orders.PutExtra("SellerId", sellerId);
                StartActivity(orders);
            });
            alertDialog.Show();
        }
    }
}