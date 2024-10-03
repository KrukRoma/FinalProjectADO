namespace FinalProjectADO.Net1
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
        public int PopularityWeek { get; set; } 
        public int PopularityMonth { get; set; } 
        public int PopularityYear { get; set; } 
    }
}


