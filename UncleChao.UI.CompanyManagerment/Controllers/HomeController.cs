using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UncleChao.UI.CompanyManagerment.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.PageTitle = "Welcome to Company Managerment System";
            return View();
        }

    }
}
