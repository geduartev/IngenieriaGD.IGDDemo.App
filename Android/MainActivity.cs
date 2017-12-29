using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using IngenieriaGD.IGDDemo.App.AndroidApp.WS;
using static IngenieriaGD.IGDDemo.App.AndroidApp.Resource;

namespace IngenieriaGD.IGDDemo.App.AndroidApp
{
    [Activity(Label = "IGDDemo App", MainLauncher = true)]
    public class MainActivity : Activity
    {
        #region Declaration of Controls

        TextView textViewMessage;
        EditText editTextUser;
        EditText editTextPassword;
        Button buttonLogin;
        ProgressBar progressBarProgress;

        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Layout.Main);

            #region Found Controls

            textViewMessage = FindViewById<TextView>(Id.textViewMessage);
            editTextUser = FindViewById<EditText>(Id.editTextUser);
            editTextPassword = FindViewById<EditText>(Id.editTextPassword);
            buttonLogin = FindViewById<Button>(Id.buttonLogin);
            progressBarProgress = FindViewById<ProgressBar>(Id.progressBarProgress);

            #endregion

            #region Event of Controls

            buttonLogin.Click += buttonLogin_Click;

            #endregion

            progressBarProgress.Visibility = Android.Views.ViewStates.Invisible;
            //var newClient = new Intent(this, typeof(NewClient));
            //newClient.PutExtra("SellerId", 0);
            //StartActivity(newClient);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(editTextUser.Text) || string.IsNullOrWhiteSpace(editTextPassword.Text))
            {
                textViewMessage.Text = ResourceMessages.LoginUserOrPasswordEmpty;
            }

            WS.ServiceSAL service = new WS.ServiceSAL();
            service.ValidateUserCompleted += Service_ValidateUserCompleted;
            service.ValidateUserAsync(editTextUser.Text, editTextPassword.Text);
            progressBarProgress.Visibility = Android.Views.ViewStates.Visible;
            textViewMessage.Text = ResourceMessages.LoginValidating;
            buttonLogin.Enabled = false;
        }

        private void Service_ValidateUserCompleted(object sender, WS.ValidateUserCompletedEventArgs e)
        {
            buttonLogin.Enabled = true;

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

            if (e.ValidateUserResult == null)
            {
                textViewMessage.Text = ResourceMessages.ItemDoesntExist;
                return;
            }

            if (!e.ValidateUserResult)
            {
                textViewMessage.Text = ResourceMessages.LoginUserOrPasswordInvalid;
                editTextPassword.Text = string.Empty;
                return;
            }

            progressBarProgress.Visibility = Android.Views.ViewStates.Invisible;
            textViewMessage.Text = ResourceMessages.Welcome;
            var menu = new Intent(this, typeof(Menu));
            menu.PutExtra("sellerId", e.ValidateUserResult);
            StartActivity(menu);
        }
    }
}

