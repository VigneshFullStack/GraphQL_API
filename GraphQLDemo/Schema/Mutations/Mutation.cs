using GraphQLDemo.Data;
using GraphQLDemo.Models;

namespace GraphQLDemo.Schema.Mutations
{
    public class Mutation
    {
        public Book AddBook(BookInput input, [Service] BookRepository repository)
        {

            // Check if the provided ID already exists in the repository
            if (repository.GetBookById(input.Id) == null) 
            {
                var newBook = new Book()
                {
                    Id = input.Id,
                    Title = input.Title,
                    ReleaseDate = input.ReleaseDate,
                    Price = input.Price,
                    Author = new Author()
                    {
                        Id = input.AuthorId,
                        Name = input.AuthorName,
                    }
                };

                repository.AddBook(newBook);
                return newBook;
            }
            else
            {
                throw new ArgumentException($"A book with ID {input.Id} already exists.");
            }
        }

        public Book UpdateBook(int id, BookInput input, [Service] BookRepository repository)
        {
            // Check if the book with the specified ID exists in the respository
            var existingBook = repository.GetBookById(id);
            if(existingBook == null)
            {
                throw new ArgumentException($"Book with ID {id} not found.");
            }

            // Create the updated book object
            var updatedBook = new Book()
            {
                Id = id,
                Title = input.Title,
                ReleaseDate = input.ReleaseDate,
                Price = input.Price,
                Author = new Author()
                {
                    Id = input.AuthorId,
                    Name = input.AuthorName,
                }
            };

            // Perform the update
            repository.UpdateBook(id, updatedBook);
            return updatedBook;
        }

        public int DeleteBook(int id, [Service] BookRepository repository)
        {
            // Check if the book with the specified ID exists in the repository
            var existingBook = repository.GetBookById(id);
            if (existingBook == null)
            {
                throw new ArgumentException($"Book with ID {id} not found.");
            }

            // Perform the deletion
            repository.DeleteBook(id);
            return id;
        }
    }
}
