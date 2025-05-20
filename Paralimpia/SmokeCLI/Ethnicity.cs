using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeCLI
{
    internal class Ethnicity
    {
        public Ethnicity(int ethnicityID, string ethnicityName)
        {
            EthnicityID = ethnicityID;
            EthnicityName = ethnicityName;
        }

        public int EthnicityID { get; set; }
        public string EthnicityName { get; set; }
    }
}
