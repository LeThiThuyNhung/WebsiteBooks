using System.Collections.Generic;
using System.Linq;

namespace S3Train.Models
{
    public class HomeViewModel
    {
        public IList<SliderItemViewModel> SliderItems { get; set; }
        public IEnumerable<IGrouping<int, ProductViewModel>> Products { get; set; }
        public IList<CategoryViewModel> CategoryItems { get; set; }
    }
}