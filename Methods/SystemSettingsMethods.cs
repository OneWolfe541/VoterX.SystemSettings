using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Models;
// https://www.newtonsoft.com/json
// Install-Package Newtonsoft.Json -Version 10.0.3
using Newtonsoft.Json;
using VoterX.SystemSettings.Methods;
using VoterX.SystemSettings.Enums;
using VoterX.SystemSettings.Context;
using VoterX.SystemSettings.Models.Database;

namespace VoterX.SystemSettings
{
    public enum StorageType
    {
        None,
        Binary,
        Json,
        CSV,
        Text,
        Database
    };

    /// <summary>
    /// Defines a concrete class for storing all system settings
    /// </summary>
    public class SystemSettingsController : IDisposable
    {
        private GlobalSettingsModel settings;
        private AbsenteeSettingsModel _absentee = new AbsenteeSettingsModel();
        private ListsModel _lists = new ListsModel();
        private StorageType storage = StorageType.None;
        private string _path = "C:\\VoterX\\Settings\\";
        private string _connection;
        private Guid? _systemId;
        private bool _debug = false;

        public string BODVersion { get; set; }
        public string BODName { get; set; }

        public SystemSettingsController()
        {
            settings = new GlobalSettingsModel();
            LoginSetup(settings);
            //LoggingMethods.LogSystem("SYSTEMSETTINGS CREATED WITH NO TYPE");
        }

        // Create settings object and preload from a storage device
        public SystemSettingsController(StorageType st) : this(st, null, null, null) { }
        public SystemSettingsController(StorageType st, string path, string connection) : this(st, path, connection, null) { }
        public SystemSettingsController(StorageType st, string path, string connection, Guid? id)
        {
            Console.WriteLine("Settings Created");

            settings = new GlobalSettingsModel();            
            storage = st;

            if (path != null) _path = path + "Settings\\";
            if (connection != null) _connection = connection;
            if (id != null) _systemId = id;

            switch (st)
            {
                case StorageType.Binary:
                    //LoggingMethods.LogSystem("SYSTEMSETTINGS CREATED WITH TYPE BINARY");
                    //LoadBinaryFile();
                    break;
                case StorageType.Json:
                    //LoggingMethods.LogSystem("SYSTEMSETTINGS CREATED WITH TYPE JSON");
                    LoadJsonFile();
                    break;
                case StorageType.CSV:
                    //LoggingMethods.LogSystem("SYSTEMSETTINGS CREATED WITH TYPE CSV");
                    //LoadCSVFile();
                    break;
                case StorageType.Text:
                    //LoggingMethods.LogSystem("SYSTEMSETTINGS CREATED WITH TYPE TEXT");
                    //LoadTextFile();
                    break;
                case StorageType.Database:
                    //LoggingMethods.LogSystem("SYSTEMSETTINGS CREATED WITH TYPE DATABASE");
                    LoadDatabase(_connection, _systemId); 
                    break;
                default:
                    //LoggingMethods.LogSystem("SYSTEMSETTINGS CREATED WITH TYPE DEFAULT");
                    //LoadDeafaults();
                    break;
            }
            LoginSetup(settings);
        }

        public AbsenteeSettingsModel Absentee
        {
            get { return _absentee; }
            set { _absentee = value; }
        }

        public SystemSettingsModel System
        {
            get { return settings.System; }
            set { settings.System = value; }
        }

        public SiteSettingsModel Site
        {
            get { return settings.Site; }
            set { settings.Site = value; }
        }

        public NetworkSettingsModel Network
        {
            get { return settings.Network; }
            set { settings.Network = value; }
        }

        public UserSettingsModel User
        {
            get { return settings.User; }
            set { settings.User = value; }
        }

        public PrinterSettingsModel Printers
        {
            get { return settings.Printers; }
            set { settings.Printers = value; }
        }

        public ElectionSettingsModel Election
        {
            get { return settings.Election; }
            set { settings.Election = value; }
        }

        public BallotSettingsModel Ballots
        {
            get { return settings.Ballots; }
            set { settings.Ballots = value; }
        }

        public ReportSettingsModel Reports
        {
            get { return settings.Reports; }
            set { settings.Reports = value; }
        }

