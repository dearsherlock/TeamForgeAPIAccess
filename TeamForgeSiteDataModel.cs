using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFClient
{
    public class TeamForgeSiteDataModel
    {
        public string SessionId  { get; set; }
        public List<TeamForgeProjectCategory> ProjectCategories { get; set; }
    }
    public class TeamForgeProjectCategory {
        public string DateCreated { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }

        public string Locked { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
    
    }
}
