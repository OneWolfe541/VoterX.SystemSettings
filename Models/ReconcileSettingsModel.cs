using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterX.SystemSettings.Models
{
    public class ReconcileSettingsModel
    {
        public string LiteralReplacementInstructions { get; set; }

        public string AreYouSureWarning { get; set; }

        public string StartPageHeader { get; set; }
        public string StartPageBoldLine1 { get; set; }
        public string StartPageInstructions1 { get; set; }
        public string StartPageItemList { get; set; }

        public string SpoiledPageHeader { get; set; }
        public string SpoiledPageBoldLine1 { get; set; }
        public string SpoiledPageInstructions1 { get; set; }        
        public string SpoiledPageInstructions2 { get; set; }
        public string SpoiledPageInstructions3 { get; set; }
        public string SpoiledPageInstructions4 { get; set; }
        public string SpoiledPageHelpLink1 { get; set; }
        public string SpoiledPageHelpDialog1 { get; set; }
        public string SpoiledPageHelpLink2 { get; set; }
        public string SpoiledPageHelpDialog2 { get; set; }
        public string SpoiledPageHelpLink3 { get; set; }
        public string SpoiledPageHelpDialog3 { get; set; }

        public string ProvisionalPageHeader { get; set; }
        public string ProvisionalPageBoldLine1 { get; set; }
        public string ProvisionalPageInstructions1 { get; set; }
        public string ProvisionalPageInstructions2 { get; set; }
        public string ProvisionalPageHelpLink1 { get; set; }
        public string ProvisionalPageHelpDialog1 { get; set; }

        public string ApplicationPageHeader { get; set; }
        public string ApplicationPageBoldLine1 { get; set; }
        public string ApplicationPageInstructions1 { get; set; }
        public string ApplicationPageInstructions2 { get; set; }
        public string ApplicationPageHelpLink1 { get; set; }
        public string ApplicationPageHelpDialog1 { get; set; }

        public string HandTallyPageHeader { get; set; }
        public string HandTallyPageBoldLine1 { get; set; }
        public string HandTallyPageInstructions1 { get; set; }
        public string HandTallyPageHelpLink1 { get; set; }
        public string HandTallyPageHelpDialog1 { get; set; }

        public string TabulatorStartPageHeader { get; set; }
        public string TabulatorStartPageBoldLine1 { get; set; }
        public string TabulatorStartPageInstructions1 { get; set; }
        public string TabulatorPageItemList { get; set; }
        public string TabulatorStartPageInstructions2 { get; set; }

        public string TabulatorListPageHeader { get; set; }
        public string TabulatorListPageBoldLine1 { get; set; }
        public string TabulatorListPageBoldLine2 { get; set; }
        public string TabulatorListPageBoldLine3 { get; set; }
        public string TabulatorListDeleteWarning { get; set; }

        public string BalancePageHeader { get; set; }
        public string BalancePageBoldLine1 { get; set; }
        public string BalancePageBoldLine2 { get; set; }
        public string BalancePageCalculation { get; set; }
        public string BalancePageHelpLink1 { get; set; }
        public string BalancePageHelpDialog1 { get; set; }

        public string InvalidPageHeader { get; set; }
        public string InvalidPageBoldLine1 { get; set; }
        public string InvalidPageInstructions1 { get; set; }
        public string InvalidPageInstructions2 { get; set; }
        public string InvalidPageInstructions3 { get; set; }
        public string InvalidPageInstructions4 { get; set; }
        public string InvalidPageBoldLine2 { get; set; }

        public ReconcileSettingsModel()
        {

        }

        public ReconcileSettingsModel(string instructions)
        {
            LiteralReplacementInstructions = instructions;
        }
    }
}
