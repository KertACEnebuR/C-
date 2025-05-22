namespace RealestateCLI
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category(int CId, string CName)
        {
            Id = CId;
            Name = CName;
        }
    }
}