﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.DTOs
{
    public class PromotionDTO
    {
        public double PromotionPercent { get; set; }
        public IList<ProductDTO> Products { get; set; }
    }
}