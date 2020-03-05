
using System.Collections.Generic;
using System.Linq;


namespace S3Train.Web.Models
{
    public class HomeViewModel
    {
        public IList<SliderItemViewModel> SliderItems { get; set; }
        public IEnumerable<IGrouping<int, ProductViewModel>> NewProducts { get; set; }
        public IEnumerable<IGrouping<int, CSProductViewModel>> CSProducts { get; set; }
        public IEnumerable<IGrouping<int, PromotionProductViewModel>> PromotionProducts { get; set; }
    }
}