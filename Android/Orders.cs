using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using static Android.Resource;

namespace IngenieriaGD.IGDDemo.App.AndroidApp
{
    [Activity(Label = "Orders - IGDDemo App")]
    public class Orders : Activity
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
        Button buttonSearchDocumentType;

        EditText editTextDocumentNumber;
        Button buttonSearchDocumentNumber;

        TextView textViewClientName;

        Button buttonNewClient;
        Button buttonContinueWithOrder;

        #endregion


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Orders);

            sellerId = Intent.GetIntExtra("sellerId", 0);

            #region Find Controls

            textViewMessage = FindViewById<TextView>(Resource.Id.textViewMessage);

            listViewDocumentTypes = FindViewById<ListView>(Resource.Id.listViewDocumentTypes);
            buttonSearchDocumentType = FindViewById<Button>(Resource.Id.buttonSearchDocumentType);

            editTextDocumentNumber = FindViewById<EditText>(Resource.Id.editTextDocumentNumber);
            buttonSearchDocumentNumber = FindViewById<Button>(Resource.Id.buttonSearchDocumentNumber);
            
            textViewClientName = FindViewById<TextView>(Resource.Id.textViewClientName);
            
            buttonNewClient = FindViewById<Button>(Resource.Id.buttonNewClient);
            buttonContinueWithOrder = FindViewById<Button>(Resource.Id.buttonContinueWithOrder);

            #endregion

            #region Event Controls

            buttonSearchDocumentNumber.Click += ButtonSearchDocumentNumber_Click;
            buttonSearchDocumentType.Click += ButtonSearchDocumentType_Click;

            buttonNewClient.Click += ButtonNewClient_Click;
            buttonContinueWithOrder.Click += ButtonContinueWithOrder_Click;

            listViewDocumentTypes.ItemClick += ListViewDocumentTypes_ItemClick;

            #endregion

            WS.ServiceSAL service = new WS.ServiceSAL();
            service.GetAllDocumentTypesCompleted += Service_GetAllDocumentTypesCompleted;
            service.GetAllDocumentTypesAsync();
        }

        private void ListViewDocumentTypes_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            position = e.Position;
        }

        private void ButtonContinueWithOrder_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonNewClient_Click(object sender, EventArgs e)
        {
            var newClient = new Intent(this, typeof(NewClient));
            newClient.PutExtra("SellerId", sellerId);
            StartActivity(newClient);
        }

        private void ButtonSearchDocumentType_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonSearchDocumentNumber_Click(object sender, EventArgs e)
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

            WS.ServiceSAL service = new WS.ServiceSAL();
            service.GetClientByDocumentCompleted += Service_GetClientByDocumentCompleted;
            service.GetClientByDocumentAsync(idsDocumentTypes[position], true, editTextDocumentNumber.Text);
            textViewMessage.Text = ResourceMessages.Waiting;
            buttonSearchDocumentNumber.Enabled = false;
        }

        private void Service_GetClientByDocumentCompleted(object sender, WS.GetClientByDocumentCompletedEventArgs e)
        {
            buttonSearchDocumentNumber.Enabled = true;

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
            
            if ( e.Result == null)
            {
                textViewMessage.Text =  ResourceMessages.DoesntExistItem + editTextDocumentNumber.Text;
                editTextDocumentNumber.Text = string.Empty;
                textViewClientName.Text = string.Empty;
                buttonContinueWithOrder.Enabled = false;
                return;
            }

            textViewMessage.Text = ResourceMessages.ItemFound;
            editTextDocumentNumber.Text = string.Empty;
            textViewClientName.Text = e.Result.FirstName + " " + e.Result.SecondName;
            buttonContinueWithOrder.Enabled = true;
        }

        private void Service_GetAllDocumentTypesCompleted(object sender, WS.GetAllDocumentTypesCompletedEventArgs e)
        {
            idsDocumentTypes = new List<int>();
            titlesDocumentTypes = new List<string>();
            codesDocumentTypes = new List<string>();
            position = -1;

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

            foreach (var item in e.Result)
            {
                idsDocumentTypes.Add(item.Id);
                titlesDocumentTypes.Add(item.Title);
                codesDocumentTypes.Add(item.Code);
            }

            listViewDocumentTypes.Adapter = new ArrayAdapter(context: this, resource: Layout.SimpleListItemSingleChoice, objects: titlesDocumentTypes);
            listViewDocumentTypes.ChoiceMode = ChoiceMode.Single;
        }
    }
}