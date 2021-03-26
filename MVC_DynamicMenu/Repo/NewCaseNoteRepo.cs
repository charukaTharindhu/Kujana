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
	public class NewCaseNoteRepo
	{
		private readonly DynamicMenuDBContext _context = null;

		public NewCaseNoteRepo(DynamicMenuDBContext context)
		{
			_context = context;
		}

		public void AddNewCaseNote(NewCaseNote model)
		{
			var NewCaseNote = new NewCaseNote
			{
				Minutes = model.Minutes,
				Participant = model.Participant,
				CaseNoteID = model.CaseNoteID,
				Date = model.Date,
				Contact_type = model.Contact_type,
				Activities_the_participant_took_part_in_AfterNoon = model.Activities_the_participant_took_part_in_AfterNoon,
				Activities_the_participant_took_part_in_Evening = model.Activities_the_participant_took_part_in_Evening,
				Activities_the_participant_took_part_in_Morning = model.Activities_the_participant_took_part_in_Morning,
				AM_staff = model.AM_staff,
				Any_behaviour_of_Concern = model.Any_behaviour_of_Concern,
				Attachement = model.Attachement,
				Brokerage = model.Brokerage,
				Did_he_she_brush_teeth_Afternoon =model.Did_he_she_brush_teeth_Afternoon,
				Did_he_she_brush_Teeth_Evening = model.Did_he_she_brush_Teeth_Evening,
				Did_he_she_brush_teeth_Morning = model.Did_he_she_brush_teeth_Morning,
				Did_He_She_Enjoy_activities_Afternoon = model.Did_He_She_Enjoy_activities_Afternoon,
				Did_He_She_Enjoy_activities_Evening = model.Did_He_She_Enjoy_activities_Evening,
				Did_he_she_wash_Afternoon = model.Did_he_she_wash_Afternoon,
				Did_He_She_Enjoy_activities_Morning =model.Did_He_She_Enjoy_activities_Morning,
				Did_he_she_wash_Evening = model.Did_he_she_wash_Evening,
				Did_he_she_wash_Morning = model.Did_he_she_wash_Morning,
				Duration_time = model.Duration_time,
				Goals_achieved =model.Goals_achieved,
				Night_shift = model.Night_shift,
				Open_bowls_Afternoon = model.Open_bowls_Afternoon,
				Open_bowls_Evening = model.Open_bowls_Evening,
				Open_bowls_Morning =model.Open_bowls_Morning,
				PM_Staff = model.PM_Staff,
				Program = model.Program,
				Recent_case_note = model.Recent_case_note,
				Referral_to = model.Referral_to,
				Stick_note = model.Stick_note,
				Type_of_paste_note_below = model.Type_of_paste_note_below,
				What_mood_the_participant_in_Afternoon = model.What_mood_the_participant_in_Afternoon,
				What_mood_the_participant_in_Evining = model.What_mood_the_participant_in_Evining,
				What_mood_the_participant_in_Morning = model.What_mood_the_participant_in_Morning,
				What_the_participant_had_to_eat_Afternoon = model.What_the_participant_had_to_eat_Afternoon,
				What_the_participant_had_to_eat_Evening = model.What_the_participant_had_to_eat_Evening,
				What_the_participant_had_to_eat_Morning = model.What_the_participant_had_to_eat_Morning,
				with = model.with
			};
			_context.NewCaseNote.Add(NewCaseNote);
			_context.SaveChanges();
		}

		public List<NewCaseNote> getAllCaseNote()
		{
			var obj = _context.NewCaseNote
			.FromSqlRaw("SELECT * FROM dbo.NewCaseNote")
			.ToList();

			return obj;
		}
		public NewCaseNote getCaseNoterById(int id)
		{
			var obj = _context.NewCaseNote
			.FromSqlRaw("SELECT * FROM dbo.NewCaseNote WHERE CaseNoteID=" + id)
			.ToList();

			return obj[0];
		}
		public void UpdateCaseNote(NewCaseNote model)
		{
			_context.NewCaseNote.Update(model);
			_context.SaveChanges();
		}

		public void DeleteCaseNote(int id)
		{
			var note = _context.NewCaseNote.FirstOrDefault(x => x.CaseNoteID == id);
			if (note != null)
			{
				_context.NewCaseNote.Remove(note);
				_context.SaveChanges();
			}
		}

		public string GetPatients()
		{
			var obj = _context.Patient.FromSqlRaw("SELECT * FROM dbo.Patient").ToList();
			var patients = JsonConvert.SerializeObject(obj);
			return patients;
		}
	}

}
