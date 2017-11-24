using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Xml.Linq;

namespace student
{
	public partial class MainPage : ContentPage
	{
        IList<Course> data = new ObservableCollection<Course>();
        HttpClient client = new HttpClient();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = data;
            //CourseContainer.ItemsSource = data;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await nombre();
        }

        public async Task<int> nombre()
        {
            client.BaseAddress = new Uri("https://us-central1-backend-mobile.cloudfunctions.net/v1/");
            HttpResponseMessage response = await client.GetAsync("courses/");
            String res = await response.Content.ReadAsStringAsync();
            var Data = JObject.Parse(res);
            data.Clear();
            foreach (var i in Data["data"])
            {
                //Console.WriteLine(i["name"].ToString());
                Course temp = new Course(i["name"].ToString(), i["id"].ToString());
                data.Add(temp);
            }
            return 0;
        }
    }
}
