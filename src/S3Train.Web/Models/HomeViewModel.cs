﻿
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
        public IList<CategoryViewModel> ProductsByCategory { get; set; }
        public IList< ProductViewModel> newProducts { get; set; }
        public IList<CSProductViewModel> csProducts { get; set; }
        public IList<PromotionProductViewModel> bestSellerProducts { get; set; }
    }
}