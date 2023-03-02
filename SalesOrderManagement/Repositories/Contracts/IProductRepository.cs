using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<DTOProduct>> GetProducts();
        Task<DTOProduct?> GetProductById(int id);
        Task<bool> Create(DTOProduct model);
        Task<bool> Update(DTOProduct model);
        Task<IEnumerable<DTOProductAttribute?>> GetProductAttributes();
    }
}
