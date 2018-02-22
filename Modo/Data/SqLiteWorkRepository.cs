using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Modo.Model;

namespace Modo.Data
{
    public class SqLiteWorkRepository : SqLiteBaseRepository, IWorkRepository
    {
        public bool DeleteWork(Work work)
        {
            throw new NotImplementedException();
        }

        public Work GetWork(int id)
        {
            throw new NotImplementedException();
        }

        public List<Work> GetWorks(bool isContainDone)
        {
            List<Work> result = null;
            try
            {
                using (var conn = DbConnection)
                {
                    conn.Open();
                    SqliteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "create table IF NOT EXISTS Work (" +
                        "Id integer primary key, Title text not null, Desc text, CreateTime datetime, ReserveTime datetime, CompleteTime datetime " +
                        ") ";
                    SqliteDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        //reader.GetData(0);
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

                throw;
            }
            return result;
        }

        public int InsertWork(Work work)
        {
            throw new NotImplementedException();
        }

        public bool Reset()
        {
            throw new NotImplementedException();
        }

        public bool UpdateWork(Work work)
        {
            throw new NotImplementedException();
        }


    }
}
