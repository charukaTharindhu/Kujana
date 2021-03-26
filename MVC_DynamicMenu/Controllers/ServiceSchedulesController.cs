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
    public class ServiceSchedulesController : Controller
    {
        private readonly ServiceSchedulesRepo _c = null;

        public ServiceSchedulesController(ServiceSchedulesRepo c)
        {
            _c = c;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult AddNewSS()
        {
            return View();
        }

        public void setSession(int id)
        {
            var newUser = _c.getUserById(id);
            HttpContext.Session.SetString("loggedname", newUser.Clients);
        }
        [HttpPost]
        public ActionResult AddNewSS(ServiceSchedules model)
        {
            _c.AddNewServiceSchedule(model);
            return RedirectPermanent("/ServiceSchedules/ShowAllSS");

        }

        [HttpGet]
        public ViewResult ShowAllSS()
        {
            HttpContext.Session.SetString("SS", _c.GetPatients());
            List<ServiceSchedules> ss = _c.GetAllSS();
            return View(ss);
        }

        [HttpGet]
        public ViewResult UpdateSS(int id)
        {
            ServiceSchedules SS = _c.GetSSById(id);
            return View(SS);
        }

        [HttpGet]
        public ViewResult ViewSS(int id)
        {
            ServiceSchedules SS = _c.GetSSById(id);
            return View(SS);
        }

        [HttpPost]
        public ActionResult UpdateSS(ServiceSchedules model)
        {
            _c.UpdateSS(model);
            return RedirectPermanent("/ServiceSchedules/ShowAllSS");
        }

        [Route("/ServiceSchedules/Delete/{id:int}")]
        public ActionResult DeleteSS(int id)
        {
            _c.DeleteSS(id);
            return RedirectPermanent("");
        }



        //--------------------------------NewServiceLogController---------------------------------//

        [HttpGet]
        public ActionResult AddNewLog(int id)
        {
            //shere id from SS page to SL page
           HttpContext.Session.SetString("ssid", id.ToString());

            //get service schedule data from repo
            //create object log

            ServiceSchedules SS = _c.GetSSById(id);
            LogSchedule newlog = new LogSchedule();

            newlog.Scheduled_start_date = SS.Start_date_and_time;
            newlog.Scheduled_start_time = SS.Start_date_and_time;
            newlog.Scheduled_finish_date = SS.Start_date_and_time;
            newlog.Scheduled_finish_time = SS.Start_date_and_time;

            newlog.Actual_start_date = SS.Start_date_and_time;
            newlog.Actual_start_time = SS.Start_date_and_time;
            newlog.Actual_finish_date = SS.Start_date_and_time;
            newlog.Actual_finish_time = SS.Start_date_and_time;

            //return model
            ViewBag.Id = id;
            return View(newlog);
        }

        [HttpPost]
        public ActionResult AddNewLog(LogSchedule model)
        {
            _c.AddNewLogSchedul(model);
            return RedirectPermanent("/ServiceSchedules/ShowLogSchedule");
        }

        [HttpGet]
        public ViewResult ShowLogSchedule()
        {
            List<LogSchedule> newSl = _c.GetAllSL();
            List<ServiceLog> sl = new List<ServiceLog>();

            foreach (var item in newSl)
            {
                ServiceLog sl1 = new ServiceLog
                {
                    Reference = item.Reference,
                    Client_name = item.Client_name,
                    Start_date = item.Actual_start_date,
                    End_date = item.Actual_finish_date,
                    Service = item.Service_and_billing_note,
                    Status = "Draft",
                    SSID = item.ReferenceID
                };
                sl.Add(sl1);
            }
            return View(sl);
        }
        
        [HttpGet]
        public ViewResult UpdateSL(int id)
        {
            LogSchedule newSL = _c.GetSLByID(id);
            return View(newSL);
        }

        [HttpGet]
        public ViewResult ViewSL(int id)
        {
            LogSchedule newSL = _c.GetSLByID(id);
            return View(newSL);
        }

        [HttpPost]
        public ActionResult UpdateSL(LogSchedule model)
        {
            _c.UpdateSL(model);
            return RedirectPermanent("/ServiceSchedules/ShowLogSchedule");
        }

        [Route("/LogSchedule/DeleteSL/{id:int}")]
        public ActionResult DeleteSL(int id)
        {
            _c.DeleteSL(id);
            return RedirectPermanent("/ServiceSchedules/ShowLogSchedule");
        }









        //-----------------------------Approved--------------------------------------//
        [HttpGet]
        public ActionResult ApprovedServiceLog(int id)
        {
            LogSchedule newSL = _c.GetLogDataByID(id);
            ApprovedTb approved = new ApprovedTb();

          
            approved.Client_name = newSL.Client_name;
            approved.Start_date = newSL.Actual_start_date;
            approved.End_date = newSL.Actual_finish_date;
            approved.Service = newSL.Service_and_billing_note;
            approved.Status = "Draft";

            _c.InsertLogdata(approved);
            _c.DeleteSL(id);

            return RedirectPermanent("/ServiceSchedules/ShowLogSchedule");
            
        }

        public ActionResult showApprovedInfo()
        {
            List<ApprovedTb> ap = _c.GetAll();
            return View(ap);
        }

        [HttpGet]
        public ViewResult ViewApproved(int id)
        {
            ApprovedTb newapp = _c.GetApprovedDataByID(id);
            return View(newapp);
        }


        //-----------------------------Invoice-----------------------------//

        [HttpGet]
        public ActionResult Invoice(int id)
        {
            ApprovedTb ap = _c.GetApprovedDataByID(id);
            InvoiceTb In = new InvoiceTb();

       
            In.Client_name = ap.Client_name;
            In.Start_date = ap.Start_date;
            In.End_date = ap.End_date;
            In.Service = ap.Service;
            In.Status = ap.Status;
            In.Cliam_number = ap.Reference;

            _c.InsertDataIntoInvoice(In);          

            return RedirectPermanent("/ServiceSchedules/ShowAllSS");
            
        }

        public ActionResult showInvoiceInfo()
        {
            List<InvoiceTb> ap = _c.GetAllInvoiceData();
            return View(ap);
        }
        [HttpGet]
        public ViewResult ShowAllSrviceInvoice()
        {
            List<MainBudgetAgreement> newSI = _c.GetAllBudget();
            List<Serviceinvoiced> si = new List<Serviceinvoiced>();

            foreach (var item in newSI)
            {
                Serviceinvoiced si1 = new Serviceinvoiced
                {
                    Service = item.MySupport[0].Support_Item,
                    Activiti_start_day = item.ServiceSchedules[0].Start_date_and_time,
                    Biller_type = item.AllocateBudgetAgreement[0].Biler_type,
                    Claim_External_refewnce = "",
                    Claim_number = 123,
                    Claim_status = "",
                    Invoice_date = "",
                    Client = item.ServiceSchedules[0].Client_name,
                    Provider = item.MySupport[0].Service_Provider,
                    Suport_item = item.MySupport[0].Support_Item,
                    Total = item.MySupport[0].Total_price,
                    Reference = item.ServiceSchedules[0].ReferenceID

                };
                si.Add(si1);
            }
            return View(si);
        }

    }
}