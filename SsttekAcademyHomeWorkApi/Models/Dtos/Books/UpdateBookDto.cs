using System.ComponentModel.DataAnnotations;

namespace SsttekAcademyHomeWorkApi.Models.Dtos.Books
{
    public class UpdateBookDto
    {

        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = default!;

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }


        [Required(ErrorMessage = "PublicationYear is required")]
        [Range(1400, 2024, ErrorMessage = "PublicationYear must be between 1400 and 2024")]
        public int? PublicationYear { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; } = default!;
        public string? Genre { get; set; }
        public string? Publisher { get; set; }

        [Required(ErrorMessage = "PageCount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "PageCount must be greater than 0")]
        public int? PageCount { get; set; }


        [Required(ErrorMessage = "Language is required")]
        public string Language { get; set; } = default!;

        [Required(ErrorMessage = "Summary is required")]
        public string Summary { get; set; } = default!;

        [Required(ErrorMessage = "AvailableCopies is required")]
        public int? AvailableCopies { get; set; }
        public string? ImageUrl { get; set; }
    }
}