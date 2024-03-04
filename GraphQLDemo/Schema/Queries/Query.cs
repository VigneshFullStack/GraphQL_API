using GraphQLDemo.Data;
using GraphQLDemo.Models;

namespace GraphQLDemo.Schema.Queries
{
    public class Query
    {
        public IEnumerable<Book> GetBooks([Service] BookRepository repository) => repository.GetBooks();

        public Book GetBookById(int id, [Service] BookRepository repository) => repository.GetBookById(id);
    }

}
