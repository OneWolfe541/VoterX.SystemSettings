using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterX.SystemSettings.Models
{
    [Serializable]
    public class GlobalSettingsModel
    {
        /// <summary>
        /// System and Application Level Settings
        /// </summary>
        public SystemSettingsModel System = new SystemSettingsModel();

        /// <summary>
        /// System and Application Level Settings
        /// </summary>
        public SiteSettingsModel Site = new SiteSettingsModel();

        /// <summary>
        /// Network and Connection Settings
        /// </summary>
        public NetworkSettingsModel Network = new NetworkSettingsModel();

        /// <summary>
        /// Current User and Admin Settings
        /// </summary>
        [field: NonSerialized()]
        public UserSettingsModel User = new UserSettingsModel();

        /// <summary>
        /// Printers and other Peripheral Settings
        /// </summary>
        public PrinterSettingsModel Printers = new PrinterSettingsModel();

        /// <summary>
        /// Election Specific Settings
        /// </summary>
        public ElectionSettingsModel Election = new ElectionSettingsModel();

        /// <summary>
        /// Ballot Settings
        /// </summary>
        public BallotSettingsModel Ballots = new BallotSettingsModel();

        /// <summary>
        /// Report Settings
        /// </summary>
        public ReportSettingsModel Reports = new ReportSettingsModel();
    }
}
