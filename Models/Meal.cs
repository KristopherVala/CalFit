using System;
using System.Collections.Generic;
using System.Text;

namespace MobileFitnessCalorieTracker.Models
{
    public class Meal
    {
        public string nameOfMeal { get; set; }

        public double Calories { get; set; }

        public int userID { get; set; }

        public int dayID { get; set; }


    }
}
