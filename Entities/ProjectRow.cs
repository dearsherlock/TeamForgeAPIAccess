using CollabNet.TeamForge.Library.Model.MainSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFClient.Entities
{
    public class ProjectRow
    {
      public   DateTime DateCreated { get; set; }
      public string HierarchyPath { get; set; }
      public bool Locked { get; set; }
      public string ParentProjectId { get; set; }
      public string Path { get; set; }
     public string Title { get; set; }
      
        public string ID { get; set; }
        public string Id { get; set; }
                      
    
    }
}
