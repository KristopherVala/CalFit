using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using MobileFitnessCalorieTracker.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MobileFitnessCalorieTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMeal : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        DayHandler model;
        public ObservableCollection<Meal> searchedMeals = new ObservableCollection<Meal>();
        ProfileModel loggedIn;
        int currentDayID; 
        public AddMeal(int passedDayId , ProfileModel loggedinUser)
        {
            InitializeComponent();
            loggedIn = loggedinUser;
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            currentDayID = passedDayId;
        }



        private void SubmitDay(object sender, EventArgs e)
        {



        }

        async private void SearchFood(object sender, EventArgs e)
        {

            if( searchEntry.Text!= null) {
                searchedMeals.Clear();
            string burg = searchEntry.Text;

            string url = "https://api.nutritionix.com/v1_1/search/" + burg + "?results=0:5&fields=*&appId=97151152&appKey=ec1c96b705e2a8b566963ef405eda712";
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();

            Rootobject deserial =  JsonConvert.DeserializeObject<Rootobject>(content , new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });


            for(int i =0; i < deserial.hits.Length; i++)
            {
                searchedMeals.Add(new Meal {userID = loggedIn.profileID, nameOfMeal = deserial.hits[i].fields.item_name, Calories = deserial.hits[i].fields.nf_calories });

            }


            mealsLister.ItemsSource = searchedMeals;


            }else
                await DisplayAlert("Error!", "Please fill in the search field!", "OK");



        }


        async private void Cancel(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);

        }

        async private void onTapped(object sender, EventArgs e)
        {

        }




        async void onSelected(Object sender, EventArgs args)
        {
            var item = mealsLister.SelectedItem as Meal;




            await _connection.CreateTableAsync<Meal>();

            var insertItem = new Meal()
            {
                nameOfMeal = item.nameOfMeal,
                Calories = item.Calories,
                userID = loggedIn.profileID,
                dayID = currentDayID
            };
            int rowsadded = await _connection.InsertAsync(insertItem);
            var i = 0; //breakpoint tester
            if(rowsadded == 1)
            {
                await DisplayAlert("Meal added!", "Thank you!", "OK");
                await Navigation.PopAsync(true);

            }
            else
            {
                await DisplayAlert("Error", "Please try again!", "OK");

            }
        }



    }

}