using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForum.Models;
using WebForum.Data;


namespace WebForum.Services
{
    public class BaiVietService
    {
        DB_ForumEntities db;

        #region Danh Sach Bai Viet
        public List<ListBaiViet> GetDanhSachBaiViet()
        {
            db = new DB_ForumEntities();
            
            var lst = db.BaiViets.Select(m => new ListBaiViet
            {
                ID = m.ID,
                countCmt = m.Cmt_BaiViet.Count(),
                countLike = m.Like_BaiViet.Count(),
                IDNguoiDang = m.AspNetUser.Id,
                linkIMG = m.linkIMG,
                NgayDang = (m.NgayCapNhat.HasValue) ? m.NgayCapNhat : m.NgayTao,
                TenBaiViet = m.TieuDe,
                TenNguoiDang = m.AspNetUser.FullName

            }).ToList();
            return lst;
        }
        #endregion

        #region Add Bai Viet

        #endregion
    }
}