using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using SQLite;
using System.IO;
using TEKUP_Trainning.UWP;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteDb))]
namespace TEKUP_Trainning.UWP
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(documentPath, "MyDataBase.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}
