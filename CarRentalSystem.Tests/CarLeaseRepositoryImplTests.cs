using NUnit.Framework;
using CarRentalSystem.dao;
using CarRentalSystem.entity;

namespace CarRentalSystem.Tests
{
    public class CarLeaseRepositoryImplTests
    {
        private ICarLeaseRepository _repo;

        [SetUp]
        public void Setup()
        {
            _repo = new CarLeaseRepositoryImpl();
        }

        [Test]
        public void GetVehicleById_ValidId_ReturnsVehicle()
        {
            // Arrange
            int vehicleId = 1; // Make sure a vehicle with ID 1 exists in DB

            // Act
            Vehicle vehicle = _repo.GetVehicleById(vehicleId);

            // Assert
            Assert.NotNull(vehicle);
            Assert.AreEqual(vehicleId, vehicle.VehicleID);
        }

        [Test]
        public void GetVehicleById_InvalidId_ThrowsException()
        {
            // Arrange
            int invalidId = -1;

            // Assert + Act
            Assert.Throws<Exception>(() => _repo.GetVehicleById(invalidId));
        }
    }
}
