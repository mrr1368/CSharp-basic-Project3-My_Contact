using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_basic_Project3_My_Contact.Repository;
using System.Data.SqlClient;

namespace CSharp_basic_Project3_My_Contact.Services
{
    internal class ContactRepository : IContactRepository
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyContatcts_DB;Integrated Security=True";

        public bool Delete(int contactId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "DELETE FROM PersonInfo WHERE ContactId =" + contactId;
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ContactId", contactId);
                connection.Open();
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Insert(string firstName, string lastName, int age, string phoneNumber, string emailAddress, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                string query = "INSERT INTO PersonInfo (FirstName, LastName, Age, PhoneNumber, EmailAddress, Address) " +
                               "VALUES (@FirstName, @LastName, @Age, @PhoneNumber, @EmailAddress, @Address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@EmailAddress", emailAddress);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable Search(string searchText)
        {
            string query = "SELECT * FROM PersonInfo WHERE FirstName LIKE @SearchText OR LastName LIKE @SearchText";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;

        }

        public DataTable SelectAll()
        {
            string query = "SELECT * FROM PersonInfo";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable SelectRow(int contactid)
        {
            string query = "SELECT * FROM PersonInfo WHERE ContactId =" + contactid;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public bool Update(int contactId, string firstName, string lastName, int age, string phoneNumber, string emailAddress, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                string query = "UPDATE PersonInfo SET FirstName = @FirstName, LastName = @LastName, Age = @Age, PhoneNumber = @PhoneNumber, " +
                               "EmailAddress = @EmailAddress, Address = @Address WHERE ContactId = @ContactId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ContactId", contactId);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@EmailAddress", emailAddress);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close(); 
            }
        }
    }
}
