using SsttekAcademyHomeWorkApi.Data;
using SsttekAcademyHomeWorkApi.Models.Entities;

namespace SsttekAcademyHomeWorkApi.Models.Repositories.Books;

public class BookRepositoryWithPostgreSql: GenericRepository<Book>,IBookRepository
{
    private readonly AppDbContext _context;
    public BookRepositoryWithPostgreSql(AppDbContext context) : base(context)
    {
        _context = context;
    }
    
    public IQueryable<Book> GetFilteredBooks(string title, string author, string genre, int? publicationYear, string isbn, string publisher)
    {
        IQueryable<Book> query = _context.Books;
        
        if (!string.IsNullOrEmpty(title))
        {
            query = query.Where(b => b.Title.Contains(title));
        }

        if (!string.IsNullOrEmpty(author))
        {
            query = query.Where(b => b.Author.Contains(author));
        }

        if (!string.IsNullOrEmpty(genre))
        {
            query = query.Where(b => b.Genre.Contains(genre));
        }

        if (publicationYear.HasValue)
        {
            query = query.Where(b => b.PublicationYear == publicationYear.Value);
        }

        if (!string.IsNullOrEmpty(isbn))
        {
            query = query.Where(b => b.ISBN.Contains(isbn));
        }

        if (!string.IsNullOrEmpty(publisher))
        {
            query = query.Where(b => b.Publisher.Contains(publisher));
        }

        return query;
    }
    
}