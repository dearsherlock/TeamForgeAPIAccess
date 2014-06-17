using CollabNet.TeamForge.Library;
using CollabNet.TeamForge.Library.Model;
using CollabNet.TeamForge.Library.Model.MainSvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using TFClient.Entities;
using CollabNet.TeamForge.Library.Model.TrackerSvc;
namespace TFClient
{
    class Program
    {

        static void Main2(string[] args)
        {
            TeamForgeSiteDataModel model = new TeamForgeSiteDataModel();
            RetriveTeamForgeWebContent.UpdateTeamForgeModelSessionId(ref model);
                        RetriveTeamForgeWebContent.UpdateTeamForgeModelProjectCategory(ref model);

        }

        static void Main(string[] args)
        {

            TeamForgeTrackerReport track = new TeamForgeTrackerReport();
       //     track.DumpFile();
            Program p = new Program();
        //    p.RetriveBySDK();
          //  p.RetriveTrackerReportBySDK();
      //      p.RetriveArtifactsFromInternalDefectTracker();
            TeamForgeTrackerReport report = new TeamForgeTrackerReport();
            report.Login();
       //     report.RetriveUserList();
            report.RetriveArtifactsFromInternalDefectTracker();
        }
        public void RetriveArtifactsFromInternalDefectTracker() {


            IContext ctx = Login();
            ITrackerSvc trackerSvc;
            try
            {
                trackerSvc = TeamForgeServiceFactory.CreateServiceClient<ITrackerSvc>(ctx);

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
                var artifactList = trackerSvc.GetArtifactList(filterId, filters);//.GetTrackerList(prjId);
               // ShowTrackerData(trackerList);
                foreach(var artifact in artifactList)
                {
                   
                }
            }
            catch (Exception aa)
            {
                throw aa;
            }
        }
        public void RetriveTrackerReportBySDK() 
        {
            IContext ctx= Login();
            ITrackerSvc trackerSvc;
            try
            {
                trackerSvc = TeamForgeServiceFactory.CreateServiceClient<ITrackerSvc>(ctx);
        
            }
            catch (Exception eee)
            {
                
                throw eee;
            }
          //  ITrackerSvc trackerSvc = TeamForgeServiceFactory.CreateServiceClient<ITrackerSvc>(ctx);
            string prjId = "proj1023"; // replace with your project id
            try
            {
                
            ITrackerListCollection trackerList = trackerSvc.GetTrackerList(prjId);

            ShowTrackerData(trackerList);
            }
            catch (Exception aa)
            {
                
                throw aa;
            }

        
        }
        private void ShowTrackerData(ITrackerListCollection trList)
        {
            //取得Tracker的大類
            //
            foreach (ITrackerRow tr in trList)
            {
                string title = tr.Title;
                string id = tr.Id;
               //var artifacts = trackerSvc.GetArtifactList(containerId, filters);

                //Display tracker info here
            }
        }
        
        public IContext Login() {
            IContext ctx = new Context();

            ctx.ContextName = "myserverName"; // a unique name to identify TeamForge server
            ctx.ServerHost = "alm.ebaotech.com"; // host part of the server URL
            ctx.UseSSL = true;
            ctx.UserName = "xxxx";
            ctx.Password = "xxxx";
            ICollabNetSvc collabnet = TeamForgeServiceFactory.CreateServiceClient<ICollabNetSvc>(ctx);
            string clientIdentifier = "My TeamForge Client";
            collabnet.Login(clientIdentifier);
            string id = collabnet.CurrentContext.SessionKey;
            return ctx;
        }
        public void RetriveBySDK() {


            IContext ctx = new Context();

            ctx.ContextName = "myserverName"; // a unique name to identify TeamForge server
            ctx.ServerHost = "alm.ebaotech.com"; // host part of the server URL
            ctx.UseSSL = true;
            ctx.UserName = "xxxx";
            ctx.Password = "xxxx";
            ICollabNetSvc collabnet = TeamForgeServiceFactory.CreateServiceClient<ICollabNetSvc>(ctx);
            string clientIdentifier = "My TeamForge Client";
            collabnet.Login(clientIdentifier);
            string id = collabnet.CurrentContext.SessionKey;

            var projects = collabnet.GetProjectList();

            //        TeamForgeObjectCopy copyUtil = new TeamForgeObjectCopy();
            //         ProjectListCollection projectsData= copyUtil.RetriveProjectListCollection(projects);
            //        var xmlD= projectsData.ToXML();
            //        System.Xml.Serialization.XmlSerializer writer =
            //new System.Xml.Serialization.XmlSerializer(typeof(ProjectListCollection));

            //        System.IO.StreamWriter file = new System.IO.StreamWriter(
            //            @"projectsData.xml");
            //        writer.Serialize(file, projectsData);
            //        file.Close();


    //        GoogleSpreadSheetUpdateUtil util = new GoogleSpreadSheetUpdateUtil();
       //     util.UpdateProjectInfo(projects);
        
        } 


        
    }
}
