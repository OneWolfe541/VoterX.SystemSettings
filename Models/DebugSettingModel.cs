using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterX.SystemSettings.Models
{
    /// <summary>
    /// Settings model used to tell the application it is running in a development environment
    /// </summary>
    public class DebugSettingModel
    {
        public bool DebugMode { get; set; }     // True if the application is in the development environment
        public Guid SystemId { get; set; }
        public string SystemName { get; set; }
        public int? SettingsType { get; set; }
        public int? SearchMethod { get; set; }
    }
}
