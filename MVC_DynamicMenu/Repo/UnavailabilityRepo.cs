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
    public class UnavailabilityRepo
    {
        private readonly DynamicMenuDBContext _c = null;

        public UnavailabilityRepo(DynamicMenuDBContext c)
        {
            _c = c;
        }

        public void AddNewUnavailability(AddNewUnavailability model)
        {
            var ua = new AddNewUnavailability
            {
                Comment = model.Comment,
                End_time = model.End_time,
                Is_all_day = model.Is_all_day,
                Recurrance = model.Recurrance,
                Start_time = model.Start_time,
                UID = model.UID,
                Worker = model.Worker
            };
            _c.AddNewUnavailability.Add(ua);
            _c.SaveChanges();
        }

        public List<AddNewUnavailability> GetAllUnavailability()
        {
            var cn = _c.AddNewUnavailability
                .FromSqlRaw("Select * from dbo.AddNewUnavailability")
                .ToList();

            return cn;
        }

        public AddNewUnavailability GetUnavailabilityById(int id)
        {
            var cn = _c.AddNewUnavailability
                .FromSqlRaw("Select * from dbo.AddNewUnavailability where UID=" + id)
                .ToList();

            return cn[0];
        }

        public void UpdateUnavailability(AddNewUnavailability model)
        {
            _c.AddNewUnavailability.Update(model);
            _c.SaveChanges();
        }

        public void DeleteUnavailability(int id)
        {
            var cn = _c.AddNewUnavailability.FirstOrDefault(x => x.UID == id);
            if (cn != null)
            {
                _c.AddNewUnavailability.Remove(cn);
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
