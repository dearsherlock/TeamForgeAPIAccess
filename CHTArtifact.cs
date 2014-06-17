using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFClient
{
    class CHTArtifact
    {
          //sb.Append("\"Artifact ID\",\"Title\",\"Description\",\"Submitted By\",\"Submitted On\",\"Last Modified\",\"Closed\"
        //,\"Status\",\"Category\",\"Priority\",\"Assigned To\",\"Reported in Release\",\"Fixed in Release\",\"Estimated Effort\",\
        //"Actual Effort\",\"Planned For\",\"Review Peer\",\"Verifier\",\"Precausation\",\"Injection Cause\",\"Resolved&Unit Test Detail\",
        //\"Injection Phase\",\"Review Finish Day\",\"Module\",\"Expect Finish Date\",\"Injection Version\",\"Defect Env\",
        //\"Analyze Finish Date\",\"Severity\",\"Verify Finish Day\",\"Rejection Reason\",\"Req ID\",\"Owner\",\"Owner  Finish Date\",
        //\"Inject By\",\"Defect Process Note\",\"Defect Type\",\"Discover Phase\",\"Responsible Party\",\"Monitoring Status\",
        //\"Dependency Parent\",\"Dependency Children\",\"Item Link\"");
        [PropOrder(SeqNo=0)]
        public string ArtifactID { get; set; }
        [PropOrder(SeqNo = 1)]
        public string Title { get; set; }
        [PropOrder(SeqNo =2)]
        public string Description { get; set; }
        [PropOrder(SeqNo = 3)]
        public string SubmittedBy { get; set; }
        [PropOrder(SeqNo = 4)]
        public DateTime SubmittedDate { get; set; }
        [PropOrder(SeqNo = 5)]
        public DateTime LastModifiedDate { get; set; }
        [PropOrder(SeqNo =6)]
        public DateTime? CloseDate { get; set; }
        //,\"Status\",\"Category\",\"Priority\",\"Assigned To\",\"Reported in Release\",\"Fixed in Release\",\"Estimated Effort\",\
        //"Actual Effort\",\"Planned For\",\"Review Peer\",\"Verifier\",\"Precausation\",\"Injection Cause\",\"Resolved&Unit Test Detail\",
        //\"Injection Phase\",\"Review Finish Day\",\"Module\",\"Expect Finish Date\",\"Injection Version\",\"Defect Env\",
        //\"Analyze Finish Date\",\"Severity\",\"Verify Finish Day\",\"Rejection Reason\",\"Req ID\",\"Owner\",\"Owner  Finish Date\",
        //\"Inject By\",\"Defect Process Note\",\"Defect Type\",\"Discover Phase\",\"Responsible Party\",\"Monitoring Status\",
        //\"Dependency Parent\",\"Dependency Children\",\"Item Link\"");
        [PropOrder(SeqNo = 7)]
        public string Status { get; set; }
        [PropOrder(SeqNo = 8)]
        public string Category { get; set; }
        [PropOrder(SeqNo = 9)]
        public int Priority { get; set; }
        [PropOrder(SeqNo = 10)]
        public string AssignedTo { get; set; }
        [PropOrder(SeqNo = 11)]
        public string ReportedinRelease { get; set; }
        [PropOrder(SeqNo = 12)]
        public string FixedinRelease { get; set; }
        [PropOrder(SeqNo = 13)]
        public int EstimatedEffort { get; set; }
        //\"Injection Phase\",\"Review Finish Day\",\"Module\",\"Expect Finish Date\",\"Injection Version\",\"Defect Env\",
        //\"Analyze Finish Date\",\"Severity\",\"Verify Finish Day\",\"Rejection Reason\",\"Req ID\",\"Owner\",\"Owner  Finish Date\",
        //\"Inject By\",\"Defect Process Note\",\"Defect Type\",\"Discover Phase\",\"Responsible Party\",\"Monitoring Status\",
        //\"Dependency Parent\",\"Dependency Children\",\"Item Link\"");
        [PropOrder(SeqNo = 14)]
        public int ActualEffort { get; set; }
        [PropOrder(SeqNo = 15)]
        public string PlannedFor { get; set; }
        [PropOrder(SeqNo = 16)]
        public string ReviewPeer { get; set; }
        [PropOrder(SeqNo = 17)]
        public string Verifier { get; set; }
        [PropOrder(SeqNo = 18)]
        public string Precausation { get; set; }
        [PropOrder(SeqNo = 19)]
        public string InjectionCause { get; set; }
        [PropOrder(SeqNo = 20)]
        public string ResolvedUnitTestDetail { get; set; }

        //\"Injection Phase\",\"Review Finish Day\",\"Module\",\"Expect Finish Date\",\"Injection Version\",\"Defect Env\",
       

        [PropOrder(SeqNo = 21)]

        public string InjectionPhase { get; set; }
        [PropOrder(SeqNo = 22)]
        public string ReviewFinishDay { get; set; }
        [PropOrder(SeqNo = 23)]
        public string Module { get; set; }
        [PropOrder(SeqNo = 24)]
        public string ExpectFinishDate { get; set; }
        [PropOrder(SeqNo = 25)]
        public string InjectionVersion { get; set; }
        [PropOrder(SeqNo = 26)]
        public string DefectEnv { get; set; }
        //\"Analyze Finish Date\",\"Severity\",\"Verify Finish Day\",\"Rejection Reason\",\"Req ID\",\"Owner\",\"Owner  Finish Date\",
       

        [PropOrder(SeqNo = 27)]

        public string AnalyzeFinishDate { get; set; }
        [PropOrder(SeqNo = 28)]
        public string Severity { get; set; }
        [PropOrder(SeqNo = 29)]
        public string VerifyFinishDay { get; set; }
        [PropOrder(SeqNo = 30)]
        public string RejectionReason { get; set; }
        [PropOrder(SeqNo = 31)]
        public string ReqID { get; set; }
        [PropOrder(SeqNo = 32)]
        public string Owner { get; set; }
        [PropOrder(SeqNo = 33)]
        public string OwnerFinishDate { get; set; }
        //\"Inject By\",\"Defect Process Note\",\"Defect Type\",\"Discover Phase\",\"Responsible Party\",\"Monitoring Status\",
        //\"Dependency Parent\",\"Dependency Children\",\"Item Link\"");


        [PropOrder(SeqNo = 34)]

        public string InjectBy { get; set; }
        [PropOrder(SeqNo = 35)]
        public string DefectProcessNote { get; set; }
        [PropOrder(SeqNo = 36)]
        public string DefectType { get; set; }
        [PropOrder(SeqNo = 37)]
        public string DiscoverPhase { get; set; }
        [PropOrder(SeqNo = 38)]
        public string ResponsibleParty { get; set; }
        [PropOrder(SeqNo = 39)]
        public string MonitoringStatus { get; set; }
        [PropOrder(SeqNo = 40)]
        public string DependencyParent { get; set; }
        [PropOrder(SeqNo = 41)]
        public string DependencyChildren { get; set; }

        [PropOrder(SeqNo = 42)]
        public string ItemLink { get; set; }




    }
    public class PropOrderAttribute : Attribute {
        public int SeqNo { get; set; }
    
    }
}
