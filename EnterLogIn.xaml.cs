using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileFitnessCalorieTracker.Models;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileFitnessCalorieTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterLogIn : ContentPage
    {
        public SQLiteAsyncConnection _connection;
        ObservableCollection<ProfileModel> allProfiles;


        public EnterLogIn()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        protected async override void OnAppearing()
        {
            //  await _connection.DropTableAsync<ProfileModel>();
            //   await _connection.DropTableAsync<Days>();

            await _connection.CreateTableAsync<ProfileModel>();
         var profilesFromDB = await _connection.Table<ProfileModel>().ToListAsync();
         allProfiles = new ObservableCollection<ProfileModel>(profilesFromDB);


        }

        async protected void SubmitSignIn(object sender, EventArgs e)
        {

            if (NameLogInEntry.Text == null || PasswordLogInEntry.Text == null)
            {
                await DisplayAlert("Error!", "Log in information missing!", "OK");

            }
            for (int i = 0; i < allProfiles.Count; i++)
            {
                if (allProfiles[i].name == NameLogInEntry.Text && allProfiles[i].password == PasswordLogInEntry.Text)
                {
                    await Navigation.PushAsync(new HomePage(allProfiles[i]));
                    break;

                }
                if(i == allProfiles.Count - 1)
                {
                    await DisplayAlert("Error!", "Log in information wrong!", "OK");

                }
            }
        }


        async private void Cancel(object sender, EventArgs e)
        {

            await Navigation.PopAsync(true);


        }

    }
}