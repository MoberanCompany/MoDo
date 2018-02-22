using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Modo.Data
{
    public class SqLiteBaseRepository
    {
        public SqLiteBaseRepository()
        {
            CreateDatabase();
        }
        public static string DbFile
        {
            get { return Path.Combine(ApplicationData.Current.LocalFolder.Path, "SimpleDb.sqlite"); }
        }
        public static SqliteConnection DbConnection
        {
            get
            {
                return new SqliteConnection("Filename=./my_database.db");
            }
        }
        public void CreateDatabase()
        {
            try
            {
                using (var conn = DbConnection)
                {
                    conn.Open();
                    SqliteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "create table IF NOT EXISTS Work (" +
                        "Id integer primary key, Title text not null, Desc text, CreateTime datetime, ReserveTime datetime, CompleteTime datetime " +
                        ") ";
                    cmd.ExecuteReader();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

                throw;
            }
        }
    }
}