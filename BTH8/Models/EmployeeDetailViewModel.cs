using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTH8.Models
{
    public class EmployeeDetailViewModel
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public string ThanhPho { get; set; }
        public int MaPB { get; set; } 
        public string TenPhong { get; set; }
    }
}