using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKonzol
{
    public class Auto
    {
        public int Azonosito { get; set; }
        public int Evjarat { get; set; }
        public Gyarto Gyarto { get; set; }
        public string Modell { get; set; }
        public int KilometerAllas { get; set; }
        public Karosszeria Karosszeria { get; set; }
        public int HengerekSzama { get; set; }
        public Valto Valto { get; set; }
        public string KulsoSzin { get; set; }
        public string BelsoSzin { get; set; }
        public int SzemelyekSzama { get; set; }
        public int Ajtok { get; set; }
        public double FogyasztasVarosban { get; set; }
        public double FogyasztasAutopalyan { get; set; }
        public int Ar { get; set; }

        public Auto(int azonosito, int evjarat, Gyarto gyarto, string modell, int kilometerAllas, Karosszeria karosszeria, int hengerekSzama, Valto valto, string kulsoSzin, string belsoSzin, int szemelyekSzama, int ajtok, double fogyasztasVarosban, double fogyasztasAutopalyan, int ar)
        {
            Azonosito = azonosito;
            Evjarat = evjarat;
            Gyarto = gyarto;
            Modell = modell;
            KilometerAllas = kilometerAllas;
            Karosszeria = karosszeria;
            HengerekSzama = hengerekSzama;
            Valto = valto;
            KulsoSzin = kulsoSzin;
            BelsoSzin = belsoSzin;
            SzemelyekSzama = szemelyekSzama;
            Ajtok = ajtok;
            FogyasztasVarosban = fogyasztasVarosban;
            FogyasztasAutopalyan = fogyasztasAutopalyan;
            Ar = ar;
        }

        public static List<Auto> LoadFromCSV(string path)
        {
            List<Auto> autok = new List<Auto>();

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines.Skip(1))
            {
                string[] v = line.Split(';');

                int Azonosito = int.Parse(v[0]);
                int Evjarat = int.Parse(v[1]);
                Gyarto Gyarto = new(int.Parse(v[2]), v[3]);
                string Modell = v[4];
                int KilometeroraAllas = int.Parse(v[5]);
                Karosszeria Karosszeria = new(int.Parse(v[6]), v[7]);
                int HengerekSzama = int.Parse(v[8]);
                Valto Valto = new(int.Parse(v[9]), v[10]);
                string KulsoSzin = v[11];
                string BelsoSzin = v[12];
                int SzemelyekSzama = int.Parse(v[13]);
                int Ajtok = int.Parse(v[14]);
                double FogyasztasVarosban = double.Parse(v[15]);
                double FogyasztasAutopalyan = double.Parse(v[16]);
                int Ar = int.Parse(v[17]);

                Auto auto = new(Azonosito, Evjarat, Gyarto, Modell, KilometeroraAllas, Karosszeria, HengerekSzama, Valto, KulsoSzin, BelsoSzin, SzemelyekSzama, Ajtok, FogyasztasVarosban, FogyasztasAutopalyan, Ar);
                autok.Add(auto);
            } 
            return autok;
        }

        public override string ToString()
        {
            return $"\tGyártó - modell: {Gyarto.GyartoNev} - {Modell}\n\tFogyasztás: {Math.Round((FogyasztasAutopalyan + FogyasztasVarosban) / 2), 2} l/100 km\n\tKilométeróra állása: {KilometerAllas} km\n\tVáltó típusa: {Valto.ValtoNev}\n\tÁra (CAD): {Ar}";

        }

    }
}
