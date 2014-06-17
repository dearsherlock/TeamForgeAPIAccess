using CollabNet.TeamForge.Library.soap60.DocumentApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TFClient
{
    class RetriveTeamForgeWebContent
    {
        public static void UpdateTeamForgeModelSessionId(ref     TeamForgeSiteDataModel model)
        {
            XmlDocument document = new XmlDocument();
            document.Load("LoginData.xml");
            string loginData = document.OuterXml;
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                webClient.Headers.Set("SOAPAction", "");
                string resultLogin = webClient.UploadString("https://alm.ebaotech.com/ce-soap60/services/CollabNet", loginData);
                string sessionId = SoapXmlParsingAtRegular.RetriveLoginValue(resultLogin);
                model.SessionId = sessionId;
            }
        }        
        
              public static void UpdateTeamForgeModelProjectCategory(       ref     TeamForgeSiteDataModel model )
        {
            XmlDocument document = new XmlDocument();
            document.Load("ProjectCategoryInfo.xml");
            string ProjectInfoData = document.OuterXml;
          ProjectInfoData=  ProjectInfoData.Replace("@SessionId@",model.SessionId);
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                webClient.Headers.Set("SOAPAction", "");
                string resultProjectInfo = webClient.UploadString("https://alm.ebaotech.com/ce-soap60/services/CollabNet", ProjectInfoData);
                resultProjectInfo = TrimSoapTagUtil.TrimSoapTagUtilFunc(resultProjectInfo);
                SoapXmlParsingAtRegular.RetriveProjectCategoryInfo(resultProjectInfo,ref model);
                DocumentFolderSoapList D = new DocumentFolderSoapList();
                //string projectInfo= SoapXmlParsingAtRegular.RetriveLoginValue(resultLogin);
                //model.SessionId = sessionId;
            }
              
              }
    }
}
