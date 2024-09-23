using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Quanly
{
    public class DAL_MilkProduction:DBConnect
    {
        public DataTable getMilkProduction()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    conn.Open();

                    // Tạo câu lệnh SQL
                    string query = "SELECT * FROM MilkProduction";

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
        public void InsertMilkProduction(int Id, int AnimalId, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO MilkProduction (MilkID, AnimalID, Liters) VALUES (@Id, @AnimalId ,@Quantity)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Thêm tham số cho câu lệnh SQL
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@AnimalId", AnimalId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    // Thực hiện câu lệnh
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }
        }
        public void UpdateMilkProductionl(int id, int newQuantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE MilkProduction SET Liters = @Quantity WHERE  AnimalID = @ID";
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
