using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Models.Database;

namespace VoterX.SystemSettings.Models
{
    public class BallotSettingsModel
    {
        public string BallotPDF { get; set; }               // Full file path of Ballot PDF
        public string BallotFolder { get; set; }
        public bool ProvisionalBallot { get; set; }         // Using Provisional PDF
        public string ProvisionalPDF { get; set; }          // Full file path of Provisional PDF
        public string ProvisionalFolder { get; set; }
        public string ProvisionalPrefix { get; set; }
        public bool SampleBallot { get; set; }              // Using Sample Ballot
        public string SamplePDF { get; set; }               // Full file path of Provisional PDF
        public string SampleFolder { get; set; }
        public string SamplePrefix { get; set; }
        public string TestBallot { get; set; }
        public bool Duplex { get; set; }
        public int IncludeBallotStyleId { get; set; }
        public int ExcludeBallotStyleId { get; set; }
        public int LabelCount { get; set; }                 // How many mailing labels to print with each ballot
        public bool IncludePartyOnLabel { get; set; }       // Display party on mailing labels

        public BallotSettingsModel()
        {

        }

        public BallotSettingsModel(VoterXSetting settings)
        {
            BallotFolder = settings.BallotFolder;
            ProvisionalFolder = settings.BallotFolder;
            ProvisionalPrefix = settings.ProvisionalPrefix;
            SampleFolder = settings.BallotFolder;
            SamplePrefix = settings.SamplePrefix;
            Duplex = settings.Duplex;
            IncludeBallotStyleId = settings.IncludeBallotStyleId;
            ExcludeBallotStyleId = settings.ExcludeBallotStyleId;
            LabelCount = settings.LabelCount ?? 1;
            IncludePartyOnLabel = settings.IncludePartyOnLabel;
        }
    }
}
