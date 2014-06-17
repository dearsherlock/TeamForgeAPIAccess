TeamForgeAPIAccess
==================

自己寫的存取TeamForge Soap API

This is a application that access teamforge soap API. 
1.Try to login, keep the login context alive. 
2.Retrive tracker basic information.
3.Collect the flexible fields. 

How to use:

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
