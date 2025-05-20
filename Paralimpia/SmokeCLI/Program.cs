namespace SmokeCLI
{
    internal class Program
    {
        //public List<Resident> residents = new List<Resident>();
        static void Main(string[] args)
        {
            var residents = Resident.FromFile(@"..\..\..\src\smoking.txt");

            Console.WriteLine("5.feladat");
            //int i = 0;
            foreach (var res in residents.Take(10))
            {
                //Console.WriteLine($"Resident ID: {i+1}");
                Console.WriteLine(res);
                //i++;
            }

            var f6 = residents.Where(r => r.Smoke == "Yes" && r.Nationality.NationalityName == "British" && r.MaritalStatus == "Married" && r.Gender == "Male" && r.GrossIncome != "Unknown").ToList();
            
            Console.WriteLine("6. feladat");
            foreach (var f in f6)
            {
                Console.WriteLine(f.ToString());
            }
            Console.WriteLine($"A leszűrt lakosok maximális jövedelmének maximuma: X angol font");

            var f7 = residents.Where(f => f.Age >= 25 && f.Age <= 30 && f.Region.Contains("Wales") && f.Smoke.Contains("No")).Select(f => $"Age: {f.Age}\nGender: {f.Gender}\nHighestQualification: {f.Qualification}").ToList();

            File.WriteAllLines(@"..\..\..\src\wales.txt", f7);

        }
    }
}
