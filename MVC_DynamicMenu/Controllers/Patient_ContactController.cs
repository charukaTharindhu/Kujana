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
    public class Patient_ContactController : Controller
    {
        private readonly Patient_ContactRepo _c = null;

        public Patient_ContactController(Patient_ContactRepo C)
        {
            _c = C;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult AddNewParticipant()
        {
            return View(new Patient());
        }
        [HttpPost]
        public ViewResult AddNewParticipant(Patient model)
        {
            model.Address = model.patient_Contacts[0].Disclose_Address;
            model.Full_Name = model.Patient_Info[0].FirstName;
            model.Gender = model.Patient_Info[0].Gender;
            model.Age = model.Patient_Info[0].Age;
            model.Telephone = model.patient_Contacts[0].Phone;
            model.Email = model.patient_Contacts[0].Email;
            model.Supervisor = "Kavidu";
            model.Emergency_Contact_Name = model.patient_Contacts[0].emargencyName;
            model.Emergency_Contact_No = model.patient_Contacts[0].emargencyPhone;

            _c.AddPatient(model);
            return View(new Patient());
        }
        /*[HttpPost]
         public ViewResult AddNewParticipant(Patient model)
        {
            Patient_Contact pc = new Patient_Contact();
            pc = model.patient_Contacts[0];

            Patient_Info pi = new Patient_Info();
            pi = model.Patient_Info[0];

            Summerising sum = new Summerising();
            sum = model.summerisings[0];

            Patient_Helth helth = new Patient_Helth();
            helth = model.patient_Helths[0];

            //Programs pro = new Programs();
           // pro = model.programs[0];

           // Case_Worker cw = new Case_Worker();
           // cw = model.Case_Worker[0];

            Housing_Register_Application house = new Housing_Register_Application();
            house = model.Housing_Register_Application[0];

            CareTeams ct = new CareTeams();
            ct = model.CareTeams[0];

            Commencement_Issuse ci = new Commencement_Issuse();
            ci = model.Commencement_Issuse[0];

            _c.AddNewPatient_Contact(pc);
            _c.AddNewPatient_Info(pi);
            _c.AddNewSummerising(sum);
            _c.AddNewPatient_Helth(helth);
           // _c.AddNewProgramm(pro);
            //_c.AddNewCase_Worker(cw);
            _c.Addhouser(house);
            _c.AddNewCareTeams(ct);
            _c.AddNewCommencement_Issuse(ci);

            return View();
        }*/

        [HttpGet]
        public ViewResult ViewAllParticipant(int id)
        {

            var model = _c.GetAllpatientInfoById(id);
            return View(model);


        }
        [HttpGet]
        public ViewResult UpdateAllPatientInfo(int id)
        {
            var model = _c.GetAllpatientInfoById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateAllPatientInfo(Patient model)
        {
            model.Address = model.patient_Contacts[0].Disclose_Address;
            model.Full_Name = model.patient_Contacts[0].Name;
            model.Gender = model.Patient_Info[0].Gender;
            model.Age = model.Patient_Info[0].Age;
            model.Telephone = model.patient_Contacts[0].Phone;
            model.Email = model.patient_Contacts[0].Email;
            model.Supervisor = "Kavidu";
            model.Emergency_Contact_Name = model.patient_Contacts[0].emargencyName;
            model.Emergency_Contact_No = model.patient_Contacts[0].emargencyPhone;

            _c.UpdateAllPatientInfo(model);
            return RedirectPermanent("/Patient_Contact/ShowAllMainParticipant");
        }
        /*
        public ActionResult UpdateAllPatientInfo(Patient model)
        {
            Patient_Contact pc = new Patient_Contact();
            pc = model.patient_Contacts[0];

            Patient_Info pi = new Patient_Info();
            pi = model.Patient_Info[0];

            Summerising sum = new Summerising();
            sum = model.summerisings[0];

            Patient_Helth helth = new Patient_Helth();
            helth = model.patient_Helths[0];

            //Programs pro = new Programs();
           // pro = model.programs[0];
           
            //Case_Worker cw = new Case_Worker();
            //cw = model.Case_Worker[0];

            Housing_Register_Application house = new Housing_Register_Application();
            house = model.Housing_Register_Application[0];

            CareTeams ct = new CareTeams();
            ct = model.CareTeams[0];

            Commencement_Issuse ci = new Commencement_Issuse();
            ci = model.Commencement_Issuse[0];

            _c.UpdateCommencementIssues(ci);
            _c.UpdateCareTeams(ct);
           // _c.UpdateCase_Worker(cw);
            _c.UpdateHousing_Register_Application(house);
            _c.UpdatePatient_Contact(pc);
            _c.UpdatePatient_Helth(helth);
            _c.UpdatePatient_Info(pi);
            //_c.UpdatePrograms(pro);
            _c.UpdateSummerising(sum);
            return RedirectPermanent("/Patient_Contact/ShowAllMainParticipant");
        }
        */

   
        public ViewResult ShowAllMainParticipant()
        {
            HttpContext.Session.SetString("Patient", _c.GetPatient());
            List<Patient> patients = _c.getAllPatient();
            List<MainParticipantTb> p = new List<MainParticipantTb>();

            foreach (var item in patients)
            {
                MainParticipantTb p1 = new MainParticipantTb
                {
                    DOB = item.Patient_Info[0].DateOfBirth,
                    Last_Name = item.Patient_Info[0].LastName,
                    First_Name = item.Patient_Info[0].FirstName,
                    Address = item.patient_Contacts[0].Disclose_Address,
                    Contact_info = item.Patient_Info[0].Indegenous_status,
                    NDIS_No = item.PatientID,
                    Office = item.Patient_Info[0].Office,
                    Programm_Info ="",
                    Setting = "",
                };

                p.Add(p1);
            }
            return View(p);
        }

        [Route("/Patient_Contact/DeletePatient{id:int}")]
        public ActionResult DeletePatient(int id)
        {
            _c.DeleteAllPatientInfo(id);
            return RedirectPermanent("/Patient_Contact/ShowAllMainParticipant");
        }

    }
}