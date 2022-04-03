using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TranTuanKiet_2119110248.Context
{
    public partial class ProductMasterData
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Avatar { get; set; }
        public Nullable<double> ProductPrice { get; set; }
        public Nullable<double> PriceDiscount { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> BrandId { get; set; }
        public string ShortDes { get; set; }
        public string FullDes { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}