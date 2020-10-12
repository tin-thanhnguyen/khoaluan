using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForum.Data;
using WebForum.Models;

namespace WebForum.Services
{
    public class DanhMucServices
    {
        DB_ForumEntities db;
        public List<DanhMucViewModel> GetDanhMucLoai()
        {
            db = new DB_ForumEntities();
            return db.DM_Loai.Select(m => new DanhMucViewModel() { id = m.ID, ten = m.TenLoai,countbaiviet=m.BaiViets.Count}).ToList();
        }

        public List<SelectListItem> GetDanhMucForSelect()
        {
            db = new DB_ForumEntities();
            return db.DM_Loai.Select(m => new SelectListItem() {
                 Value=m.ID.ToString(),
                 Text=m.TenLoai,
                  
            }).ToList();
        }

    }
}