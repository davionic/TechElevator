using SSGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.DAL
{
    public class ProductSqlDAL : IProductsDAL
    {
        private readonly string _connectionString;

        public ProductSqlDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ProductModel GetProduct(int id)
        {
            //return GetProducts().FirstOrDefault(product => product.Id == id);
            ProductModel product = new ProductModel();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM products WHERE Product_Id = @Id", conn);

                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    product.Name = (string)reader["Name"];
                    product.Cost = (decimal)reader["Price"];
                    product.Description = (string)reader["Description"];
                    product.ProductImage = (string)reader["Image_Name"];
                    product.Id = (int)reader["product_id"];
                }
            }

            return product;
        }

        public IList<ProductModel> GetProducts()
        {
            IList<ProductModel> products = new List<ProductModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM products", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var product = new ProductModel
                    {
                        Id = (int)reader["Product_Id"],
                        Name = (string)reader["Name"],
                        Cost = (decimal)reader["Price"],
                        Description = (string)reader["Description"],
                        ProductImage = (string)reader["Image_Name"],

                    };
                    products.Add(product);
                }
            }

            return products;
        }

        
    }

}
