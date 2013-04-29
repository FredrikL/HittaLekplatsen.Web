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

        public ActionResult Index()
        {
            var p = new Playground()
            {
                Location = new Location(13, 55),
                HasBenches = true,
                HasPublicToilet = false,
                HasSandbox = true,
                HasSlide = true,
                HasSwing = true,

            };
            _repository.Add(p);
            return View(_repository.GetAll());
        }

        public ActionResult Detail(string id)
        {
            Playground p = null;
            return View(p);
        }
    }
}
