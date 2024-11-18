using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWorkApi.Models.Services.Books;
using SsttekAcademyHomeWorkApi.Models.Dtos.Books;
using Microsoft.AspNetCore.Authorization;
using SsttekAcademyHomeWorkApi.Models.Dtos.Commons;
using Swashbuckle.AspNetCore.Annotations;


namespace SsttekAcademyHomeWorkApi.Controllers
{
    [Authorize]
    [ApiController]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
    [Route("api/book")]
    public class BooksController(IBookService bookService) : CustomControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<BookDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Book List",
            Description = "Book lists"
        )]
        public async Task<IActionResult> Index()
        {
            return HandleServiceResult(await bookService.GetBooks());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Book Detail",
            Description = "Book detail for a given ID"
        )]
        public async Task<IActionResult> Detail(int id)
        {
            return HandleServiceResult(await bookService.GetBook(id));
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create Book",
            Description = "This system add new book"
        )]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateBookDto createBookDto)
        {
            return HandleServiceResult(await bookService.Add(createBookDto));
        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(
            Summary = "Update Book",
            Description = "This system update book"
        )]
        public async Task<IActionResult> Update(UpdateBookDto bookDto)
        {
            return HandleServiceResult(await bookService.Update(bookDto));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [SwaggerOperation(
            Summary = "Delete Book",
            Description = "This system delete book"
        )]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleServiceResult(await bookService.Delete(id));
        }
    }
}
