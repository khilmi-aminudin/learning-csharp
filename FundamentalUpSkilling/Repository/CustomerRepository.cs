using FundamentalUpSkilling.Config;
using FundamentalUpSkilling.Models;
using Npgsql;

namespace FundamentalUpSkilling.Repository;

class CustomerRepository : ICustomerRepository
{
    public void Create(Customer customer)
    {
        var _db = DbConfig.GetInstance().GetConnection();
        NpgsqlConnection connection = _db;
        try
        {
            var sqlQuery = "INSERT INTO m_customer(name,phone_number) VALUES ( @name, @phone_number );";
            var command = new NpgsqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@name", customer.Name);
            command.Parameters.AddWithValue("@phone_number", customer.PhoneNumber);

            command.ExecuteNonQuery();
            Console.WriteLine("New customer successfully inserted");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error insert table : " + e.Message);
        }
        finally
        {
            connection.Close();
        }
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void GenerateTable()
    {
        var _db = DbConfig.GetInstance().GetConnection();
        NpgsqlConnection connection = _db;

        try
        {
            const string createTable = @"
            CREATE TABLE IF NOT EXISTS m_customer(
                id BIGSERIAL,
                name VARCHAR(50) NOT NULL,
                phone_number VARCHAR(15) NOT NULL,
                is_active BOOLEAN 
            )";
            var command = new NpgsqlCommand(createTable, connection);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error creating table : " + e.Message);
        }
        finally
        {
            connection.Close();
        }
    }

    public List<Customer> GetAll()
    {
        var result = new List<Customer>();

        var _db = DbConfig.GetInstance().GetConnection();
        NpgsqlConnection connection = _db;
        try
        {
            var sqlQuery = "SELECT * FROM m_customer;";
            var reader = new NpgsqlCommand(sqlQuery, connection).ExecuteReader();
            while (reader.Read())
            {
            long id = DBNull.Value.Equals(reader["id"]) ? 0 : Convert.ToInt64(reader["id"]);
            string name = reader["name"] == DBNull.Value ? string.Empty : reader["name"].ToString();
            string phoneNumber = reader["phone_number"] == DBNull.Value ? string.Empty : reader["phone_number"].ToString();
            bool isActive = reader["is_active"] == DBNull.Value ? false : Convert.ToBoolean(reader["is_active"]);

            result.Add(new Customer
            {
                Id = id,
                Name = name,
                PhoneNumber = phoneNumber,
                IsActive = isActive
            });
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error list customer : " + e.Message);
        }
        finally
        {
            connection.Close();
        }

        return result;
    }

    public Customer? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Customer customer)
    {
        throw new NotImplementedException();
    }
}