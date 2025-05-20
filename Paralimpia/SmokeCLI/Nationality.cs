using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeCLI
{
    internal class Nationality
    {
        public Nationality(int nationalityID, string nationalityName)
        {
            NationalityID = nationalityID;
            NationalityName = nationalityName;
        }

        public int NationalityID { get; set; }
        public string NationalityName { get; set; }
    }
}
