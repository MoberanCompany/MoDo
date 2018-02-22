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

        public Work GetWork(long id)
        {
            throw new NotImplementedException();
        }

        public void SaveWork(Work work)
        {
            throw new NotImplementedException();
        }
    }
}
