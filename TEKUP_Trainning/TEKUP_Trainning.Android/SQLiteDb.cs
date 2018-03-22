using System;
using System.IO;
using Xamarin.Forms;
using SQLite;
using TEKUP_Trainning.Droid;

[assembly:Dependency(typeof(SQLiteDb))]
namespace TEKUP_Trainning.Droid
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "MyDataBase.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}