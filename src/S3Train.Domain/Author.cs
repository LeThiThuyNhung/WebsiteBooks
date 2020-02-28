using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class Author : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Author_Product> Author_Products { get; set; }
    }
}
