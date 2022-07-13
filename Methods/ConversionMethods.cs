using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Models.Database;

namespace VoterX.SystemSettings
{
    public static class ConversionMethods
    {
        public static VoterXSetting ConvertToDatabase(this VoterXSetting entity, SystemSettingsController settings)
        {
            VoterXSetting newSettings = new VoterXSetting()
            {
                // System Settings
                SystemId = settings.System.SystemId,
                SystemName = settings.System.MachineName,
                PollId = settings.System.SiteID.Value,
                PlaceName = settings.System.SiteName,
                Computer = settings.System.MachineID,
                Verified = settings.System.SiteVerified,
                SearchType = (int?)settings.System.SearchOptions,
                VCCType = (int)settings.System.VCCType,
                BallotStub = settings.System.BallotStub,
                Permit = settings.System.Permit,
                SignatureFolder = settings.System.SignatureFolder,
                LoginType = settings.System.LoginType,
                IdRequired = settings.System.IdRequired,
                TimeOut = settings.System.TimeOut,
                PDFTools = settings.System.PDFTools,

                // Site Settings
                EarlyVotingPollId = settings.Site.EarlyVotingSiteID,
                EarlyVotingPlaceName = settings.Site.EarlVotingSiteName,
                ElectionDayPollId = settings.Site.ElectionDaySiteID,
                ElectionDayPlaceName = settings.Site.ElectionDaySiteName,
                HybridLocation = settings.Site.HybridLocation.Value,

                // Network Settings
                SQLMode = settings.Network.SQLMode,
                SQLServerName = settings.Network.SQLServer,
                DatabaseName = settings.Network.LocalDatabase,

                // Printer Settings
                BallotPrinter = settings.Printers.BallotPrinter,
                BallotSize = settings.Printers.BallotSize,
                BallotBin = settings.Printers.BallotBin,

                ApplicationPrinter = settings.Printers.BallotPrinter,
                AppSize = settings.Printers.AppSize,
                AppBin = settings.Printers.AppBin,

                ReportPrinter = settings.Printers.BallotPrinter,
                ReportSize = settings.Printers.ReportSize,
                ReportBin = settings.Printers.ReportBin,

                LabelPrinter = settings.Printers.BallotPrinter,
                LabelSize = settings.Printers.LabelSize,
                LabelBin = settings.Printers.LabelBin,

                // Election Settings
                ElectionId = settings.Election.ElectionID,
                CountyCode = settings.Election.CountyCode,
                ElectionType = (int)settings.Election.ElectionType,
                ElectionEntity = settings.Election.ElectionEntity,
                ElectionTitle = settings.Election.ElectionTitle,
                ElectionDate = settings.Election.ElectionDate,
                EligibleParties = PartiesToString(settings.Election.EligibleParties),

                // Ballot Settings
                BallotFolder = settings.Ballots.BallotFolder,
                ProvisionalPrefix = settings.Ballots.ProvisionalPrefix,
                SamplePrefix = settings.Ballots.SamplePrefix,
                Duplex = settings.Ballots.Duplex,
                IncludeBallotStyleId = settings.Ballots.IncludeBallotStyleId,
                ExcludeBallotStyleId = settings.Ballots.ExcludeBallotStyleId,
                LabelCount = settings.Ballots.LabelCount,
                IncludePartyOnLabel = settings.Ballots.IncludePartyOnLabel,

                // Report Settings
                ReportsFolder = settings.Reports.ReportsFolder,
                ExcelExportFolder = settings.Reports.ExcelExportFolder,
                ExcelExportFileName = settings.Reports.ExcelExportFile,
                ReconcileCopies = settings.Reports.ReconcileCopies,

                // Absentee System Settings
                AbsenteePollId = settings.Absentee.SiteID,
                AbsenteePlaceName = settings.Absentee.SiteName,
                AllMailMode = settings.Absentee.AllMailMode,
                ScanOnlyMode = settings.Absentee.ScanOnly,
                VoteInPerson = settings.Absentee.CanVoteInPersonOnThisMachine.Value,
                BoardLocationRequired = settings.Absentee.BoardLocationRequired.Value,
                BatchPrintingMode = settings.Absentee.BatchPrintingMode,

                // Absentee Application Settings
                ApplicationEntityName = settings.Absentee.CountyName,
                ApplicationClerkName = settings.Absentee.ClerkName,
                ApplicationReturnAddress1 = settings.Absentee.ApplicationReturnAddress1,
                ApplicationReturnAddress2 = settings.Absentee.ApplicationReturnAddress2,
                ApplicationReturnCity = settings.Absentee.ApplicationReturnCity,
                ApplicationReturnState = settings.Absentee.ApplicationReturnState,
                ApplicationReturnZip = settings.Absentee.ApplicationReturnZip,
                ApplicationElectionTitle = settings.Absentee.ElectionTitle,
                ApplicationElectionDateLong = settings.Absentee.ElectionDateLong,
                ApplicationElectionTitleSpanish = settings.Absentee.ElectionTitle,
                ApplicationElectionDateLongSpanish = settings.Absentee.ElectionDateLongSpanish,

                // Ballot Return Label Settings
                BallotReturnAddress1 = settings.Absentee.BallotReturnAddress1,
                BallotReturnAddress2 = settings.Absentee.BallotReturnAddress2,
                BallotReturnCity = settings.Absentee.BallotReturnCity,
                BallotReturnState = settings.Absentee.BallotReturnState,
                BallotReturnZip = settings.Absentee.BallotReturnZip,

                // IMB Generation Settings
                IMBBarCodeId = settings.Absentee.IMBBarCodeId,
                IMBOutServiceTypeId = settings.Absentee.IMBOutServiceTypeId,
                IMBInServiceTypeId = settings.Absentee.IMBInServiceTypeId,
                IMBMailerOutGoing = settings.Absentee.IMBOutGoing,
                IMBMailerIncoming = settings.Absentee.IMBIncoming,
                IMBSerialPrefix = settings.Absentee.IMBPrefix,

                LastModified = DateTime.Now
            };

            return newSettings;
        }

        private static string PartiesToString(List<string> partyList)
        {
            if(partyList != null)
            {
                string parties = "";
                foreach(string party in partyList)
                {
                    parties += "," + party;
                }
                return parties;
            }
            else
            {
                return null;
            }
        }
    }
}
