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
    public class AddDocument_SkillRepo
    {
        private readonly DynamicMenuDBContext _c = null;

        public AddDocument_SkillRepo(DynamicMenuDBContext c)
        {
            _c = c;
        }

        public void AddDocument_Skill(AddDocument_Skill model)
        {
            var doc = new AddDocument_Skill
            {
                Alert_template = model.Alert_template,
                Certificate_number = model.Certificate_number,
                Checked_by = model.Checked_by,
                Competency = model.Competency,
                Completed = model.Completed,
                Description = model.Description,
                DocID = model.DocID,
                Expiry_date = model.Expiry_date,
                Preriod_befor_Expiring_reminder = model.Preriod_befor_Expiring_reminder,
                Select_file = model.Select_file,
                Send_alert = model.Send_alert,
                Valid_for = model.Valid_for
            };
            _c.AddDocument_Skill.Add(doc);
            _c.SaveChanges();
        }

        public List<AddDocument_Skill> getAllDocument_Skill()
        {
            var obj = _c.AddDocument_Skill.FromSqlRaw("Select * from dbo.AddDocument_Skill").ToList();
            return obj;
        }

        public AddDocument_Skill GetDocument_SkillByID(int id)
        {
            var obj = _c.AddDocument_Skill
                .FromSqlRaw("Select * from dbo.AddNewStaffMeeting where DocID =" + id)
                .ToList();

            return obj[0];
        }

        public MyProfile GetProfileInfoByID(int id)
        {
            var obj = _c.MyProfile
                .FromSqlRaw("Select * from dbo.MyProfile where UserId =" + id)
                .ToList();
            if(obj.Count==0||obj.Count<0)
            {
                return null;
            }
            else
            {
                return obj[0];
            }
            
        }

        public void UpdateDocument_Skill(AddDocument_Skill model)
        {
            _c.AddDocument_Skill.Update(model);
            _c.SaveChanges();
        }

        public void UpdateProfileInfo(MyProfile model)
        {
            if(model.ProfileID == 0)
            {
                _c.MyProfile.Add(model);
            }
            else
            {
                _c.MyProfile.Update(model);
            }
                
            _c.SaveChanges();
        }

        public void DeleteDocument_Skill(int id)
        {
            var doc = _c.AddDocument_Skill.FirstOrDefault(x => x.DocID == id);
            if (doc != null)
            {
                _c.AddDocument_Skill.Remove(doc);
                _c.SaveChanges();
            }
        }

        public string GetPatients()
        {
            var obj = _c.Patient.FromSqlRaw("SELECT * FROM dbo.Patient").ToList();
            var patients = JsonConvert.SerializeObject(obj);
            return patients;
        }

        public List<MyProfile> GetAllProfilInfo()
        {
            var obj = _c.MyProfile.FromSqlRaw("Select * from dbo.MyProfile").ToList();
            return obj;
        }
    }
}

