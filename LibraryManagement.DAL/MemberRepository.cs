using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LibraryManagement.Enums;

namespace LibraryManagement.DAL
{
    public class MemberRepository
    {
        public LoginResult UserLogin(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Library"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UserLogin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50)).Value = username;
                    cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 255)).Value = password;
                    SqlParameter returnValue = new SqlParameter
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    cmd.Parameters.Add(returnValue);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        int result = (int)returnValue.Value;
                        return (LoginResult)result;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return LoginResult.ErrorOccurred; 
                    }
                }
            }
        }
    }
}
