using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Api.Data;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.DTOs;
using System.Linq;

namespace SalesOrderManagement.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SalesOrderDBContext _dbContext;
        public ProductRepository(SalesOrderDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DTOProduct?> GetProductById(int id)
        {
            try
            {
                var Product = await this._dbContext.Product.FindAsync(id);
                if (Product == null)
                {
                    return null;
                }
                var DTOProduct = new DTOProduct { ProductId = Product.ProductId, ProductName = Product.ProductName };
                return DTOProduct;
            }
            catch (Exception)
            {
                return null;

            }
        }
        public async Task<IEnumerable<DTOProduct>> GetProducts()
        {
            try
            {
                var DTOProducts = await this._dbContext.Product
                .Select(it => new DTOProduct
                {
                    ProductId = it.ProductId,
                    ProductName = it.ProductName,
                    DTOProductAttributes = it.ProductAttribute.Select(_it => new DTOProductAttribute
                    {
                        ProductAttributeId = _it.ProductAttributeId,
                        ProductAttributeType = _it.ProductAttributeType,
                        DimensionId = _it.DimensionId,
                        ActualDimension = _it.Dimension.Width + " X " + _it.Dimension.Height
                    }).ToList()
                }).ToListAsync();
                return DTOProducts;
            }
            catch (Exception)
            {
                return Enumerable.Empty<DTOProduct>();
            }
        }
        public async Task<bool> Create(DTOProduct model)
        {
            try
            {
                var product = new Product() { ProductName = model.ProductName ?? string.Empty };
                foreach (var attribute in model.DTOProductAttributes)
                {
                    var _attribute = new ProductAttribute() { ProductAttributeType = attribute.ProductAttributeType ?? string.Empty, DimensionId = attribute.DimensionId };
                    product.ProductAttribute.Add(_attribute);
                }
                await _dbContext.Product.AddAsync(product);
                var result = await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(DTOProduct model)
        {
            try
            {
                var Product = await this._dbContext.Product.FindAsync(model.ProductId);
                if (Product != null)
                {
                    Product.ProductName = model.ProductName ?? string.Empty;
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<DTOProductAttribute?>> GetProductAttributes()
        {
            try
            {
                var DTOProductAttributes = await this._dbContext.ProductAttribute
                .Select(it => new DTOProductAttribute
                {
                    ProductAttributeId = it.ProductAttributeId,
                    ProductId = it.ProductId,
                    ProductName = it.Product.ProductName,
                    ProductAttributeType = it.ProductAttributeType,
                    ActualDimension = it.Dimension.Width + " X " + it.Dimension.Height,
                    ProductAttributeName = it.Product.ProductName + " " + it.ProductAttributeType + " " + it.Dimension.Width + " X " + it.Dimension.Height
                }).ToListAsync();
                return DTOProductAttributes;
            }
            catch (Exception)
            {
                return Enumerable.Empty<DTOProductAttribute>();
            }
        }
    }
}
