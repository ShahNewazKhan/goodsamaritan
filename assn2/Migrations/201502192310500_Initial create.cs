namespace assn2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbuserRelationships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssignedWorkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BadDateReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CityofAssaults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CityofResidences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        clientRefNum = c.Int(nullable: false),
                        month = c.Int(nullable: false),
                        day = c.Int(nullable: false),
                        surname = c.String(),
                        firstName = c.String(),
                        policeFileNum = c.String(),
                        courtFileNum = c.Int(nullable: false),
                        SWCFileNum = c.Int(nullable: false),
                        RiskAssessmentAssignee = c.String(),
                        AbuserName = c.String(),
                        numToddler = c.Int(nullable: false),
                        numChildren = c.Int(nullable: false),
                        numYouth = c.Int(nullable: false),
                        dateLastTransferred = c.DateTime(nullable: false),
                        dateClosed = c.DateTime(nullable: false),
                        dateReOpened = c.DateTime(nullable: false),
                        AbuserRelationship_Id = c.Int(),
                        Age_Id = c.Int(),
                        AssignedWorker_Id = c.Int(),
                        Crisis_Id = c.Int(),
                        DuplicateFile_Id = c.Int(),
                        Ethnicity_Id = c.Int(),
                        FamilyViolenceFile_Id = c.Int(),
                        fisYear_Id = c.Int(),
                        incident_Id = c.Int(),
                        Program_Id = c.Int(),
                        ReferralContact_Id = c.Int(),
                        ReferralSource_Id = c.Int(),
                        RepeatClient_Id = c.Int(),
                        RiskLevel_Id = c.Int(),
                        RiskStatus_Id = c.Int(),
                        Service_Id = c.Int(),
                        StatusofFile_Id = c.Int(),
                        VictimofIncident_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbuserRelationships", t => t.AbuserRelationship_Id)
                .ForeignKey("dbo.Ages", t => t.Age_Id)
                .ForeignKey("dbo.AssignedWorkers", t => t.AssignedWorker_Id)
                .ForeignKey("dbo.Crises", t => t.Crisis_Id)
                .ForeignKey("dbo.DuplicateFiles", t => t.DuplicateFile_Id)
                .ForeignKey("dbo.Ethnicities", t => t.Ethnicity_Id)
                .ForeignKey("dbo.FamilyViolenceFiles", t => t.FamilyViolenceFile_Id)
                .ForeignKey("dbo.FiscalYears", t => t.fisYear_Id)
                .ForeignKey("dbo.Incidents", t => t.incident_Id)
                .ForeignKey("dbo.Programs", t => t.Program_Id)
                .ForeignKey("dbo.ReferralContacts", t => t.ReferralContact_Id)
                .ForeignKey("dbo.ReferralSources", t => t.ReferralSource_Id)
                .ForeignKey("dbo.RepeatClients", t => t.RepeatClient_Id)
                .ForeignKey("dbo.RiskLevels", t => t.RiskLevel_Id)
                .ForeignKey("dbo.RiskStatus", t => t.RiskStatus_Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .ForeignKey("dbo.StatusofFiles", t => t.StatusofFile_Id)
                .ForeignKey("dbo.VictimofIncidents", t => t.VictimofIncident_Id)
                .Index(t => t.AbuserRelationship_Id)
                .Index(t => t.Age_Id)
                .Index(t => t.AssignedWorker_Id)
                .Index(t => t.Crisis_Id)
                .Index(t => t.DuplicateFile_Id)
                .Index(t => t.Ethnicity_Id)
                .Index(t => t.FamilyViolenceFile_Id)
                .Index(t => t.fisYear_Id)
                .Index(t => t.incident_Id)
                .Index(t => t.Program_Id)
                .Index(t => t.ReferralContact_Id)
                .Index(t => t.ReferralSource_Id)
                .Index(t => t.RepeatClient_Id)
                .Index(t => t.RiskLevel_Id)
                .Index(t => t.RiskStatus_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.StatusofFile_Id)
                .Index(t => t.VictimofIncident_Id);
            
            CreateTable(
                "dbo.Crises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DuplicateFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ethnicities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FamilyViolenceFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FiscalYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Incidents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReferralContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReferralSources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RepeatClients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RiskLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RiskStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusofFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VictimofIncidents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EvidenceStoreds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HIVMeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HospitalAttendeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicalOnlies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MultiplePerpetrators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PoliceAttendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PoliceReporteds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReferredtoCBVS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReferringHospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SexWorkExploitations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SmartEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccompanimentMinutes = c.Int(nullable: false),
                        NumberTransportsProvided = c.Int(nullable: false),
                        ReferredToNurse = c.Boolean(nullable: false),
                        BadDateReport_Id = c.Int(),
                        CityOfAssault_Id = c.Int(),
                        CityOfResidence_Id = c.Int(),
                        Client_Id = c.Int(),
                        DrugFacilitatedAssault_Id = c.Int(),
                        EvidenceStored_Id = c.Int(),
                        HIVMeds_Id = c.Int(),
                        HospitalAttended_Id = c.Int(),
                        MedicalOnly_Id = c.Int(),
                        MultiplePerpetrators_Id = c.Int(),
                        PoliceAttendance_Id = c.Int(),
                        PoliceReported_Id = c.Int(),
                        ReferredToCBVS_Id = c.Int(),
                        ReferringHospital_Id = c.Int(),
                        SexWorkExploitation_Id = c.Int(),
                        SocialWorkAttendance_Id = c.Int(),
                        ThirdPartyReport_Id = c.Int(),
                        VictimServesAttendance_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BadDateReports", t => t.BadDateReport_Id)
                .ForeignKey("dbo.CityofAssaults", t => t.CityOfAssault_Id)
                .ForeignKey("dbo.CityofResidences", t => t.CityOfResidence_Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.DrugfacilitatedAssaults", t => t.DrugFacilitatedAssault_Id)
                .ForeignKey("dbo.EvidenceStoreds", t => t.EvidenceStored_Id)
                .ForeignKey("dbo.HIVMeds", t => t.HIVMeds_Id)
                .ForeignKey("dbo.HospitalAttendeds", t => t.HospitalAttended_Id)
                .ForeignKey("dbo.MedicalOnlies", t => t.MedicalOnly_Id)
                .ForeignKey("dbo.MultiplePerpetrators", t => t.MultiplePerpetrators_Id)
                .ForeignKey("dbo.PoliceAttendances", t => t.PoliceAttendance_Id)
                .ForeignKey("dbo.PoliceReporteds", t => t.PoliceReported_Id)
                .ForeignKey("dbo.ReferredtoCBVS", t => t.ReferredToCBVS_Id)
                .ForeignKey("dbo.ReferringHospitals", t => t.ReferringHospital_Id)
                .ForeignKey("dbo.SexWorkExploitations", t => t.SexWorkExploitation_Id)
                .ForeignKey("dbo.SocialWorkAttendances", t => t.SocialWorkAttendance_Id)
                .ForeignKey("dbo.ThirdPartyReports", t => t.ThirdPartyReport_Id)
                .ForeignKey("dbo.VictimServicesAttendances", t => t.VictimServesAttendance_Id)
                .Index(t => t.BadDateReport_Id)
                .Index(t => t.CityOfAssault_Id)
                .Index(t => t.CityOfResidence_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.DrugFacilitatedAssault_Id)
                .Index(t => t.EvidenceStored_Id)
                .Index(t => t.HIVMeds_Id)
                .Index(t => t.HospitalAttended_Id)
                .Index(t => t.MedicalOnly_Id)
                .Index(t => t.MultiplePerpetrators_Id)
                .Index(t => t.PoliceAttendance_Id)
                .Index(t => t.PoliceReported_Id)
                .Index(t => t.ReferredToCBVS_Id)
                .Index(t => t.ReferringHospital_Id)
                .Index(t => t.SexWorkExploitation_Id)
                .Index(t => t.SocialWorkAttendance_Id)
                .Index(t => t.ThirdPartyReport_Id)
                .Index(t => t.VictimServesAttendance_Id);
            
            CreateTable(
                "dbo.DrugfacilitatedAssaults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialWorkAttendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ThirdPartyReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VictimServicesAttendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SmartEntities", "VictimServesAttendance_Id", "dbo.VictimServicesAttendances");
            DropForeignKey("dbo.SmartEntities", "ThirdPartyReport_Id", "dbo.ThirdPartyReports");
            DropForeignKey("dbo.SmartEntities", "SocialWorkAttendance_Id", "dbo.SocialWorkAttendances");
            DropForeignKey("dbo.SmartEntities", "SexWorkExploitation_Id", "dbo.SexWorkExploitations");
            DropForeignKey("dbo.SmartEntities", "ReferringHospital_Id", "dbo.ReferringHospitals");
            DropForeignKey("dbo.SmartEntities", "ReferredToCBVS_Id", "dbo.ReferredtoCBVS");
            DropForeignKey("dbo.SmartEntities", "PoliceReported_Id", "dbo.PoliceReporteds");
            DropForeignKey("dbo.SmartEntities", "PoliceAttendance_Id", "dbo.PoliceAttendances");
            DropForeignKey("dbo.SmartEntities", "MultiplePerpetrators_Id", "dbo.MultiplePerpetrators");
            DropForeignKey("dbo.SmartEntities", "MedicalOnly_Id", "dbo.MedicalOnlies");
            DropForeignKey("dbo.SmartEntities", "HospitalAttended_Id", "dbo.HospitalAttendeds");
            DropForeignKey("dbo.SmartEntities", "HIVMeds_Id", "dbo.HIVMeds");
            DropForeignKey("dbo.SmartEntities", "EvidenceStored_Id", "dbo.EvidenceStoreds");
            DropForeignKey("dbo.SmartEntities", "DrugFacilitatedAssault_Id", "dbo.DrugfacilitatedAssaults");
            DropForeignKey("dbo.SmartEntities", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.SmartEntities", "CityOfResidence_Id", "dbo.CityofResidences");
            DropForeignKey("dbo.SmartEntities", "CityOfAssault_Id", "dbo.CityofAssaults");
            DropForeignKey("dbo.SmartEntities", "BadDateReport_Id", "dbo.BadDateReports");
            DropForeignKey("dbo.Clients", "VictimofIncident_Id", "dbo.VictimofIncidents");
            DropForeignKey("dbo.Clients", "StatusofFile_Id", "dbo.StatusofFiles");
            DropForeignKey("dbo.Clients", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Clients", "RiskStatus_Id", "dbo.RiskStatus");
            DropForeignKey("dbo.Clients", "RiskLevel_Id", "dbo.RiskLevels");
            DropForeignKey("dbo.Clients", "RepeatClient_Id", "dbo.RepeatClients");
            DropForeignKey("dbo.Clients", "ReferralSource_Id", "dbo.ReferralSources");
            DropForeignKey("dbo.Clients", "ReferralContact_Id", "dbo.ReferralContacts");
            DropForeignKey("dbo.Clients", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.Clients", "incident_Id", "dbo.Incidents");
            DropForeignKey("dbo.Clients", "fisYear_Id", "dbo.FiscalYears");
            DropForeignKey("dbo.Clients", "FamilyViolenceFile_Id", "dbo.FamilyViolenceFiles");
            DropForeignKey("dbo.Clients", "Ethnicity_Id", "dbo.Ethnicities");
            DropForeignKey("dbo.Clients", "DuplicateFile_Id", "dbo.DuplicateFiles");
            DropForeignKey("dbo.Clients", "Crisis_Id", "dbo.Crises");
            DropForeignKey("dbo.Clients", "AssignedWorker_Id", "dbo.AssignedWorkers");
            DropForeignKey("dbo.Clients", "Age_Id", "dbo.Ages");
            DropForeignKey("dbo.Clients", "AbuserRelationship_Id", "dbo.AbuserRelationships");
            DropIndex("dbo.SmartEntities", new[] { "VictimServesAttendance_Id" });
            DropIndex("dbo.SmartEntities", new[] { "ThirdPartyReport_Id" });
            DropIndex("dbo.SmartEntities", new[] { "SocialWorkAttendance_Id" });
            DropIndex("dbo.SmartEntities", new[] { "SexWorkExploitation_Id" });
            DropIndex("dbo.SmartEntities", new[] { "ReferringHospital_Id" });
            DropIndex("dbo.SmartEntities", new[] { "ReferredToCBVS_Id" });
            DropIndex("dbo.SmartEntities", new[] { "PoliceReported_Id" });
            DropIndex("dbo.SmartEntities", new[] { "PoliceAttendance_Id" });
            DropIndex("dbo.SmartEntities", new[] { "MultiplePerpetrators_Id" });
            DropIndex("dbo.SmartEntities", new[] { "MedicalOnly_Id" });
            DropIndex("dbo.SmartEntities", new[] { "HospitalAttended_Id" });
            DropIndex("dbo.SmartEntities", new[] { "HIVMeds_Id" });
            DropIndex("dbo.SmartEntities", new[] { "EvidenceStored_Id" });
            DropIndex("dbo.SmartEntities", new[] { "DrugFacilitatedAssault_Id" });
            DropIndex("dbo.SmartEntities", new[] { "Client_Id" });
            DropIndex("dbo.SmartEntities", new[] { "CityOfResidence_Id" });
            DropIndex("dbo.SmartEntities", new[] { "CityOfAssault_Id" });
            DropIndex("dbo.SmartEntities", new[] { "BadDateReport_Id" });
            DropIndex("dbo.Clients", new[] { "VictimofIncident_Id" });
            DropIndex("dbo.Clients", new[] { "StatusofFile_Id" });
            DropIndex("dbo.Clients", new[] { "Service_Id" });
            DropIndex("dbo.Clients", new[] { "RiskStatus_Id" });
            DropIndex("dbo.Clients", new[] { "RiskLevel_Id" });
            DropIndex("dbo.Clients", new[] { "RepeatClient_Id" });
            DropIndex("dbo.Clients", new[] { "ReferralSource_Id" });
            DropIndex("dbo.Clients", new[] { "ReferralContact_Id" });
            DropIndex("dbo.Clients", new[] { "Program_Id" });
            DropIndex("dbo.Clients", new[] { "incident_Id" });
            DropIndex("dbo.Clients", new[] { "fisYear_Id" });
            DropIndex("dbo.Clients", new[] { "FamilyViolenceFile_Id" });
            DropIndex("dbo.Clients", new[] { "Ethnicity_Id" });
            DropIndex("dbo.Clients", new[] { "DuplicateFile_Id" });
            DropIndex("dbo.Clients", new[] { "Crisis_Id" });
            DropIndex("dbo.Clients", new[] { "AssignedWorker_Id" });
            DropIndex("dbo.Clients", new[] { "Age_Id" });
            DropIndex("dbo.Clients", new[] { "AbuserRelationship_Id" });
            DropTable("dbo.VictimServicesAttendances");
            DropTable("dbo.ThirdPartyReports");
            DropTable("dbo.SocialWorkAttendances");
            DropTable("dbo.DrugfacilitatedAssaults");
            DropTable("dbo.SmartEntities");
            DropTable("dbo.SexWorkExploitations");
            DropTable("dbo.ReferringHospitals");
            DropTable("dbo.ReferredtoCBVS");
            DropTable("dbo.PoliceReporteds");
            DropTable("dbo.PoliceAttendances");
            DropTable("dbo.MultiplePerpetrators");
            DropTable("dbo.MedicalOnlies");
            DropTable("dbo.HospitalAttendeds");
            DropTable("dbo.HIVMeds");
            DropTable("dbo.EvidenceStoreds");
            DropTable("dbo.VictimofIncidents");
            DropTable("dbo.StatusofFiles");
            DropTable("dbo.Services");
            DropTable("dbo.RiskStatus");
            DropTable("dbo.RiskLevels");
            DropTable("dbo.RepeatClients");
            DropTable("dbo.ReferralSources");
            DropTable("dbo.ReferralContacts");
            DropTable("dbo.Programs");
            DropTable("dbo.Incidents");
            DropTable("dbo.FiscalYears");
            DropTable("dbo.FamilyViolenceFiles");
            DropTable("dbo.Ethnicities");
            DropTable("dbo.DuplicateFiles");
            DropTable("dbo.Crises");
            DropTable("dbo.Clients");
            DropTable("dbo.CityofResidences");
            DropTable("dbo.CityofAssaults");
            DropTable("dbo.BadDateReports");
            DropTable("dbo.AssignedWorkers");
            DropTable("dbo.Ages");
            DropTable("dbo.AbuserRelationships");
        }
    }
}
