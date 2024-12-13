using System.Linq;
using NUnit.Framework;
using ReadFromDatabase.Data;
using ReadFromDatabase.Models;
using ReadFromDatabase.Repositories;

namespace ReadFromDatabase.Tests.Repositories;

[TestFixture]
[TestOf(typeof(PlaneRepository))]
public class PlaneRepositoryTest
{
    TicketManagementDatabaseContext _context = new TicketManagementDatabaseContext();

    [Test]
    public void TestCreateNewPlaneAndInsertIntoDatabase()
    {
        // Arrange
        PlaneRepository planeRepository = new PlaneRepository();
        
        Plane newPlane = new Plane(){Id = 666, Name = "Test Plane", Make = "New Make", Model = "New Model"};
        
        Plane result = new Plane();
        
        // Act
        planeRepository.CreatePlane(newPlane);
        
        _context.Planes.Clear();

        _context.ReadPlanes();
        
        result = _context.Planes.Where(plane => plane.Id == newPlane.Id).FirstOrDefault();
        
        // Assert
        Assert.That(newPlane, Is.EqualTo(result));
    }
}