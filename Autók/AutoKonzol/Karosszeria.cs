using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKonzol
{
    public class Karosszeria
    {
        public Karosszeria(int karosszeriaId, string karosszeriaNev)
        {
            KarosszeriaId = karosszeriaId;
            KarosszeriaNev = karosszeriaNev;
        }

        public int KarosszeriaId { get; set; }
        public string KarosszeriaNev { get; set; }
    }
}
