using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagement.DAL
{
    public class MemberRepository
    {
        public int UserLogin(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Library"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UserLogin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50)).Value = username;
                    cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 255)).Value = password;
                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        int result = (int)returnValue.Value;
                        return result;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return -2; 
                    }
                }
            }
        }
    }
}
