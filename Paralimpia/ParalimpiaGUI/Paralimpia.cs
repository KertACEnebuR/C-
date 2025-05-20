using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParalimpiaGUI
{
    class Paralimpia
    {
        public int Id { get; set; }
        public string Orszag { get; set; }
        public string Varos { get; set; }
        public int Ev { get; set; }
        public int Arany { get; set; }
        public int Ezust { get; set; }
        public int Bronz { get; set; }

        public Paralimpia(int id, string orszag, string varos, int ev, int arany, int ezust, int bronz)
        {
            Id = id;
            Orszag = orszag;
            Varos = varos;
            Ev = ev;
            Arany = arany;
            Ezust = ezust;
            Bronz = bronz;
        }

        public static List<Paralimpia> FromFile(string path)
        {
            List<Paralimpia> sporolok = new List<Paralimpia>();

            foreach (var l in File.ReadAllLines(path))
            {
                string[] v = l.Split("\t");

                int Id = int.Parse(v[0]);
                string Orszag = v[1];
                string Varos = v[2];
                int Ev = int.Parse(v[3]);
                int Arany = int.Parse(v[4]);
                int Ezust = int.Parse(v[5]);
                int Bronz = int.Parse(v[6]);

                Paralimpia sporolo = new(Id, Orszag, Varos, Ev, Arany, Ezust, Bronz);
                sporolok.Add(sporolo);
            }
            return sporolok;
        } 
    }
}
