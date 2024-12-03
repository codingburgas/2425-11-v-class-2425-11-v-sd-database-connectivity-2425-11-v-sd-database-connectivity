using System.Data;
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
            
        }
        
        _connection.Open();
    }

    public void PullDataFromDatabase()
    {
        SqlCommand command = new SqlCommand("SELECT * FROM Planes", _connection);

        SqlDataReader reader = command.ExecuteReader();

        foreach (string row in reader)
        {
            string[] splitString = row.Split(',');
            
            Planes.Add(new Plane()
                {
                    // TODO: Unhandled exception. System.InvalidCastException: Unable to cast object of type 'System.Data.Common.DataRecordInternal' to type 'System.String'.
                    Id = int.Parse(splitString[0]),
                    Name = splitString[1],
                    Make = splitString[2],
                    Model = splitString[3],
                }
            );
        }

        foreach (Plane plane in Planes)
        {
            Console.WriteLine($"{plane.Id} - {plane.Name} - {plane.Make} - {plane.Model}");
        }
    }

    public void CheckConnection()
    {
        if (_connection.State == ConnectionState.Open)
        {
            Console.WriteLine("Connection established");
            
            PullDataFromDatabase();
        }
        else
        {
            Console.WriteLine("Connection not established");
        }
    }
}