using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Models.Dtos.Books
{
    public class UpdateBookDto
    {
        [Required(ErrorMessage = "Id is required")]
        [SwaggerSchema("Unique identifier of the book.")]
        [DefaultValue(1)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [SwaggerSchema("Title of the book.")]
        [DefaultValue("Updated Book Title")]
        public string Title { get; set; } = default!;

        [Required(ErrorMessage = "Author is required")]
        [SwaggerSchema("Author of the book.")]
        [DefaultValue("Updated Author Name")]
        public string Author { get; set; }

        [Required(ErrorMessage = "PublicationYear is required")]
        [Range(1400, 2024, ErrorMessage = "PublicationYear must be between 1400 and 2024")]
        [SwaggerSchema("Year the book was published.")]
        [DefaultValue(2023)]
        public int? PublicationYear { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [SwaggerSchema("International Standard Book Number.")]
        [DefaultValue("123-4567890123")]
        public string ISBN { get; set; } = default!;

        [SwaggerSchema("Genre of the book.")]
        [DefaultValue("Fiction")]
        public string? Genre { get; set; }

        [SwaggerSchema("Publisher of the book.")]
        [DefaultValue("Updated Publisher Name")]
        public string? Publisher { get; set; }

        [Required(ErrorMessage = "PageCount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "PageCount must be greater than 0")]
        [SwaggerSchema("Number of pages in the book.")]
        [DefaultValue(400)]
        public int? PageCount { get; set; }

        [Required(ErrorMessage = "Language is required")]
        [SwaggerSchema("Language the book is written in.")]
        [DefaultValue("English")]
        public string Language { get; set; } = default!;

        [Required(ErrorMessage = "Summary is required")]
        [SwaggerSchema("Brief summary of the book.")]
        [DefaultValue("This is an updated summary of the book.")]
        public string Summary { get; set; } = default!;

        [Required(ErrorMessage = "AvailableCopies is required")]
        [SwaggerSchema("Number of copies available.")]
        [DefaultValue(8)]
        public int? AvailableCopies { get; set; }

        [SwaggerSchema("URL of the book's cover image.")]
        [DefaultValue("https://example.com/updated-image.jpg")]
        public string? ImageUrl { get; set; }
    }
}
