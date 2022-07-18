using MVCCrudUsingAdo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MVCCrudUsingAdo.DAL
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductDAL()
        {
            con=new SqlConnection(Startup.ConnectionString);
        }

        public List<Product> GetAllProducts()
        {
            List<Product> plist = new List<Product>();
            string qry = "select * from Product";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Id = Convert.ToInt32(dr["pro_id"]);
                    p.Name = dr["pro_Name"].ToString();
                    p.Price = Convert.ToDouble(dr["pro_price"]);
                    plist.Add(p);
                }
            }
            con.Close();
            return plist;
        }
        public Product GetProductById(int id)
        {
            Product p = new Product();
            string qry = "select * from Product where pro_id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    p.Id = Convert.ToInt32(dr["pro_id"]);
                    p.Name = dr["pro_name"].ToString();
                    p.Price = Convert.ToDouble(dr["pro_price"]);
                }
            }
            con.Close();
            return p;
        }

        public int AddProduct(Product prod)
        {
            string qry = "insert into Product values(@name,@price)";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateProduct(Product prod)
        {
            string qry = "update Product set pro_name=@name , pro_price=@price where pro_id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", prod.Id);
            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteProduct(int id)
        {
            string qry = "delete from Product where pro_id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }





}
