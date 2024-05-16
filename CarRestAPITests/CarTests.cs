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
    public class CarTests
    {

        [TestMethod()]
        public void ToStringTest()
        {
            string str = new Car { Id = 1, Brand = "Ford", Model = "Focus", HorsePower = 85 }.ToString();
            Assert.AreEqual("Car: 1, Ford, Focus, 85", str);
        }

        [TestMethod()]
        public void ValidateIdTest()
        {
            Car car = new Car { Id = 0, Brand = "Ford", Model = "Focus", HorsePower = 85 };
            Assert.ThrowsException<ArgumentNullException>(() => car.ValidateId());
            car.Id = -1;
            Assert.ThrowsException<ArgumentException>(() => car.ValidateId());
        }

        [TestMethod()]
        public void ValidateBrandTest()
        {
            
            Car car = new Car { Id = 1, Brand = null, Model = "Focus", HorsePower = 85 };
            Assert.ThrowsException<ArgumentNullException>(() => car.ValidateBrand());
            car.Brand = "";
            Assert.ThrowsException<ArgumentException>(() => car.ValidateBrand());

        }

        [TestMethod()]
        public void ValidateModelTest()
        {
            Car car = new Car { Id = 1, Brand = "Ford", Model = null, HorsePower = 85 };
            Assert.ThrowsException<ArgumentNullException>(() => car.ValidateModel());
            car.Model = "";
            Assert.ThrowsException<ArgumentException>(() => car.ValidateModel());

        }

        [TestMethod()]
        public void ValidateHorsePowerTest()
        {
            Car car = new Car { Id = 1, Brand = "Ford", Model = "Focus", HorsePower = null };
            Assert.ThrowsException<ArgumentNullException>(() => car.ValidateHorsePower());
            car.HorsePower = 39;
            Assert.ThrowsException<ArgumentException>(() => car.ValidateHorsePower());

        }

        [TestMethod()]
        public void ValidateTest()
        {
            Car car = new Car { Id = 0, Brand = null, Model = null, HorsePower = null };
            Assert.ThrowsException<ArgumentNullException>(() => car.Validate());
            car.Id = -1;
            Assert.ThrowsException<ArgumentException>(() => car.Validate());
            car.Id = 1;
            car.Brand = "";
            Assert.ThrowsException<ArgumentException>(() => car.Validate());
            car.Brand = "Ford";
            car.Model = "";
            Assert.ThrowsException<ArgumentException>(() => car.Validate());
            car.Model = "Focus";
            car.HorsePower = 39;
            Assert.ThrowsException<ArgumentException>(() => car.Validate());

        }
    }
}