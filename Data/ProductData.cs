using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductData
    {
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(DbConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_ListProducts", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(reader["product_id"]),
                            Name = reader["name"].ToString(),
                            Price = Convert.ToDecimal(reader["price"]),
                            Stock = Convert.ToInt32(reader["stock"]),
                            Active = Convert.ToBoolean(reader["active"])
                        });
                    }
                }
            }

            return products;
        }
    }
}
