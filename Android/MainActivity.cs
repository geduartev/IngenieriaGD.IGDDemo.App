using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace Android
{
    [Activity(Label = "IGDDemo App", MainLauncher = true)]
    public class MainActivity : Activity
    {
        TextView textViewMessage;
        EditText editTextUser;
        EditText editTextPassword;
        Button buttonLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            textViewMessage = FindViewById<TextView>(Resource.Id.textViewMessage);
            editTextUser = FindViewById<EditText>(Resource.Id.editTextUser);
            editTextPassword = FindViewById<EditText>(Resource.Id.editTextPassword);
            buttonLogin = FindViewById<Button>(Resource.Id.buttonLogin);

            buttonLogin.Click += buttonLogin_Click;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(editTextUser.Text) || string.IsNullOrWhiteSpace(editTextPassword.Text))
            {
                textViewMessage.Text = "Debe ingresar usuario y contraseña.";
            }

            WS.ServiceSAL service = new WS.ServiceSAL();
            service.ValidateUserCompleted += Service_ValidateUserCompleted;
            service.ValidateUserAsync(editTextUser.Text, editTextPassword.Text);
            textViewMessage.Text = "Validando, por favor espere...";
            buttonLogin.Enabled = false;
        }

        private void Service_ValidateUserCompleted(object sender, WS.ValidateUserCompletedEventArgs e)
        {
            buttonLogin.Enabled = true;

            if (e.Error != null)
            {
                textViewMessage.Text = e.Error.Message;
            }
            else if (e.Cancelled)
            {
                textViewMessage.Text = "Request was cancelled.";
            }
            else
            {
                if (!e.ValidateUserResult)
                {
                    textViewMessage.Text = "Usuario o clave inválidos. Por favor intente de nuevo.";
                    editTextPassword.Text = string.Empty;
                    return;
                }
            }

            textViewMessage.Text = "Bienvenido...";
            var menu = new Intent(this, typeof(Menu));
            StartActivity(menu);
        }
    }
}

