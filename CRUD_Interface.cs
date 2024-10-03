using FinalProjectADO.Net1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectADO.Net1
{
    internal class CRUD_Interface
    {
        BookstoreContext context = new BookstoreContext();
        public void RegisterUser(User newUser)
        {
           
                context.Users.Add(newUser);
                context.SaveChanges();

        }

        public User Login(string username, string password)
        {
          
                var user = context.Users.SingleOrDefault(u => u.Username == username);
                if (user != null && user.Password == password)
                {
                    return user;
                }
                return null;
          
        }

        public void AddBook(Book newBook)
        {
          
                context.Books.Add(newBook);
                context.SaveChanges();
           
        }

        public void DeleteBook(int bookId)
        {
           
                var book = context.Books.Find(bookId);
                if (book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
           
        }

        public List<Book> GetAllBooks()
        {
            return context.Books.Include(b => b.Author)
                        .Include(b => b.Genre)
                        .Include(b => b.Publisher)
                        .ToList();
        }

        public void UpdateBook(Book updatedBook)
        {
           
                var existingBook = context.Books.Find(updatedBook.Id);
                if (existingBook != null)
                {
                    existingBook.Title = updatedBook.Title;
                    existingBook.AuthorId = updatedBook.AuthorId;
                    existingBook.PublisherId = updatedBook.PublisherId;
                    existingBook.GenreId = updatedBook.GenreId;
                    existingBook.PageCount = updatedBook.PageCount;
                    existingBook.PublicationYear = updatedBook.PublicationYear;
                    existingBook.CostPrice = updatedBook.CostPrice;
                    existingBook.SalePrice = updatedBook.SalePrice;
                    existingBook.IsContinuation = updatedBook.IsContinuation;

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
           
        }


        public void SellBook(int bookId)
        {
            
                var book = context.Books.Find(bookId);
                if (book != null)
                {
                    book.IsSold = true;
                    book.SalesCount++;
                    context.SaveChanges();
                }
           
        }

        public void SetBookOnPromotion(int bookId, decimal discountPercentage, DateTime endDate)
        {
           
                var book = context.Books.Find(bookId);
                if (book != null)
                {
                    book.IsOnPromotion = true;
                    book.SalePrice -= book.SalePrice * (discountPercentage / 100);
                    book.PromotionEndDate = endDate;
                    context.SaveChanges();
                }
           
        }

        public void ReserveBookForUser(int userId, int bookId)
        {
          
                var user = context.Users.Find(userId);
                var book = context.Books.Find(bookId);

                if (user == null)
                {
                    Console.WriteLine("User not found.");
                    return;
                }

                if (book == null)
                {
                    Console.WriteLine("Book not found.");
                    return;
                }

                var userBook = new UserBook { UserId = userId, BookId = bookId };
                context.UserBooks.Add(userBook);

                try
                {
                    context.SaveChanges();
                    Console.WriteLine("Book successfully reserved for the user.");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("An error occurred while reserving the book: " + ex.InnerException?.Message);
                }
            
        }
        public List<Book> GetNewBooks()
        {
            if (context.Books == null)
            {
                throw new InvalidOperationException("Books property is not initialized");
            }

            var currentDate = DateTime.Now;
            var lastYear = currentDate.AddYears(-1);

            return context.Books.Where(b => b.PublicationYear >= lastYear.Year && b.PublicationYear <= currentDate.Year).ToList();
        }

        public List<Book> GetMostPopularBooks()
        {
            return context.Books.OrderByDescending(b => b.Popularity).Take(10).ToList();
        }

        public List<Author> GetMostPopularAuthors()
        {
            return context.Authors.OrderByDescending(a => a.Popularity).Take(10).ToList();
        }

        public List<Genre> GetMostPopularGenres(string period)
        {
            switch (period)
            {
                case "week":
                    return context.Genres.OrderByDescending(g => g.Books.Sum(b => b.Popularity)).Take(10).ToList();
                case "month":
                    return context.Genres.OrderByDescending(g => g.Books.Sum(b => b.Popularity)).Take(10).ToList();
                case "year":
                    return context.Genres.OrderByDescending(g => g.Books.Sum(b => b.Popularity)).Take(10).ToList();
                default:
                    throw new ArgumentException("Invalid period");
            }
        }
    
}
}
