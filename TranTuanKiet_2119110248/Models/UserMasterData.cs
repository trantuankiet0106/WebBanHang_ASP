﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TranTuanKiet_2119110248.Context
{
    public partial class UserMasterData
    {
        public int UserID { get; set; }
        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string LastName { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string FistName { get; set; }
        //[Display(Name = "Tên đăng Nhập")]
        //[Required(ErrorMessage = "Không được bỏ trống")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu *")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string Password { get; set; }
        public Nullable<bool> sex { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreaterDate { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string Email { get; set; }
        public Nullable<int> Admin { get; set; }
    }
}