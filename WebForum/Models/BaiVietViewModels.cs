using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebForum.Data;
namespace WebForum.Models
{
    public class ListBaiViet
    {
        public int? ID { get; set; }
        public int? IDLoaiBaiViet { get; set; }
        public string TenBaiViet { get; set; }
        public string linkIMG { get; set; }
        public int? countCmt { get; set; }
        public int? countLike { get; set; }
        public string IDNguoiDang { get; set; }
        public string TenNguoiDang { get; set; }
        public DateTime? NgayDang { get; set; }
    }
    public class AddBaiViet
    {
        public int? ID { get; set; }
        [Required(ErrorMessage = "Vui long chon danh muc bai viet")]
        public int? IDLoaiBaiViet { get; set; }
        [Required(ErrorMessage = "Vui long nhap tieu de bai viet")]
        public string TenBaiViet { get; set; }
        public string linkIMG { get; set; }
        [Required(ErrorMessage = "Vui long nhap noi dung bai viet")]
        public string NoiDung { get; set; }
    }
    
}