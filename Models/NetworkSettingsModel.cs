using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Models.Database;

namespace VoterX.SystemSettings.Models
{
    public class NetworkSettingsModel
    {
        //public int NetworkTypeID { get; set; }              // Type of Network, 1=Standard, 2=Access, 3=ODBCSQL        
        //public string TableLink { get; set; }               // Full file path of Linked Tables (Access accdb, mdb)
        public int SQLMode { get; set; }                    // 0=Debug/Dev 1=Live/Site Testing
        public string SQLServer { get; set; }
        public string LocalDatabase { get; set; }
        //public DateTime StartDate { get; set; }             // Date if Installation
        //public DateTime LastLogin { get; set; }             // Time Stamp of New Voter
        //public DateTime LastEndOfDayUpdate { get; set; }    // Time of Last Code Update from SQL Server {End of Day}
        //public DateTime LastSQLUpdate { get; set; }         // Time of Last full Update from SQL server {Log In}        
        //public string LocalTable { get; set; }              // Name of Local Table { ODBCSQL }
        //public string RemoteTable { get; set; }             // Name of Remote Table { ODBCSQL }
        //public bool Table2 { get; set; }                    // Second Remote Table
        //public string LocalTable2 { get; set; }             // Name of Local Table { ODBCSQL }
        //public string RemoteTable2 { get; set; }            // Name of Remote Table { ODBCSQL }

        public NetworkSettingsModel()
        {

        }

        public NetworkSettingsModel(VoterXSetting settings)
        {
            SQLMode = settings.SQLMode.Value;
            SQLServer = settings.SQLServerName;
            LocalDatabase = settings.DatabaseName;
        }
    }
    
}
