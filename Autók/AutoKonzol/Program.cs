namespace AutoKonzol
{
    internal class Program
    {
        List<Auto> autok = new List<Auto>();
        static void Main(string[] args)
        {
            var autok = Auto.LoadFromCSV(@"..\..\..\src\carsData.csv");

            var f6 = autok.Where(a => a.Gyarto.GyartoNev.Contains("Rolls-Royce") && a.Karosszeria.KarosszeriaNev.Contains("Sedan") && a.HengerekSzama == 8).Count();

            Console.WriteLine($"6. feladat - 8 hengeres, Rolls-Royse sedanok száma az adott időszakban: {f6} db");

            Console.WriteLine("7. fladat - A legdrágább autó");
            var f7 = autok.OrderByDescending(a => a.Ar).First();

            Console.WriteLine($"{f7.Azonosito}. autó\n{f7.ToString()}\n\tÁra (HUF): {Math.Round(f7.Ar * 248.02)}");

            Console.WriteLine("8. feladat - Adatok fájlba írása");

            string[] markak = new string[] { "Aston Martin", "Ferrari", "McLaren", "Mercedes-Benz", "Prosche" };
            var f8 = autok.Where(a => markak.Contains(a.Gyarto.GyartoNev)).Select(a => $"{a.Azonosito};{a.Gyarto.GyartoNev};{a.Modell};{a.Evjarat};{a.KilometerAllas}").ToList();

            File.WriteAllLines(@"..\..\..\src\forma-1.txt", f8);
        }
    }
}
