using CRUD_App_PureTech_Task.Models;
using CRUD_App_PureTech_Task.Repository;

namespace CRUD_App_PureTech_Task.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository repo;
        public ProductServices(IProductRepository repo)
        {
            this.repo = repo;
        }
        public int AddProduct(Product product)
        {
            return repo.AddProduct(product);
        }

        public int DeleteProduct(int id)
        {
          return repo.DeleteProduct(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return repo.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return repo.GetProductById(id);
        }

        public int UpdateProduct(Product product)
        {
            return repo.UpdateProduct(product);
        }
    }
}
