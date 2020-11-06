using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForum.Models;
using WebForum.Data;
using System.Net;

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
        public int AddEditBaiViet(AddBaiViet model)
        {
            
            int kq = 0;
            bool isAdd = true;
            BaiViet baiviet = new BaiViet();
            baiviet.ID = model.ID.Value;
            baiviet.IDLoaiBaiViet = model.IDLoaiBaiViet;
            baiviet.TieuDe = model.TenBaiViet;
            baiviet.NoiDung = model.NoiDung;
            baiviet.linkIMG = model.linkIMG;
            if (model.ID==null)
            {
                isAdd = false;
                baiviet.isCapNhat = true;
                baiviet.NgayCapNhat = DateTime.Now;
            }
            else
            {
                baiviet.IDNguoiTao = null;// nua cap nhat sau
                baiviet.NgayTao = DateTime.Now;
            }
            using (var db = new DB_ForumEntities())
            {
                if(isAdd)
                {
                    db.BaiViets.Add(baiviet);
                }
                db.SaveChanges();
            }
            return kq;
        }
       
        #endregion
    }
}