        //public string Path
        //{
        //    get { return path; }
        //    private set { path = value; }
        //}

        public ListsModel Lists
        {
            get { return _lists; }
            set { _lists = value; }
        }

        public void SetElectionMode()
        {
            if (settings.System.VCCType != VotingCenterMode.SampleBallots)
            {
                if (DateTime.Now < settings.Election.ElectionDate)
                {
                    settings.System.VCCType = VotingCenterMode.EarlyVoting;
                }
                else
                {
                    settings.System.VCCType = VotingCenterMode.ElectionDay;
                }
            }
        }

        public void SetElectionMode(bool debug)
        {
            if (debug == false && settings.System.VCCType != VotingCenterMode.SampleBallots)
            {
                if (DateTime.Now < settings.Election.ElectionDate)
                {
                    settings.System.VCCType = VotingCenterMode.EarlyVoting;
                }
                else
                {
                    settings.System.VCCType = VotingCenterMode.ElectionDay;
                }
            }
        }

        public void SaveSettings()
        {
            switch (storage)
            {
                case StorageType.Binary:
                    CreateBinaryFile();
                    break;
                case StorageType.Json:
                    CreateJsonFile();
                    break;
                case StorageType.CSV:
                    //LoadCSVFile();
                    break;
                case StorageType.Text:
                    //LoadTextFile();
                    break;
                case StorageType.Database:
                    SaveDatabase(_connection, _systemId); 
                    break;
                default:
                    //LoadDeafaults();
                    break;
            }
        }

        public void SaveAbsentee()
        {
            switch (storage)
            {
                case StorageType.Binary:
                    //CreateBinaryFile();
                    break;
                case StorageType.Json:
                    CreateAbsenteeFile();
                    break;
                case StorageType.CSV:
                    //LoadCSVFile();
                    break;
                case StorageType.Text:
                    //LoadTextFile();
                    break;
                case StorageType.Database:
                    SaveDatabase(_connection, _systemId);
                    break;
                default:
                    //LoadDeafaults();
                    break;
            }
        }

        /// <summary>
        /// Define the Directory Path where the System Settings File is stored
        /// </summary>
        /// <param name="newPath"></param>
        public void SetFilePath(string newPath)
        {
            //LoggingMethods.LogSystem("SYSTEMSETTINGS FILE PATH CREATED");
            _path = newPath;
        }

        public string GetFilePath()
        {
            return _path;
        }

        /// <summary>
        /// Saves a settings object in a binary file
        /// </summary>
        public void CreateBinaryFile()
        {
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/walkthrough-persisting-an-object-in-visual-studio
            Stream settingsStream = File.Create(_path + "av.sys");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(settingsStream, settings);
            settingsStream.Close();
            //LoggingMethods.LogIO("SYSTEMSETTINGS BINARY FILE CREATED");
        }

        public void LoadJsonFile()
        {
            using (StreamReader file = new StreamReader(_path + "av.sys.json"))
            {
                string json = file.ReadToEnd();
                settings = JsonConvert.DeserializeObject<GlobalSettingsModel>(json);
            }
            //LoggingMethods.LogIO("SYSTEMSETTINGS JSON FILE LOADED");
        }

