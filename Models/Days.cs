using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MobileFitnessCalorieTracker.Models
{
    public class Days
    {
        // public ObservableCollection<Meal> mealsList = new ObservableCollection<Meal>();

        [PrimaryKey, AutoIncrement]
        public int DayId { get; set; }

        public int userID { get; set; }

        public string dateEntered { get; set; }

        public Days(int userPass, string datePass)
        {
            userID = userPass;

            dateEntered = datePass;

           // mealsList = new ObservableCollection<Meal> { };


        }

        public Days()
        {
          //  mealsList = new ObservableCollection<Meal> { };
        }
        public int GetID(int indexPass)
        {
            return userID;
        }



        public void addMeal(Meal mealpass)
        {

          //  mealsList.Add(mealpass);
        }

    }
}

