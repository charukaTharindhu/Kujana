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
    public class NewCallNoteRepo
    {
        private readonly DynamicMenuDBContext _c = null;

        public NewCallNoteRepo(DynamicMenuDBContext c)
        {
            _c = c;
        }

        public void AddCallNote(NewCallNote model)
        {
            var cn = new NewCallNote
            {
                PraticipantID = model.PraticipantID,
                Program = model.Program,
                Type_of_Past_noteOBelow = model.Type_of_Past_noteOBelow,

            };
            _c.NewCallNote.Add(cn);
            _c.SaveChanges();
        }

        public List<NewCallNote> GetAllCallNote()
        {
            var cn = _c.NewCallNote
                .FromSqlRaw("Select * from dbo.NewCallNote")
                .ToList();

            return cn;
        }

        public NewCallNote GetCallNoteById(int id)
        {
            var cn = _c.NewCallNote
                .FromSqlRaw("Select * from dbo.NewCallNote where CallNoteID =" + id)
                .ToList();

            return cn[0];
        }

        public void UpdateCallNote(NewCallNote model)
        {
            _c.NewCallNote.Update(model);
            _c.SaveChanges();
        }

        public void DeleteCallNote(int id)
        {
            var cn = _c.NewCallNote.FirstOrDefault(x => x.CallNoteID == id);
            if (cn != null)
            {
                _c.NewCallNote.Remove(cn);
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
