using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class NewCaseNote
    {
        [Key]
        public int CaseNoteID { get; set; }
        public string Type_of_paste_note_below { get; set; }
        public string Goals_achieved { get; set; }
        public string Attachement { get; set; }
        public string Participant { get; set; }
        public string Date { get; set; }
        public string AM_staff { get; set; }
        public string Duration_time { get; set; }
        public string Night_shift { get; set; }
        public string Contact_type { get; set; }
        public string Referral_to { get; set; }
        public string Program { get; set; }
        public string Stick_note { get; set; }
        public string PM_Staff { get; set; }
        public string Minutes { get; set; }
        public string with { get; set; }
        public string Brokerage { get; set; }
        public string What_mood_the_participant_in_Morning { get; set; }
        public string What_mood_the_participant_in_Afternoon { get; set; }
        public string What_mood_the_participant_in_Evining { get; set; }
        public string What_the_participant_had_to_eat_Morning { get; set; }
        public string What_the_participant_had_to_eat_Afternoon { get; set; }
        public string What_the_participant_had_to_eat_Evening { get; set; }
        public string Activities_the_participant_took_part_in_Morning { get; set; }
        public string Activities_the_participant_took_part_in_AfterNoon { get; set; }
        public string Activities_the_participant_took_part_in_Evening { get; set; }
        public string Did_He_She_Enjoy_activities_Morning { get; set; }
        public string Did_He_She_Enjoy_activities_Afternoon { get; set; }
        public string Did_He_She_Enjoy_activities_Evening { get; set; }
        public string Did_he_she_wash_Morning { get; set; }
        public string Did_he_she_wash_Afternoon { get; set; }
        public string Did_he_she_wash_Evening { get; set; }
        public string Did_he_she_brush_teeth_Morning { get; set; }
        public string Did_he_she_brush_Teeth_Evening { get; set; }
        public string Did_he_she_brush_teeth_Afternoon { get; set; }
        public string Did_he_she_bath_Morning { get; set; }
        public string Did_he_she_bath_Evening { get; set; }
        public string Did_he_she_bath_Afternoon { get; set; }
        public string Open_bowls_Evening { get; set; }
        public string Open_bowls_Morning { get; set; }
        public string Open_bowls_Afternoon { get; set; }
        public string Any_behaviour_of_Concern { get; set; }
        public string Recent_case_note { get; set; }
    }
}
