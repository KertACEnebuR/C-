using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlayAppsCLI
{
    public class App
    {
        public string AppName { get; set; }
        public Category Category { get; set; }
        public ContentRating ContentRating { get; set; }
        public double Rating { get; set; }
        public string Reviews { get; set; }
        public string CurrentVer { get; set; }
        public int UpdateYear { get; set; }
        public int UpdateMonth { get; set; }


        public App(string appName, Category category, ContentRating contentRating, double rating, string reviews, string currentVer, int updateYear, int updateMonth)
        {
            AppName = appName;
            Category = category;
            ContentRating = contentRating;
            Rating = rating;
            Reviews = reviews;
            CurrentVer = currentVer;
            UpdateYear = updateYear;
            UpdateMonth = updateMonth;
        }

        public static List<App> LoadFromCSV(string path)
        {
            List<App> apps = new List<App>();

            string[] lines = File.ReadAllLines(path);

            foreach (var l in lines.Skip(1))
            {
                string[] v = l.Split(';');

                string AppName = v[0];
                Category Category = new(int.Parse(v[1]), v[2]);
                ContentRating ContentRating = new(int.Parse(v[3]), v[4]);
                double Rating = double.Parse(v[5].Replace('.', ','));
                string Reviews = v[6];
                string CurrentVer = v[7];
                int UpdateYear = int.Parse(v[8]);
                int UpdateMonth = int.Parse(v[9]);

                App app = new(AppName, Category, ContentRating, Rating, Reviews, CurrentVer, UpdateYear, UpdateMonth);
                apps.Add(app);
            }
            return apps;
        }

        public string StarRating(double ratings)
        {
            if (ratings != -1)
            {
                double roundedRating = Math.Round(ratings);
                string stars = string.Empty;

                for (int i = 0; i < roundedRating; i++)
                {
                    stars += "*";
                }
                return stars;
            }
            else
            {
                return "-";
            }
        }
                

        public override string ToString()
        {
            return $"{AppName} {StarRating(Rating)}";
        }

    }
}
