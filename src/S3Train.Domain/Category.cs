using System.Collections.Generic;

namespace S3Train.Domain
{
    public class Category : EntityBase
    {
        public string NameCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}