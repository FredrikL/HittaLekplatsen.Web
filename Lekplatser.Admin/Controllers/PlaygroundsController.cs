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

        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

    }
}
