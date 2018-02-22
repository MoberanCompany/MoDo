using Modo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modo.Data
{
    public interface IWorkRepository
    {
        long InsertWork(Work work);

        Work GetWork(long id);
        List<Work> GetWorks(bool isContainDone);

        bool UpdateWork(Work work);
        bool DeleteWork(Work work);

        bool Reset();
    }
}
