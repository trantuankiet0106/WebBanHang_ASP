using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TranTuanKiet_2119110248.Context
{
    public partial class ProductMasterData
    {
        public int ProductId { get; set; }
        [Display(Name ="Tên sản Phẩm")]
        [Required(ErrorMessage = "Không được bỏ trống Tên sản Phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Hình ảnh")]
      
        public string Avatar { get; set; }
        [Display(Name = "Giá Gốc")]
  
        public Nullable<double> ProductPrice { get; set; }
        [Display(Name = "Giá Khuyến mãi")]
        public Nullable<double> PriceDiscount { get; set; }
        [Display(Name = " Danh Mục")]
        public Nullable<int> CategoryId { get; set; }
        [Display(Name = " Thương Hiệu")]
        public Nullable<int> BrandId { get; set; }
        [Display(Name = "Mô Tả Ngắn")]
        public string ShortDes { get; set; }
        [Display(Name = "Mô Tả Đầy Đủ")]
        public string FullDes { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get ; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreateDate { get; set; }
        [Display(Name = "Ngày chỉnh sữa")]
     
        public Nullable<System.DateTime> UpdateDate { get; set; }
        [Display(Name = "Loại sản Phẩm")]
        public Nullable<int> TypeId { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}