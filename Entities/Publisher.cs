﻿namespace FinalProjectADO.Net1.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}


