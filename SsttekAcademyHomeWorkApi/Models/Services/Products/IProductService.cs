using SsttekAcademyHomeWorkApi.Models.Entities;

namespace SsttekAcademyHomeWorkApi.Models.Services.Products;

public interface IProductService
{
    List<Product> GetAll();
    Product GetById(int id);
    void Create(Product product);
    void Update(Product product);
    void Delete(int id);
}