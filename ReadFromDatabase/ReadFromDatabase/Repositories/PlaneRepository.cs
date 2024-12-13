using Microsoft.Data.SqlClient;
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

        SqlCommand command = new SqlCommand($"INSERT INTO [Planes] VALUES {newPlane.Id},{newPlane.Name},{newPlane.Make},{newPlane.Model}");
        
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        
        adapter.InsertCommand.ExecuteNonQuery();
    }
    
    // UPDATE
    public void UpdatePlane(Plane updatedPlane)
    {
        Plane plane = _context.Planes.Where(x=>x.Id == updatedPlane.Id).FirstOrDefault();
        
        plane.Name = updatedPlane.Name;
        plane.Make = updatedPlane.Make;
        plane.Model = updatedPlane.Model;
        
        _context.Planes.Remove(plane);
        _context.Planes.Add(updatedPlane);
        
        SqlCommand command = new SqlCommand($"UPDATE [Planes] SET [Id] = {updatedPlane.Id}, [Name] = {updatedPlane.Name}, Make = {updatedPlane.Make}, Model = {updatedPlane.Model} WHERE [Id] = {updatedPlane.Id}");
        
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        
        adapter.UpdateCommand.ExecuteNonQuery();
    }
    
    // DELETE
    public void DeletePlane(Plane deletedPlane)
    {
        _context.Planes.Remove(deletedPlane);
        
        SqlCommand command = new SqlCommand($"DELETE FROM [Planes] WHERE [Id] = {deletedPlane.Id}");
        
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        
        adapter.DeleteCommand.ExecuteNonQuery();
    }
}