﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.DTOs
{
    public class CSProductDTO
    {
        public string NameProduct { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public int Grouping { get; set; }
    }
}
