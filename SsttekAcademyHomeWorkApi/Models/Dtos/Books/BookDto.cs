using System.ComponentModel;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Models.Dtos.Books
{
    public class BookDto
    {
        [SwaggerSchema("Unique identifier of the book.")]
        [DefaultValue(1)]
        public int Id { get; set; }

        [SwaggerSchema("Title of the book.")]
        [DefaultValue("Sample Book Title")]
        public string Title { get; set; } = default!;

        [SwaggerSchema("Author of the book.")]
        [DefaultValue("Author Name")]
        public string Author { get; set; }

        [SwaggerSchema("Year the book was published.")]
        [DefaultValue(2023)]
        public int PublicationYear { get; set; }

        [SwaggerSchema("International Standard Book Number.")]
        [DefaultValue("123-4567890123")]
        public string ISBN { get; set; } = default!;

        [SwaggerSchema("Genre of the book.")]
        [DefaultValue("Fiction")]
        public string? Genre { get; set; }

        [SwaggerSchema("Publisher of the book.")]
        [DefaultValue("Publisher Name")]
        public string? Publisher { get; set; }

        [SwaggerSchema("Number of pages in the book.")]
        [DefaultValue(350)]
        public int PageCount { get; set; }

        [SwaggerSchema("Language the book is written in.")]
        [DefaultValue("English")]
        public string Language { get; set; } = default!;

        [SwaggerSchema("Brief summary of the book.")]
        [DefaultValue("This is a sample summary of the book.")]
        public string Summary { get; set; } = default!;

        [SwaggerSchema("Number of copies available.")]
        [DefaultValue(10)]
        public int AvailableCopies { get; set; }

        [SwaggerSchema("URL of the book's cover image.")]
        [DefaultValue("https://example.com/image.jpg")]
        public string? ImageUrl { get; set; }
    }
}