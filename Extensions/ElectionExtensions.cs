using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Models;

namespace VoterX.SystemSettings.Extensions
{
    public static class ElectionExtensions
    {
        /// <summary>
        /// Check if today is election day
        /// </summary>
        /// <param name="election"></param>
        /// <returns></returns>
        public static bool IsElectionDay(this ElectionSettingsModel election)
        {
            //return true;
            if (election.ElectionDate.Date == DateTime.Now.Date) return true;
            else return false;
        }
    }
}
