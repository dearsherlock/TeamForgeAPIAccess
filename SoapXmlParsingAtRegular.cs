using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TFClient
{
    class SoapXmlParsingAtRegular
    {
        #region RetriveLoginData
        public static Regex regexRetriveLoginData = new Regex(
      "loginReturn\\sxsi:type=\\\"xsd:string\\\">([\\w\\d]{1,})</lo" +
      "ginReturn>",
    RegexOptions.CultureInvariant
    | RegexOptions.Compiled
    );
        public static string RetriveLoginValue(string xmlData)
        {
         
            Match m = regexRetriveLoginData.Match(xmlData);

            return m.Groups[1].Value;
        }
        #endregion

        #region RetriveProjectCategory

        public static Regex regexRetriveProjectCategory = new Regex(
      "<multiRef\\sid=\\\"id\\d\\\"\\s><dateCreated>(.{1,})</dateCr" +
      "eated><description>(.{1,}\\n{0,})</description><hierarchyPat" +
      "h/><id>([\\w\\d]{1,})</id><locked>([\\w]{1,})</locked><paren" +
      "tProjectId>([\\w]{0,})</parentProjectId><path>([\\.\\w\\d]{1" +
      ",})</path><title>([\\.\\w\\d]{1,})</title></multiRef>",
    RegexOptions.CultureInvariant
    | RegexOptions.Compiled
    );
        public static void RetriveProjectCategoryInfo(string data,ref TeamForgeSiteDataModel model)
        {
            MatchCollection ms = regexRetriveProjectCategory.Matches(data);
            model.ProjectCategories = new List<TeamForgeProjectCategory>();

            foreach(Match match in ms)
            {
                //TeamForgeProjectCategory category = new TeamForgeProjectCategory { DateCreated="" };
                model.ProjectCategories.Add(
                    new TeamForgeProjectCategory { 
                        DateCreated = match.Groups[1].Value,
                        Description = match.Groups[2].Value,
                        Id = match.Groups[4].Value,
                        Locked = match.Groups[5].Value,
                        Path = match.Groups[6].Value,
                        Title = match.Groups[7].Value
                    }                                
                );
              
            }
        }
        #endregion


    }
}
