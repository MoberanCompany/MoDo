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
        
        /// <summary>
        /// todo 삭제하기
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
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

        /// <summary>
        /// todo 리스트 가져오기
        /// </summary>
        /// <param name="isContainDone"></param>
        /// <returns></returns>
        public List<Work> GetWorks(bool isContainDone)
        {
            try
            {
                using (var conn = DbConnection)
                {
                    conn.Open();
                    var list = conn.GetAll<Work>();
                    if (isContainDone == false)
                    {
                        return list.Where(w => w.CompleteTime == null).ToList();
                    }
                    
                    return list.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return new List<Work>();
        }

        /// <summary>
        /// todo 추가
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        public long InsertWork(Work work)
        {
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
            }

            return -1;
        }

        /// <summary>
        /// todo 전부 삭제
        /// </summary>
        /// <returns></returns>
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
        }

        /// <summary>
        /// todo 업데이트
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
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
