using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modo.Model
{
    [Table("Work")]
    public class Work
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ReserveTime { get; set; }
        public DateTime? CompleteTime { get; set; }
    }
}
