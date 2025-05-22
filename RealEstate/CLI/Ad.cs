namespace RealestateCLI
{
    class Ad 
    {
        private string desctription;

        public Ad(int id, int rooms, string latLong, int floors, int area, string desctription, bool freeOfCharge, string imageUrl, DateTime createAt, Seller seller, Category category)
        {
            Id = id;
            Rooms = rooms;
            Latlong = latLong;
            Floors = floors;
            Area = area;
            this.desctription = desctription;
            FreeOfCharge = freeOfCharge;
            ImageUrl = imageUrl;
            CreateAt = createAt;
            Seller = seller;
            Category = category;
        }

        public int Id { get; set; }
        public int Rooms { get; set; }
        public string Latlong { get; set; }
        public int Floors { get; set; }
        public int Area { get; set; }
        public string Description { get; set; }
        public bool FreeOfCharge { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateAt { get; set; }
        public Seller Seller { get; set; }
        public Category Category { get; set; }
        

        public static List<Ad> LoadFromCsv(string path)
        {
            List<Ad> ads = new List<Ad>();

            string[] r = File.ReadAllLines(path);

            foreach (var v in r.Skip(1))
            {
                var s = v.Split(";");

                int Id = int.Parse(s[0]);
                int Rooms = int.Parse(s[1]);
                string LatLong = s[2];
                int Floors = int.Parse(s[3]);
                int Area = int.Parse(s[4]);
                string Desctription = s[5];
                bool FreeOfCharge = s[6] == "1" ? true : false;
                string ImageUrl = s[7];
                DateTime CreateAt = Convert.ToDateTime(s[8]);
                Seller Seller = new Seller(int.Parse(s[9]), s[10], s[11]);
                Category Category = new Category(int.Parse(s[12]), s[13]);

                Ad ad = new(Id, Rooms, LatLong, Floors, Area, Desctription, FreeOfCharge, ImageUrl, CreateAt, Seller, Category);
                ads.Add(ad);
            }
            return ads;
        }
    }
}