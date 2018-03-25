using MezogazdasagiDron.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MezogazdasagiDron.Controllers
{
    public class FarmController : Controller
    {
        public ActionResult Index(string farmId)
        {
            var userName = this.User.Identity.Name;

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(farmId))
            {
                throw new NullReferenceException();
            }

            var model = TableStorageService.Get(userName, farmId);

            return View("Index", model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string farmName)
        {
            // Validate request
            var userName = this.User.Identity.Name;

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new NullReferenceException();
            }

            var farm = TableStorageService.Insert(userName, farmName);

            return View("Index", farm);
        }
    }
}