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
            try
            {
                using (var conn = DbConnection)
                {
                    conn.Open();
                    return conn.Get<Work>(id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return null;
        }

        public List<Work> GetWorks(bool isContainDone)
        {
            try
            {
                using (var conn = DbConnection)
                {
                    conn.Open();
                    return conn.GetAll<Work>().ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return new List<Work>();
        }

        public long InsertWork(Work work)
        {
            try
            {
                using (var conn = DbConnection)
                {
                    conn.Open();
                    var workId = conn.Insert<Work>(work);
                    conn.Close();
                    return workId;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return -1;
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
