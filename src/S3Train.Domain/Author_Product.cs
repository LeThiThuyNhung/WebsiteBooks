using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class Author_Product : EntityBase
    {
        public Guid AuthorId { get; set; }
        public Guid ProductId { get; set; }
        public string Role { get; set; }
        public virtual Author Author { get; set; }
        public virtual Product Product { get; set; }
    }
}
