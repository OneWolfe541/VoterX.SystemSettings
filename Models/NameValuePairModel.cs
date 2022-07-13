using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterX.SystemSettings.Models
{
    public class NameValuePairModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public NameValuePairModel() { }

        public NameValuePairModel(int id, string desc)
        {
            Id = id;
            Description = desc;
        }
    }

    public class NameCharPairModel
    {
        public string Char { get; set; }
        public string Description { get; set; }

        public NameCharPairModel() { }

        public NameCharPairModel(string character, string desc)
        {
            Char = character;
            Description = desc;
        }
    }
}
