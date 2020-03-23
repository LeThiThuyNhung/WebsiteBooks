using System.Collections.Generic;

namespace S3Train.Domain
{
    public class Publisher : EntityBase
    {
        public string NamePublisher { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
