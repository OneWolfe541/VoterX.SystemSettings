using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterX.SystemSettings.Models
{
    public interface ITroubleShootingQuestionnaireText
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        string Description { get; set; }

        string ReportMessage { get; set; }
        string ReprintMessage { get; set; }
        string ReportQuestion { get; set; }
        string PrinterMessage { get; set; }
        string PrinterQuestion { get; set; }
        string OptionsMessage { get; set; }
        string ReprintChoiceMessage { get; set; }
        string ExitChoiceMessage { get; set; }
        string FinalMessage { get; set; }
    }
}
