using System.Data.SqlClient;
using ReadFromDatabase.Models;

namespace ReadFromDatabase.Data;

public class TicketManagementDatabaseContext
{
    public List<Ticket> Tickets { get; set; }
    public List<Customer> Customers { get; set; }
    public List<Plane> Planes { get; set; }

    public TicketManagementDatabaseContext()
    {
        // TODO: Add connection settings
    }
    
    // TODO: Add onConfig
}