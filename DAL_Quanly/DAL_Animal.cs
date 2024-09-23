using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Quanly;
using System.Xml.Linq;

namespace DAL_Quanly
{
    public class DAL_Animal:DBConnect
    {
        public DataTable getAnimal()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    conn.Open();

                    // Tạo câu lệnh SQL
                    string query = "SELECT * FROM Animal";

                    // Thực hiện câu lệnh SQL
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return dt;
                }
            }
        }
        public string getTypeAnimal(int id)
        {
            string type = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT TypeAnimal FROM Animal WHERE AnimalId = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Thêm tham số cho câu lệnh SQL
                    cmd.Parameters.AddWithValue("@id", id);

                    // Sử dụng SqlDataReader để đọc dữ liệu
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Nếu tìm thấy dòng dữ liệu
                        if (reader.Read())
                        {
                            type = reader.GetString(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu cần
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return type;
        }
        public void InsertAnimal(int Id,string name, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Animal (AnimalId, TypeAnimal, Quantity) VALUES (@AnimalId, @TypeAnimal ,@Quantity)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Thêm tham số cho câu lệnh SQL
                    cmd.Parameters.AddWithValue("@AnimalId", Id);
                    cmd.Parameters.AddWithValue("@TypeAnimal", name);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    // Thực hiện câu lệnh
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }
        }
        public void UpdateAnimal(int id, int newQuantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Animal SET Quantity = @Quantity WHERE AnimalID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Quantity", newQuantity);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
