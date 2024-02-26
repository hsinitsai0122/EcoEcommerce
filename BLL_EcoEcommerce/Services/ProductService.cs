using BLL_EcoEcommerce.Entities;
using BLL_EcoEcommerce.Mappers;
using Shared_EcoEcommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL=DAL_EcoEcommerce.Entities;

namespace BLL_EcoEcommerce.Services
{
    public class ProductService : IProductRepository<Product>
    {
        private readonly IProductRepository<DAL.Product> _productRepository;

        public ProductService(IProductRepository<DAL.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll().Select(d => d.ToBLL());
        }

        public Product GetById(int id)
        {
            Product entity = _productRepository.GetById(id).ToBLL();
            if(!(entity.Id_Product == 0))
            {
                return entity;
            }
            else
            {
                return null;
            }
        }
        public string GetProductNameById(int id)
        {
            try
            {
                string productName = _productRepository.GetProductNameById(id);

                
                if (productName != null)
                {
                    return productName; 
                }
                else
                {
                    throw new ArgumentException($"Product with ID {id} not found");
                }
            }
            catch (Exception ex)
            { 
                throw new Exception("Error retrieving product name", ex);
            }
        }

        public IEnumerable<Product> FilterByPopularity()
        {
            return _productRepository.FilterByPopularity().Select(d => d.ToBLL());
        }

        public IEnumerable<Product> FilterByName(string name)
        {
            return _productRepository.FilterByName(name).Select(d => d.ToBLL());
        }
        public IEnumerable<Product> FilterByCateg(string proCateg)
        {
            return _productRepository.FilterByCateg(proCateg).Select(d => d.ToBLL());
        }

        public IEnumerable<Product> FilterByEcoScore(string ecoCriteria)
        {
            return _productRepository.FilterByEcoScore(ecoCriteria).Select(d => d.ToBLL());
        }


        public int Insert(Product entity)
        {
            return _productRepository.Insert(entity.ToDAL());
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity.ToDAL());
        }
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

    }
}
