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
    }


}