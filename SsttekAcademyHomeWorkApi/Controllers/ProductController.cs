using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWorkApi.Models.Dtos;
using SsttekAcademyHomeWorkApi.Models.Entities;
using SsttekAcademyHomeWorkApi.Models.Services;

namespace SsttekAcademyHomeWorkApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IProductService _productService;

    public ProductController([FromServices] IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _productService= _serviceProvider.GetRequiredKeyedService<IProductService>("default");
    }
    
    
    [HttpPost]
    public IActionResult Create(
        [FromHeader(Name = "User-Name")] string userName, 
        [FromBody] ProductCreateDto dto)
    {
        var product = new Product
        {
            Id = new Random().Next(1, 1000),
            Name = dto.Name,
            Price = dto.Price,
            Category = dto.Category
        };
        
        _productService.Create(product);

        var productDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Category = product.Category
        };

        Console.WriteLine($"Product created by: {userName}");

        return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
    }

    // READ: Tüm ürünleri kategori bazlı filtreleme (Query parametresinden veri alma)
    [HttpGet]
    public IActionResult GetAll([FromQuery] string? category)
    {
        var products = _productService.GetAll();

        if (!string.IsNullOrEmpty(category))
        {
            products = products.Where(p => p.Category == category).ToList();
        }

        var productDtos = products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Category = p.Category
        }).ToList();

        return Ok(productDtos);
    }

    // READ: ID ile ürün getirme (Route parametresinden veri alma)
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var _productService = _serviceProvider.GetRequiredKeyedService<IProductService>("default");
        var product = _productService.GetById(id);
        if (product == null) return NotFound();

        var productDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Category = product.Category
        };

        return Ok(productDto);
    }

    // UPDATE: Ürün güncelleme
    [HttpPut]
    public IActionResult Update([FromBody] ProductUpdateDto dto)
    {
        var existingProduct = _productService.GetById(dto.Id);
        if (existingProduct == null) return NotFound();

        existingProduct.Name = dto.Name;
        existingProduct.Price = dto.Price;
        existingProduct.Category = dto.Category;

        _productService.Update(existingProduct);

        return NoContent();
    }

    // DELETE: Ürün silme
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var product = _productService.GetById(id);
        if (product == null) return NotFound();

        _productService.Delete(id);
        return NoContent();
    }
    

    // SPECIAL SERVICE: Anahtar bazlı servis kullanımı
    [HttpGet("special/{id}")]
    public IActionResult GetByIdFromSpecialService([FromRoute] int id)
    {
        var _specialProductService= _serviceProvider.GetRequiredKeyedService<IProductService>("special");
        var product = _specialProductService.GetById(id);
        if (product == null) return NotFound();
    
        var productDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Category = product.Category
        };
    
        return Ok(productDto);
    }
}
