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
    public class CallNoteController : Controller
    {
        private readonly NewCallNoteRepo _context = null;

        public CallNoteController(NewCallNoteRepo context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult AddCallNote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCallNote(NewCallNote model)
        {
            _context.AddCallNote(model);
            return RedirectPermanent("/CallNote/ShowAllCallNote");
        }

        public ViewResult ShowAllCallNote()
        {
            HttpContext.Session.SetString("callnote", _context.GetPatients());
            List<NewCallNote> CN = _context.GetAllCallNote();
            List<MainCallNoteTb> cn = new List<MainCallNoteTb>();

            foreach (var item in CN)
            {
                MainCallNoteTb cn1 = new MainCallNoteTb
                {
                    Call_note = item.Type_of_Past_noteOBelow,
                    ParticipantID = item.CallNoteID
                    
                };

                cn.Add(cn1);
            }
            return View(cn);

        }
        [HttpGet]
        public ViewResult UpdateCallNote(int id)
        {
            NewCallNote cn = _context.GetCallNoteById(id);
            return View(cn);
        }

        [Route("/CallNote/DeleteCallNote/{id:int}")]
        public ActionResult DeleteCallNote(int id)
        {
            _context.DeleteCallNote(id);
            return RedirectPermanent("/CallNote/ShowAllCallNote");
        }

        [HttpPost]
        public ActionResult UpdateCallNote(NewCallNote model)
        {
            _context.UpdateCallNote(model);
            return RedirectPermanent("/CallNote/ShowAllCallNote");
        }
    }
}
