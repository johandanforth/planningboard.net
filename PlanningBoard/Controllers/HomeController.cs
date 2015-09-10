using System.Web.Mvc;

using PlanningBoard.Infrastructure.Alerts;
using PlanningBoard.Model;
using PlanningBoard.ViewModels;

namespace PlanningBoard.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBoardRepository _boardRepository;

        public HomeController()
        {
            _boardRepository = new BoardRepository();
        }

        public ActionResult Index()
        {
            ViewBag.BoardName = "PlanningBoard.Net";

            var model = new BoardsViewModel {Boards = _boardRepository.List()};
            
            return View(model);
        }

        [HttpPost]
        public ActionResult AddBoard(Board board)
        {
            if (board.Id == 0)
            {
                _boardRepository.Add(new Board() { Name = board.Name });
                return RedirectToAction("Index").WithSuccess("New Board Added");
            }
            
            _boardRepository.Update(board);
            return RedirectToAction("Index").WithSuccess("Board Updated");
        }

        public ActionResult GetBoard(int id)
        {
            var board = _boardRepository.Get(id);

            var jsonResult = Json(
                board != null
                    ? new
                    {
                        id = board.Id,
                        name = board.Name
                    }
                    : new
                    {
                        id = 0,
                        name = "",
                    },
                JsonRequestBehavior.AllowGet);
            return jsonResult;
        }
    }
}