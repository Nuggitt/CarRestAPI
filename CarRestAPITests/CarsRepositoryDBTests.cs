using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRestAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarRestAPI.Tests
{
    [TestClass()]
    public class CarsRepositoryDBTests
    {
        private const bool useDatabase = true;
        private static CarsRepositoryDB? _carsRepositoryDB;

        [ClassInitialize]
        public static void InitOnce(TestContext context)
        {
            if (useDatabase)
            {
                var optionsBuilder = new DbContextOptionsBuilder<CarsDbContext>();

                optionsBuilder.UseSqlServer(DBSecrets.ConnectionString);

                CarsDbContext carsDbContext = new CarsDbContext(optionsBuilder.Options);
                carsDbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Cars");
                _carsRepositoryDB = new CarsRepositoryDB(carsDbContext);
            }

        }

        [TestMethod()]
        public void AddCarTest()
        {
            Car Ford =_carsRepositoryDB.AddCar(new Car { Id = 1, Brand = "Ford", Model = "Focus", HorsePower = 85 });
            Car Skoda = _carsRepositoryDB.AddCar(new Car() { Id = 2, Brand = "Skoda", Model = "Octavia", HorsePower = 105 });
            Assert.AreEqual("Ford", Ford.Brand);
            Assert.IsTrue(Skoda.Id == 2);
            IEnumerable<Car> cars = _carsRepositoryDB.GetAllCars();
            Assert.IsTrue(cars.Count() == 2);
        }

        [TestMethod()]
        public void GetAllCarsTest()
        {
            // Arrange: Setup initial state
            _carsRepositoryDB.DeleteAllCars();

            // Act: Add cars
            _carsRepositoryDB.AddCar(new Car { Id = 5, Brand = "Ford", Model = "Focus", HorsePower = 85 });
            _carsRepositoryDB.AddCar(new Car { Id = 6, Brand = "Skoda", Model = "Octavia", HorsePower = 105 });

            // Assert: Verify the count
            IEnumerable<Car> cars = _carsRepositoryDB.GetAllCars();
            Assert.AreEqual(2, cars.Count());
        }



        [TestMethod()]
        public void GetCarByIdTest()
        {
            _carsRepositoryDB.AddCar(new Car { Id = 4, Brand = "Ford", Model = "Focus", HorsePower = 85 });
            Car? car = _carsRepositoryDB.GetCarById(4);
        }

        [TestMethod()]
        public void UpdateCarTest()
        {
            Car car = _carsRepositoryDB.AddCar(new Car { Id = 7, Brand = "Ford", Model = "Focus", HorsePower = 85 });
            Car updatedCar = _carsRepositoryDB.UpdateCar(new Car { Id = 7, Brand = "Ford", Model = "Focus", HorsePower = 100 });
            Assert.AreEqual(100, updatedCar.HorsePower);
            Assert.IsNotNull(updatedCar);
          
        }

        [TestMethod()]
        public void DeleteCarTest()
        {
            Car car = _carsRepositoryDB.AddCar(new Car { Id = 9, Brand = "Ford", Model = "Focus", HorsePower = 85 });
            Car deletedCar = _carsRepositoryDB.DeleteCar(9);
            Assert.IsNotNull(deletedCar);
            Assert.AreEqual("Ford", deletedCar.Brand);

        }
    }
}