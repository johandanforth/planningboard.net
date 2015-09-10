using System;
using System.Linq;
using System.Web.Mvc;
using PlanningBoard.Infrastructure.Alerts;
using PlanningBoard.Model;
using PlanningBoard.ViewModels;

namespace PlanningBoard.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUserRerpository _userRerpository;

        public HomeController()
        {
            _boardRepository = new BoardRepository();
            _userRerpository = new UserRepository();
        }

        private string Username
        {
            get
            {
                return User.Identity.Name.Substring(User.Identity.Name.IndexOf("\\", StringComparison.Ordinal) + 1);
            }
        }

        public ActionResult Index()
        {
            ViewBag.BoardName = "PlanningBoard.Net";

            var user = _userRerpository.GetUser(Username);
            var boards = _boardRepository.List(user.Id);
            var boardUsers = _boardRepository.BoardUsers(user.Id);

            var userboards = boards.Select(board => new UserBoardsViewModel()
            {
                BoardId = board.Id,
                BoardName = board.Name,
                IsAdmin = boardUsers.Any(b => b.BoardId == board.Id && b.IsAdmin)
            }).ToList();

            var model = new BoardsViewModel
            {
                Boards = userboards
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddBoard(Board board)
        {
            if (board.Id == 0)
            {
                _boardRepository.Add(new Board() {Name = board.Name});
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