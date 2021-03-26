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
    public class UnavailabilityController : Controller
    {
        private readonly UnavailabilityRepo _c = null;

        public UnavailabilityController(UnavailabilityRepo c)
        {
            _c = c;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult AddNewUnavailability()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewUnavailability(AddNewUnavailability model)
        {
            _c.AddNewUnavailability(model);
            return RedirectPermanent("/Unavailability/GetAllUnavailability");
        }
        [HttpGet]
        public ViewResult GetAllUnavailability()
        {
            HttpContext.Session.SetString("availability", _c.GetPatients());
            List<AddNewUnavailability> UA = _c.GetAllUnavailability();
            List<MainUnavailabilityTb> ua = new List<MainUnavailabilityTb>();

            foreach (var item in UA)
            {
                MainUnavailabilityTb ua1 = new MainUnavailabilityTb
                {
                    Worker = item.Worker,
                    Start_time = item.Start_time,
                    Recurrance = item.Recurrance,
                    Is_all_day = item.Is_all_day,
                    End_time = item.End_time,
                    Comment = item.Comment,
                    Approved = "Approved",
                    End_Recurrance = "",
                    UnavailabilityID = item.UID
                };
                ua.Add(ua1);
            }
            return View(ua);
        }
        [HttpGet]
        public ViewResult UpdateUnavailability(int id)
        {
            AddNewUnavailability UN = _c.GetUnavailabilityById(id);
            return View(UN);
        }

        [HttpGet]
        public ViewResult ViewtUnavailability(int id)
        {
            AddNewUnavailability UN = _c.GetUnavailabilityById(id);
            return View(UN);
        }

        [HttpPost]
        public ActionResult UpdateUnavailability(AddNewUnavailability model)
        {
            _c.UpdateUnavailability(model);
            return RedirectPermanent("/Unavailability/GetAllUnavailability");
        }

        [Route("Unavailability/DeleteUnavailability/{id:int}")]
        public ActionResult DeleteUnavailability(int id)
        {
            _c.DeleteUnavailability(id);
            return RedirectPermanent("/Unavailability/GetAllUnavailability");
        }
    }
}
