using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Vinwonders.Connection
{
    internal class ConnectData
    {
        //B1: Khai báo chuỗi kết nối
        // Lấy đường dẫn kết nối có tên "ConnectLocalDB" được lưu trong file cấu hình App.config
        string strConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectLocalDB"].ConnectionString;

        // Khai báo biến SqlConnection dùng để làm cầu nối giữa C# và SQL Server
        SqlConnection sqlConn = null;

        // THÊM HÀM NÀY: Để DAL có thể lấy được ống kết nối và tạo Transaction
        public SqlConnection GetConnection()
        {
            return sqlConn;
        }

        //B2: Tạo cổng kết nối
        /// <summary>
        /// Phương thức dùng để khởi tạo và mở cánh cửa kết nối tới cơ sở dữ liệu.
        /// Lệnh if giúp kiểm tra xem kết nối đã mở chưa, nếu chưa mở thì mới mở để tránh lỗi.
        /// </summary>
        public void OpenConnect()
        {
            sqlConn = new SqlConnection(strConnect);
            if (sqlConn.State != ConnectionState.Open)
            {
                sqlConn.Open();
            }
        }

        //B3: Đóng cổng kết nối
        /// <summary>
        /// Phương thức dùng để ngắt kết nối với SQL Server sau khi dùng xong.
        /// Việc này cực kỳ quan trọng giúp giải phóng bộ nhớ (RAM) và tránh tình trạng treo Database.
        /// </summary>
        public void CloseConnect()
        {
            if (sqlConn.State != ConnectionState.Closed)
            {
                sqlConn.Close();
                sqlConn.Dispose(); // Xóa sạch rác trong bộ nhớ
            }
        }

        //PT hiển thị danh sách
        /// <summary>
        /// Phương thức dùng để thực thi các câu lệnh SELECT trả về một BẢNG dữ liệu (Nhiều dòng, nhiều cột).
        /// Thường dùng đổ dữ liệu lên DataGridView.
        /// </summary>
        /// <param name="sql">Tên của Store Procedure trong SQL</param>
        /// <param name="parameters">Danh sách các tham số cần truyền xuống SQL (nếu có)</param>
        /// <returns>DataTable chứa dữ liệu kết quả</returns>
        public DataTable ReadData(string sql, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            OpenConnect(); // Gọi hàm mở kết nối

            // SqlCommand là công cụ để mang câu lệnh từ C# xuống SQL chạy
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.StoredProcedure; // Định dạng lệnh là Store Procedure
            sqlCmd.Connection = sqlConn;

            // Nếu có tham số (ví dụ tìm theo tên), thì nạp các tham số đó vào Command
            if (parameters != null)
            {
                sqlCmd.Parameters.AddRange(parameters);
            }

            int rowsAffected = sqlCmd.ExecuteNonQuery();

            // SqlDataAdapter giống như một chiếc xe tải chở dữ liệu từ SQL về
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCmd);
            sqlData.Fill(dt); // Đổ dữ liệu vào bảng dt

            sqlData.Dispose(); // Dọn dẹp xe tải
            CloseConnect(); // Đóng cửa kết nối
            return dt; // Trả bảng dữ liệu về cho tầng gọi nó
        }

        //PT thực hiện lệnh: Thêm, xóa, sửa
        /// <summary>
        /// Phương thức dùng để thực thi các lệnh làm thay đổi dữ liệu như INSERT, UPDATE, DELETE.
        /// </summary>
        /// <param name="sql">Tên của Store Procedure</param>
        /// <param name="parameters">Danh sách dữ liệu cần Thêm/Sửa/Xóa</param>
        /// <returns>True nếu thành công (có dòng bị thay đổi), False nếu thất bại</returns>
        public bool ChangeData(string sql, SqlParameter[] parameters = null)
        {
            OpenConnect();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = sql;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = sqlConn;

                if (parameters != null)
                {
                    sqlCmd.Parameters.AddRange(parameters);
                }

                // ExecuteNonQuery chuyên dùng để chạy lệnh Thêm/Sửa/Xóa và trả về số dòng bị tác động
                int rowsAffected = sqlCmd.ExecuteNonQuery();
                CloseConnect();
                sqlCmd.Dispose();

                // Trả về true nếu có ít nhất 1 dòng bị thay đổi dữ liệu, hoặc -1 nếu Stored Procedure dùng SET NOCOUNT ON
                return rowsAffected > 0 || rowsAffected == -1;
            }
            catch (Exception)
            {
                CloseConnect(); // Đảm bảo luôn đóng kết nối khi lỗi để chống rò rỉ bộ nhớ
                throw; // Ném lỗi ra ngoài để tầng DAL/GUI bắt và hiển thị lỗi chính xác
            }
        }

        /// <summary>
        /// Phương thức dùng để thực thi các lệnh tính toán chỉ trả về ĐÚNG MỘT Ô GIÁ TRỊ.
        /// Thường dùng cho các hàm thống kê như: SUM (tổng tiền), COUNT (đếm số lượng).
        /// </summary>
        /// <param name="sql">Tên Store Procedure</param>
        /// <param name="parameters">Tham số đầu vào (nếu có)</param>
        /// <returns>Dữ liệu dưới dạng object (cần Convert ép kiểu sau khi nhận được)</returns>
        public object ResultData(string sql, SqlParameter[] parameters = null)
        {
            OpenConnect();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = sql;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = sqlConn;

                if (parameters != null)
                {
                    sqlCmd.Parameters.AddRange(parameters);
                }

                // ExecuteScalar chuyên dùng để bốc lấy giá trị nằm ở [Dòng 1, Cột 1] của kết quả SQL
                object result = sqlCmd.ExecuteScalar();

                CloseConnect();
                sqlCmd.Dispose();
                return result; // Trả con số tính toán được về
            }
            catch (Exception)
            {
                CloseConnect(); 
                throw; // Ném lỗi ra ngoài
            }
        }
    }
}
