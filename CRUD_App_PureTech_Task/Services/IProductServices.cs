using CRUD_App_PureTech_Task.Models;

namespace CRUD_App_PureTech_Task.Services
{
    public interface IProductServices
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProductById(int id);
        public int AddProduct(Product product);
        public int UpdateProduct(Product product);
        public int DeleteProduct(int id);
    }
}
