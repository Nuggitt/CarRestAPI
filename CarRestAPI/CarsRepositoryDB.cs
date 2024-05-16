using Microsoft.EntityFrameworkCore;

namespace CarRestAPI
{
    public class CarsRepositoryDB
    {
        private readonly CarsDbContext carsDbContext;

        public CarsRepositoryDB(CarsDbContext carsDbContext)
        {
            this.carsDbContext = carsDbContext;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return carsDbContext.Cars.ToList();
        }

        public Car? GetCarById(int id)
        {
            return carsDbContext.Cars.Find(id);
        }

        public Car AddCar(Car newCar)
        {
            newCar.ValidateId();
            newCar.ValidateBrand();
            newCar.ValidateModel();
            newCar.ValidateHorsePower();

            carsDbContext.Cars.Add(newCar);
            carsDbContext.SaveChanges();
            return newCar;
        }

        public Car UpdateCar(Car car)
        {
            car.Validate();
            Car? carToUpdate = GetCarById(car.Id);
            if (carToUpdate == null)
            {
                throw new ArgumentException("Car not found");
            }
            carToUpdate.Id = car.Id;
            carToUpdate.Brand = car.Brand;
            carToUpdate.Model = car.Model;
            carToUpdate.HorsePower = car.HorsePower;
            carsDbContext.SaveChanges();
            return car;
        }

        public Car DeleteCar(int id)
        {
            Car? car = GetCarById(id);
            if (car == null)
            {
                throw new ArgumentException("Car not found");
            }
            carsDbContext.Cars.Remove(car);
            carsDbContext.SaveChanges();
            return car;
        }

        public Car DeleteAllCars()
        {
            carsDbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Cars");
            return new Car();
        }


    }
}
