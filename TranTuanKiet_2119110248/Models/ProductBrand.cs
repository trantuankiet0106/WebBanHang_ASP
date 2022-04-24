using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranTuanKiet_2119110248.Context;

namespace TranTuanKiet_2119110248.Models
{
    public class ProductBrand
    {
        public int id { get; set; }
        public List<Product> listProducts { get; set; }
        public List<Brand> listBrand { get; set; }

    }
}