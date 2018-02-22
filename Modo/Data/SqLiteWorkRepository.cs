using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using Modo.Model;

namespace Modo.Data
{
    public class SqLiteWorkRepository : SqLiteBaseRepository, IWorkRepository
    {
        public SqLiteWorkRepository()
        {

        }
        
        public bool DeleteWork(Work work)
        {
            throw new NotImplementedException();
        }

        public Work GetWork(long id)
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

        public long InsertWork(Work work)
        {
            try
            {
                using (var conn = DbConnection)
                {
                    conn.Open();

                    long workId = conn.Insert<Work>(work);

                    conn.Close();
                    return workId;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

                throw;
            }

        }

        public bool Reset()
        {
            try
            {
                using (var conn = DbConnection)
                {
                    conn.Open();
                    return conn.DeleteAll<Work>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

                throw;
            }

            throw new NotImplementedException();
        }

        public bool UpdateWork(Work work)
        {
            throw new NotImplementedException();
        }


    }
}
