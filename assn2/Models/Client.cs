using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace assn2.Models
{
    public class Client
    {
        public int Id { get; set; }
        public int clientRefNum { get; set; }
        public virtual FiscalYear fisYear { get; set; }

        [Range(1,12)]
        public int month { get; set; }
        
        [Range(1,31)]
        public int day { get; set; }
        public string surname { get; set; }
        public string firstName { get; set; }
        
        [RegularExpression("/\\d{2}-\\d{4}/")]
        public string policeFileNum { get; set; }
        public int courtFileNum { get; set; }
        public int SWCFileNum { get; set; }
        public virtual RiskLevel RiskLevel { get; set; }
        public virtual Crisis Crisis { get; set; }
        public virtual Service Service { get; set; }
        public virtual Program Program { get; set; }
        public string RiskAssessmentAssignee { get; set; }
        public virtual RiskStatus RiskStatus { get; set; }
        public virtual AssignedWorker AssignedWorker { get; set; }
        public virtual ReferralSource ReferralSource { get; set; }
        public virtual ReferralContact ReferralContact { get; set; }
        public virtual Incident incident { get; set; }
        public string AbuserName { get; set; }
        public virtual AbuserRelationship AbuserRelationship { get; set; }
        public virtual VictimofIncident VictimofIncident { get; set; }
        public virtual FamilyViolenceFile FamilyViolenceFile { get; set; }
        public char gender { get; set; }
        public Ethnicity Ethnicity { get; set; }
        public Age Age { get; set; }
        public RepeatClient RepeatClient { get; set; }
        public DuplicateFile DuplicateFile { get; set; }
        public int numToddler { get; set; }
        public int numChildren { get; set; }
        public int numYouth { get; set; }
        public StatusofFile StatusofFile { get; set; }
        public DateTime dateLastTransferred { get; set; }
        public DateTime dateClosed { get; set; }
        public DateTime dateReOpened { get; set; }
    }
}