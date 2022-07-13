using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Enums;
using VoterX.SystemSettings.Models;

namespace VoterX.SystemSettings.Extensions
{
    public static class SystemExtensions
    {
        public static VotingCenterMode InvertVCCType(this SystemSettingsModel system)
        {
            if (system.VCCType == VotingCenterMode.EarlyVoting)
            {
                return VotingCenterMode.ElectionDay;
            }
            else if (system.VCCType == VotingCenterMode.ElectionDay)
            {
                return VotingCenterMode.EarlyVoting;
            }
            else return VotingCenterMode.None;
        }

        public static string VCCTypeString(this SystemSettingsModel system)
        {
            if (system.VCCType == VotingCenterMode.EarlyVoting)
            {
                return "Early Voting";
            }
            else if (system.VCCType == VotingCenterMode.ElectionDay)
            {
                return "Election Day";
            }
            else return null;
        }
    }
}
