using System;
using MobileFitnessCalorieTracker.iOS;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseIOS))]

namespace MobileFitnessCalorieTracker.iOS
{
    public class DatabaseIOS : ISQLiteDb
    {

            public SQLiteAsyncConnection GetConnection()
            {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MobileFitness.db3");

            return new SQLiteAsyncConnection(path);
        }

        }
    }
