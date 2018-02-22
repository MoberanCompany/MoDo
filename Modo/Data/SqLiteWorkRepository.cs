using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Work GetWork(int id)
        {
            throw new NotImplementedException();
        }

        public List<Work> GetWorks(bool isContainDone)
        {
            throw new NotImplementedException();
        }

        public int InsertWork(Work work)
        {
            throw new NotImplementedException();
        }

        public bool UpdateWork(Work work)
        {
            throw new NotImplementedException();
        }
    }
}
