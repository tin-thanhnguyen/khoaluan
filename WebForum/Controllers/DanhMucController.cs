using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForum.Services;

namespace WebForum.Controllers
{
    public class DanhMucController : Controller
    {

        DanhMucServices servise;
        public DanhMucController()
        {
            servise = new DanhMucServices();
        }

        // GET: DanhMuc
        public ActionResult DM_BaiViet()
        {
            var lst = servise.GetDanhMucLoai().ToList();


            return PartialView("_DM_BaiVietPartial",lst);
        }

        
    }
}