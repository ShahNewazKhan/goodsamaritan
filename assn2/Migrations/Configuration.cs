namespace assn2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using assn2.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<assn2.DAL.GSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(assn2.DAL.GSContext context)
        {
            var fiscalyears = getFiscalYears();
            var risklevels = getRiskLevels();
            var crisis = getCrisis();
            var programs = getPrograms();
            var riskstatus = getRiskStatus();
            var assignedworker = getAssignedWorker();
            var referralsource = getReferralSource();
            var referralcontact = getReferralContact();
            var incident = getIncident();
            var abuserrelationship = getAbuserRelationship();
            var victimofincident = getVictimofIncident();
            var familyviolencefile = getFamilyViolenceFile();
            var ethnicity = getEthnicity();
            var age = getAge();
            var repeatclient = getRepeatClient();
            var duplicatefile = getDuplicateFile();
            var statusoffile = getStatusofFile();
            var sexworkexploitation = getSexWorkExploitation();
            var multipleperpetrators = getMultiplePerpetrators();
            var drugfacilitatedassault = getDrugfacilitatedAssault();
            var cityofassault = getCityofAssault();
            var cityofresidence = getCityofResidence();
            var referringhospital = getReferringHospital();
            var hospitalattended = getHospitalAttended();
            var socialworkattendance = getSocialWorkAttendance();
            var policeattendance = getPoliceAttendance();
            var victimservicesattendance = getVictimServicesAttendance();
            var medicalonly = getMedicalOnly();
            var evidencestored = getEvidenceStored();
            var hivmeds = getHIVMeds();
            var referredtocbvs = getReferredtoCBVS();
            var policereported = getPoliceReported();
            var thirdpartyreport = getThirdPartyReport();
            var baddatereport = getBadDateReport();
            var service = getService();


            fiscalyears.ForEach(f => context.FiscalYear.AddOrUpdate(p => p.Id, f));
            risklevels.ForEach(f => context.RiskLevel.AddOrUpdate(p => p.Id, f));
            crisis.ForEach(f => context.Crisis.AddOrUpdate(p => p.Id, f));
            programs.ForEach(f => context.Program.AddOrUpdate(p => p.Id, f));
            riskstatus.ForEach(f => context.RiskStatus.AddOrUpdate(p => p.Id, f));
            assignedworker.ForEach(f => context.AssignedWorker.AddOrUpdate(p => p.Id, f));
            referralsource.ForEach(f => context.ReferralSource.AddOrUpdate(p => p.Id, f));
            referralcontact.ForEach(f => context.ReferralContact.AddOrUpdate(p => p.Id, f));
            incident.ForEach(f => context.Incident.AddOrUpdate(p => p.Id, f));
            abuserrelationship.ForEach(f => context.AbuserRelationship.AddOrUpdate(p => p.Id, f));
            victimofincident.ForEach(f => context.IncidentVictim.AddOrUpdate(p => p.Id, f));
            familyviolencefile.ForEach(f => context.FamilyViolenceFile.AddOrUpdate(p => p.Id, f));
            ethnicity.ForEach(f => context.Ethnicity.AddOrUpdate(p => p.Id, f));
            age.ForEach(f => context.Age.AddOrUpdate(p => p.Id, f));
            repeatclient.ForEach(f => context.RepeatClient.AddOrUpdate(p => p.Id, f));
            duplicatefile.ForEach(f => context.DuplicateFile.AddOrUpdate(p => p.Id, f));
            statusoffile.ForEach(f => context.StatusOfFile.AddOrUpdate(p => p.Id, f));
            sexworkexploitation.ForEach(f => context.SexWorkExploitation.AddOrUpdate(p => p.Id, f));
            multipleperpetrators.ForEach(f => context.MultiplePerpetrators.AddOrUpdate(p => p.Id, f));
            drugfacilitatedassault.ForEach(f => context.DrugfacilitatedAssault.AddOrUpdate(p => p.Id, f));
            cityofassault.ForEach(f => context.CityOfAssault.AddOrUpdate(p => p.Id, f));
            cityofresidence.ForEach(f => context.CityOfResidence.AddOrUpdate(p => p.Id, f));
            referringhospital.ForEach(f => context.ReferringHospital.AddOrUpdate(p => p.Id, f));
            hospitalattended.ForEach(f => context.HospitalAttended.AddOrUpdate(p => p.Id, f));
            socialworkattendance.ForEach(f => context.SocialWorkAttendance.AddOrUpdate(p => p.Id, f));
            policeattendance.ForEach(f => context.PoliceAttendance.AddOrUpdate(p => p.Id, f));
            victimservicesattendance.ForEach(f => context.VictimServicesAttendance.AddOrUpdate(p => p.Id, f));
            medicalonly.ForEach(f => context.MedicalOnly.AddOrUpdate(p => p.Id, f));
            evidencestored.ForEach(f => context.EvidenceStored.AddOrUpdate(p => p.Id, f));
            hivmeds.ForEach(f => context.HIVMeds.AddOrUpdate(p => p.Id, f));
            referredtocbvs.ForEach(f => context.ReferredtoCBVS.AddOrUpdate(p => p.Id, f));
            policereported.ForEach(f => context.PoliceReported.AddOrUpdate(p => p.Id, f));
            thirdpartyreport.ForEach(f => context.ThirdPartyReport.AddOrUpdate(p => p.Id, f));
            baddatereport.ForEach(f => context.BadDateReport.AddOrUpdate(p => p.Id, f));
            service.ForEach(f => context.Service.AddOrUpdate(p => p.Id, f) );

            context.SaveChanges();
        }

        private List<FiscalYear> getFiscalYears()
        {
            var res = new List<FiscalYear>
            {
                new FiscalYear { Value="10-11" },
                new FiscalYear { Value="11-12" },
                new FiscalYear { Value="12-13" },
                new FiscalYear { Value="13-14" },
                new FiscalYear { Value="14-15" },
                new FiscalYear { Value="15-16" },
                new FiscalYear { Value="16-17" }
            };

            return res;
        }

        private List<RiskLevel> getRiskLevels()
        {
            var res = new List<RiskLevel> 
            {
                new RiskLevel { Value="High" },
                new RiskLevel { Value="DVU" },
                new RiskLevel { Value="NULL" }
            };

            return res;
        }

        private List<Crisis> getCrisis()
        {
            var res = new List<Crisis>
            {
                new Crisis { Value="Call" },
                new Crisis { Value="Accompaniment" },
                new Crisis { Value="Drop-In" }
            };

            return res;
        }

        private List<Service> getService()
        {
            var res = new List<Service>
            {
                new Service { Value="File" },
                new Service { Value="N/A" }
            };

            return res;
        }

        private List<Program> getPrograms()
        {
            var res = new List<Program>
            {
                new Program { Value="Crisis" },
                new Program { Value="Court" },
                new Program { Value="SMART" },
                new Program { Value="DVU" },
                new Program { Value="MCFD" }
            };

            return res;
        }

        private List<RiskStatus> getRiskStatus()
        {
            var res = new List<RiskStatus>
            {
                new RiskStatus { Value="Pending" },
                new RiskStatus { Value="Complete" },
                new RiskStatus { Value="NULL" }
            };

            return res;
        }

        private List<AssignedWorker> getAssignedWorker()
        {
            var res = new List<AssignedWorker>
            {
                new AssignedWorker { Value="Michelle" },
                new AssignedWorker { Value="Tyra" },
                new AssignedWorker { Value="Louise" },
                new AssignedWorker { Value="Angela" },
                new AssignedWorker { Value="Dave" },
                new AssignedWorker { Value="Troy" },
                new AssignedWorker { Value="Michael" },
                new AssignedWorker { Value="Manpreet" },
                new AssignedWorker { Value="Patrick" },
                new AssignedWorker { Value="None" }
            };

            return res;
        }

        private List<ReferralSource> getReferralSource()
        {
            var res = new List<ReferralSource>
            {
                new ReferralSource { Value="Community Agency" },
                new ReferralSource { Value="Family/Friend" },
                new ReferralSource { Value="Government" },
                new ReferralSource { Value="CVAP" },
                new ReferralSource { Value="CBVS" }
            };

            return res;
        }

        private List<ReferralContact> getReferralContact()
        {
            var res = new List<ReferralContact>
            {
                new ReferralContact { Value="PBVS" },
                new ReferralContact { Value="MCFD" },
                new ReferralContact { Value="VictimLINK" },
                new ReferralContact { Value="TH" },
                new ReferralContact { Value="Self" },
                new ReferralContact { Value="FNS" },
                new ReferralContact { Value="Other" },
                new ReferralContact { Value="Medical" }
            };

            return res;
        }

        private List<Incident> getIncident()
        {
            var res = new List<Incident>
	        {
		        new Incident { Value="Abduction" },
		        new Incident { Value="AdultHistoricalSexualAssault" },
		        new Incident { Value="AdultSexualAssault" },
		        new Incident { Value="PartnerAssault" },
		        new Incident { Value="AttemptedMurder" },
		        new Incident { Value="ChildPhysicalAssault" },
		        new Incident { Value="ChildSexualAbuseExploitation" },
		        new Incident { Value="CriminalHarassmentStalking" },
		        new Incident { Value="ElderAbuse" },
		        new Incident { Value="HumanTrafficking" },
		        new Incident { Value="Murder" },
		        new Incident { Value="NA" },
		        new Incident { Value="Other" },
		        new Incident { Value="OtherAssault" },
		        new Incident { Value="OtherCrime–DV" },
		        new Incident { Value="OtherFamilialAssault" },
		        new Incident { Value="Threatening" },
		        new Incident { Value="YouthSexualAssaultExploitation" }
	        };

            return res;
        }

        private List<AbuserRelationship> getAbuserRelationship()
        {
            var res = new List<AbuserRelationship>
	        {
		        new AbuserRelationship { Value="Acquaintance" },
		        new AbuserRelationship { Value="BadDate" },
		        new AbuserRelationship { Value="DNA" },
		        new AbuserRelationship { Value="Ex-Partner" },
		        new AbuserRelationship { Value="Friend" },
		        new AbuserRelationship { Value="MultiplePerps" },
		        new AbuserRelationship { Value="NA" },
		        new AbuserRelationship { Value="Other" },
		        new AbuserRelationship { Value="OtherFamilial" },
		        new AbuserRelationship { Value="Parent" },
		        new AbuserRelationship { Value="Partner" },
		        new AbuserRelationship { Value="Sibling" },
		        new AbuserRelationship { Value="Stranger" }
	        };

            return res;
        }

        private List<VictimofIncident> getVictimofIncident()
        {
            var res = new List<VictimofIncident>
	        {
		        new VictimofIncident { Value="Primary" },
		        new VictimofIncident { Value="Secondary" }
	        };

            return res;
        }

        private List<FamilyViolenceFile> getFamilyViolenceFile()
        {
            var res = new List<FamilyViolenceFile>
	        {
		        new FamilyViolenceFile { Value="Yes" },
		        new FamilyViolenceFile { Value="No" },
		        new FamilyViolenceFile { Value="NA" }
	        };

            return res;
        }

        private List<Ethnicity> getEthnicity()
        {
            var res = new List<Ethnicity>
	        {
		        new Ethnicity { Value="Indigenous" },
		        new Ethnicity { Value="Asian" },
		        new Ethnicity { Value="Black" },
		        new Ethnicity { Value="Caucasian" },
		        new Ethnicity { Value="Declined" },
		        new Ethnicity { Value="Latin" },
		        new Ethnicity { Value="MiddleEastern" },
		        new Ethnicity { Value="Other" },
		        new Ethnicity { Value="SouthAsian" },
		        new Ethnicity { Value="SouthEastAsian" }
	        };

            return res;
        }

        private List<Age> getAge()
        {
            var res = new List<Age>
	        {
		        new Age { Value="Adult>24<65" },
		        new Age { Value="Youth>12<19" },
		        new Age { Value="Youth>18<25" },
		        new Age { Value="Child<13" },
		        new Age { Value="Senior>64" }
	        };

            return res;
        }

        private List<RepeatClient> getRepeatClient()
        {
            var res = new List<RepeatClient>
	        {
		        new RepeatClient { Value="Yes" },
		        new RepeatClient { Value="null" }
	        };

            return res;
        }

        private List<DuplicateFile> getDuplicateFile()
        {
            var res = new List<DuplicateFile>
	        {
		        new DuplicateFile { Value="Yes" },
		        new DuplicateFile { Value="null" }
	        };

            return res;
        }

        private List<StatusofFile> getStatusofFile()
        {
            var res = new List<StatusofFile>
	        {
		        new StatusofFile { Value="Reopened" },
		        new StatusofFile { Value="Closed" },
		        new StatusofFile { Value="Open" }
	        };

            return res;
        }

        private List<SexWorkExploitation> getSexWorkExploitation()
        {
            var res = new List<SexWorkExploitation>
	        {
		        new SexWorkExploitation { Value="Yes" },
		        new SexWorkExploitation { Value="No" },
		        new SexWorkExploitation { Value="NA" }
	        };

            return res;
        }

        private List<MultiplePerpetrators> getMultiplePerpetrators()
        {
            var res = new List<MultiplePerpetrators>
	        {
		        new MultiplePerpetrators { Value="Yes" },
		        new MultiplePerpetrators { Value="No" },
		        new MultiplePerpetrators { Value="NA" }
	        };

            return res;
        }

        private List<DrugfacilitatedAssault> getDrugfacilitatedAssault()
        {
            var res = new List<DrugfacilitatedAssault>
	        {
		        new DrugfacilitatedAssault { Value="Yes" },
		        new DrugfacilitatedAssault { Value="No" },
		        new DrugfacilitatedAssault { Value="NA" }
	        };

            return res;
        }

        private List<CityofAssault> getCityofAssault()
        {
            var res = new List<CityofAssault>
	        {
		        new CityofAssault { Value="Surrey" },
		        new CityofAssault { Value="Abbotsford" },
		        new CityofAssault { Value="Agassiz" },
		        new CityofAssault { Value="BostonBar" },
		        new CityofAssault { Value="Burnaby" },
		        new CityofAssault { Value="Chilliwack" },
		        new CityofAssault { Value="Coquitlam" },
		        new CityofAssault { Value="Delta" },
		        new CityofAssault { Value="HarrisonHotSprings" },
		        new CityofAssault { Value="Hope" },
		        new CityofAssault { Value="Langley" },
		        new CityofAssault { Value="MapleRidge" },
		        new CityofAssault { Value="Mission" },
		        new CityofAssault { Value="NewWestminster" },
		        new CityofAssault { Value="PittMeadows" },
		        new CityofAssault { Value="PortCoquitlam" },
		        new CityofAssault { Value="PortMoody" },
		        new CityofAssault { Value="Vancouver" },
		        new CityofAssault { Value="WhiteRock" },
		        new CityofAssault { Value="Yale" },
		        new CityofAssault { Value="Other–BC" },
		        new CityofAssault { Value="Out-of-Province" },
		        new CityofAssault { Value="International" }
	        };

            return res;
        }

        private List<CityofResidence> getCityofResidence()
        {
            var res = new List<CityofResidence>
	        {
		        new CityofResidence { Value="Surrey" },
		        new CityofResidence { Value="Abbotsford" },
		        new CityofResidence { Value="Agassiz" },
		        new CityofResidence { Value="BostonBar" },
		        new CityofResidence { Value="Burnaby" },
		        new CityofResidence { Value="Chilliwack" },
		        new CityofResidence { Value="Coquitlam" },
		        new CityofResidence { Value="Delta" },
		        new CityofResidence { Value="HarrisonHotSprings" },
		        new CityofResidence { Value="Hope" },
		        new CityofResidence { Value="Langley" },
		        new CityofResidence { Value="MapleRidge" },
		        new CityofResidence { Value="Mission" },
		        new CityofResidence { Value="NewWestminster" },
		        new CityofResidence { Value="PittMeadows" },
		        new CityofResidence { Value="PortCoquitlam" },
		        new CityofResidence { Value="PortMoody" },
		        new CityofResidence { Value="Vancouver" },
		        new CityofResidence { Value="WhiteRock" },
		        new CityofResidence { Value="Yale" },
		        new CityofResidence { Value="Other–BC" },
		        new CityofResidence { Value="Out-of-Province" },
		        new CityofResidence { Value="International" }
	        };

            return res;
        }

        private List<ReferringHospital> getReferringHospital()
        {
            var res = new List<ReferringHospital>
	        {
		        new ReferringHospital { Value="AbbotsfordRegionalHospital" },
		        new ReferringHospital { Value="SurreyMemorialHospital" },
		        new ReferringHospital { Value="BurnabyHospital" },
		        new ReferringHospital { Value="ChilliwackGeneralHospital" },
		        new ReferringHospital { Value="DeltaHospital" },
		        new ReferringHospital { Value="EagleRidgeHospital" },
		        new ReferringHospital { Value="FraserCanyonHospital" },
		        new ReferringHospital { Value="LangleyHospital" },
		        new ReferringHospital { Value="MissionHospital" },
		        new ReferringHospital { Value="PeaceArchHospital" },
		        new ReferringHospital { Value="RidgeMeadowsHospital" },
		        new ReferringHospital { Value="RoyalColumbiaHospital" }
	        };

            return res;
        }

        private List<HospitalAttended> getHospitalAttended()
        {
            var res = new List<HospitalAttended>
	        {
		        new HospitalAttended { Value="AbbotsfordRegionalHospital" },
		        new HospitalAttended { Value="SurreyMemorialHospital" },
		        new HospitalAttended { Value="BurnabyHospital" },
		        new HospitalAttended { Value="ChilliwackGeneralHospital" },
		        new HospitalAttended { Value="DeltaHospital" },
		        new HospitalAttended { Value="EagleRidgeHospital" },
		        new HospitalAttended { Value="FraserCanyonHospital" },
		        new HospitalAttended { Value="LangleyHospital" },
		        new HospitalAttended { Value="MissionHospital" },
		        new HospitalAttended { Value="PeaceArchHospital" },
		        new HospitalAttended { Value="RidgeMeadowsHospital" },
		        new HospitalAttended { Value="RoyalColumbiaHospital" }
	        };

            return res;
        }

        private List<SocialWorkAttendance> getSocialWorkAttendance()
        {
            var res = new List<SocialWorkAttendance>
	        {
		        new SocialWorkAttendance { Value="Yes" },
		        new SocialWorkAttendance { Value="No" },
		        new SocialWorkAttendance { Value="NA" }
	        };

            return res;
        }

        private List<PoliceAttendance> getPoliceAttendance()
        {
            var res = new List<PoliceAttendance>
	        {
		        new PoliceAttendance { Value="Yes" },
		        new PoliceAttendance { Value="No" },
		        new PoliceAttendance { Value="NA" }
	        };

            return res;
        }

        private List<VictimServicesAttendance> getVictimServicesAttendance()
        {
            var res = new List<VictimServicesAttendance>
	        {
		        new VictimServicesAttendance { Value="Yes" },
		        new VictimServicesAttendance { Value="No" },
		        new VictimServicesAttendance { Value="NA" }
	        };

            return res;
        }

        private List<MedicalOnly> getMedicalOnly()
        {
            var res = new List<MedicalOnly>
	        {
		        new MedicalOnly { Value="Yes" },
		        new MedicalOnly { Value="No" },
		        new MedicalOnly { Value="NA" }
	        };

            return res;
        }

        private List<EvidenceStored> getEvidenceStored()
        {
            var res = new List<EvidenceStored>
	        {
		        new EvidenceStored { Value="Yes" },
		        new EvidenceStored { Value="No" },
		        new EvidenceStored { Value="NA" }
	        };

            return res;
        }

        private List<HIVMeds> getHIVMeds()
        {
            var res = new List<HIVMeds>
	        {
		        new HIVMeds { Value="Yes" },
		        new HIVMeds { Value="No" },
		        new HIVMeds { Value="NA" }
	        };

            return res;
        }

        private List<ReferredtoCBVS> getReferredtoCBVS()
        {
            var res = new List<ReferredtoCBVS>
	        {
		        new ReferredtoCBVS { Value="Yes" },
		        new ReferredtoCBVS { Value="No" },
		        new ReferredtoCBVS { Value="PVBSOnly" },
		        new ReferredtoCBVS { Value="NA" }
	        };

            return res;
        }

        private List<PoliceReported> getPoliceReported()
        {
            var res = new List<PoliceReported>
	        {
		        new PoliceReported { Value="Yes" },
		        new PoliceReported { Value="No" },
		        new PoliceReported { Value="NA" }
	        };

            return res;
        }

        private List<ThirdPartyReport> getThirdPartyReport()
        {
            var res = new List<ThirdPartyReport>
	        {
		        new ThirdPartyReport { Value="Yes" },
		        new ThirdPartyReport { Value="No" },
		        new ThirdPartyReport { Value="NA" }
	        };

            return res;
        }

        private List<BadDateReport> getBadDateReport()
        {
            var res = new List<BadDateReport>
	        {
		        new BadDateReport { Value="Yes" },
		        new BadDateReport { Value="No" },
		        new BadDateReport { Value="NA" }
	        };

            return res;
        }
    }
}
