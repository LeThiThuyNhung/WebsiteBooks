using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class Position : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
