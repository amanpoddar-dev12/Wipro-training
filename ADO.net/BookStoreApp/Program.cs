using BookStoreApp.Models;
using BookStoreApp.Data;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=AMANPODDAR\\SQLEXPRESS;Database=BookStoreDB;Trusted_Connection=True;";
        var repo = new BookRepository(connectionString);

        while (true)
        {
            Console.WriteLine("\nBookstore Management");
            Console.WriteLine("1. View Books");
            Console.WriteLine("2. Add Book");
            Console.WriteLine("3. Update Book");
            Console.WriteLine("4. Delete Book");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var books = repo.GetAllBooks();
                    foreach (var b in books)
                    {
                        Console.WriteLine($"{b.BookId} - {b.Title} by {b.Author} (${b.Price})");
                    }
                    break;

                case 2:
                    Book newBook = new Book();
                    Console.Write("Enter Title: ");
                    newBook.Title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    newBook.Author = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    newBook.Price = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Enter Published Date (yyyy-mm-dd): ");
                    newBook.PublishedDate = DateTime.Parse(Console.ReadLine());
                    repo.AddBook(newBook);
                    Console.WriteLine("Book added successfully!");
                    break;

                case 3:
                    Console.Write("Enter Book ID to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Book updatedBook = new Book();
                    updatedBook.BookId = updateId;
                    Console.Write("Enter Title: ");
                    updatedBook.Title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    updatedBook.Author = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    updatedBook.Price = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Enter Published Date (yyyy-mm-dd): ");
                    updatedBook.PublishedDate = DateTime.Parse(Console.ReadLine());
                    repo.UpdateBook(updatedBook);
                    Console.WriteLine("Book updated successfully!");
                    break;

                case 4:
                    Console.Write("Enter Book ID to delete: ");
                    int deleteId = Convert.ToInt32(Console.ReadLine());
                    repo.DeleteBook(deleteId);
                    Console.WriteLine("Book deleted successfully!");
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}
