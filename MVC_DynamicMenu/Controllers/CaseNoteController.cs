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
    public class CaseNoteController : Controller
    {
        private readonly NewCaseNoteRepo _c = null;

        public CaseNoteController(NewCaseNoteRepo c)
        {
            _c = c;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult AddNewCaseNote()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewCaseNote(NewCaseNote newPsa)
        {
            _c.AddNewCaseNote(newPsa);
            return RedirectPermanent("/CaseNote/getAllCaseNote");
        }
        [HttpGet]
        public ViewResult getAllCaseNote()
        {
            HttpContext.Session.SetString("note", _c.GetPatients());
            List<NewCaseNote> Note = _c.getAllCaseNote();
            List<Main_Case_Note> note = new List<Main_Case_Note>();

            foreach (var item in Note)
            {
                Main_Case_Note note1 = new Main_Case_Note
                {
                    Added_by = "",
                    Contact_type = item.Contact_type,
                    Date = item.Date,
                    NoteID = item.CaseNoteID,
                    Note_summary = "",
                    Participant = item.Participant,
                    Hours = item.Minutes
                };
                note.Add(note1);
            }
            return View(note);
        }
        [HttpGet]
        public ViewResult UpdateCaseNote(int id)
        {
            NewCaseNote note = _c.getCaseNoterById(id);
            return View(note);
        }

        [HttpGet]
        public ViewResult ViewCaseNote(int id)
        {
            NewCaseNote note = _c.getCaseNoterById(id);
            return View(note);
        }

        [HttpPost]
        public ActionResult UpdateCaseNote(NewCaseNote model)
        {
            _c.UpdateCaseNote(model);
            return RedirectPermanent("/CaseNote/getAllCaseNote");
        }

        [Route("CaseNote/DeleteCaseNote/{id:int}")]
        public ActionResult DeleteCaseNote(int id)
        {
            _c.DeleteCaseNote(id);
            return RedirectPermanent("/CaseNote/getAllCaseNote");
        }
    }
}
