using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Models.Database;

namespace VoterX.SystemSettings.Models
{
    public class ReportSettingsModel
    {
        //public bool AllowReports { get; set; }          // Allow reports to be printed on this machine
        public string ReportsFolder { get; set; }
        //public string SomeRandomReport { get; set; }
        public string ExcelExportFolder { get; set; }
        public string ExcelExportFile { get; set; }
        public int ReconcileCopies { get; set; }

        public ReportSettingsModel()
        {

        }

        public ReportSettingsModel(VoterXSetting settings)
        {
            ReportsFolder = settings.ReportsFolder;
            ExcelExportFolder = settings.ExcelExportFolder;
            ExcelExportFile = settings.ExcelExportFileName;
            ReconcileCopies = settings.ReconcileCopies;
        }
    }
}
