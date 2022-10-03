using ArandaSoft.PruebaTecnica.Entities.DTOs;
using ArandaSoft.PruebaTecnica.Entities.Entities;
using ArandaSoft.PruebaTecnica.Entities.Enums;
using ArandaSoft.PruebaTecnica.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArandaSoft.PruebaTecnica.Services.Bi
{
    public class ProductServices : IProductServices

    {
        private readonly IProductRepository _productRepository;
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<int> DeleteProduct(string code)
        {

            return await _productRepository.Delete(code);
        }
        public  IQueryable<Product> GetAll ()
        {
            return _productRepository.GetAll();
        }  
        public IQueryable<Product> GetByParameters(ProductFilterDTO productFilterDTO)
        {
            var query = _productRepository.GetByParameters();

            if (!string.IsNullOrEmpty(productFilterDTO.Category))
            {
                query = query.Where(u => u.Category.ToLower() == productFilterDTO.Category.ToLower());
            }
            if (!string.IsNullOrEmpty(productFilterDTO.Name))
            {
                query = query.Where(u => u.Name.ToLower().Contains(productFilterDTO.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(productFilterDTO.Description))
            {
                query = query.Where(u => u.Category.ToLower() == productFilterDTO.Description.ToLower());
            }

            if (!string.IsNullOrEmpty(productFilterDTO.OrderBy) && !string.IsNullOrEmpty(productFilterDTO.OrderColumn))
            {
                if (productFilterDTO.OrderBy.ToLower() == "desc")
                {
                    if (productFilterDTO.OrderColumn.ToLower() == OrderColumn.name.ToString())
                    {
                        query = query.OrderByDescending(u => u.Name);
                    }
                    if (productFilterDTO.OrderColumn.ToLower() == OrderColumn.category.ToString())
                    {
                        query = query.OrderByDescending(u => u.Category);
                    }
                }
                else
                {
                    if (productFilterDTO.OrderColumn.ToLower() == OrderColumn.name.ToString())
                    {
                        query = query.OrderBy(u => u.Name);
                    }
                    if (productFilterDTO.OrderColumn.ToLower() == OrderColumn.category.ToString())
                    {
                        query = query.OrderBy(u => u.Category);
                    }
                }
            }

            query = query.Skip(productFilterDTO.Count).Take(productFilterDTO.PageSize);

            return query;
        }
        public Task<int> SaveProduct(Product product)
        {
            product.Id = Guid.NewGuid().ToString();
            return _productRepository.Save(product);
        }
        public bool UpdateProduct(Product product)
        {
            return _productRepository.Update(product);
        }
    }
}
