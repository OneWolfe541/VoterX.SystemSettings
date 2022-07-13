using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterX.SystemSettings.Models
{
    public class UserSettingsModel
    {
        public int PasswordType { get; set; }           // 1=Global User 2=User Database
        public string SystemPassword { get; set; }      // Password for Users
        public string AdminPassword { get; set; }       // Password for Critical System Functions
        public string ManagePassword { get; set; }      // Management Password User Bypass
        public string GlobalPassword { get; set; }
        public string BoardPassword { get; set; }
        public string SuperPassword { get; set; }
        public int UserID { get; set; }                 // User Id From Poll Officials
        public string UserName { get; set; }            // User Name From Poll Officials
        public string FullName { get; set; }
        public string Party { get; set; }
        public string PositionName { get; set; }
        public int SiteID { get; set; }
    }
}
