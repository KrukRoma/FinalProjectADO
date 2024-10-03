using FinalProjectADO.Net1.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectADO.Net1
{
    public class BookstoreContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-GE7UVHJ\SQLEXPRESS; Initial Catalog=FinalProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
           );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData(
        new Author { Id = 1, Surname = "Shevchenko", Name = "Taras", FatherName = "Grigorievich", Popularity = 100 },
        new Author { Id = 2, Surname = "Franko", Name = "Ivan", FatherName = "Yosypovych", Popularity = 95 }
    );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Fiction", PopularityWeek = 80, PopularityMonth = 90, PopularityYear = 70 },
                new Genre { Id = 2, Name = "Non-Fiction", PopularityWeek = 70, PopularityMonth = 60, PopularityYear = 80 }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Publishing House 1", Address = "Address 1" },
                new Publisher { Id = 2, Name = "Publishing House 2", Address = "Address 2" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "user1", Password = "password1" },
                new User { Id = 2, Username = "user2", Password = "password2" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Book 1", AuthorId = 1, PublisherId = 1, GenreId = 1, PageCount = 200, PublicationYear = 2020, CostPrice = 10.00m, SalePrice = 15.00m, IsContinuation = false, IsSold = false, IsOnPromotion = false, Popularity = 50 },
                new Book { Id = 2, Title = "Book 2", AuthorId = 2, PublisherId = 2, GenreId = 2, PageCount = 300, PublicationYear = 2021, CostPrice = 20.00m, SalePrice = 25.00m, IsContinuation = false, IsSold = false, IsOnPromotion = true, PromotionEndDate = DateTime.Now.AddMonths(1), Popularity = 60 }
            );

            modelBuilder.Entity<UserBook>().HasData(
                new UserBook { UserId = 1, BookId = 1 },
                new UserBook { UserId = 2, BookId = 2 }
            );

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.Books)
                .WithOne(b => b.Publisher)
                .HasForeignKey(b => b.PublisherId);

            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Books)
                .WithOne(b => b.Genre)
                .HasForeignKey(b => b.GenreId);

            modelBuilder.Entity<UserBook>()
                .HasKey(ub => new { ub.UserId, ub.BookId });

            modelBuilder.Entity<UserBook>()
                .HasOne(ub => ub.User)
                .WithMany(u => u.UserBooks)
                .HasForeignKey(ub => ub.UserId);

            modelBuilder.Entity<UserBook>()
                .HasOne(ub => ub.Book)
                .WithMany();
        }

    }
}


