using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Extensions;

namespace VoterX.SystemSettings.Enums
{
    public enum ElectionType : int
    {
        None = 0,

        [StringValue("Primary")]
        Primary = 1,

        [StringValue("General")]
        General = 2,

        [StringValue("All Mail")]
        AllMail = 3
    }
}
