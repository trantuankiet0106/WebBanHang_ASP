using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TranTuanKiet_2119110248.Models
{
    public class BrandMasterData
    {
        public int BranID { get; set; }
        public string BrandName { get; set; }
        public string Avatar { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

    }
}