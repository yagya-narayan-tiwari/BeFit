using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace BeFir.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage ="Username required")]
        [StringLength(20 , ErrorMessage ="username is too long")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Password must be between 8 and 20 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{4,20}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
        public string Password { set; get; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [RegularExpression(@"^\d{10,10}$", ErrorMessage = "Enter valid Phone Number")]
        public string PhoneNumber { set; get; }




        public static void insert(User user)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BeFit_DB;Integrated Security=True";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();

                cmdInsert.Connection = cn;

                cmdInsert.CommandType = System.Data.CommandType.Text;

                cmdInsert.CommandText = "insert into Users values(@UserName , @Password , @Email , @PhoneNumber)";

                cmdInsert.Parameters.AddWithValue("@UserName", user.UserName);
                cmdInsert.Parameters.AddWithValue("@Password", user.Password);
                cmdInsert.Parameters.AddWithValue("@Email", user.Email);
                cmdInsert.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);

                cmdInsert.ExecuteNonQuery();
                Console.WriteLine(cmdInsert.CommandText);

                Console.WriteLine("Data inseted successfully !!");

                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                cn.Close();
            }

        }


        // to update the data

        public static void update(User user)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BeFit_DB;Integrated Security=True";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();

                cmdInsert.Connection = cn;

                cmdInsert.CommandType = System.Data.CommandType.Text;

                cmdInsert.CommandText = "update Users set Password = @Password , Email = @Email , PhoneNumber = @PhoneNumber where UserName = @UserName";

                cmdInsert.Parameters.AddWithValue("@UserName", user.UserName);
                cmdInsert.Parameters.AddWithValue("@Password", user.Password);
                cmdInsert.Parameters.AddWithValue("@Email", user.Email);
                cmdInsert.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);

                cmdInsert.ExecuteNonQuery();

                Console.WriteLine(cmdInsert.CommandText);
                Console.WriteLine("Data updated successfully !!");
                Console.WriteLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                cn.Close();
            }




        }


        // to delete the data
        public static void delete(string username)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BeFit_DB;Integrated Security=True";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();

                cmdInsert.Connection = cn;

                cmdInsert.CommandType = System.Data.CommandType.Text;

                cmdInsert.CommandText = "delete from Users where UserName = @UserName";

                cmdInsert.Parameters.AddWithValue("@UserName", username);


                cmdInsert.ExecuteNonQuery();

                Console.WriteLine(cmdInsert.CommandText);
                Console.WriteLine("Data deleted successfully !!");
                Console.WriteLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                cn.Close();
            }
        }


        /*

        // to get the single data of employee
        public static Employee getSingleEmployee(int id)
        {
            SqlConnection cn = new SqlConnection();

            Employee emp = null;

            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True";
                cn.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "select * from Employees where EmpNo = @EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", id);


                SqlDataReader dr = cmd.ExecuteReader();

                emp = new Employee();

                if (dr.Read())
                {
                    emp.EmpNo = dr.GetInt32("EmpNo");
                    emp.Name = dr.GetString("Name");
                    emp.Basic = dr.GetDecimal("Basic");
                    emp.DeptNo = dr.GetInt32("DeptNo");
                }
                else
                {
                    Console.WriteLine("Employee data not found !!!");
                }

                dr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                cn.Close();
            }


            return emp;
        }

        // to get all employees data 
        public static List<Employee> getAllEmployees()
        {
            SqlConnection cn = new SqlConnection();

            List<Employee> empList = new List<Employee>();


            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True";

                cn.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "select * from Employees";

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Employee emp = new Employee();
                    emp.EmpNo = rd.GetInt32("EmpNo");
                    emp.Name = rd.GetString("Name");
                    emp.Basic = rd.GetDecimal("Basic");
                    emp.DeptNo = rd.GetInt32("DeptNo");

                    empList.Add(emp);
                }

                rd.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }


            return empList;
        }
        */

    }
}
