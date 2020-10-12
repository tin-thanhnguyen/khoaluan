using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForum.Services;
using WebForum.Models;
using PagedList;

namespace WebForum.Controllers
{
    public class HomeController : Controller
    {
        BaiVietService service;
        public HomeController(){
            service = new BaiVietService();
        }
        public ActionResult Index(string currentFilter,string searchString, int? page)
        {
            var lst = service.GetDanhSachBaiViet();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                lst = lst.Where(s => s.TenBaiViet.Contains(searchString)).ToList();
            }

            int pageSize =10;
            int pageNumber = (page ?? 1);
            return View(lst.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}