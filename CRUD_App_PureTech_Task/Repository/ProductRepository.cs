using CRUD_App_PureTech_Task.Data;
using CRUD_App_PureTech_Task.Models;

namespace CRUD_App_PureTech_Task.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddProduct(Product product)
        {
            int res = 0;
            db.products.Add(product);
            res = db.SaveChanges();
            return res;
        }

        public int DeleteProduct(int id)
        {
            int res = 0;

            var result = db.products.Where(x=> x.Prod_Id == id).FirstOrDefault();

            if(result != null)
            {
                db.products.Remove(result);
                res = db.SaveChanges();
            }
             return res;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return db.products.ToList();
        }

        public Product GetProductById(int id)
        {
             var result = db.products.Where(x=> x.Prod_Id == id).SingleOrDefault();
             return result;  
        }

        public int UpdateProduct(Product product)
        {
            int res = 0;
            var result = db.products.Where(x => x.Prod_Id == product.Prod_Id).SingleOrDefault();

            if (result != null)
            {
                result.Prod_Name = product.Prod_Name;
                result.Prod_price = product.Prod_price;
                result.Prod_Description = product.Prod_Description;
                result.Prod_imageUrl = product.Prod_imageUrl;
                res = db.SaveChanges();
            }
            return res;
        }
    }
}
