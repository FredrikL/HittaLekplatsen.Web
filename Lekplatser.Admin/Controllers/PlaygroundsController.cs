using System.Web.Mvc;
using Lekplatser.Dto;
using Lekplatser.Shared.Repository;

namespace Lekplatser.Admin.Controllers
{
    public class PlaygroundsController : Controller
    {
        private readonly IPlaygroundRepository _playgroundRepository;
        private readonly IAdminPlayGroundRepository _adminPlayGroundRepository;

        public PlaygroundsController(IPlaygroundRepository playgroundRepository, IAdminPlayGroundRepository adminPlayGroundRepository)
        {
            _playgroundRepository = playgroundRepository;
            _adminPlayGroundRepository = adminPlayGroundRepository;
        }

        public ActionResult Index()
        {
            return View(_adminPlayGroundRepository.GetAll());
        }

        public ActionResult Create(Playground p)
        {
            _playgroundRepository.Add(p);

            return RedirectToAction("Index");
        }

        public ActionResult Detail(string id)
        {
            Playground p = _playgroundRepository.GetById(id);
            return View(p);
        }

        public ActionResult Search(float Lat, float Long)
        {
            var p = _playgroundRepository.GetByLocation(Lat, Long);
            return View(p);
        }
    }
}
