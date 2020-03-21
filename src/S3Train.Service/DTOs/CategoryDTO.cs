using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.DTOs
{
    public class CategoryDTO
    {
        public string CategoryName { get; set; }

        public IList<ProductDTO> Products { get; set; }
    }
}
