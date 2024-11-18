using SsttekAcademyHomeWorkApi.Models.Entities;
using SsttekAcademyHomeWorkApi.Models.Dtos.Books;
using SsttekAcademyHomeWorkApi.Models.Commons;

namespace SsttekAcademyHomeWorkApi.Models.Services.Books
{
    public interface IBookService
    {
        Task<ServiceResult<List<BookDto>>> GetFilteredBooksAsync(
            string title, string author, string genre, int? publicationYear, string isbn, string publisher);

        Task<ServiceResult<List<BookDto>>> GetBooks();

        Task<ServiceResult<BookDto>> GetBook(int id);

        Task<ServiceResult> Add(CreateBookDto book);

        Task<ServiceResult> Update(UpdateBookDto book);

        Task<ServiceResult> Delete(int id);
    }
}