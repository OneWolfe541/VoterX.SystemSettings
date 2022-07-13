using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Models.Database;

namespace VoterX.SystemSettings.Models
{
    public class PrinterSettingsModel
    {
        public bool NoPad { get; set; }                     // No Signature Pad
        public string BallotPrinter { get; set; }           // Ballot Printer
        public int BallotSize { get; set; }                 // Ballot Paper Size
        public int BallotBin { get; set; }               // Ballot Source Tray
        public string ApplicationPrinter { get; set; }      // Application Printer
        public int AppSize { get; set; }                    // Application Paper Size
        public int AppBin { get; set; }                  // Application Source Tray
        public string SamplePrinter { get; set; }           // Label Printer
        public int SampleSize { get; set; }                 // Label Paper Size
        public int SampleBin { get; set; }               // Label Source Tray
        public string ReportPrinter { get; set; }           // Report Printer
        public int ReportSize { get; set; }                 // Report Paper Size
        public int ReportBin { get; set; }               // Report Source Tray
        public string LabelPrinter { get; set; }           // Report Printer
        public int LabelSize { get; set; }                 // Report Paper Size
        public int LabelBin { get; set; }               // Report Source Tray
        //public bool LowQualityBallot { get; set; }
        //public int? BallotQuality { get; set; }   
        
        public PrinterSettingsModel()
        {

        }

        public PrinterSettingsModel(VoterXSetting settings)
        {
            NoPad = false;

            BallotPrinter = settings.BallotPrinter;
            BallotSize = settings.BallotSize;
            BallotBin = settings.BallotBin;

            ApplicationPrinter = settings.ApplicationPrinter;
            AppSize = settings.AppSize;
            AppBin = settings.AppBin;

            ReportPrinter = settings.ReportPrinter;
            ReportSize = settings.ReportSize;
            ReportBin = settings.ReportBin;

            SamplePrinter = settings.BallotPrinter;
            SampleSize = settings.BallotSize;
            SampleBin = settings.BallotBin;

            LabelPrinter = settings.LabelPrinter;
            LabelSize = settings.LabelSize;
            LabelBin = settings.LabelBin;
        }
    }
}
