using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Net.Http;



namespace student
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        HttpClient client = new HttpClient();

        public Login ()
		{
			InitializeComponent ();
            checkConnectivity(CrossConnectivity.Current.IsConnected);
            CrossConnectivity.Current.ConnectivityChanged += HandleConnectivityChanged;
        }
        
        public async Task<bool> CheckLogin()
        {
            String Username = username.Text;
            String Password = password.Text;
            username.Text = "";
            password.Text = "";
            client.BaseAddress = new Uri("https://us-central1-backend-mobile.cloudfunctions.net/v1/");
            string resq = @"{""username : " + Username + " , password : " + Password + "\"" + "}";
            HttpStringContent palabra = new HttpStringContent(resq, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("login/student/",palabra);
            
            if (response.ReadAsBoolAsync())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task SendLoginAsync(Object sender, System.EventArgs e)
        {
            if (await CheckLogin())
            {
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Error", "Error", "OK");
            }
        }

        async void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            await DisplayAlert("HandleConnectivityChanged", "Changed", "Ok");
            checkConnectivity(e.IsConnected);
        }

        public void checkConnectivity(bool sw)
        {
            if (sw)
            {

            }
            else
            {
                DisplayAlert("Error", "Error connection", "OK");
            }
        }
    }
}