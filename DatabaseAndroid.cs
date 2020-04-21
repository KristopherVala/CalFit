using System;
using SQLite;
using System.IO;
using MobileFitnessCalorieTracker.Droid;


[assembly: Xamarin.Forms.Dependency(typeof(DatabaseAndroid))]

namespace MobileFitnessCalorieTracker.Droid
{
   public class DatabaseAndroid : ISQLiteDb
    {
		public SQLiteAsyncConnection GetConnection()
		{
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MobileFitness.db3");

            return new SQLiteAsyncConnection(path);
        }

	}
}   