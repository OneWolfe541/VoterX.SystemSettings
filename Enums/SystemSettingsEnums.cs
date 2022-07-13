using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Extensions;

namespace VoterX.SystemSettings.Enums
{
    //public enum SystemMode : int
    //{
    //    None = 0,

    //    [StringValue("Early Voting")]
    //    EarlyVoting = 1,

    //    [StringValue("Election Day")]
    //    ElectionDay = 2,

    //    [StringValue("Sample Ballots")]
    //    SampleBallots = 3,

    //    [StringValue("Absentee")]
    //    Absentee = 4
    //}

    public enum SearchMode
    {
        None = 0,
        Normal = 1,
        Scan = 2,
        Queue = 3
    }

    public enum VotingCenterMode : int
    {
        None = 0,
        EarlyVoting = 1,
        ElectionDay = 2,
        SampleBallots = 3,
        Absentee = 4
    }

    public static class VotingCenterModeExtensions
    {
        public static string ToString(this VotingCenterMode mode)
        {
            string message = "";
            switch (mode)
            {
                case VotingCenterMode.EarlyVoting:
                    message = "Early Voting";
                    break;
                case VotingCenterMode.ElectionDay:
                    message = "Election Day";
                    break;
                case VotingCenterMode.SampleBallots:
                    message = "Sample Ballot";
                    break;
                case VotingCenterMode.Absentee:
                    message = "Absentee";
                    break;
            }
            return message;
        }
    }

    public class VotingCenterModel
    {
        public int id { get; set; }
        public string description { get; set; }
    }

    public static class VotingCenterHelper
    {
        public static List<VotingCenterModel> GetVotingCenterList()
        {
            List<VotingCenterModel> list = new List<VotingCenterModel>();
            list.Add(new VotingCenterModel { id = 1, description = "Early Voting" });
            list.Add(new VotingCenterModel { id = 2, description = "Election Day" });
            list.Add(new VotingCenterModel { id = 3, description = "Sample Ballot" });
            list.Add(new VotingCenterModel { id = 4, description = "Absentee" });

            return list;
        }
    }
}
