using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranTuanKiet_2119110248.Models
{
    public class ProductCategory
    {
        public int id { get; set; }
       public List<Product> listProducts { get; set; }
       public List<Category> listCategory { get; set; }
    }
}