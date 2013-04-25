using System.Linq;
using System.Web.Mvc;
using Lekplatser.Admin.Repository;
using Lekplatser.Dto;

namespace Lekplatser.Admin.Controllers
{
    public class PlaygroundsController : Controller
    {
        private readonly IPlaygroundRepository _repository;

        public PlaygroundsController(IPlaygroundRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Playgrounds/

        public ActionResult Index()
        {
            var items = Enumerable.Empty<Playground>();

            return View(items);
        }

    }
}
