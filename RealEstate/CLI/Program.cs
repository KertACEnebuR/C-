using System;
using System.Drawing;
using System.Globalization;

namespace RealestateCLI
{
    internal class Program
    {
        List<Ad> ads = new List<Ad>();
        static void Main(string[] args)
        {
            var ads = Ad.LoadFromCsv(@"../../../SRC/realestates.csv");

            var FoldszintiAtlagAlapterulet = ads.Where(e => e.Floors == 0).Average(e => e.Area);

            Console.WriteLine($"1. Földszinti ingatlanok átlagos alapterülete: {Math.Round(FoldszintiAtlagAlapterulet, 2)} m2");

            double MeseVarC1 = 47.4164220114023;
            double MeseVarC2 = 19.066342425796986;

            var Legkozelebbi = ads
                .Where(e => e.FreeOfCharge)
                .OrderBy(e => DistanceTo(e, MeseVarC1, MeseVarC2))
                .FirstOrDefault();


            Console.WriteLine($"2. A mesevár...:" +
                $"\n\tEladó neve\t: {Legkozelebbi.Seller.Name}" +
                $"\n\tEladó Telefonja\t: {Legkozelebbi.Seller.Phone}" +
                $"\n\tAlapterület\t: {Legkozelebbi.Area}" +
                $"\n\tSzobák száma\t: {Legkozelebbi.Rooms}");
        }

        public static double DistanceTo(Ad ingatlan, double refLat, double refLon)
        {
            string[] parts = ingatlan.Latlong.Split(',');

            double ingatlanLat = double.Parse(parts[0], CultureInfo.InvariantCulture);
            double ingatlanLon = double.Parse(parts[1], CultureInfo.InvariantCulture);

            double dLat = ingatlanLat - refLat;
            double dLon = ingatlanLon - refLon;

            return Math.Sqrt(Math.Pow(dLat, 2) + Math.Pow(dLon, 2));
        }
    }
}