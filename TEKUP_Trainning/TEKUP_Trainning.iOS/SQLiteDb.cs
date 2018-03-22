using System;
using System.IO;
using Xamarin.Forms;
using SQLite;
using TEKUP_Trainning.iOS;

[assembly:Dependency(typeof(SQLiteDb))]
namespace TEKUP_Trainning.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {

            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "MYDB.db3");
            return new SQLiteAsyncConnection(path);
        }

    }
}
