namespace FinalProjectADO.Net1.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public int PublicationYear { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsContinuation { get; set; }
        public bool IsSold { get; set; }
        public bool IsOnPromotion { get; set; }
        public DateTime? PromotionEndDate { get; set; }
        public int SalesCount { get; set; }

        public int Popularity { get; set; }
    }
}


