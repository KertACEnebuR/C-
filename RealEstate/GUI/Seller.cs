namespace RealEstateGUI
{
    class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public Seller(int SId, string SName, string SPhone)
        {
            Id = SId;
            Name = SName;
            Phone = SPhone;
        }
    }
}