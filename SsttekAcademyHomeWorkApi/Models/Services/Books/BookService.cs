using Microsoft.EntityFrameworkCore;
using SsttekAcademyHomeWorkApi.Data;
using SsttekAcademyHomeWorkApi.Models.Commons;
using SsttekAcademyHomeWorkApi.Models.Entities;
using SsttekAcademyHomeWorkApi.Models.Repositories.Books;
using SsttekAcademyHomeWorkApi.Models.Dtos.Books;

namespace SsttekAcademyHomeWorkApi.Models.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult<List<BookDto>>> GetBooks()
        {
            var books = await _bookRepository.GetAllAsync();
            var bookViewModels = books.Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublicationYear = book.PublicationYear,
                ISBN = book.ISBN,
                Genre = book.Genre,
                Publisher = book.Publisher,
                PageCount = book.PageCount,
                Language = book.Language,
                Summary = book.Summary,
                AvailableCopies = book.AvailableCopies,
                ImageUrl = book.ImageUrl
            }).ToList();

            return ServiceResult<List<BookDto>>.SuccessResult(bookViewModels);
        }

        public async Task<ServiceResult<BookDto>> GetBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                return ServiceResult<BookDto>.ErrorResult("Kitap bulunamadı.");

            var bookViewModel = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublicationYear = book.PublicationYear,
                ISBN = book.ISBN,
                Genre = book.Genre,
                Publisher = book.Publisher,
                PageCount = book.PageCount,
                Language = book.Language,
                Summary = book.Summary,
                AvailableCopies = book.AvailableCopies,
                ImageUrl = book.ImageUrl
            };

            return ServiceResult<BookDto>.SuccessResult(bookViewModel);
        }

        public async Task<ServiceResult> Add(CreateBookDto bookViewModel)
        {
            var book = new Book
            {
                Title = bookViewModel.Title,
                Author = bookViewModel.Author,
                PublicationYear = bookViewModel.PublicationYear.Value,
                ISBN = bookViewModel.ISBN,
                Genre = bookViewModel.Genre,
                Publisher = bookViewModel.Publisher,
                PageCount = bookViewModel.PageCount.Value,
                Language = bookViewModel.Language,
                Summary = bookViewModel.Summary,
                AvailableCopies = bookViewModel.AvailableCopies.Value,
                ImageUrl = bookViewModel.ImageUrl
            };

            await _bookRepository.AddAsync(book);
            _unitOfWork.Commit();

            return ServiceResult<object>.SuccessResult(null, "Kitap başarıyla eklendi.");
        }

        public async Task<ServiceResult> Update(UpdateBookDto bookViewModel)
        {
            var book = await _bookRepository.GetByIdAsync(bookViewModel.Id);
            if (book == null)
                return ServiceResult<object>.ErrorResult("Kitap bulunamadı.");

            book.Title = bookViewModel.Title;
            book.Author = bookViewModel.Author;
            book.PublicationYear = bookViewModel.PublicationYear.Value;
            book.ISBN = bookViewModel.ISBN;
            book.Genre = bookViewModel.Genre;
            book.Publisher = bookViewModel.Publisher;
            book.PageCount = bookViewModel.PageCount.Value;
            book.Language = bookViewModel.Language;
            book.Summary = bookViewModel.Summary;
            book.AvailableCopies = bookViewModel.AvailableCopies.Value;
            book.ImageUrl = bookViewModel.ImageUrl;

            _bookRepository.Update(book);
            _unitOfWork.Commit();

            return ServiceResult<object>.SuccessResult(null, "Kitap başarıyla güncellendi.");
        }

        public async Task<ServiceResult> Delete(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                return ServiceResult<object>.ErrorResult("Kitap bulunamadı.");

            _bookRepository.Delete(book);
            _unitOfWork.Commit();

            return ServiceResult<object>.SuccessResult(null, "Kitap başarıyla silindi.");
        }

        public async Task<ServiceResult<List<BookDto>>> GetFilteredBooksAsync(
            string title, string author, string genre, int? publicationYear, string isbn, string publisher)
        {
            var query = _bookRepository.GetFilteredBooks(title, author, genre, publicationYear, isbn, publisher);
            var books = await query.ToListAsync();

            var bookViewModels = books.Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublicationYear = book.PublicationYear,
                ISBN = book.ISBN,
                Genre = book.Genre,
                Publisher = book.Publisher,
                PageCount = book.PageCount,
                Language = book.Language,
                Summary = book.Summary,
                AvailableCopies = book.AvailableCopies,
                ImageUrl = book.ImageUrl
            }).ToList();

            return ServiceResult<List<BookDto>>.SuccessResult(bookViewModels);
        }
    }
}
