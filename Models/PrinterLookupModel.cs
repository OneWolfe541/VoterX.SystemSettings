using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterX.SystemSettings.Models
{
    public class PrinterLookupModel
    {
        public string PrinterName { get; set; }
        public List<PrinterTray> Bins { get; set; }
        public List<PaperSize> PaperSizes { get; set; }        
    }
}
