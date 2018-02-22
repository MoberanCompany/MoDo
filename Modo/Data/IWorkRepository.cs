using Modo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modo.Data
{
    interface IWorkRepository
    {
        Work GetWork(long id);
        void SaveWork(Work work);
    }
}
