using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TranTuanKiet_2119110248.Models;

namespace TranTuanKiet_2119110248.Context
{
    
    [MetadataType(typeof(BrandMasterData))]
    public partial class Brand
    {
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
 

    [MetadataType(typeof(ProductMasterData))]
    public partial class Product
    {
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public object ViewDetail { get; internal set; }

      
    }


    [MetadataType(typeof(CategoryMasterData))]
    public partial class Category
    {
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }

    [MetadataType(typeof(UserMasterData))]
    public partial class User
    {
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }


    [MetadataType(typeof(OrderMasterData))]
    public partial class Order 
    {
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }

    [MetadataType(typeof(OrderDetailMasterData))]
    public partial class OrderDetail
    {
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
    
}