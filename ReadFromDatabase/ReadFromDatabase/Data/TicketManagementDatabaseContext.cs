using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using ReadFromDatabase.Models;

namespace ReadFromDatabase.Data;

public class TicketManagementDatabaseContext
{
    private SqlConnection _connection = null;
    public List<Ticket> Tickets { get; set; }
    public List<Customer> Customers { get; set; }
    public List<Plane> Planes { get; set; }
    public TicketManagementDatabaseContext()
    {
        // TODO: Hide connection string in an environment variable
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=TicketManagementDatabase;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        if (_connection == null)
        {
            _connection = new SqlConnection(connectionString);
            
            Tickets = new List<Ticket>();
            Customers = new List<Customer>();
            Planes = new List<Plane>();
            
            _connection.Open();
            
            ReadPlanes();
            ReadCustomers();
            ReadTickets();
        }
    }

    public void ReadPlanes()
    {
        SqlCommand command = new SqlCommand("SELECT * FROM [Planes]", _connection);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Planes.Add(new Plane()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = Convert.ToString(reader["Name"]),
                Make = Convert.ToString(reader["Make"]),
                Model = Convert.ToString(reader["Model"]),
            });
        }
        
        reader.Close();
    }
    
    public void ReadCustomers()
    {
        SqlCommand command = new SqlCommand("SELECT * FROM [Customers]", _connection);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Customers.Add(new Customer()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Age = Convert.ToInt32(reader["Age"]),
                Country = Convert.ToString(reader["Country"]),
                FirstName = Convert.ToString(reader["FirstName"]),
                LastName = Convert.ToString(reader["LastName"]),
            });
        }
        
        reader.Close();
    }
    
    public void ReadTickets()
    {
        SqlCommand command = new SqlCommand("SELECT * FROM [Tickets]", _connection);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Tickets.Add(new Ticket()
            {
                Id = Convert.ToInt32(reader["Id"]),
                From = Convert.ToString(reader["From"]),
                To = Convert.ToString(reader["To"]),
                DepartureTime = Convert.ToDateTime(reader["DepartureTime"]),
                ArrivalTime = Convert.ToDateTime(reader["ArrivalTime"]),
                SeatNumber = Convert.ToString(reader["SeatNumber"]),
                
                PlaneId = Planes.Where(x=> x.Id == Convert.ToInt32(reader["PlaneId"])).FirstOrDefault(),
                
                CustomerId = Customers.Where(x => x.Id == Convert.ToInt32(reader["CustomerId"])).FirstOrDefault(),
            });
        }
        
        reader.Close();
    }
}