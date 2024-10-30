namespace SsttekAcademyHomeWorkApi.Models.Dtos;

public class ProductUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}