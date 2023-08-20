﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranTuanKiet_2119110248.Context;

namespace TranTuanKiet_2119110248.Models
{
    public class HomeModel 
    {
        public new List<Category> lstCategory { get; set; }
        public new List<Product> lstProduct { get; set; }
        public new List<Slide> lstSlides { get; set; }
        public new List<Picture>lstPicture { get; set; }
        public new List<Brand>lstBrand { get; set; }
        public new List<About> lstabouts { get; set; }
        public new List<OrderDetail> lstOrderDetail { get; set; }
        public new List<User> lstUsers { get; set; }
        public int id { get; set; }


    }
}