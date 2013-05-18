using System.Threading.Tasks;
using System.Web.Mvc;

namespace Benchmarks.AspNet.Controllers
{
    public class JsonController : AsyncController
    {
        public Task<JsonResult> Index()
        {
            return Task.FromResult(Json(new { message = "Hello World" }, JsonRequestBehavior.AllowGet));
        }
    }
}
