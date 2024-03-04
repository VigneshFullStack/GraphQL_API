using GraphQLDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLDemo.Data
{
    public class BookRepository
    {
        private List<Book> _books;

        public BookRepository()
        {
            _books = new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Title = "To Kill a Mockingbird",
                    ReleaseDate = new System.DateTime(1960, 7, 11),
                    Price = 10.99m,
                    Author = new Author { Id = 1, Name = "Harper Lee" }
                },
                new Book
                {
                    Id = 2,
                    Title = "1984",
                    ReleaseDate = new System.DateTime(1949, 6, 8),
                    Price = 12.50m,
                    Author = new Author { Id = 2, Name = "George Orwell" }
                },
                new Book
                {
                    Id = 3,
                    Title = "The Great Gatsby",
                    ReleaseDate = new System.DateTime(1925, 4, 10),
                    Price = 8.99m,
                    Author = new Author { Id = 3, Name = "F. Scott Fitzgerald" }
                },
                new Book
                {
                    Id = 4,
                    Title = "Harry Potter and the Philosopher's Stone",
                    ReleaseDate = new System.DateTime(1997, 6, 26),
                    Price = 15.99m,
                    Author = new Author { Id = 4, Name = "J.K. Rowling" }
                },
                new Book
                {
                    Id = 5,
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    ReleaseDate = new System.DateTime(1954, 7, 29),
                    Price = 14.50m,
                    Author = new Author { Id = 5, Name = "J.R.R. Tolkien" }
                }
            };
        }

        public IEnumerable<Book> GetBooks() => _books;

        public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void AddBook(Book book) => _books.Add(book);

        public void UpdateBook(int id, Book updatedBook)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == id);
            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title;
                existingBook.ReleaseDate = updatedBook.ReleaseDate;
                existingBook.Price = updatedBook.Price;
                existingBook.Author = updatedBook.Author;
            }
        }

        public void DeleteBook(int id) => _books.RemoveAll(b => b.Id == id);
    }
}
