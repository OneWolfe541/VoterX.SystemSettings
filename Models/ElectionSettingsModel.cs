using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Enums;
using VoterX.SystemSettings.Models.Database;

namespace VoterX.SystemSettings.Models
{
    public class ElectionSettingsModel
    {
        public int ElectionID { get; set; }             // AES Election ID from Support Center        
        public string CountyCode { get; set; }          // Organization Code
        public ElectionType ElectionType { get; set; }  // Type of Election 1=Primary 2=General
        public string ElectionEntity { get; set; }      // Municipal, County, or State Government holding the Election
        public string ElectionTitle { get; set; }       // Title of Election
        public DateTime ElectionDate { get; set; }      // Date of Election

        public List<string> EligibleParties { get; set; }

        public ElectionSettingsModel()
        {

        }

        public ElectionSettingsModel(VoterXSetting settings)
        {
            ElectionID = settings.ElectionId;
            CountyCode = settings.CountyCode;
            ElectionType = (ElectionType)settings.ElectionType;
            ElectionEntity = settings.ElectionEntity;
            ElectionTitle = settings.ElectionTitle;
            ElectionDate = settings.ElectionDate;
            EligibleParties = ParseParties(settings.EligibleParties);
        }

        private List<string> ParseParties(string parties)
        {
            if (parties != null)
            {
                return parties.Split(',').ToList();
            }
            else return null;
        }
    }
}
