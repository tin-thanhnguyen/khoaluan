using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForum.Data;
namespace WebForum.Models
{
    public class ListBaiViet
    {
        public int? ID { get; set; }
        public string TenBaiViet { get; set; }
        public string linkIMG { get; set; }
        public int? countCmt { get; set; }
        public int? countLike { get; set; }
        public string IDNguoiDang { get; set; }
        public string TenNguoiDang { get; set; }
        public DateTime? NgayDang { get; set; }
    }
    public class AddBaiViet : BaiViet
    {

    }
    
}