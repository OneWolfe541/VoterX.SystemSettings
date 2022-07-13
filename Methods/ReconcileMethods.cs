using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoterX.SystemSettings.Models;
using Newtonsoft.Json;

namespace VoterX.SystemSettings.Methods
{
    public static class ReconcileMethods
    {
        public static ReconcileSettingsModel Create()
        {
            return new ReconcileSettingsModel(
                "LITERAL STRINGS CAN BE REPLACED WITH VALUES OR DATA FIELDS: \r\n"
                + "[APP] = Application or Permit\r\n"
                + "[REG] = AvReconciles.Regular\r\n"
                + "[COMREG] = AvReconciles.ComputerRegular"
                + "[SPOIL] = AvReconciles.Spoiled\r\n"
                + "[COMSPOIL] = AvReconciles.ComputerSpoiled"
                + "[PROV] = AvReconciles.Provisional\r\n"
                + "[COMPROV] = AvReconciles.ComputerProvisional"
                + "[HAND] = AvReconciles.HandTally\r\n"
                + "[COMWRONG] = Count of Wrong Voters\r\n"
                + "[COMFLED] = Count of Fled Voters");
        }

        public static ReconcileSettingsModel LoadJsonFile(string path)
        {
            using (StreamReader file = new StreamReader(path + "av.rec.json"))
            {
                try
                {
                    string json = file.ReadToEnd();
                    return JsonConvert.DeserializeObject<ReconcileSettingsModel>(json);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Saves a settings object in a Json formated file
        /// </summary>
        public static void CreateJsonFile(string path, ReconcileSettingsModel settings)
        {
            // https://stackoverflow.com/questions/37199412/how-to-serialize-data-into-indented-json
            // or
            // https://stackoverflow.com/questions/2661063/how-do-i-get-formatted-json-in-net-using-c
            using (StreamWriter file = File.CreateText(path + "av.rec.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                //serialize object directly into file stream
                serializer.Serialize(file, settings);
                //file.Close(); // I think the using statement already closes the file
            }
        }

        public static void CreateJsonFile(string path)
        {
            CreateJsonFile(path, Create());
        }
    }
}
