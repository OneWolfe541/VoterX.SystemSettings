using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterX.SystemSettings.Models.Database
{
    public class VoterXSetting
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid VoterXSettingId { get; set; }
        [Column(Order = 1)]
        public Guid SystemId { get; set; }                              // Azure defined unique identifier for this laptop
        [Column(Order = 2)]
        public string SystemName { get; set; }                          // Computer name of this laptop

        
        // System Settings
        [Column(Order = 3)]
        public int PollId { get; set; }                                 // Poll Id for this site provided by SERVIS
        [Column(Order = 4)]
        public string PlaceName { get; set; }                           // Site name provided by SERVIS
        [Column(Order = 5)]
        public int Computer { get; set; }                               // Computer number for the site
        [Column(Order = 6)]
        public bool Verified { get; set; }                              // Has the laptop completed the verification process - Default: false
        [Column(Order = 7)]
        public int? SearchType { get; set; }                            // Defines the default search screen (None = 0, Normal = 1, Scan = 2, Queue = 3) - Default: 1
        [Column(Order = 8)]
        public int VCCType { get; set; }                                // VCC system mode (None = 0, Early Voting = 1, Election Day = 2, Sample Ballots = 3,  Absentee = 4 (not used) ) - Default: 1
        [Column(Order = 9)]
        public int? BallotStub { get; set; }                            // Print a stub with the ballot - used by Eddy County (Don't Print Ballot Stubs = 0, Print Ballot Stubs = 1) - Default: 0
        [Column(Order = 10)]
        public int? Permit { get; set; }                                // Print permits on election day (Don't Print Permits = 0, Print Permits = 1) - Default: 1
        [Column(Order = 11)]
        public string SignatureFolder { get; set; }                     // Location where the voter signature is stored ("//SF_BOCA_EV-01/Signatures" or "C:\VoterX\Signatures") - Default: "//SYSTEM-01/Signatures"
        [Column(Order = 12)]
        public int? LoginType { get; set; }                             // Use default logins or separate login for each user/pollworker (Single User = 1, Multiple Users = 2) - Default: 1
        [Column(Order = 13)]
        public bool? IdRequired { get; set; }                           // Forces the id check for all voters - Default: false
        [Column(Order = 14)]
        public int? TimeOut { get; set; }                               // Duration in minutes before system auto logs off - Default: 0
        [Column(Order = 15)]
        public string PDFTools { get; set; }                            // License key for PDF Tools ("1-UCAE4-X1374-GCBGU-3LA2U-B5NQ1-G5FXW-MWT3X")


        // Site Settings
        [Column(Order = 16)]
        public int? EarlyVotingPollId { get; set; }                     // Poll Id for Early Voting state - Default: null
        [Column(Order = 17)]
        public string EarlyVotingPlaceName { get; set; }                // Site Name for Early Voting state - Default: null
        [Column(Order = 18)]
        public int? ElectionDayPollId { get; set; }                     // Poll Id for Election Day state - Default: null
        [Column(Order = 19)]
        public string ElectionDayPlaceName { get; set; }                // Site Name for Election Day state - Default: null
        [Column(Order = 20)]
        public bool HybridLocation { get; set; }                        // Forces the system to check if a voter is eligible to vote at this site - Default: false


        // Network Settings
        [Column(Order = 22)]
        public int? SQLMode { get; set; }                               // SQL authentication mode (Windows Account = 0, SQL Account = 1, Use hard coded connection string = 3) This should always be set to 1
        [Column(Order = 23)]
        public string SQLServerName { get; set; }                       // Name of the SQL database - should always be system 1 for each site
        [Column(Order = 24)]
        public string DatabaseName { get; set; }                        // Name of the election database - Default: "ELECTION"


        // Printer Settings
        [Column(Order = 25)]
        public string BallotPrinter { get; set; }                       // Full name of the printer where ballots are printed - Default: null
        [Column(Order = 26)]
        public int BallotSize { get; set; }                             // Code refering to the size of the ballot stock - defined by the printer - can be found in the av.pr.json file - Default: 0
        [Column(Order = 27)]
        public int BallotBin { get; set; }                              // Code refering to the paper tray for the ballot stock - defined by the printer - Default: 0
        [Column(Order = 28)]
        public string ApplicationPrinter { get; set; }                  // Full name of the printer where applications are printed - Default: null
        [Column(Order = 29)]
        public int AppSize { get; set; }                                // Code refering to the size of the application paper - defined by the printer - can be found in the av.pr.json file - Default: 0
        [Column(Order = 30)]
        public int AppBin { get; set; }                                 // Code refering to the paper tray for the aplications - defined by the printer - Default: 0
        [Column(Order = 31)]
        public string ReportPrinter { get; set; }                       // Full name of the printer where reports are printed - Default: null
        [Column(Order = 32)]
        public int ReportSize { get; set; }                             // Code refering to the size of the report paper - defined by the printer - Default: 0
        [Column(Order = 33)]
        public int ReportBin { get; set; }                              // Code refering to the paper tray for the reports - defined by the printer - Default: 0
        [Column(Order = 34)]
        public string LabelPrinter { get; set; }                        // Full name of the printer where labels are printed - DYMO - Default: null
        [Column(Order = 35)]
        public int LabelSize { get; set; }                              // Code refering to the size of the label paper - defined by the printer - used for sheet labels - Default: 0
        [Column(Order = 36)]
        public int LabelBin { get; set; }                               // Code refering to the paper tray for the reports - defined by the printer - used for sheet labels - Default: 0


        // Election Settings                                            // These values should be pulled from tblElections
        [Column(Order = 37)]
        public int ElectionId { get; set; }                             // SERVIS designated election id - Default: 0
        [Column(Order = 38)]
        public string CountyCode { get; set; }                          // State assigned 2 digit code for the county - Examples: "01" "02" "16" "33"
        [Column(Order = 39)]
        public int? ElectionType { get; set; }                          // Partisan (Primary) = 1, Nonpartisan (General/Special) = 2
        [Column(Order = 40)]
        public string ElectionEntity { get; set; }                      // Name of the group/entity holding the election (county/city) - "Valencia County"
        [Column(Order = 41)]
        public string ElectionTitle { get; set; }                       // Name of the election - "Valencia County Special Belin School District 1 Election"
        [Column(Order = 42)]
        public DateTime ElectionDate { get; set; }                      // Date of the election - The VCC system will switch from EV to ED mode 1 day prior to this value - Cannot switch back to EV if current date is greater than this value
        [Column(Order = 43)]
        public string EligibleParties { get; set; }                     // List of party codes that are eligible for this election - Primary Only - NO SPACES - "DEM,REP,LIB" - Default: null


        // Ballot Settings
        [Column(Order = 44)]
        public string BallotFolder { get; set; }                        // Location where ballot PDFs are stored - Default: "C:\VoterX\Ballots\"
        [Column(Order = 45)]
        public string ProvisionalPrefix { get; set; }                   // Provisional ballot naming convention - Default: "PROV_"
        [Column(Order = 46)]
        public string SamplePrefix { get; set; }                        // Sample ballot naming convention - Default: "SAM_"
        [Column(Order = 47)]
        public bool Duplex { get; set; }                                // Duplex double sided ballots - Default: false
        [Column(Order = 48)]
        public int IncludeBallotStyleId { get; set; }                   // Ballot Style white list - Default: 0
        [Column(Order = 49)]
        public int ExcludeBallotStyleId { get; set; }                   // Ballot Style black list - Default: 0
        [Column(Order = 50)]
        public int? LabelCount { get; set; }                            // Number of address labels to print with each ballot - Absentee only - Default: 1
        [Column(Order = 51)]
        public bool IncludePartyOnLabel { get; set; }                   // Display party code on address label - Absentee only - Default: false


        // Report Settings
        [Column(Order = 52)]
        public string ReportsFolder { get; set; }                       // Location where (frx) report files are stored - Default: "C:\Program Files\VoterX\Reports"
        [Column(Order = 53)]
        public string ExcelExportFolder { get; set; }                   // Location where excel and csv files are exported from the Report Wizard - Default: "C:\VoterX\Export"
        [Column(Order = 54)]
        public string ExcelExportFileName { get; set; }                 // Default name for export files - Default: "SAMPLE REPORT"
        [Column(Order = 55)]
        public int ReconcileCopies { get; set; }                        // Number of copies of the reconcile report that will be printed - Default: 1


        // Absentee System Settings
        [Column(Order = 56)]
        public int? AbsenteePollId { get; set; }                        // Poll Id for the absentee site - Default: null
        [Column(Order = 57)]
        public string AbsenteePlaceName { get; set; }                   // Name of the absentee site - Default: null
        [Column(Order = 58)]
        public bool AllMailMode { get; set; }                           // Set the system to run in all mail mode - Default: false
        [Column(Order = 59)]
        public bool ScanOnlyMode { get; set; }                          // Set system to only scan return ballots/applications - Default: false
        [Column(Order = 60)]
        public bool VoteInPerson { get; set; }                          // Allow In-Person voting on this absentee system - Default: false
        [Column(Order = 61)]
        public bool BoardLocationRequired { get; set; }                 // Force users to enter locations in absentee board entries - Default: false
        [Column(Order = 62)]
        public string BatchPrintingMode { get; set; }                   // Batch all districts or one at a time - ("ALL", "SINGLE") - Default: "ALL"

        // Absentee Application Settings
        [Column(Order = 63)]
        public string ApplicationEntityName { get; set; }               // Name of the entity or county using the system - Appears on printed applications - Default: null
        [Column(Order = 64)]
        public string ApplicationClerkName { get; set; }                // Name of the county clerk - Appears on the printed applications - Default: null
        [Column(Order = 65)]
        public string ApplicationReturnAddress1 { get; set; }           // Return address for the printed application - Default: null
        [Column(Order = 66)]
        public string ApplicationReturnAddress2 { get; set; }           // - Default: null
        [Column(Order = 67)]
        public string ApplicationReturnCity { get; set; }               // - Default: null
        [Column(Order = 68)]
        public string ApplicationReturnState { get; set; }              // - Default: null
        [Column(Order = 69)]
        public string ApplicationReturnZip { get; set; }                // - Default: null
        [Column(Order = 70)]
        public string ApplicationElectionTitle { get; set; }            // English version of the election title as it should appear on the printed application - Default: null
        [Column(Order = 71)]
        public string ApplicationElectionDateLong { get; set; }         // Date spelled out in english. "Tuesday, November 3rd, 2020" - Default: null
        [Column(Order = 72)]
        public string ApplicationElectionTitleSpanish { get; set; }     // Local spanish translation of the election title as it should appear on the printed application - Default: null
        [Column(Order = 73)]
        public string ApplicationElectionDateLongSpanish { get; set; }  // Date spelled out in spanish. (Formated regionally) - Default: null


        // Ballot Return Label Settings
        [Column(Order = 74)]
        public string BallotReturnAddress1 { get; set; }                // Ballot return address label - Default: null
        [Column(Order = 75)]
        public string BallotReturnAddress2 { get; set; }                // - Default: null
        [Column(Order = 76)]
        public string BallotReturnCity { get; set; }                    // - Default: null
        [Column(Order = 77)]
        public string BallotReturnState { get; set; }                   // - Default: null
        [Column(Order = 78)]
        public string BallotReturnZip { get; set; }                     // - Default: null


        // IMB Generation Settings
        [Column(Order = 79)]
        public string IMBBarCodeId { get; set; }                        // 2 digit bar code for IMB - Default: "01" (VCC - Default: null)
        [Column(Order = 80)]
        public string IMBOutServiceTypeId { get; set; }                 // 3 digit Outgoing service type - Default: "715" (VCC - Default: null)
        [Column(Order = 81)]
        public string IMBInServiceTypeId { get; set; }                  // 3 digit Incoming service type - Default: "778" (VCC - Default: null)
        [Column(Order = 82)]
        public string IMBMailerOutGoing { get; set; }                   // 6 or 9 digit outgoing mailer id - (VCC - Default: null)
        [Column(Order = 83)]
        public string IMBMailerIncoming { get; set; }                   // 6 or 9 digit incoming mailer id - (VCC - Default: null)
        [Column(Order = 84)]
        public string IMBSerialPrefix { get; set; }                     // Characters added to the front of ballot/voter id - Default: null


        [Column(Order = 85)]
        public bool ForceUpdate { get; set; }                           // Force VoterX client to update settings in the background
        [Column(Order = 86)]
        public bool LocalOnly { get; set; }                             // Tells Election Sync to push the record up to the server
        [Column(Order = 87)]
        public DateTime LastModified { get; set; }                      // Controls when this record needs to be synced

    }
}
