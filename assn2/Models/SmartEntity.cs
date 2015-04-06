using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assn2.Models
{
    public class SmartEntity
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public SexWorkExploitation SexWorkExploitation { get; set; }
        public MultiplePerpetrators MultiplePerpetrators { get; set; }
        public DrugfacilitatedAssault DrugFacilitatedAssault { get; set; }
        public CityofAssault CityOfAssault { get; set; }
        public CityofResidence CityOfResidence { get; set; }
        public int AccompanimentMinutes { get; set; }
        public ReferringHospital ReferringHospital { get; set; }
        public HospitalAttended HospitalAttended { get; set; }
        public SocialWorkAttendance SocialWorkAttendance { get; set; }
        public PoliceAttendance PoliceAttendance { get; set; }
        public VictimServicesAttendance VictimServesAttendance { get; set; }
        public MedicalOnly MedicalOnly { get; set; }
        public EvidenceStored EvidenceStored { get; set; }
        public HIVMeds HIVMeds { get; set; }
        public ReferredtoCBVS ReferredToCBVS { get; set; }
        public PoliceReported PoliceReported { get; set; }
        public ThirdPartyReport ThirdPartyReport { get; set; }
        public BadDateReport BadDateReport { get; set; }
        public int NumberTransportsProvided { get; set; }
        public bool ReferredToNurse { get; set; }
    }
}