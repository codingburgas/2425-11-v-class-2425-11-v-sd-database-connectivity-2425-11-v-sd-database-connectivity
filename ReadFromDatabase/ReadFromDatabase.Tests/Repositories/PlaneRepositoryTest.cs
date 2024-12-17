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
        
        Plane newPlane = new Plane(){Id = 667, Name = "TestA Plane", Make = "New Make", Model = "New Model"};
        
        Plane result = new Plane();
        
        // Act
        //planeRepository.CreatePlane(newPlane);
        
        //_context.Planes.Clear();

        _context.ReadPlanes();
        
        result = _context.Planes.Where(plane => plane.Id == newPlane.Id).FirstOrDefault();
        
        // Assert
        Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(newPlane.Id));
                Assert.That(result.Name, Is.EqualTo(newPlane.Name));
                Assert.That(result.Make, Is.EqualTo(newPlane.Make));
                Assert.That(result.Model, Is.EqualTo(newPlane.Model));
            }
            );
    }
}