using FinalProjectADO.Net1.Entities;

namespace FinalProjectADO.Net1
{
    class Menu
    {
        CRUD_Interface cRUD_ = new CRUD_Interface();
        public  void RegisterUser()
        {
            var user = new User();

            Console.Write("Enter username: ");
            user.Username = Console.ReadLine();

            Console.Write("Enter password: ");
            user.Password = Console.ReadLine();

            cRUD_.RegisterUser(user);
            Console.WriteLine("User registered successfully.");
        }

        public void LoginUser()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();

            Console.Write("Enter password: ");
            var password = Console.ReadLine();

            var user = cRUD_.Login(username, password);
            if (user != null)
            {
                Console.WriteLine("Login successful.");
                ManageBooks();
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }

        public void SearchBook(List<Book> books)
        {
            Console.WriteLine("Choose search option:");
            Console.WriteLine("1. Search by book title");
            Console.WriteLine("2. Search by author");
            Console.WriteLine("3. Search by genre");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter book title:");
                    string title = Console.ReadLine();
                    var booksByTitle = books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
                    DisplayBooks(booksByTitle);
                    break;

                case "2":
                    Console.WriteLine("Enter author's name:");
                    string author = Console.ReadLine();
                    var booksByAuthor = books.Where(b => b.Author.Surname.Contains(author, StringComparison.OrdinalIgnoreCase) ||
                                                         b.Author.Name.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
                    DisplayBooks(booksByAuthor);
                    break;

                case "3":
                    Console.WriteLine("Enter genre:");
                    string genre = Console.ReadLine();
                    var booksByGenre = books.Where(b => b.Genre.Name.Contains(genre, StringComparison.OrdinalIgnoreCase)).ToList();
                    DisplayBooks(booksByGenre);
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }



        private  void ManageBooks()
        {
           
            while (true)
            {
                Console.WriteLine("Select an action:");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Delete a book");
                Console.WriteLine("3. View all books");
                Console.WriteLine("4. Update a book");
                Console.WriteLine("5. Sell a book");
                Console.WriteLine("6. Set a book on promotion");
                Console.WriteLine("7. Reserve a book for a user");
                Console.WriteLine("8. Search books");
                Console.WriteLine("9. View new books");
                Console.WriteLine("10. Most popular book");
                Console.WriteLine("11. Most popular author");
                Console.WriteLine("12. Most popular genre");
                Console.WriteLine("0. Logout");
                Console.Write("Your choice: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        DeleteBook();
                        break;
                    case "3":
                        ViewAllBooks();
                        break;
                    case "4":
                        UpdateBook();
                        break;
                    case "5":
                        SellBook();
                        break;
                    case "6":
                        SetBookOnPromotion(new BookstoreContext());
                        break;
                    case "7":
                        ReserveBookForUser();
                        break;
                    case "8":
                        SearchBook(cRUD_.GetAllBooks());
                        break;
                    case "9":
                        //if (context == null)
                        //{
                        //    Console.WriteLine("Context is not initialized");
                        //    break;
                        //}

                        var newBooks = cRUD_.GetNewBooks();
                        Console.WriteLine("New books:");
                        foreach (var book in newBooks)
                        {
                            Console.WriteLine($"Title: {book.Title}, Author: {book.Author.Surname} {book.Author.Name}, Genre: {book.Genre.Name}, Publication Year: {book.PublicationYear}");
                        }
                        break;
                    case "10":
                        var popularBooks = cRUD_.GetMostPopularBooks();
                        Console.WriteLine("Most popular books:");
                        foreach (var book in popularBooks)
                        {
                            Console.WriteLine($"Title: {book.Title}, Author: {book.Author.Surname} {book.Author.Name}, Genre: {book.Genre.Name}, Publication Year: {book.PublicationYear}, Popularity: {book.Popularity}");
                        }
                        break;
                    case "11":
                        var popularAuthors = cRUD_.GetMostPopularAuthors();
                        Console.WriteLine("Most popular authors:");
                        foreach (var author in popularAuthors)
                        {
                            Console.WriteLine($"Name: {author.Name}, Surname: {author.Surname}, Popularity: {author.Popularity}");
                        }
                        break;
                    case "12":
                        Console.WriteLine("Select period:");
                        Console.WriteLine("1. Week");
                        Console.WriteLine("2. Month");
                        Console.WriteLine("3. Year");
                        int periodChoice = Convert.ToInt32(Console.ReadLine());

                        string period = "";
                        switch (periodChoice)
                        {
                            case 1:
                                period = "week";
                                break;
                            case 2:
                                period = "month";
                                break;
                            case 3:
                                period = "year";
                                break;
                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }

                        if (!string.IsNullOrEmpty(period))
                        {
                            var popularGenres = cRUD_.GetMostPopularGenres(period);
                            Console.WriteLine($"Most popular genres for {period}:");
                            foreach (var genre in popularGenres)
                            {
                                Console.WriteLine($"Name: {genre.Name}, Popularity: {genre.Books.Sum(b => b.Popularity)}");
                            }
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        private  void AddBook()
        {
            var book = new Book();

            Console.Write("Enter the book title: ");
            book.Title = Console.ReadLine();

            Console.Write("Enter the author ID: ");
            book.AuthorId = int.Parse(Console.ReadLine());

            Console.Write("Enter the publisher ID: ");
            book.PublisherId = int.Parse(Console.ReadLine());

            Console.Write("Enter the genre ID: ");
            book.GenreId = int.Parse(Console.ReadLine());

            Console.Write("Enter the page count: ");
            book.PageCount = int.Parse(Console.ReadLine());

            Console.Write("Enter the publication year: ");
            book.PublicationYear = int.Parse(Console.ReadLine());

            Console.Write("Enter the cost price: ");
            book.CostPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the sale price: ");
            book.SalePrice = decimal.Parse(Console.ReadLine());

            Console.Write("Is this book a continuation (true/false): ");
            book.IsContinuation = bool.Parse(Console.ReadLine());

            cRUD_.AddBook(book);
            Console.WriteLine("Book added successfully.");
        }

        private  void DeleteBook()
        {
            Console.Write("Enter the book ID to delete: ");
            int bookId = int.Parse(Console.ReadLine());
            cRUD_.DeleteBook(bookId);
            Console.WriteLine("Book deleted successfully.");
        }

        private  void ViewAllBooks()
        {
            var books = cRUD_.GetAllBooks();

            if (books.Any())
            {
                Console.WriteLine("List of all books in the store:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author ID: {book.AuthorId}, Publisher ID: {book.PublisherId}, Genre ID: {book.GenreId}, Page Count: {book.PageCount}, Publication Year: {book.PublicationYear}, Cost Price: {book.CostPrice}, Sale Price: {book.SalePrice}, Is Continuation: {book.IsContinuation}");
                }
            }
            else
            {
                Console.WriteLine("No books available in the store.");
            }
        }

        private  void UpdateBook()
        {
            BookstoreContext context = new BookstoreContext();
            Console.Write("Enter the book ID to update: ");
            int bookId = int.Parse(Console.ReadLine());

            var book = context.Books.Find(bookId);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.Write("Enter the new book title: ");
            book.Title = Console.ReadLine();

            Console.Write("Enter the new author ID: ");
            book.AuthorId = int.Parse(Console.ReadLine());

            Console.Write("Enter the new publisher ID: ");
            book.PublisherId = int.Parse(Console.ReadLine());

            Console.Write("Enter the new genre ID: ");
            book.GenreId = int.Parse(Console.ReadLine());

            Console.Write("Enter the new page count: ");
            book.PageCount = int.Parse(Console.ReadLine());

            Console.Write("Enter the new publication year: ");
            book.PublicationYear = int.Parse(Console.ReadLine());

            Console.Write("Enter the new cost price: ");
            book.CostPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the new sale price: ");
            book.SalePrice = decimal.Parse(Console.ReadLine());

            Console.Write("Is this book a continuation (true/false): ");
            book.IsContinuation = bool.Parse(Console.ReadLine());

            cRUD_.UpdateBook(book);
            Console.WriteLine("Book updated successfully.");
        }

        private  void SellBook()
        {
            Console.Write("Enter the book ID to sell: ");
            int bookId = int.Parse(Console.ReadLine());
            cRUD_.SellBook(bookId);
            Console.WriteLine("Book sold successfully.");
        }

        private  void SetBookOnPromotion(BookstoreContext context)
        {
            Console.WriteLine("Enter the ID of the book to set on promotion:");
            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                var book = context.Books.FirstOrDefault(b => b.Id == bookId);

                if (book != null)
                {
                    Console.WriteLine($"Current Price: {book.SalePrice:C}");
                    Console.WriteLine("Enter discount percentage (e.g., 20 for 20%):");

                    if (decimal.TryParse(Console.ReadLine(), out decimal discountPercentage) && discountPercentage > 0 && discountPercentage <= 100)
                    {
                        decimal discountAmount = book.SalePrice * (discountPercentage / 100);
                        decimal newSalePrice = book.SalePrice - discountAmount;

                        book.IsOnPromotion = true;
                        book.SalePrice = newSalePrice;

                        context.SaveChanges();
                        Console.WriteLine($"The book '{book.Title}' is now on promotion with a sale price of {newSalePrice:C} after a discount of {discountPercentage}%.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for discount percentage. Please enter a value between 1 and 100.");
                    }
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid book ID.");
            }
        }



        private  void ReserveBookForUser()
        {
            Console.Write("Enter the user ID to reserve the book: ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("Enter the book ID to reserve: ");
            int bookId = int.Parse(Console.ReadLine());

            cRUD_.ReserveBookForUser(userId, bookId);
            Console.WriteLine("Book reserved for the user successfully.");
        }

        private  void DisplayBooks(List<Book> books)
        {
            if (books.Count > 0)
            {
                Console.WriteLine("Search results:");
                foreach (var book in books)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author.Surname} {book.Author.Name}, Genre: {book.Genre.Name}");
                }
            }
            else
            {
                Console.WriteLine("No books found for the given criteria.");
            }
        }

    }
}


