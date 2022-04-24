using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TranTuanKiet_2119110248.Context
{
    public partial class OderMasterdata
    {

        public int Id { get; set; }

        [Display(Name = "Tên Hàng")]
        public string Name { get; set; }
        [Display(Name = "MÃ Khách Hàng")]
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<int> Status { get; set; }
        public string ProducName { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<double> prices { get; set; }

    }
}