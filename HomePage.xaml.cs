using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using MobileFitnessCalorieTracker.Models;
using System.Collections.ObjectModel;

namespace MobileFitnessCalorieTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        DayHandler model = new DayHandler();
        ProfileModel loggedInUser;

        ObservableCollection<Days> listofdays;

        public HomePage(ProfileModel passedUser)
        {
            InitializeComponent();

            loggedInUser = passedUser;

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            BindingContext = model.daysList;
            DaysLister.ItemsSource = model.daysList;
            DaysListerRight.ItemsSource = model.daysList;

        }

        protected async override void OnAppearing()
        {
            listofdays = new ObservableCollection<Days>();
            //  await _connection.DropTableAsync<ProfileModel>();

            await _connection.CreateTableAsync<Days>();
            var daysFromDB = await _connection.Table<Days>().ToListAsync();


            for(var i = 0; i < daysFromDB.Count; i++)
            {
                if (daysFromDB[i].GetID(i) == loggedInUser.profileID)
                {
                    listofdays.Add(daysFromDB[i]);
                }


            }

            DaysLister.ItemsSource = listofdays;
            DaysListerRight.ItemsSource = listofdays;


        }


        async private void profileButton(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Profile(loggedInUser));

        }

        async private void addDay(object sender, EventArgs e)
        {
            bool safeTomake = true;
            for(int i = 0; i < listofdays.Count; i++)
            {
                if (listofdays[i].dateEntered.Equals(DateTime.Now.ToString("MMMM dd")) ){
                    safeTomake = false; 
                }

            }

            if(safeTomake){ 
            model.addDay(loggedInUser.profileID, DateTime.Now.ToString("MMMM dd"));

            await _connection.CreateTableAsync<Days>();

            var insertItem = new Days()
            {
                userID = loggedInUser.profileID,
                dateEntered = DateTime.Now.ToString("MMMM dd")
              //  mealsList = new ObservableCollection<Meal>()
        };
                listofdays.Add(insertItem);
            int rowsadded = await _connection.InsertAsync(insertItem);
            var i = 0; //breakpoint tester
              DaysLister.ItemsSource = listofdays;

            }
            else
            {
                await DisplayAlert("Error!", "Day already created!", "OK");

            }

        }


        async void onSelected(Object sender, EventArgs args)
        {
            var item = DaysLister.SelectedItem as Days;

            var index = item.DayId;

             await Navigation.PushAsync(new AddMeal(index, loggedInUser));


        }



        async void onSelectedMoreDetails(Object sender, EventArgs args)
        {
            var item = DaysListerRight.SelectedItem as Days;

            var index = item.DayId;

            await Navigation.PushAsync(new DetailsOfDay(index, loggedInUser));


        }


    }
}