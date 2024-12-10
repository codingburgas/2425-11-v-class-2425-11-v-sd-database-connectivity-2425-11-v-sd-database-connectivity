using ReadFromDatabase.Data;
using ReadFromDatabase.Models;

namespace ReadFromDatabase.Repositories;

public class PlaneRepository : TicketManagementDatabaseContext
{
    private TicketManagementDatabaseContext _context = new TicketManagementDatabaseContext();
    
    // CREATE 
    public void CreatePlane(Plane newPlane)
    {
        _context.Planes.Add(newPlane);
    }
    
    // UPDATE
    public void Update(Plane updatedPlane)
    {
        
    }
}