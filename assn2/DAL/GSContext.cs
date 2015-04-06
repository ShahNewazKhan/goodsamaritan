using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using assn2.Models;

namespace assn2.DAL
{
    public class GSContext : DbContext
    {
        public GSContext() : base("DefaultConnection") { }

        public DbSet<AbuserRelationship> AbuserRelationship { get; set; }
        public DbSet<Age> Age { get; set; }
        public DbSet<AssignedWorker> AssignedWorker { get; set; }
        public DbSet<BadDateReport> BadDateReport { get; set; }
        public DbSet<CityofAssault> CityOfAssault { get; set; }
        public DbSet<CityofResidence> CityOfResidence { get; set; }
        public DbSet<Crisis> Crisis { get; set; }
        public DbSet<DuplicateFile> DuplicateFile { get; set; }
        public DbSet<Ethnicity> Ethnicity { get; set; }
        public DbSet<EvidenceStored> EvidenceStored { get; set; }
        public DbSet<FamilyViolenceFile> FamilyViolenceFile { get; set; }
        public DbSet<FiscalYear> FiscalYear { get; set; }
        public DbSet<HIVMeds> HIVMeds { get; set; }
        public DbSet<HospitalAttended> HospitalAttended { get; set; }
        public DbSet<Incident> Incident { get; set; }
        public DbSet<VictimofIncident> IncidentVictim { get; set; }
        public DbSet<MedicalOnly> MedicalOnly { get; set; }
        public DbSet<MultiplePerpetrators> MultiplePerpetrators { get; set; }
        public DbSet<PoliceAttendance> PoliceAttendance { get; set; }
        public DbSet<PoliceReported> PoliceReported { get; set; }
        public DbSet<Program> Program { get; set; }
        public DbSet<DrugfacilitatedAssault> DrugfacilitatedAssault { get; set; }
        public DbSet<ReferralContact> ReferralContact { get; set; }
        public DbSet<ReferralSource> ReferralSource { get; set; }
        public DbSet<ReferredtoCBVS> ReferredtoCBVS { get; set; }
        public DbSet<ReferringHospital> ReferringHospital { get; set; }
        public DbSet<RepeatClient> RepeatClient { get; set; }
        public DbSet<RiskLevel> RiskLevel { get; set; }
        public DbSet<RiskStatus> RiskStatus { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<SexWorkExploitation> SexWorkExploitation { get; set; }
        public DbSet<SocialWorkAttendance> SocialWorkAttendance { get; set; }
        public DbSet<StatusofFile> StatusOfFile { get; set; }
        public DbSet<ThirdPartyReport> ThirdPartyReport { get; set; }
        public DbSet<VictimServicesAttendance> VictimServicesAttendance { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<SmartEntity> SmartEntity { get; set; }
    }
}