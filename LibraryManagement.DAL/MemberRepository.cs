using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LibraryManagement.Enums;

namespace LibraryManagement.DAL
{
    public class MemberRepository
    {
        public DataTable GetAllMembers()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Library"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllMembers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable membersTable = new DataTable();
                            adapter.Fill(membersTable);
                            return membersTable;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return null; // Return null to indicate failure
                    }
                }
            }
        }

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
        public (bool isSuccess, string message) AddUser(string name, string address, string phone, string email, string password, bool isAdmin)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Library"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RegisterUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 255)).Value = name;
                    cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 255)).Value = address;
                    cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 15)).Value = phone;
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 255)).Value = email;
                    cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 255)).Value = password; 
                    cmd.Parameters.Add(new SqlParameter("@IsAdmin", SqlDbType.Bit)).Value = isAdmin;

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

                        switch (result)
                        {
                            case 1:
                                return (true, "User registration successful.");
                            case -1:
                                return (false, "Email already exists.");
                            case -2:
                            default:
                                return (false, "An error occurred during registration.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return (false, "An unexpected error occurred.");
                    }
                }
            }
        }
    }
}
