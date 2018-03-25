using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MezogazdasagiDron.Controllers
{
    public class ImageController : Controller
    {
        [HttpPost]
        public ActionResult Upload()
        {
            return View();
        }
    }
}