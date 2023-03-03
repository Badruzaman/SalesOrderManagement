using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Web.Pages.Product
{
    public class SalesOrderBase : ComponentBase
    {
        [Inject]
        protected IProductService ProductService { get; set; }
        protected IEnumerable<DTOProduct> Products { get; set; }
        [Inject]
        protected IDimensionService DimensionService { get; set; }
        protected IEnumerable<DTODimension> Dimensions { get; set; }
        protected DTOProduct product { get; set; } = new DTOProduct();
        protected int AttributeTypeId { get; set; }
        protected string message = string.Empty;
        protected bool getModelValidation(DTOProduct model)
        {
            if (string.IsNullOrWhiteSpace(model.ProductName))
            {
                return false;
            }
            else
            {
                if (!(model.DTOProductAttributes.Count() > 0))
                {
                    return false;
                }
                else
                {
                    foreach (var item in model.DTOProductAttributes)
                    {
                        if (!(item.DimensionId > 0))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        protected bool checkDuplicateProduct(DTOProduct model, int dimensionId, string Attrtype)
        {
            bool isExist = model.DTOProductAttributes.Any(it => it.DimensionId == dimensionId && it.ProductAttributeType == Attrtype);
            return isExist;
        }
        protected List<AttributeType> GetAttributeTypes()
        {
           return new List<AttributeType>() { new AttributeType { TypeId = 1, Name = "Doors" }, new AttributeType { TypeId = 2, Name = "Window" } };
        }
    }
    public class AttributeType
    {
        public int TypeId { get; set; }
        public string Name { get; set; }
    }

}
