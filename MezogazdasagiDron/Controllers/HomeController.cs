using System.Web.Mvc;

namespace MezogazdasagiDron.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Aktualitasok()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
            //Image image = Image.FromFile(@"C:\Projects\MezogazdasagiDron\MezogazdasagiDron\Images\Aktualitasok_01.jpg");
            //PropertyItem propItem = image.GetPropertyItem(2);
            //uint degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
            //uint degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
            //uint minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
            //uint minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
            //uint secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
            //uint secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
        }
        public ActionResult PreciziosKarFelmeres()
        {
            return View();
        }

        public ActionResult Uploader()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("SignUpSignIn", "Account");
            }

            return View();
        }
    }
}