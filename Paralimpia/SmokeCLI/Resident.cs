using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeCLI
{
    internal class Resident
    {
        public int Age { get; set; }
        public string AmtWeekydays { get; set; }
        public string AmtWeekyends { get; set; }
        public Ethnicity Ethnicity { get; set; }
        public string Gender { get; set; }
        public string GrossIncome { get; set; }
        public string MaritalStatus { get; set; }
        public Nationality Nationality { get; set; }
        public string Qualification { get; set; }
        public string Region { get; set; }
        public string Smoke { get; set; }
        public string Type { get; set; }

        public Resident(int age, string amtWeekydays, string amtWeekyends, Ethnicity ethnicity, string gender, string grossIncome, string maritalStatus, Nationality nationality, string qualification, string region, string smoke, string type)
        {
            Age = age;
            AmtWeekydays = amtWeekydays;
            AmtWeekyends = amtWeekyends;
            Ethnicity = ethnicity;
            Gender = gender;
            GrossIncome = grossIncome;
            MaritalStatus = maritalStatus;
            Nationality = nationality;
            Qualification = qualification;
            Region = region;
            Smoke = smoke;
            Type = type;
        }

        public static List<Resident> FromFile(string path)
        {
            List<Resident> residents = new List<Resident>();

            foreach (var l in File.ReadAllLines(path).Skip(1))
            {
                string[] v = l.Split(';');

                int Age = int.Parse(v[0]);
                string AmtWeekdays = v[1] == "NA" ? "NA" : v[1];
                string AmtWeekends = v[2] == "NA" ? "NA" : v[2];
                Ethnicity Ethnicity = new(int.Parse(v[3]), v[4]);
                string Gender = v[5];
                string GrossIncome = v[6];
                string MaritalStatus = v[7];
                Nationality Nationality = new(int.Parse(v[8]), v[9]);
                string Qualification = v[10];
                string Region = v[11];
                string Smoke = v[12];
                string Type = v[13];

                Resident resident = new(Age, AmtWeekdays, AmtWeekends, Ethnicity, Gender, GrossIncome, MaritalStatus, Nationality, Qualification, Region, Smoke, Type);
                residents.Add(resident);
            }
            return residents;
        }

        public string SmokePerWeek(string weekdays, string weekends)
        {
            if (weekdays == "NA" || weekends == "NA")
            {
                return "NaN";
            }
            else
            {
                return $"{ Math.Round((int.Parse(weekends) + int.Parse(weekdays)) / 7.0, 2) }";
            }


        }

        public override string ToString()
        {
            return /*$"Resident ID: {}\n" +*/
                    $"Age: {Age}\n" +
                    $"AmtWeekdays: {AmtWeekydays}\n" +
                    $"AmtWeekends: {AmtWeekyends}\n" +
                    $"Ethnicity: {Ethnicity.EthnicityName}\n" +
                    $"Gender: {Gender}\n" +
                    $"Gross Income: {GrossIncome}\n" +
                    $"Marital Status: {MaritalStatus}\n" +
                    $"Nationality: {Nationality.NationalityName}\n" +
                    $"Qualification: {Qualification}\n" +
                    $"Region: {Region}\n" +
                    $"Smoke: {Smoke}\n" +
                    $"Type: {Type}\n" +
                    $"Average: {SmokePerWeek(AmtWeekydays, AmtWeekyends)}\n";
        }
    }
}
