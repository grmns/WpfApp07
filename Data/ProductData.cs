using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public class ProductData
    {
        // Método para obtener todos los productos
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

        public void InsertProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(DbConnection.ConnectionString))
            {
                SqlCommand command = new SqlCommand("InsertProduct", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Stock", product.Stock);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void DeleteProductLogical(int productID)
        {
            using (SqlConnection connection = new SqlConnection(DbConnection.ConnectionString))
            {
                SqlCommand command = new SqlCommand("DeleteProductLogical", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductID", productID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
