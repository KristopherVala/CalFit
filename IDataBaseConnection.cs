using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileFitnessCalorieTracker
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();

    }
}
