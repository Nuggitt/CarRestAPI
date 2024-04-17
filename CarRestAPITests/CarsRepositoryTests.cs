using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRestAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRestAPI.Tests
{
    [TestClass()]
    public class CarsRepositoryTests
    {
        private CarsRepository _carsRepository = new CarsRepository();


        [TestMethod()]
        public void GetAllCarsTest()
        {
            List<Car> cars = _carsRepository.GetAllCars();
            Assert.AreEqual(cars[0].Brand, "Ford");
            Assert.AreEqual(26, cars.Count);

            var carsWithF = cars.Where(c => c.Brand.StartsWith("F"));
            Assert.AreEqual(2, carsWithF.Count());

            var carsWithHorsePowerOver200 = cars.Where(c => c.HorsePower > 200);
            Assert.AreEqual(5, carsWithHorsePowerOver200.Count());

        }

        [TestMethod()]
        public void GetCarByIdTest()
        {
            Car? car = _carsRepository.GetCarById(1);
            Assert.AreEqual("Ford", car?.Brand);
        }

        [TestMethod()]
        public void AddCarTest()
        {
            _carsRepository.AddCar(new Car { Id = 27, Brand = "Ford", Model = "Mustang", HorsePower = 450 });
            List<Car> cars = _carsRepository.GetAllCars();
            Assert.AreEqual(27, cars.Count);
            Assert.AreEqual("Mustang", cars[26].Model);
        }

        [TestMethod()]
        public void UpdateCarTest()
        {
            Car car = new Car { Id = 1, Brand = "Ford", Model = "Focus", HorsePower = 85 };
            _carsRepository.AddCar(car);
            car.Brand = "Ferrai";
            _carsRepository.UpdateCar(car);
            Car? updatedCar = _carsRepository.GetCarById(1);
            Assert.AreEqual("Ferrai", updatedCar?.Brand);
           
        }

        [TestMethod()]
        public void DeleteCarTest()
        {
            _carsRepository.DeleteCar(1);
            List<Car> cars = _carsRepository.GetAllCars();
            Assert.AreEqual(25, cars.Count);
            Assert.IsNull(_carsRepository.GetCarById(1));

        }
    }
}