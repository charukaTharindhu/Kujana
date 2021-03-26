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
    public class Patient_ContactRepo
    {
        private readonly DynamicMenuDBContext _c = null;

        public Patient_ContactRepo(DynamicMenuDBContext c)
        {
           _c = c;
        }
		public List<Patient_Info> GetAllPatientInfo()
        {
			var patientInfo = _c.Patient_Info.FromSqlRaw("Select * from Patient_Info").ToList();
			return patientInfo;
        }
		/*
		public void AddNewPatient_Contact(Patient_Contact model)
		{
			var NewPcontact = new Patient_Contact
			{
				PatientID = model.PatientID,
				Line2 = model.Line2,
				Patient = model.Patient,
				Can_text = model.Can_text,
				City = model.City,
				Country = model.Country,
				ContactID = model.ContactID,
				Email = model.Email,
				Disclose_Address = model.Disclose_Address,
				Comment = model.Comment,
				emargencyPhone = model.emargencyPhone,
				Line1 = model.Line1,
				LivingWith = model.LivingWith,
				Name = model.Name,
				Phone = model.Phone,
				Relationship = model.Relationship,
				Security = model.Security,
				Start_Date = model.Start_Date,
				State = model.State,
				AddComment = model.AddComment,
				Type = model.Type

			};
			_c.Patient_Contact.Add(NewPcontact);
			_c.SaveChanges();
		}

		public void AddNewPatient_Info(Patient_Info model)
		{
			var NewPInfo = new Patient_Info
			{
				CeterLink_Number = model.CeterLink_Number,
				COB_Comment = model.COB_Comment,
				Comments = model.Comments,
				Country = model.Country,
				DateOfBirth = model.DateOfBirth,
				Effective_date = model.Effective_date,
				FirstName = model.FirstName,
				Gender = model.Gender,
				Indegenous_status = model.Indegenous_status,
				Interpreted_needed = model.Interpreted_needed,
				Language_spoken_at_home = model.Language_spoken_at_home,
				LastName = model.LastName,
				NDIS_Number = model.NDIS_Number,
				Office = model.Office,
				Other_Cultural_Issues = model.Other_Cultural_Issues,
				Patient = model.Patient,
				Primary_income_source = model.Primary_income_source,
				PatientID = model.PatientID,
				Patient_InfoID = model.Patient_InfoID,
				IncomeComments = model.IncomeComments
			};
			_c.Patient_Info.Add(NewPInfo);
			_c.SaveChanges();
		}

		public void AddNewSummerising(Summerising model)
		{
			var NewSummerising = new Summerising
			{
				Complaints_Date = model.Complaints_Date,
				Complaints_dateExplained = model.Complaints_dateExplained,
				Complaints_Reason = model.Complaints_Reason,
				Connection_to_family_and_Significant_people_MinimalImprovement = model.Connection_to_family_and_Significant_people_MinimalImprovement,
				Connection_to_family_and_Significant_people_ModerateImprovement = model.Connection_to_family_and_Significant_people_ModerateImprovement,
				Connection_to_family_and_Significant_people_NoChange = model.Connection_to_family_and_Significant_people_NoChange,
				Connection_to_family_and_Significant_people_SubstantialImprovement = model.Connection_to_family_and_Significant_people_SubstantialImprovement,
				Connection_to_family_and_Significant_people_Sufficient_at_Commencement = model.Connection_to_family_and_Significant_people_Sufficient_at_Commencement,
				Connection_to_family_and_Significant_people_View_of_self_Comments = model.Connection_to_family_and_Significant_people_View_of_self_Comments,
				Connection_to_family_and_Significant_people_Worse = model.Connection_to_family_and_Significant_people_Worse,
				Date_of_exit = model.Date_of_exit,
				ExitInterviewConsent_Comment = model.ExitInterviewConsent_Comment,
				ExitInterviewConsent_ConsentAtExite = model.ExitInterviewConsent_ConsentAtExite,
				ExitInterviewConsent_Date = model.ExitInterviewConsent_Date,
				Goals_Achived_at_exit_Comment = model.Goals_Achived_at_exit_Comment,
				Goals_Achived_at_exit_Selection = model.Goals_Achived_at_exit_Selection,
				InformationSharingWithThirdParties_ConsentToShareInformation = model.InformationSharingWithThirdParties_ConsentToShareInformation,
				InformationSharingWithThirdParties_Date = model.InformationSharingWithThirdParties_Date,
				InformationSharingWithThirdParties_informationSharingWithThirdParties = model.InformationSharingWithThirdParties_informationSharingWithThirdParties,
				MedicalConsent_Consent  = model.MedicalConsent_Consent,
				MedicalConsent_Date = model.MedicalConsent_Date,
				MedicalConsent_MedicalConsent = model.MedicalConsent_MedicalConsent,
				ourWayOfWorkingOutComes_DateCompleted = model.ourWayOfWorkingOutComes_DateCompleted,
				Participants_level_of_Engagement_In_this_Program_Comment = model.Participants_level_of_Engagement_In_this_Program_Comment,
				Participants_level_of_Engagement_In_this_Program_sellection = model.Participants_level_of_Engagement_In_this_Program_sellection,
				Primary_model_of_service_while_Involved_with_program_Comment = model.Primary_model_of_service_while_Involved_with_program_Comment,
				Primary_model_of_service_while_Involved_with_program_selection =  model.Primary_model_of_service_while_Involved_with_program_selection,
				PrivacyAndConsent_Date = model.PrivacyAndConsent_Date,
				PrivacyAndConsent_Date_Signed = model.PrivacyAndConsent_Date_Signed,
				PrivacyAndConsent_Reason = model.PrivacyAndConsent_Reason,
				Reason_of_exit_Comment = model.Reason_of_exit_Comment,
				Reason_of_exit_Selection = model.Reason_of_exit_Selection,
				RightAndResponsibilities_Date = model.RightAndResponsibilities_Date,
				RightAndResponsibilities_DateExplained = model.RightAndResponsibilities_DateExplained,
				RightAndResponsibilities_Reason = model.RightAndResponsibilities_Reason,
				SummerisingID = model.SummerisingID,
				Test_question_Comments = model.Test_question_Comments,
				Test_question_MinimalImprovement = model.Test_question_MinimalImprovement,
				Test_question_ModerateImprovement = model.Test_question_ModerateImprovement,
				Test_question_NoChange = model.Test_question_NoChange,
				Test_question_SubstantialImprovement = model.Test_question_SubstantialImprovement,
				Test_question_Sufficient_at_Commencement = model.Test_question_Sufficient_at_Commencement,
				Test_question_Worse = model.Test_question_Worse,
				View_of_future_Comments = model.View_of_future_Comments,
				View_of_future_MinimalImprovement = model.View_of_future_MinimalImprovement,
				View_of_future_ModerateImprovement = model.View_of_future_ModerateImprovement,
				View_of_future_NoChange = model.View_of_future_NoChange,
				View_of_future_SubstantialImprovement = model.View_of_future_SubstantialImprovement,
				View_of_future_Sufficient_at_Commencement = model.View_of_future_Sufficient_at_Commencement,
				View_of_future_Worse = model.View_of_future_Worse,
				View_of_self_Comments = model.View_of_self_Comments,
				View_of_self_MinimalImprovement = model.View_of_self_MinimalImprovement,
				View_of_self_ModerateImprovement = model.View_of_self_ModerateImprovement,
				View_of_self_NoChange = model.View_of_self_NoChange,
				View_of_self_SubstantialImprovement = model.View_of_self_SubstantialImprovement,
				View_of_self_Sufficient_at_Commencement = model.View_of_self_Sufficient_at_Commencement,
				View_of_self_Worse = model.View_of_self_Worse
				
			};
			_c.Summerising.Add(NewSummerising);
			_c.SaveChanges();
		}

		public void AddNewPatient_Helth(Patient_Helth model)
		{
			var NewPHelth = new Patient_Helth
			{
				Acquried_brain_injury = model.Acquried_brain_injury,
				Allergies = model.Allergies,
				Cardiovscular = model.Cardiovscular,
				Chronic_pain = model.Chronic_pain,
				Diabetes = model.Diabetes,
				Dissabilities_none = model.Dissabilities_none,
				Down_Syndrome = model.Down_Syndrome,
				Epilepsy = model.Epilepsy,
				Exp = model.Exp,
				Hearing_inmpairment = model.Hearing_inmpairment,
				Infectious_Disease = model.Infectious_Disease,
				Interlrctual_disability = model.Interlrctual_disability,
				Medicare_number = model.Medicare_number,
				Obesity = model.Obesity,
				Other = model.Other,
				Patient = model.Patient,
				PatientHelthID = model.PatientHelthID,
				PatientID = model.PatientID,
				Physical_disability = model.Physical_disability,
				Repiratory = model.Repiratory,
				Skin_condition = model.Skin_condition,
				Suffix = model.Suffix,
				Suspected_ABI = model.Suspected_ABI,
				Unknown = model.Unknown,
				Vission_impa = model.Vission_impa,
				Acquried_brain_injury_comment = model.Acquried_brain_injury_comment,
				Allergies_comment = model.Allergies_comment,
				Cardiovscular_comment = model.Cardiovscular_comment,
				Chronic_pain_comment = model.Chronic_pain_comment,
				Diabetes_comment = model.Diabetes_comment,
				Dissabilities_none_Comment = model.Dissabilities_none_Comment,
				Down_Syndrome_comment = model.Down_Syndrome_comment,
				Epilepsy_comment = model.Epilepsy_comment,
				Hearing_inmpairment_comment = model.Hearing_inmpairment_comment,
				Infectious_Disease_comment = model.Infectious_Disease_comment,
				Interlrctual_disability_comment = model.Interlrctual_disability_comment,
				Medical_none = model.Medical_none,
				Medical_none_Comment = model.Medical_none_Comment,
				Obesity_comment = model.Obesity_comment,
				Other_Comment = model.Other_Comment,
				Physical_disability_comment = model.Physical_disability_comment,
				Repiratory_comment = model.Repiratory_comment,
				Skin_condition_comment = model.Skin_condition_comment,
				Suspected_ABI_comment = model.Suspected_ABI_comment,
				Unknown_comment = model.Unknown_comment,
				Vission_impap_comment = model.Vission_impap_comment
						
			};
			_c.Patient_Helth.Add(NewPHelth);
			_c.SaveChanges();
		}

		public void AddNewProgramm(Programs model)
		{
			var NewProgramm = new Programs
			{
				Commenced =model.Commenced,
				DateOfExit = model.DateOfExit,
				Pause = model.Pause,
				Program = model.Program,
				ProgramID = model.ProgramID,
				Resume = model.Resume,
				Setting = model.Setting,
				
				
			};
			_c.Programs.Add(NewProgramm);
			_c.SaveChanges();
		}

		public void AddNewCase_Worker(Case_Worker model)
		{
			var NewCase_Worker = new Case_Worker
			{
				DateAllocated = model.DateAllocated,
				DateDeallocated = model.DateDeallocated,
				KeyWorker =model.KeyWorker,
				Patient =model.Patient,
				PatientID = model.PatientID,
				WorkerID = model.WorkerID
			};
			_c.Case_Worker.Add(NewCase_Worker);
			_c.SaveChanges();
		}

		public void Addhouser(Housing_Register_Application model)
		{
			var NewHouse = new Housing_Register_Application
			{
				PatientID = model.PatientID,
				ApplicationID = model.ApplicationID,
				Application_number = model.Application_number,
				Date_Submited = model.Date_Submited,
				Location_Submited  = model.Location_Submited,
				Patient = model.Patient,
				priority_catogory = model.priority_catogory,
				Application_type = model.Application_type,
				priority_type = model.priority_type
				
			};
			_c.Housing_Register_Application.Add(NewHouse);
			_c.SaveChanges();
		}

		public void AddNewCareTeams(CareTeams model)
		{
			var NewCase_Worker = new CareTeams
			{
				PatientID = model.PatientID,
				Patient = model.Patient,
				Address = model.Address,
				Agency_name = model.Agency_name,
				CareTeameID = model.CareTeameID,
				Group = model.Group,
				Phone = model.Phone,
				Referal_Date = model.Referal_Date,
				Referal_name = model.Referal_name,
				Referal_source = model.Referal_source,
				Sub_Program = model.Sub_Program
			};
			_c.CareTeams.Add(NewCase_Worker);
			_c.SaveChanges();
		}

		public void AddNewCommencement_Issuse(Commencement_Issuse model)
		{
			var issuse = new Commencement_Issuse
			{
				PatientID = model.PatientID,
				Patient  = model.Patient,
				CommencementID = model.CommencementID,
				Comments = model.Comments,
				Issues = model.Issues,
				Program_Details_and_Support_needs = model.Program_Details_and_Support_needs,
				Select_Other_issues = model.Select_Other_issues
				
			};
			_c.Commencement_Issuse.Add(issuse);
			_c.SaveChanges();
		}

	
		*/
		/*public void UpdateCommencementIssues(Commencement_Issuse model)
        {
			_c.Commencement_Issuse.Update(model);
			_c.SaveChanges();
        }

		public void UpdatePatient_Contact(Patient_Contact model)
		{
			_c.Patient_Contact.Update(model);
			_c.SaveChanges();
		}

		public void UpdatePatient_Info(Patient_Info model)
		{
			_c.Patient_Info.Update(model);
			_c.SaveChanges();
		}

		public void UpdateSummerising(Summerising model)
		{
			_c.Summerising.Update(model);
			_c.SaveChanges();
		}

		public void UpdatePatient_Helth(Patient_Helth model)
		{
			_c.Patient_Helth.Update(model);
			_c.SaveChanges();
		}

		public void UpdatePrograms(Programs model)
		{
			_c.Programs.Update(model);
			_c.SaveChanges();
		}
		public void UpdateCase_Worker(Case_Worker model)
		{
			_c.Case_Worker.Update(model);
			_c.SaveChanges();
		}

		public void UpdateHousing_Register_Application(Housing_Register_Application model)
		{
			_c.Housing_Register_Application.Update(model);
			_c.SaveChanges();
		}
		public void UpdateCareTeams(CareTeams model)
		{
			_c.CareTeams.Update(model);
			_c.SaveChanges();
		}
		*/


		public string GetPatient()
		{
			var obj = _c.Patient.FromSqlRaw("Select * from dbo.Patient").ToList();
			var patient = JsonConvert.SerializeObject(obj);

			return patient;
		}

		public void AddPatient(Patient model)
        {
			_c.Patient.Add(model);
			_c.SaveChanges();
        }

		public Patient GetAllpatientInfoById(int id)
		{
			List<Patient> obj = _c.Patient.FromSqlRaw("Select * from dbo.Patient where PatientID=" + id).ToList();
			obj[0].Patient_Info = _c.Patient_Info.FromSqlRaw("Select * from dbo.Patient_Info where PatientID=" + id).ToList();
			obj[0].patient_Contacts = _c.Patient_Contact.FromSqlRaw("Select * from dbo.patient_Contact where PatientID=" + id).ToList();
			obj[0].summerisings = _c.Summerising.FromSqlRaw("Select * from dbo.summerising where PatientID=" + id).ToList();
			obj[0].patient_Helths = _c.Patient_Helth.FromSqlRaw("Select * from dbo.patient_Helth where PatientID=" + id).ToList();
			obj[0].programs = _c.Programs.FromSqlRaw("Select * from dbo.programs where PatientID=" + id).ToList();
			obj[0].Case_Worker = _c.Case_Worker.FromSqlRaw("Select * from dbo.Case_Worker where PatientID=" + id).ToList();
			obj[0].Housing_Register_Application = _c.Housing_Register_Application.FromSqlRaw("Select * from dbo.Housing_Register_Application where PatientID=" + id).ToList();
			obj[0].CareTeams = _c.CareTeams.FromSqlRaw("Select * from dbo.CareTeams where PatientID=" + id).ToList();
			//obj[0].Files = _c.File.FromSqlRaw("Select * from dbo.File where PatientID=" + id).ToList();
			obj[0].Commencement_Issuse = _c.Commencement_Issuse.FromSqlRaw("Select * from dbo.Commencement_Issuse where PatientID=" + id).ToList();
			return obj[0];
		}

		public List<Patient> getAllPatient()
		{
			List<Patient> obj = _c.Patient.FromSqlRaw("SELECT * FROM dbo.Patient").ToList();

			for (int i = 0; i < obj.Count; i++)
			{
				obj[i].Patient_Info = _c.Patient_Info.FromSqlRaw("Select * from dbo.Patient_Info where PatientID=" + obj[i].PatientID).ToList();
				obj[i].patient_Contacts = _c.Patient_Contact.FromSqlRaw("Select * from dbo.patient_Contact where PatientID=" + obj[i].PatientID).ToList();
				obj[i].summerisings = _c.Summerising.FromSqlRaw("Select * from dbo.summerising where PatientID=" + obj[i].PatientID).ToList();
				obj[i].patient_Helths = _c.Patient_Helth.FromSqlRaw("Select * from dbo.patient_Helth where PatientID=" + obj[i].PatientID).ToList();
				obj[i].programs = _c.Programs.FromSqlRaw("Select * from dbo.programs where PatientID=" + obj[i].PatientID).ToList();
				obj[i].Case_Worker = _c.Case_Worker.FromSqlRaw("Select * from dbo.Case_Worker where PatientID=" + obj[i].PatientID).ToList();
				obj[i].Housing_Register_Application = _c.Housing_Register_Application.FromSqlRaw("Select * from dbo.Housing_Register_Application where PatientID=" + obj[i].PatientID).ToList();
				obj[i].CareTeams = _c.CareTeams.FromSqlRaw("Select * from dbo.CareTeams where PatientID=" + obj[i].PatientID).ToList();
				//obj[i].Files = _c.File.FromSqlRaw("Select * from dbo.File where PatientID=" + obj[i].PatientID).ToList();
				obj[i].Commencement_Issuse = _c.Commencement_Issuse.FromSqlRaw("Select * from dbo.Commencement_Issuse where PatientID=" + obj[i].PatientID).ToList();
				

			}
			return obj;
		}
		public void UpdateAllPatientInfo(Patient model)
        {
			_c.Patient.Update(model);
			_c.SaveChanges();
        }

		public void DeleteAllPatientInfo(int id)
		{
			
			var Patient_Info = _c.Patient_Info.FirstOrDefault(x => x.PatientID == id);
			if (Patient_Info != null)
			{
				_c.Patient_Info.Remove(Patient_Info);
				_c.SaveChanges();
			}

			var patient_Contacts = _c.Patient_Contact.FirstOrDefault(x => x.PatientID == id);
			if (patient_Contacts != null)
			{
				_c.Patient_Contact.Remove(patient_Contacts);
				_c.SaveChanges();
			}

			var Summerising = _c.Summerising.FirstOrDefault(x => x.PatientID == id);
			if (Summerising != null)
			{
				_c.Summerising.Remove(Summerising);
				_c.SaveChanges();
			}

			var Patient_Helth = _c.Patient_Helth.FirstOrDefault(x => x.PatientID == id);
			if (Patient_Helth != null)
			{
				_c.Patient_Helth.Remove(Patient_Helth);
				_c.SaveChanges();
			}

			var Programs = _c.Programs.FirstOrDefault(x => x.PatientID == id);
			if (Programs != null)
			{
				_c.Programs.Remove(Programs);
				_c.SaveChanges();
			}

			var Case_Worker = _c.Case_Worker.FirstOrDefault(x => x.PatientID == id);
			if (Case_Worker != null)
			{
				_c.Case_Worker.Remove(Case_Worker);
				_c.SaveChanges();
			}

			var Housing_Register_Application = _c.Housing_Register_Application.FirstOrDefault(x => x.PatientID == id);
			if (Housing_Register_Application != null)
			{
				_c.Housing_Register_Application.Remove(Housing_Register_Application);
				_c.SaveChanges();
			}

			var CareTeams = _c.CareTeams.FirstOrDefault(x => x.PatientID == id);
			if (CareTeams != null)
			{
				_c.CareTeams.Remove(CareTeams);
				_c.SaveChanges();
			}

			var Commencement_Issuse = _c.Commencement_Issuse.FirstOrDefault(x => x.PatientID == id);
			if (Commencement_Issuse != null)
			{
				_c.Commencement_Issuse.Remove(Commencement_Issuse);
				_c.SaveChanges();
			}
			var patient = _c.Patient.FirstOrDefault(x => x.PatientID == id);
			if (patient != null)
			{
				_c.Patient.Remove(patient);
				_c.SaveChanges();
			}
		}
	}
}
