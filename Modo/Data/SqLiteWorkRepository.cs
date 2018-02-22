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
            try
            {
                using (var conn = DbConnection)
                {
                    conn.Open();
                    return conn.Delete(work);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Work GetWork(long id)
        {
            throw new NotImplementedException();
        }

        public List<Work> GetWorks(bool isContainDone)
        {
            try
            {
                using (var conn = DbConnection)
                {
                    conn.Open();
                    return (List <Work>) conn.GetAll<Work>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public long InsertWork(Work work)
        {
            //string title = work.Title;
            //DateTime dateTime = work.CreateTime;
            //int workId = work.Id;

            //InsertDatabase(title, dateTime);
            //return workId;
            ////throw new NotImplementedException();

            try
            {
                using (var conn = DbConnection)
                {
                    conn.Open();

                    return conn.Insert<Work>(work);
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
            throw new NotImplementedException();
        }

        public bool UpdateWork(Work work)
        {
            try
            {
                using (var conn = DbConnection)
                {
                    conn.Open();
                    return conn.Update(work);
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
