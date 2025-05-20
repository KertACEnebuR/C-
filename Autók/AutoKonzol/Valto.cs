using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKonzol
{
    public class Valto
    {
        public Valto(int valtoId, string valtoNev)
        {
            ValtoId = valtoId;
            ValtoNev = valtoNev;
        }

        public int ValtoId { get; set; }
        public string ValtoNev { get; set; }
    }
}
