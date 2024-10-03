namespace FinalProjectADO.Net1
{
    public class Author
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public int Popularity { get; set; }
        public ICollection<Book> Books { get; set; }
        
    }
}


