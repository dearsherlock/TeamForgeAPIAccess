using CollabNet.TeamForge.Library;
using CollabNet.TeamForge.Library.Model;
using CollabNet.TeamForge.Library.Model.MainSvc;
using CollabNet.TeamForge.Library.Model.TrackerSvc;
using CollabNet.TeamForge.Library.soap60.TrackerApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TFClient
{
    class TeamForgeTrackerReport
    {
        public void DumpFile()
        {
            //https://alm.ebaotech.com/sf/sfmain/do/exportItems/projects.msig/tracker.defect
            TeamForgeSiteDataModel model = new TeamForgeSiteDataModel();
            RetriveTeamForgeWebContent.UpdateTeamForgeModelSessionId(ref model);

        }
        public void Login()
        {
          ctxHome= new Context();

          ctxHome.ContextName = "myserverName"; // a unique name to identify TeamForge server
          ctxHome.ServerHost = "alm.ebaotech.com"; // host part of the server URL
          ctxHome.UseSSL = true;
          ctxHome.UserName = "xxxx";
          ctxHome.Password = "xxxx";
          ICollabNetSvc collabnet = TeamForgeServiceFactory.CreateServiceClient<ICollabNetSvc>(ctxHome);
            string clientIdentifier = "My TeamForge Client";
            collabnet.Login(clientIdentifier);
            string id = collabnet.CurrentContext.SessionKey;
            
        }
        private void DumpCSVFile(string projNo,string trackerId,IArtifactDetailListCollection artifactDetails)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("\"Artifact ID\",\"Title\",\"Description\",\"Submitted By\",\"Submitted On\",\"Last Modified\",\"Closed\",\"Status\",\"Category\",\"Priority\",\"Assigned To\",\"Reported in Release\",\"Fixed in Release\",\"Estimated Effort\",\"Actual Effort\",\"Planned For\",\"Review Peer\",\"Verifier\",\"Precausation\",\"Injection Cause\",\"Resolved&Unit Test Detail\",\"Injection Phase\",\"Review Finish Day\",\"Module\",\"Expect Finish Date\",\"Injection Version\",\"Defect Env\",\"Analyze Finish Date\",\"Severity\",\"Verify Finish Day\",\"Rejection Reason\",\"Req ID\",\"Owner\",\"Owner  Finish Date\",\"Inject By\",\"Defect Process Note\",\"Defect Type\",\"Discover Phase\",\"Responsible Party\",\"Monitoring Status\",\"Dependency Parent\",\"Dependency Children\",\"Item Link\"");
            sb.Append("\r\n");
           // sb.AppendLine();
            List<CHTArtifact> chtArtifacts = MappingDataModel(artifactDetails);
            Type type = typeof(CHTArtifact);
            PropertyInfo[] properties = type.GetProperties();
            //   DumpCSVFile(chtArtifacts);

            foreach (CHTArtifact chtArtifact in chtArtifacts)
            {
                foreach (PropertyInfo prp in properties)
                {
                    if (prp.CanRead)
                    {
                        sb.Append("\"").Append(processStringSpecially(prp.GetValue(chtArtifact, null) )
                          ).Append("\"").Append(',');
                    }
                }
                sb.Length--; // Remove last ";"
                sb.Append("\r\n");
            }
            //proj1023-tracker1063-20140610-0953.csv
            //Response.Write(String.Format("{0:00000}", 123)); // 輸出 00123
            File.AppendAllText(@"W:\Download\" + projNo + "-" + trackerId+"-" + DateTime.Now.Year +
                String.Format("{0:00}", DateTime.Now.Month)+ String.Format("{0:00}", DateTime.Now.Day)+"-"+
                 String.Format("{0:00}", DateTime.Now.Hour)+ String.Format("{0:00}", DateTime.Now.Minute)+".csv",sb.ToString());
              
        }

        private string processStringSpecially(object data) 
        {
            if(data==null){
                return "";
            }
            return data.ToString().Replace("\n", "\r\n").Replace("\"","\"\"");
        }

        private List<CHTArtifact> MappingDataModel(IArtifactDetailListCollection artifactDetails)
        {
            collabnetService = TeamForgeServiceFactory.CreateServiceClient<ICollabNetSvc>(ctxHome);
            List<CHTArtifact> artifactResults = new List<CHTArtifact>();
            foreach (var artifactDetail in artifactDetails)
            {
                artifactResults.Add(new CHTArtifact
                {
                    ArtifactID = artifactDetail.Id,
                    CloseDate = artifactDetail.CloseDate,
                    Description = artifactDetail.Description,
                    LastModifiedDate = artifactDetail.LastModifiedDate,
                    SubmittedBy = artifactDetail.SubmittedByFullname,
                    SubmittedDate = artifactDetail.SubmittedDate,
                    Title = artifactDetail.Title,
                    AssignedTo = artifactDetail.AssignedToFullName,
                    Category = artifactDetail.Category,
                    EstimatedEffort = artifactDetail.EstimatedEffort,
                    FixedinRelease = artifactDetail.ResolvedInReleaseTitle,
                    Priority = artifactDetail.Priority,
                    ReportedinRelease = artifactDetail.ReportedInReleaseTitle,
                    Status = artifactDetail.Status,
                    ActualEffort = artifactDetail.ActualEffort,
                    PlannedFor = artifactDetail.PlanningFolderTitle,
                    Precausation = artifactDetail.FlexFields["Precausation"].ToString(),
                    Module = artifactDetail.FlexFields["Module"].ToString(),
                    AnalyzeFinishDate = artifactDetail.FlexFields["Analyze Finish Date"].ToString(),
                    DefectEnv = artifactDetail.FlexFields["Defect Env"].ToString(),
                    DefectProcessNote = artifactDetail.FlexFields["Defect Process Note"].ToString(),
                    DefectType = artifactDetail.FlexFields["Defect Type"].ToString(),
                    DependencyChildren = "",
                    DependencyParent = "",
                    DiscoverPhase = artifactDetail.FlexFields["Discover Phase"].ToString(),
                    ExpectFinishDate = artifactDetail.FlexFields["Expect Finish Date"].ToString(),
                    InjectBy =
                    TranslateUserFullName(
                    artifactDetail.FlexFields["Inject By"]),
                    InjectionCause = artifactDetail.FlexFields["Injection Cause"].ToString(),
                    InjectionPhase = artifactDetail.FlexFields["Injection Phase"].ToString(),
                    InjectionVersion = artifactDetail.FlexFields["Injection Version"].ToString(),
                    ItemLink = "",
                    MonitoringStatus = "",
                    Owner =  
                    TranslateUserFullName(
                    artifactDetail.FlexFields["Owner"]),
                    OwnerFinishDate = artifactDetail.FlexFields["Owner  Finish Date"].ToString(),
                    RejectionReason = artifactDetail.FlexFields["Rejection Reason"].ToString(),
                    ReqID = artifactDetail.FlexFields["Req ID"].ToString(),
                    ResolvedUnitTestDetail = artifactDetail.FlexFields["Resolved&Unit Test Detail"].ToString(),
                    ResponsibleParty = artifactDetail.FlexFields["Responsible Party"].ToString(),
                    ReviewFinishDay = artifactDetail.FlexFields["Review Finish Day"].ToString(),
                    ReviewPeer =
                    TranslateUserFullName(
                    artifactDetail.FlexFields["Review Peer"]),
                    Severity = artifactDetail.FlexFields["Severity"].ToString(),
                    Verifier = 
                    TranslateUserFullName(
                    artifactDetail.FlexFields["Verifier"]),
                    VerifyFinishDay = artifactDetail.FlexFields["Verify Finish Day"].ToString(),


                });

            }
            return artifactResults;

        }
        IContext ctxHome;
        public void RetriveArtifactsFromInternalDefectTracker()
        {
            //Login();
            ITrackerSvc trackerSvc;
            try
            {
                trackerSvc = TeamForgeServiceFactory.CreateServiceClient<ITrackerSvc>(ctxHome);
            }
            catch (Exception eee)
            {
                throw eee;
            }
            string prjId = "proj1023";
            try
            {
                IArtifactFilterCollection filters = trackerSvc.CreateArtifactFilterCollection();
                string filterId = "tracker1063";
                
                //其實跟概略性的差不多哩GetArtifactDetailList
                StringBuilder sbFd = new StringBuilder();
          
                //var t = trackerSvc.GetFields(filterId);
                var artifactDetail = trackerSvc.GetArtifactDetailList(filterId, filters, null);

                DumpCSVFile(prjId, filterId, artifactDetail);
            }
            catch (Exception aa)
            {
                throw aa;
            }
        }

        ICollabNetSvc collabnetService;
        private string TranslateUserFullName(object userInfo) 
        {
       //     collabnetService = TeamForgeServiceFactory.CreateServiceClient<ICollabNetSvc>(ctxHome);
            Type type = userInfo.GetType();

            if (type == typeof(string))
            {
                return TranslateSingleUserFullName(userInfo.ToString());
            }
            else  if (type == typeof(ArrayList))
            {
                StringBuilder sbName = new StringBuilder();
                foreach (var va in (ArrayList)userInfo)
                {
                    sbName.Append(TranslateSingleUserFullName(va.ToString())).Append(", ");
                }
                sbName.Length--;
                sbName.Length--;

                return sbName.ToString();
            }
            return "";// user.FullName;
        }
        private string TranslateSingleUserFullName(string userId)
        {

         

            if (string.IsNullOrEmpty(userId))
            {
                return "";
            }
            string kValue;
            if (UserDatas.TryGetValue(userId, out kValue) == false)
            {
                var user = collabnetService.GetUserData(userId);
                UserDatas.Add(userId, user.FullName);
                kValue = user.FullName;
            }
            return kValue;// user.FullName;
    }
        private Dictionary<string, string> UserDatas = new Dictionary<string, string>();


        public void RetriveUserList() {
            ICollabNetSvc collabnet = TeamForgeServiceFactory.CreateServiceClient<ICollabNetSvc>(ctxHome);
            var u1=collabnet.GetUserData("cht07");
          var T=  collabnet.GetUserGroupListForProject("proj1023");
            var ps=collabnet.GetUserGroupList();
            var users=collabnet.GetUserList(null);
        
        }
    }
}
