using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWorkApi.Models.Services.Books;
using SsttekAcademyHomeWorkApi.Models.Dtos.Books;
using Microsoft.AspNetCore.Authorization;


namespace SsttekAcademyHomeWorkApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController(IBookService bookService) : CustomControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return HandleServiceResult(await bookService.GetBooks());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            return HandleServiceResult(await bookService.GetBook(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateBookDto createBookDto)
        {
            return HandleServiceResult(await bookService.Add(createBookDto));
        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateBookDto bookDto)
        {
            return HandleServiceResult(await bookService.Update(bookDto));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleServiceResult(await bookService.Delete(id));
        }
    }
}
