using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForum.Models;

namespace WebForum.Controllers
{
    public class BaiVietController : Controller
    {
        // GET: BaiViet
       public ActionResult CreateBaiViet()
        {
            AddBaiViet model = new AddBaiViet();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateBaiViet(AddBaiViet model)
        {
            return Redirect("Home/Index");
        }
    }
}