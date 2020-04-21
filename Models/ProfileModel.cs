using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileFitnessCalorieTracker.Models
{
    public class ProfileModel
    {
        [PrimaryKey, AutoIncrement]
        public int profileID { get; set; }

        public string name { get; set; }

        public string age { get; set; }

        public string dateSignedUp { get; set; }


        public string password { get; set; }


      /*  public ProfileModel(string namePass, string agePass, string passwordPass)
        {
            name = namePass;

            age = agePass;

            password = passwordPass;

        }*/
    }
}
