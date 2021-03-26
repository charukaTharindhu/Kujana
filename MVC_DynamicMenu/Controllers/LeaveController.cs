using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_DynamicMenu.Models;
using MVC_DynamicMenu.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Controllers
{
    public class LeaveController : Controller
    {
        private readonly LeaveRepo _c = null;

        public LeaveController(LeaveRepo c)
        {
            _c = c;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult AddNewLeave()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewLeave(AddNewLeave model)
        {
            _c.AddNewLeave(model);
            return RedirectPermanent("/Leave/GetAllLeave");
        }
        [HttpGet]
        public ViewResult GetAllLeave()
        {
            HttpContext.Session.SetString("Leave", _c.GetPatients());
            List<AddNewLeave> Leave = _c.GetAllLeave();
            List<MainLeaveTb> leave = new List<MainLeaveTb>();

            foreach (var item in Leave)
            {
                MainLeaveTb leave1 = new MainLeaveTb
                {
                    Worker = item.Worker,
                    Start_time = item.Start_time,
                    End_time = item.End_time,
                    Comment = item.Comment,
                    Approved = "Approved",
                    LeaveID = item.LID
                };
                leave.Add(leave1);
            }
            return View(leave);
        }
        [HttpGet]
        public ViewResult UpdateLeave(int id)
        {
            AddNewLeave leave = _c.GetLeaveById(id);
            return View(leave);
        }

        [HttpGet]
        public ViewResult ViewtLeave(int id)
        {
            AddNewLeave leave = _c.GetLeaveById(id);
            return View(leave);
        }

        [HttpPost]
        public ActionResult UpdateLeave(AddNewLeave model)
        {
            _c.UpdateLeave(model);
            return RedirectPermanent("/Leave/GetAllLeave");
        }

        [Route("Leave/DeleteLeave/{id:int}")]
        public ActionResult DeleteLeave(int id)
        {
            _c.DeleteLeave(id);
            return RedirectPermanent("/Leave/GetAllLeave");
        }
    }
}
