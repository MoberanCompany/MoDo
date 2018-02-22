using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modo.Message
{
    public enum SourcePage
    {
        None,
        List,
        Calender,
        Setting,
        Detail
    }

    public class MovePage
    {
        public SourcePage SourcePageType { get; set; }
        public bool IsTop { get; set; }

        public MovePage()
        {
            IsTop = true;
        }
    }
}
