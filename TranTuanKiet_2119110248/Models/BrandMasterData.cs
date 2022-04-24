using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TranTuanKiet_2119110248.Context
{
    public class  BrandMasterData
    {
        [Display(Name = "Mã Thương Hiệu")]
        public int BranID { get; set; }
        [Display(Name = "Tên Thương Hiệu")]
        public string BrandName { get; set; }
        [Display(Name = "Hình Ảnh")]
        public string Avatar { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreateDate { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

    }
}