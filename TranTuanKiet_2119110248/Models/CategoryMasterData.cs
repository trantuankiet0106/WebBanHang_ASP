using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TranTuanKiet_2119110248.Context
{
    public partial class CategoryMasterData
    {
        public int id { get; set; }
        [Display(Name = "Tên danh Mục *")]
        public string name { get; set; }
        [Display(Name = "hình ảnh")]
        public string avatar { get; set; }
        [Display(Name = "Phổ Biến")]
        public Nullable<int> Popular { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Trang Chủ")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdateOnUtc { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}