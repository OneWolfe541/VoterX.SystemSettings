using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Models.Database;

namespace VoterX.SystemSettings.Models
{
    // Used for conversion from early voting site to election day site
    // When the same physical site can have different ID for early and election day
    // Simply swapping between an Active and Aternate site if an admin were to change the VCC Mode more than once
    public class SiteSettingsModel
    {
        public int? EarlyVotingSiteID { get; set; }                 // Number representing the BOD site
        public string EarlVotingSiteName { get; set; }              // Site Name
        public int? ElectionDaySiteID { get; set; }                 // Number representing the BOD site
        public string ElectionDaySiteName { get; set; }             // Site Name
        public bool? HybridLocation { get; set; }

        public SiteSettingsModel()
        {

        }

        public SiteSettingsModel(VoterXSetting settings)
        {
            EarlyVotingSiteID = settings.EarlyVotingPollId;
            EarlVotingSiteName = settings.EarlyVotingPlaceName;
            ElectionDaySiteID = settings.ElectionDayPollId;
            ElectionDaySiteName = settings.ElectionDayPlaceName;
            HybridLocation = settings.HybridLocation;
        }
    }
}
