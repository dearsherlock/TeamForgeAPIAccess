using CollabNet.TeamForge.Library.Model.MainSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFClient.Entities;

namespace TFClient
{
   public  class TeamForgeObjectCopy
    {
        public ProjectListCollection RetriveProjectListCollection(IProjectListCollection projectListCollection)
        {
            ProjectListCollection projects=new ProjectListCollection();
            foreach(var it in projectListCollection)
            {
                projects.Add(new  ProjectRow { 
                      DateCreated=it.DateCreated,
                       HierarchyPath=it.HierarchyPath,
                        Locked=it.Locked,
                         ParentProjectId=it.ParentProjectId,
                          Path=it.Path,
                          Title= it.Title,
                          ID=        it.ID
                          , Id= it.Id
                           
                });

            }
            return projects;

            
        }
    }
}
