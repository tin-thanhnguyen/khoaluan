using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForum.Models;
using WebForum.Services;

namespace WebForum.Controllers
{
    public class BaiVietController : Controller
    {
        BaiVietService service;
        public BaiVietController()
        {
            service = new BaiVietService();
        }
        // GET: BaiViet
       public ActionResult CreateBaiViet()
        {
            AddBaiViet model = new AddBaiViet();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateBaiViet(AddBaiViet model)
        {
            if(ModelState.IsValid)
            {
                int kq = service.AddEditBaiViet(model);
                  
            }    
            return Redirect("Home/Index");
        }
    }
}