using SalesOrderManagement.Models.DTOs;
using System.Threading.Tasks;

namespace SalesOderManagement.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<DTOProduct>> GetProducts();
        Task Create(DTOProduct model);
        Task<DTOProduct?> GetProductById(int id);
        Task Update(DTOProduct model);
        Task<IEnumerable<DTOProductAttribute>> GetProductAttributes();
    }   
}
