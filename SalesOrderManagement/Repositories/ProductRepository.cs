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
                var dTOProduct = await (from product in _dbContext.Product
                                        join productAttribute in _dbContext.ProductAttribute
                                        on product.ProductId equals productAttribute.ProductId
                                        join dimension in _dbContext.Dimension
                                        on productAttribute.DimensionId equals dimension.DimensionId
                                        where product.ProductId == id
                                        select new DTOProduct
                                        {
                                            ProductId = product.ProductId,
                                            ProductName = product.ProductName,
                                            DTOProductAttributes = product.ProductAttribute.Select(_it => new DTOProductAttribute
                                            {
                                                ProductAttributeId = _it.ProductAttributeId,
                                                ProductAttributeType = _it.ProductAttributeType,
                                                TypeId = _it.ProductAttributeType == "Doors" ? 1 : 2,
                                                DimensionId = _it.DimensionId,
                                                ActualDimension = _it.Dimension.Width + " X " + _it.Dimension.Height
                                            }).ToList()
                                        }).FirstOrDefaultAsync();

                return dTOProduct;
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
                var dTOProducts = await this._dbContext.Product
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
                return dTOProducts;
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
                List<int> deletedIds = new List<int>();
                var product = await this._dbContext.Product.Where(it => it.ProductId == model.ProductId).Include(_it => _it.ProductAttribute).FirstOrDefaultAsync();
                if (product != null)
                {
                    foreach (var item in product.ProductAttribute)
                    {
                        deletedIds.Add(item.ProductAttributeId);
                    }
                    product.ProductName = model.ProductName ?? string.Empty;
                    foreach (var _item in model.DTOProductAttributes)
                    {
                        if (_item.ProductAttributeId == 0)
                        {
                            product.ProductAttribute.Add(new ProductAttribute() { ProductAttributeId = _item.ProductAttributeId, ProductAttributeType = _item.ProductAttributeType, DimensionId = _item.DimensionId });
                        }
                        else
                        {
                            var updateModel = product.ProductAttribute.FirstOrDefault(_it => _it.ProductAttributeId == _item.ProductAttributeId);
                            if (updateModel != null)
                            {
                                updateModel.ProductAttributeId = _item.ProductAttributeId;
                                updateModel.ProductAttributeType = _item.ProductAttributeType;
                                deletedIds.Remove(_item.ProductAttributeId);
                            }
                        }
                    }
                    foreach (var id in deletedIds)
                    {
                        var deletedModel = product.ProductAttribute.FirstOrDefault(_it => _it.ProductAttributeId.Equals(id));
                        if (deletedModel != null)
                        {
                            product.ProductAttribute.Remove(deletedModel);
                        }
                    }
                    await _dbContext.SaveChangesAsync();
                }
                return true;
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
