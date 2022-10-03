using ArandaSoft.PruebaTecnica.Entities.DTOs;
using ArandaSoft.PruebaTecnica.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaSoft.PruebaTecnica.Entities.Interfaces
{
    public interface IProductRepository
    {
        public IQueryable<Product> GetAll();
        public IQueryable<Product> GetByParameters();
        public Task<int> Save(Product product);
        public bool Update(Product product);
        public Task<int> Delete(string code);
    }
}
