using System.Linq;

namespace GooglePlayAppsCLI
{
    internal class Program
    {
        List<App> apps = new List<App>();
        static void Main(string[] args)
        {
            var apps = App.LoadFromCSV(@"..\..\..\src\apps.csv");

            //6. feladat
            int index = 1;
            foreach (var app in apps)
            {
                Console.WriteLine($"{index}. {app.ToString()}");
                index += 1; 
            }

            //7. feladat 
            var f7date = apps.OrderByDescending(a => FormattedDate(a.UpdateYear, a.UpdateMonth)).First();

            var f7 = apps.Where(a => a.ContentRating.ContentRatingName.Contains("Everyone") && a.Category.CategoryName.Contains("PHOTOGRAPHY") && a.UpdateYear == f7date.UpdateYear && a.UpdateMonth == f7date.UpdateMonth)
                         .OrderByDescending(a => f7date)
                         .ToList();

            Console.WriteLine($"Frissítve: {f7date.UpdateYear}.{f7date.UpdateMonth}");
            foreach (var i in f7)
            {
                Console.WriteLine(i.ToString());
            }

            //8. feladat
            var f8 = apps.OrderByDescending(a => a.Rating).Select(a => (a.Rating == -1 ? "NO RESULT" : a.Rating) + "\t" + $"{a.AppName}-{a.CurrentVer}");

            File.WriteAllLines(@"..\..\..\src\bests.txt", f8);

        }

        public static DateTime FormattedDate(int year, int month)
        {
            return new DateTime(year, month, 1);
        } 
    }
}
