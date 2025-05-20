using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKonzol
{
    public class Gyarto
    {
        public Gyarto(int gyartoId, string gyartoNev)
        {
            GyartoId = gyartoId;
            GyartoNev = gyartoNev;
        }

        public int GyartoId { get; set; }
        public string GyartoNev { get; set; }
    }
}
