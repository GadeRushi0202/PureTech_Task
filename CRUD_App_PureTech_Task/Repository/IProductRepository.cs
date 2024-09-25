using CRUD_App_PureTech_Task.Models;

namespace CRUD_App_PureTech_Task.Repository
{
    public interface IProductRepository 
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProductById(int id);
        public int AddProduct(Product product);
        public int UpdateProduct(Product product);
        public int DeleteProduct(int id);
    }
}
