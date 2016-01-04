using MWS.Domain.Entidades;
using MWS.Domain.Repositories;
using MWS.Domain.Specs;
using MWS.Infra.Persistence.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MWS.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private StoreDataContext _context;

        public ProductRepository(StoreDataContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public List<Product> Get()
        {
            return _context.Products.ToList();
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public List<Product> Get(int skip, int take)
        {
            return _context.Products.OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }

        public List<Product> GetProductsInStock()
        {
            return _context.Products.Where(ProductSpecs.GetProductsInStock()).ToList();
        }

        public List<Product> GetProductsOutOfStock()
        {
            return _context.Products.Where(ProductSpecs.GetProductsOutOfStock()).ToList();
        }

        public void Update(Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
        }
    }
}