using System.Web.Mvc;

namespace Benchmarks.AspNet.Controllers
{
    public class JsonController : AsyncController
    {
        public ActionResult Index()
        {
            return Json(new { message = "Hello World" }, JsonRequestBehavior.AllowGet);
        }
    }
}
