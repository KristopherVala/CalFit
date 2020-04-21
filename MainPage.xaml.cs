using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
namespace MobileFitnessCalorieTracker
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        private SQLiteAsyncConnection _connection;

        public MainPage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();


        }
      


        async public void HomePageButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EnterLogIn());
        }

        async public void SignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }

    }
}
