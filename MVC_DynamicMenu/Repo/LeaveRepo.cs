using Microsoft.EntityFrameworkCore;
using MVC_DynamicMenu.Data;
using MVC_DynamicMenu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Repo
{
    public class LeaveRepo
    {
        private readonly DynamicMenuDBContext _c = null;

        public LeaveRepo(DynamicMenuDBContext c)
        {
            _c = c;
        }

        public void AddNewLeave(AddNewLeave model)
        {
            var leave = new AddNewLeave
            {
                LID = model.LID,
                Comment = model.Comment,
                End_time = model.End_time,             
                Start_time = model.Start_time,             
                Worker = model.Worker
            };
            _c.AddNewLeave.Add(leave);
            _c.SaveChanges();
        }

        public List<AddNewLeave> GetAllLeave()
        {
            var leave = _c.AddNewLeave
                .FromSqlRaw("Select * from dbo.AddNewLeave")
                .ToList();

            return leave;
        }

        public AddNewLeave GetLeaveById(int id)
        {
            var cn = _c.AddNewLeave
                .FromSqlRaw("Select * from dbo.AddNewLeave where LID=" + id)
                .ToList();

            return cn[0];
        }

        public void UpdateLeave(AddNewLeave model)
        {
            _c.AddNewLeave.Update(model);
            _c.SaveChanges();
        }

        public void DeleteLeave(int id)
        {
            var leave = _c.AddNewLeave.FirstOrDefault(x => x.LID == id);
            if (leave != null)
            {
                _c.AddNewLeave.Remove(leave);
                _c.SaveChanges();
            }
        }

        public string GetPatients()
        {
            var obj = _c.Patient.FromSqlRaw("SELECT * FROM dbo.Patient").ToList();
            var patients = JsonConvert.SerializeObject(obj);
            return patients;
        }
    }
}
