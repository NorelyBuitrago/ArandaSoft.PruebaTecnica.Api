using ArandaSoft.PruebaTecnica.Entities.DTOs;
using ArandaSoft.PruebaTecnica.Entities.Entities;
using ArandaSoft.PruebaTecnica.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaSoft.PruebaTecnica.Repository.Data
{
    public class ProductRepository : IProductRepository

    {
        private readonly DbContexAplic _dbContexAplic;

        public ProductRepository(DbContexAplic dbContexAplic)
        {
            _dbContexAplic = dbContexAplic;
        }
        public async Task<int> Delete(string code)
        {
            var item = await _dbContexAplic.Product.Where(u => u.Code == code).FirstOrDefaultAsync();
            if (item != null)
            {
                _dbContexAplic.Product.Remove(item);
            }
            return _dbContexAplic.SaveChanges();
        }

        public IQueryable<Product> GetAll()
        {
            return _dbContexAplic.Product.AsQueryable();
        }

        public IQueryable<Product> GetByParameters()
        {
            return _dbContexAplic.Product.AsNoTracking().AsQueryable();
        }

        public async Task<int> Save(Product product)
        {

            _dbContexAplic.Product.Add(product);
            return _dbContexAplic.SaveChanges();

        }

        public bool Update(Product product)
        {
            var productUpdate = _dbContexAplic.Product.Where(u => u.Id == product.Id).FirstOrDefault();
            if (productUpdate != null)
            {
                productUpdate.Code = product.Code;
                productUpdate.Name = product.Name;
                productUpdate.BriefDescription = product.BriefDescription;
                productUpdate.Category = product.Category;
                productUpdate.ImageProduct = product.ImageProduct;
            }
            return _dbContexAplic.SaveChanges() > 0;

        }
    }
}
