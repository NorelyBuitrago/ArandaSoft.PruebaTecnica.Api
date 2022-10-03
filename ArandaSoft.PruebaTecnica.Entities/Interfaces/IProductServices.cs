using ArandaSoft.PruebaTecnica.Entities.DTOs;
using ArandaSoft.PruebaTecnica.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaSoft.PruebaTecnica.Entities.Interfaces
{
    public interface IProductServices
    {
        public IQueryable<Product> GetAll();
        public IQueryable<Product> GetByParameters(ProductFilterDTO productFilterDTO);             
        public Task<int> SaveProduct(Product product);
        public bool UpdateProduct(Product product);
        public Task<int> DeleteProduct(string code);

    }
}
