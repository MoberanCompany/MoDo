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
        public static string DbFile
        {
            get { return Path.Combine(ApplicationData.Current.LocalFolder.Path, "SimpleDb.sqlite"); }
        }
    }
}
