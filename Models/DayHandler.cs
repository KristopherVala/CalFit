using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using SQLite;

namespace MobileFitnessCalorieTracker.Models
{
   public class DayHandler
    {
        [PrimaryKey]
        public int Id { get; set; }

        public ObservableCollection<Days> daysList { get; set; }


        public DayHandler()
        {
            daysList = new ObservableCollection<Days>
            { };



        }
     public int GetID(int indexPass)
        {
            return daysList[indexPass].userID;
        }

        public ObservableCollection<Days> getDays()
        {
            var days = new ObservableCollection<Days>();

            return days;

        }

        public void addDay(int UID, string datePass)
        {
            Days temp = new Days(UID, datePass);
            daysList.Add(temp);

        }



    }
}
