using System.Linq;
using System.Web.Mvc;
using Lekplatser.Dto;

namespace Lekplatser.Admin.Controllers
{
    public class PlaygroundsController : Controller
    {
        //
        // GET: /Playgrounds/

        public ActionResult Index()
        {
            var items = Enumerable.Empty<Playground>();

            return View(items);
        }

    }
}
