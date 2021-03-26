using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_DynamicMenu.Data;
using MVC_DynamicMenu.Models;
using MVC_DynamicMenu.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Controllers
{
    public class Document_SkillController : Controller
    {
        private readonly AddDocument_SkillRepo _context = null;

        public Document_SkillController(AddDocument_SkillRepo context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult AddDocument_Skill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDocument_Skill(AddDocument_Skill doc)
        {
            _context.AddDocument_Skill(doc);
            return RedirectPermanent("/Document_Skill/ShowAllSkillAvidence");
        }

        public ViewResult ShowAllSkillAvidence()
        {
            HttpContext.Session.SetString("doc", _context.GetPatients());
            List<MyProfile> profile = _context.GetAllProfilInfo();
            return View(profile);

        }

        [HttpGet]
        public ViewResult UpdateDocument_Skill(int id)
        {
            AddDocument_Skill FF = _context.GetDocument_SkillByID(id);
            return View(FF);
        }

    

        [HttpGet]
        public ViewResult ViewDocument_Skill(int id)
        {
            AddDocument_Skill doc = _context.GetDocument_SkillByID(id);
            return View(doc);
        }

        [Route("/Document_Skill/DeleteDocument_Skill/{id:int}")]
        public ActionResult DeleteDocument_Skill(int id)
        {
            _context.DeleteDocument_Skill(id);
            return RedirectPermanent("/Document_Skill/ShowAllSkillAvidence");
        }

        [HttpPost]
        public ActionResult UpdateDocument_Skill(AddDocument_Skill model)
        {
            _context.UpdateDocument_Skill(model);
            return RedirectPermanent("/Document_Skill/ShowAllSkillAvidence");
        }

        [HttpGet]
        public ViewResult UpdateProfileInfo(int id)
        {
            
            MyProfile profile = _context.GetProfileInfoByID(id);
            
            return View(profile);
        }

        [HttpPost]
        public ActionResult UpdateProfileInfo(MyProfile model)
        {
            model.UserID = Int32.Parse(HttpContext.Session.GetString("userid"));
            _context.UpdateProfileInfo(model);
            return RedirectPermanent("/Document_Skill/UpdateProfileInfo");
        }
    }
}
