using VoterX.SystemSettings.Enums;
using VoterX.SystemSettings.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterX.SystemSettings.Models
{
    /// <summary>
    /// System and Application Level Settings
    /// </summary>
    public class SystemSettingsModel
    {
        /// <summary>
        /// Current version of VoterX
        /// </summary>
        
        public Guid SystemId { get; set; }

        public string BODName { get; set; }             // Current version of VoterX
        public string BODVersion { get; set; }          // Current version of VoterX
        //public string BODType { get; set; }             // Hash values for Absentee and VCC
                                                        // Absentee = "82f99512335c701d889ba52faf31bcc224b05e43e4f6ebf892e5d1806fbef1eb"
                                                        // VCC = "f42d8b2d4e1364ed176ca8fac3c6f6a9762831b471b4421d5de6bc3c6989f941"
        public string PDFTools { get; set; }            // OEM KEY 1-UCAE4-X1374-GCBGU-3LA2U-B5NQ1-G5FXW-MWT3X
        public int? SiteID { get; set; }                // Number representing the BOD site
        public string SiteName { get; set; }            // Site Name
        public int MachineID { get; set; }              // Laptop number
        public string MachineName { get; set; }         // Computer name & Logmein name
        public bool SiteVerified { get; set; }          // Site has been verified
        public SearchMode SearchOptions { get; set; }   // 1=Normal 2=Scan 3=Queue
        public VotingCenterMode VCCType { get; set; }   // 1=EV 2=Poll 3=Sample Ballots
        public int BallotStub { get; set; }             // 0=No 1=Yes
        public int Permit { get; set; }                 // 0=No 1=Yes
        //public int Popup { get; set; }                  // 0=No 1=Yes
        //public bool ZeroReport { get; set; }            // Zero Report Printed

        public string SignatureFolder { get; set; }
        //public bool AdminComputer { get; set; }         // Administration Computer at Site
        //public bool SiteServer { get; set; }            // Onsite server
        //public bool Login { get; set; }
        public int LoginType { get; set; }              // 1=Single User 2=Multiple Users
        public bool IdRequired { get; set; }            // Forces the id check for all voters

        public bool ReportErrorLogging { get; set; }    // Turn ON and OFF log files for FastReports
        public int TimeOut { get; set; }

        public SystemSettingsModel()
        {

        }

        public SystemSettingsModel(VoterXSetting settings)
        {
            SystemId = settings.SystemId;
            SiteID = settings.PollId;
            SiteName = settings.PlaceName;
            MachineID = settings.Computer;
            MachineName = settings.SystemName;
            SiteVerified = settings.Verified;
            SearchOptions = (SearchMode)settings.SearchType;
            VCCType = (VotingCenterMode)settings.VCCType;
            BallotStub = settings.BallotStub.Value;
            Permit = settings.Permit.Value;
            SignatureFolder = settings.SignatureFolder;
            LoginType = settings.LoginType.Value;
            IdRequired = settings.IdRequired.Value;
            TimeOut = settings.TimeOut.Value;
        }
    }
}