        /// <summary>
        /// Saves a settings object in a Json formated file
        /// </summary>
        public void CreateJsonFile()
        {
            // https://stackoverflow.com/questions/37199412/how-to-serialize-data-into-indented-json
            // or
            // https://stackoverflow.com/questions/2661063/how-do-i-get-formatted-json-in-net-using-c
            using (StreamWriter file = File.CreateText(_path + "av.sys.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                //serialize object directly into file stream
                serializer.Serialize(file, settings);
                //file.Close(); // I think the using statement already closes the file
            }

            //LoggingMethods.LogIO("SYSTEMSETTINGS JSON FILE CREATED");
        }

        public AbsenteeSettingsModel LoadAbsenteeFile()
        {
            try
            {
                using (StreamReader file = new StreamReader(_path + "av.abs.json"))
                {
                    string json = file.ReadToEnd();
                    return JsonConvert.DeserializeObject<AbsenteeSettingsModel>(json);
                }
            }
            catch
            {
                AbsenteeSettingsModel none = new AbsenteeSettingsModel();
                none.BODType = "";
                return none;
            }            
        }

        public bool CheckAbsenteeFile()
        {
            _absentee = LoadAbsenteeFile();
            // Absentee Mode
            if (_absentee.BODType == "XXXX")
            {                
                return true;
            }
            else
            {
                return false;
            }

            // VCC Mode
            //if (GlobalSettings.System.BODType == "f42d8b2d4e1364ed176ca8fac3c6f6a9762831b471b4421d5de6bc3c6989f941")
            //{
            //    // Then vcc type
            //    absenteeMode = false;
            //}
        }

        public void CreateAbsenteeFile()
        {
            //AbsenteeSettingsModel absentee = new AbsenteeSettingsModel();
            _absentee.BODType = "XXXX";
            // https://stackoverflow.com/questions/37199412/how-to-serialize-data-into-indented-json
            // or
            // https://stackoverflow.com/questions/2661063/how-do-i-get-formatted-json-in-net-using-c
            using (StreamWriter file = File.CreateText(_path + "av.abs.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                //serialize object directly into file stream
                serializer.Serialize(file, _absentee);
                //file.Close(); // I think the using statement already closes the file
            }

            //LoggingMethods.LogIO("SYSTEMSETTINGS JSON FILE CREATED");
        }

        private SystemContext GetSettingsContext(string connection)
        {
            if(connection == null)
            {
                return new SystemContext();
            }
            else
            {
                return new SystemContext(connection);
            }
        }

        public void LoadDatabase(string connection, Guid? id) 
        {
            using (var SystemDB = GetSettingsContext(connection))
            {
                VoterXSetting settings;
                if (id == null)
                {
                    // Select first record
                    settings = SystemDB.VoterXSettings.FirstOrDefault();
                }
                else
                {
                    // Select specific record
                    settings = SystemDB.VoterXSettings.Where(s => s.VoterXSettingId == id).FirstOrDefault();
                }

                //settings = SystemDB.VoterXSettings.FirstOrDefault();

                if (settings != null)
                {
                    this.System = new SystemSettingsModel(settings);
                    this.Site = new SiteSettingsModel(settings);
                    this.Network = new NetworkSettingsModel(settings);
                    this.Printers = new PrinterSettingsModel(settings);
                    this.Election = new ElectionSettingsModel(settings);
                    this.Ballots = new BallotSettingsModel(settings);
                    this.Reports = new ReportSettingsModel(settings);
                    this.Absentee = new AbsenteeSettingsModel(settings);

                    // Reset force update flag
                    if(settings.ForceUpdate == true)
                    {
                        // Set new values
                        settings.ForceUpdate = false;
                        settings.LocalOnly = true;
                        settings.LastModified = DateTime.Now;

                        try
                        {
                            // Save changes
                            SystemDB.SaveChanges();
                        }
                        catch (Exception error)
                        {
                            var message = error.Message;
                        }
                    }
                }
            }
        }
        
        public void SaveDatabase(string connection, Guid? id)
        {
            using (var SystemDB = GetSettingsContext(connection))
            {
                VoterXSetting settings;
                if (id == null)
                {
                    settings = SystemDB.VoterXSettings.FirstOrDefault();
                }
                else
                {
                    settings = SystemDB.VoterXSettings.Where(s => s.SystemId == id).FirstOrDefault();
                }

                if (settings != null)
                {
                    // UPDATE RECORD
                    //settings = ConversionMethods.ConvertToDatabase(this);

                    // System Settings
                    //settings.SystemId = this.System.SystemId;
                    settings.SystemName = this.System.MachineName;
                    settings.PollId = this.System.SiteID.Value;
                    settings.PlaceName = this.System.SiteName;
                    settings.Computer = this.System.MachineID;
                    settings.Verified = this.System.SiteVerified;
                    settings.SearchType = (int?)this.System.SearchOptions;
                    settings.VCCType = (int)this.System.VCCType;
                    settings.BallotStub = this.System.BallotStub;
                    settings.Permit = this.System.Permit;
                    settings.SignatureFolder = this.System.SignatureFolder;
                    settings.LoginType = this.System.LoginType;
                    settings.IdRequired = this.System.IdRequired;
                    settings.TimeOut = this.System.TimeOut;
                    settings.PDFTools = this.System.PDFTools;

                    // Site Settings
                    settings.EarlyVotingPollId = this.Site.EarlyVotingSiteID;
                    settings.EarlyVotingPlaceName = this.Site.EarlVotingSiteName;
                    settings.ElectionDayPollId = this.Site.ElectionDaySiteID;
                    settings.ElectionDayPlaceName = this.Site.ElectionDaySiteName;
                    settings.HybridLocation = this.Site.HybridLocation.Value;

                    // Network Settings
                    settings.SQLMode = this.Network.SQLMode;
                    settings.SQLServerName = this.Network.SQLServer;
                    settings.DatabaseName = this.Network.LocalDatabase;

                    // Printer Settings
                    settings.BallotPrinter = this.Printers.BallotPrinter;
                    settings.BallotSize = this.Printers.BallotSize;
                    settings.BallotBin = this.Printers.BallotBin;

                    settings.ApplicationPrinter = this.Printers.ApplicationPrinter;
                    settings.AppSize = this.Printers.AppSize;
                    settings.AppBin = this.Printers.AppBin;

                    settings.ReportPrinter = this.Printers.ReportPrinter;
                    settings.ReportSize = this.Printers.ReportSize;
                    settings.ReportBin = this.Printers.ReportBin;

                    settings.LabelPrinter = this.Printers.LabelPrinter;
                    settings.LabelSize = this.Printers.LabelSize;
                    settings.LabelBin = this.Printers.LabelBin;

                    // Election Settings
                    settings.ElectionId = this.Election.ElectionID;
                    settings.CountyCode = this.Election.CountyCode;
                    settings.ElectionType = (int)this.Election.ElectionType;
                    settings.ElectionEntity = this.Election.ElectionEntity;
                    settings.ElectionTitle = this.Election.ElectionTitle;
                    settings.ElectionDate = this.Election.ElectionDate;
                    settings.EligibleParties = PartiesToString(this.Election.EligibleParties);

                    // Ballot Settings
                    settings.BallotFolder = this.Ballots.BallotFolder;
                    settings.ProvisionalPrefix = this.Ballots.ProvisionalPrefix;
                    settings.SamplePrefix = this.Ballots.SamplePrefix;
                    settings.Duplex = this.Ballots.Duplex;
                    settings.IncludeBallotStyleId = this.Ballots.IncludeBallotStyleId;
                    settings.ExcludeBallotStyleId = this.Ballots.ExcludeBallotStyleId;
                    settings.LabelCount = this.Ballots.LabelCount;
                    settings.IncludePartyOnLabel = this.Ballots.IncludePartyOnLabel;

                    // Report Settings
                    settings.ReportsFolder = this.Reports.ReportsFolder;
                    settings.ExcelExportFolder = this.Reports.ExcelExportFolder;
                    settings.ExcelExportFileName = this.Reports.ExcelExportFile;
                    settings.ReconcileCopies = this.Reports.ReconcileCopies;

                    // Absentee System Settings
                    settings.AbsenteePollId = this.Absentee.SiteID;
                    settings.AbsenteePlaceName = this.Absentee.SiteName;
                    settings.AllMailMode = this.Absentee.AllMailMode;
                    settings.ScanOnlyMode = this.Absentee.ScanOnly;
                    settings.VoteInPerson = this.Absentee.CanVoteInPersonOnThisMachine.Value;
                    settings.BoardLocationRequired = this.Absentee.BoardLocationRequired.Value;
                    settings.BatchPrintingMode = this.Absentee.BatchPrintingMode;

                    // Absentee Application Settings
                    settings.ApplicationEntityName = this.Absentee.CountyName;
                    settings.ApplicationClerkName = this.Absentee.ClerkName;
                    settings.ApplicationReturnAddress1 = this.Absentee.ApplicationReturnAddress1;
                    settings.ApplicationReturnAddress2 = this.Absentee.ApplicationReturnAddress2;
                    settings.ApplicationReturnCity = this.Absentee.ApplicationReturnCity;
                    settings.ApplicationReturnState = this.Absentee.ApplicationReturnState;
                    settings.ApplicationReturnZip = this.Absentee.ApplicationReturnZip;
                    settings.ApplicationElectionTitle = this.Absentee.ElectionTitle;
                    settings.ApplicationElectionDateLong = this.Absentee.ElectionDateLong;
                    settings.ApplicationElectionTitleSpanish = this.Absentee.ElectionTitle;
                    settings.ApplicationElectionDateLongSpanish = this.Absentee.ElectionDateLongSpanish;

                    // Ballot Return Label Settings
                    settings.BallotReturnAddress1 = this.Absentee.BallotReturnAddress1;
                    settings.BallotReturnAddress2 = this.Absentee.BallotReturnAddress2;
                    settings.BallotReturnCity = this.Absentee.BallotReturnCity;
                    settings.BallotReturnState = this.Absentee.BallotReturnState;
                    settings.BallotReturnZip = this.Absentee.BallotReturnZip;

                    // IMB Generation Settings
                    settings.IMBBarCodeId = this.Absentee.IMBBarCodeId;
                    settings.IMBOutServiceTypeId = this.Absentee.IMBOutServiceTypeId;
                    settings.IMBInServiceTypeId = this.Absentee.IMBInServiceTypeId;
                    settings.IMBMailerOutGoing = this.Absentee.IMBOutGoing;
                    settings.IMBMailerIncoming = this.Absentee.IMBIncoming;
                    settings.IMBSerialPrefix = this.Absentee.IMBPrefix;

                    settings.ForceUpdate = false;
                    settings.LocalOnly = true;
                    settings.LastModified = DateTime.Now;

                    try
                    {
                        SystemDB.SaveChanges();
                    }
                    catch (Exception error)
                    {
                        var message = error.Message;
                    }
                }
            }
        }

        public void SaveDatabase(string connection, Guid? id, bool update)
        {
            using (var SystemDB = GetSettingsContext(connection))
            {
                VoterXSetting settings;
                if (id == null)
                {
                    settings = SystemDB.VoterXSettings.FirstOrDefault();
                }
                else
                {
                    settings = SystemDB.VoterXSettings.Where(s => s.SystemId == id).FirstOrDefault();
                }

                if (settings != null)
                {
                    // UPDATE RECORD
                    settings.ForceUpdate = update;
                    settings.LocalOnly = true;
                    settings.LastModified = DateTime.Now;

                    try
                    {
                        SystemDB.SaveChanges();
                    }
                    catch (Exception error)
                    {
                        var test = error;
                    }
                }
            }
        }

        public bool CheckForUpdate()
        {
            bool result = false;

            // Check storage type
            if(storage == StorageType.Database)
            {
                // Create context
                using (var SystemDB = GetSettingsContext(_connection))
                {
                    // Get update flag
                    var id = this.System.SystemId;
                    bool requireUpdate = SystemDB.VoterXSettings.Where(s => s.VoterXSettingId == id).Select(r => r.ForceUpdate).FirstOrDefault();

                    if (requireUpdate == true)
                    {
                        result = requireUpdate;

                        // Load new settings
                        LoadDatabase(_connection, id);

                        // Reset update flag
                        //SaveDatabase(_connection, _systemId, false);
                    }
                }
            }

            return result;
        }

        private string PartiesToString(List<string> partyList)
        {
            if (partyList != null)
            {
                //string parties = "";
                //foreach (string party in partyList)
                //{
                //    parties += "," + party;
                //}
                //return parties;
                return String.Join(",", partyList);
            }
            else
            {
                return null;
            }
        }

        public DebugSettingModel LoadDebugFile(string path)
        {
            _path = path;
            return LoadDebugFile();
        }

        public string GetDebugFile(string path)
        {
            using (StreamReader file = new StreamReader(path + "av.debug.json"))
            {
                return file.ReadToEnd();
            }
        }

        public DebugSettingModel LoadDebugFile()
        {
            try
            {
                using (StreamReader file = new StreamReader(_path + "av.debug.json"))
                {
                    string json = file.ReadToEnd();
                    return JsonConvert.DeserializeObject<DebugSettingModel>(json);
                }
            }
            catch
            {
                DebugSettingModel none = new DebugSettingModel();
                none.DebugMode = false;
                return none;
            }
        }

        public bool CheckDebugFile()
        {
            DebugSettingModel debug = LoadDebugFile();
            // Absentee Mode
            if (debug.DebugMode == true)
            {
                _debug = true;
                return true;
            }
            else
            {
                _debug = false;
                return false;
            }
        }

        public bool GetDebugMode()
        {
            return _debug;
        }


        public void CreateDebugFile()
        {
            DebugSettingModel debug = new DebugSettingModel();
            debug.DebugMode = true;
            // https://stackoverflow.com/questions/37199412/how-to-serialize-data-into-indented-json
            // or
            // https://stackoverflow.com/questions/2661063/how-do-i-get-formatted-json-in-net-using-c
            using (StreamWriter file = File.CreateText(_path + "av.debug.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                //serialize object directly into file stream
                serializer.Serialize(file, debug);
                //file.Close(); // I think the using statement already closes the file
            }

            //LoggingMethods.LogIO("SYSTEMSETTINGS JSON FILE CREATED");
        }

        public UserSettingsModel LoadUserFile()
        {
            try
            {
                using (StreamReader file = new StreamReader(_path + "av.usr.json"))
                {
                    string json = file.ReadToEnd();
                    var user = JsonConvert.DeserializeObject<UserSettingsModel>(json);
                    //settings.User.UserName = user.UserName;
                    return user;
                }
            }
            catch
            {
                UserSettingsModel none = new UserSettingsModel();
                none.UserName = "";
                return none;
            }
        }

        //internal void CreatePrinterListFile(List<PrinterLookupModel> PrinterListToSave)
        //{
        //    // https://stackoverflow.com/questions/37199412/how-to-serialize-data-into-indented-json
        //    // or
        //    // https://stackoverflow.com/questions/2661063/how-do-i-get-formatted-json-in-net-using-c
        //    using (StreamWriter file = File.CreateText(path + "av.pr.json"))
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        serializer.Formatting = Formatting.Indented;
        //        //serialize object directly into file stream
        //        serializer.Serialize(file, PrinterListToSave);
        //        //file.Close(); // I think the using statement already closes the file
        //    }

        //    //LoggingMethods.LogIO("SYSTEMSETTINGS JSON FILE CREATED");
        //}

        //internal List<PrinterLookupModel> LoadPrinterListFile()
        //{
        //    try
        //    {
        //        using (StreamReader file = new StreamReader(path + "av.pr.json"))
        //        {
        //            string json = file.ReadToEnd();
        //            return JsonConvert.DeserializeObject<List<PrinterLookupModel>>(json);
        //        }
        //    }
        //    catch
        //    {
        //        //List<PrinterLookupModel> none = new List<PrinterLookupModel>();
        //        return null;
        //    }
        //}

        public async Task<bool> LoadPrinterLists()
        {
            // Set loading Flag
            _lists.PrintersLoaded = false;

            // Load printers list from either file or OS
            _lists.Printers = await PrinterMethods.LoadPrinterLists(_path);

            // Check if lists finished loading
            if (_lists.Printers.Count() > 0)
            {
                _lists.PrintersLoaded = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ReloadPrinterLists()
        {
            // Set loading Flag
            _lists.PrintersLoaded = false;

            // Load printers list from either file or OS
            _lists.Printers = await PrinterMethods.ReloadPrinterLists(_path);

            // Check if lists finished loading
            if (_lists.Printers.Count() > 0)
            {
                _lists.PrintersLoaded = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LoginSetup(GlobalSettingsModel login)
        {
            login.User.AdminPassword = "7117";
            login.User.ManagePassword = "7537";
            login.User.GlobalPassword = "7717";
            login.User.BoardPassword = "7657";
            login.User.SuperPassword = "7357";
        }

        public void Dispose()
        {
            Console.WriteLine("Settings Disposed");
        }
    }
}
