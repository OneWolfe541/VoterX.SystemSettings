using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterX.SystemSettings.Models.TroubleShooting
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ApplicationTroubleshootingQuestionnaireText : ITroubleShootingQuestionnaireText
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Description { get; set; }

        public string ReportMessage { get; set; }
        public string ReprintMessage { get; set; }
        public string ReportQuestion { get; set; }
        public string PrinterMessage { get; set; }
        public string PrinterQuestion { get; set; }
        public string OptionsMessage { get; set; }
        public string ReprintChoiceMessage { get; set; }
        public string ExitChoiceMessage { get; set; }
        public string FinalMessage { get; set; }
    }
}
