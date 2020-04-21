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
    public partial class SignUp : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        ObservableCollection<ProfileModel> allProfiles;

        public SignUp()
        {
            InitializeComponent();


        }

        async private void SubmitSignUp(object sender, EventArgs e)
        {

            if (NameEntry.Text != null && AgeEntry.Text != null && PasswordEntry.Text != null)
            {
                _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

              await _connection.CreateTableAsync<ProfileModel>();

                var insertItem = new ProfileModel()
                {
                    name = NameEntry.Text,
                    age = AgeEntry.Text,
                    password = PasswordEntry.Text,
                     dateSignedUp = DateTime.Now.ToString("MMMM dd")

                };

             int rowsadded = await _connection.InsertAsync(insertItem);


                await DisplayAlert("Thank you " + NameEntry.Text +"!","We are so excited that you have registered! We hope you achieve your goals!", "OK");

                await Navigation.PushAsync(new EnterLogIn());
            }
            else
            {
                await DisplayAlert("Error!", "The name, age or password field cannot be empty!", "OK");


            }

        }


      async private void Cancel(object sender, EventArgs e)
        {

            await Navigation.PopAsync(true);


        }

    }
}