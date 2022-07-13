using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Models.Database;

namespace VoterX.SystemSettings.Models
{
    public class AbsenteeSettingsModel
    {
        public string BODType { get; set; }             // Hash values for Absentee and VCC
                                                        // Absentee = "82f99512335c701d889ba52faf31bcc224b05e43e4f6ebf892e5d1806fbef1eb"
                                                        // VCC = "f42d8b2d4e1364ed176ca8fac3c6f6a9762831b471b4421d5de6bc3c6989f941"
        public int SiteID { get; set; }                 // Number representing the BOD site
        public string SiteName { get; set; }            // Site Name

        public string CountyName { get; set; }
        public string ClerkName { get; set; }

        // Application Return Addresse
        public string ApplicationReturnAddress1 { get; set; }
        public string ApplicationReturnAddress2 { get; set; }
        public string ApplicationReturnCity { get; set; }
        public string ApplicationReturnState { get; set; }
        public string ApplicationReturnZip { get; set; }

        // Ballot Return Address
        public string BallotReturnAddress1 { get; set; }
        public string BallotReturnAddress2 { get; set; }
        public string BallotReturnCity { get; set; }
        public string BallotReturnState { get; set; }
        public string BallotReturnZip { get; set; }

        // IMB Settings
        public string IMBBarCodeId { get; set; }
        public string IMBOutServiceTypeId { get; set; }
        public string IMBInServiceTypeId { get; set; }
        //public string IMBMailerId { get; set; }
        public string IMBOutGoing { get; set; }
        public string IMBIncoming { get; set; }
        public string IMBPrefix { get; set; }

        public bool BatchReportPrinted { get; set; }
        public DateTime BatchReportPrintedDate { get; set; }
        public string BatchPrintingMode { get; set; }

        public string ElectionTitle { get; set; }
        public string ElectionDateLong { get; set; }
        public string ElectionTitleSpanish { get; set; }
        public string ElectionDateLongSpanish { get; set; }

        public bool AllMailMode { get; set; }
        public bool ScanOnly { get; set; }
        public bool? CanVoteInPersonOnThisMachine { get; set; }

        public bool? TestScreen { get; set; }
        public bool? ShowSliderIcons { get; set; }

        public bool? BoardLocationRequired { get; set; }

        public AbsenteeSettingsModel()
        {

        }

        public AbsenteeSettingsModel(VoterXSetting settings)
        {
            SiteID = settings.AbsenteePollId??1;
            SiteName = settings.AbsenteePlaceName;
            AllMailMode = settings.AllMailMode;
            ScanOnly = settings.ScanOnlyMode;
            CanVoteInPersonOnThisMachine = settings.VoteInPerson;
            BoardLocationRequired = settings.BoardLocationRequired;
            BatchPrintingMode = settings.BatchPrintingMode;

            CountyName = settings.ApplicationEntityName;
            ClerkName = settings.ApplicationClerkName;
            ApplicationReturnAddress1 = settings.ApplicationReturnAddress1;
            ApplicationReturnAddress2 = settings.ApplicationReturnAddress2;
            ApplicationReturnCity = settings.ApplicationReturnCity;
            ApplicationReturnState = settings.ApplicationReturnState;
            ApplicationReturnZip = settings.ApplicationReturnZip;
            ElectionTitle = settings.ApplicationElectionTitle;
            ElectionDateLong = settings.ApplicationElectionDateLong;
            ElectionTitleSpanish = settings.ApplicationElectionTitleSpanish;
            ElectionDateLongSpanish = settings.ApplicationElectionDateLongSpanish;

            BallotReturnAddress1 = settings.BallotReturnAddress1;
            BallotReturnAddress2 = settings.BallotReturnAddress2;
            BallotReturnCity = settings.BallotReturnCity;
            BallotReturnState = settings.BallotReturnState;
            BallotReturnZip = settings.BallotReturnZip;

            IMBBarCodeId = settings.IMBBarCodeId;
            IMBOutServiceTypeId = settings.IMBOutServiceTypeId;
            IMBInServiceTypeId = settings.IMBInServiceTypeId;
            IMBOutGoing = settings.IMBMailerOutGoing;
            IMBIncoming = settings.IMBMailerIncoming;
            IMBPrefix = settings.IMBSerialPrefix;

            BatchPrintingMode = settings.BatchPrintingMode;
        }
    }
}
