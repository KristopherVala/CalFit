using MobileFitnessCalorieTracker.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileFitnessCalorieTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsOfDay : ContentPage
    {

        private SQLiteAsyncConnection _connection;
        public ObservableCollection<Meal> searchedMeals = new ObservableCollection<Meal>();
        ProfileModel loggedIn;
        int currentDayID;
        double totalCalories = 0;


        public DetailsOfDay(int passedDayId, ProfileModel loggedinUser)
        {
            InitializeComponent();

            loggedIn = loggedinUser;
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            currentDayID = passedDayId;
        }



        protected async override void OnAppearing()
        {

            searchedMeals = new ObservableCollection<Meal>();

            await _connection.CreateTableAsync<Meal>();
            var mealsFromDB = await _connection.Table<Meal>().ToListAsync();

            for (var i = 0; i < mealsFromDB.Count; i++)
            {
                if (mealsFromDB[i].dayID == currentDayID && mealsFromDB[i].userID == loggedIn.profileID)
                {
                    searchedMeals.Add(mealsFromDB[i]);
                }

               

            }
            for (var x = 0; x < searchedMeals.Count; x++)
            {

                totalCalories += searchedMeals[x].Calories;
            }
            totalLabel.Text = "Total Calories: " + totalCalories;
            mealsLister.ItemsSource = searchedMeals;
            mealsListerRight.ItemsSource = searchedMeals;



        }



    }
}