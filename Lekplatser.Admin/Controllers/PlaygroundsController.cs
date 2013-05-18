using System.Linq.Expressions;
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
            return View(_repository.GetAll());
        }

        public ActionResult Create(Playground p)
        {
            _repository.Add(p);

            return RedirectToAction("Index");
        }

        public ActionResult Detail(string id)
        {
            Playground p = _repository.GetById(id);
            return View(p);
        }

        public ActionResult Search(float Lat, float Long)
        {
            var p = _repository.GetByLocation(Lat, Long);
            return View(p);
        }
    }
}
