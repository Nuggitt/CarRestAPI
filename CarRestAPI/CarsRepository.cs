namespace CarRestAPI
{
    public class CarsRepository
    {
        private List<Car> cars = new List<Car>
        {       new Car { Id = 1, Brand = "Ford", Model = "Focus", HorsePower = 85 },
                new Car { Id = 2, Brand = "Toyota", Model = "Corolla", HorsePower = 110 },
                new Car { Id = 3, Brand = "Volkswagen", Model = "Golf", HorsePower = 90 },
                new Car { Id = 4, Brand = "Honda", Model = "Civic", HorsePower = 100 },
                new Car { Id = 5, Brand = "Chevrolet", Model = "Cruze", HorsePower = 115 },
                new Car { Id = 6, Brand = "Hyundai", Model = "Elantra", HorsePower = 128 },
                new Car { Id = 7, Brand = "Kia", Model = "Forte", HorsePower = 147 },
                new Car { Id = 8, Brand = "Mazda", Model = "Mazda3", HorsePower = 155 },
                new Car { Id = 9, Brand = "Nissan", Model = "Sentra", HorsePower = 149 },
                new Car { Id = 10, Brand = "Subaru", Model = "Impreza", HorsePower = 152 },
                new Car { Id = 11, Brand = "Audi", Model = "A3", HorsePower = 184 },
                new Car { Id = 12, Brand = "BMW", Model = "3 Series", HorsePower = 255 },
                new Car { Id = 13, Brand = "Mercedes-Benz", Model = "A-Class", HorsePower = 188 },
                new Car { Id = 14, Brand = "Lexus", Model = "IS", HorsePower = 241 },
                new Car { Id = 15, Brand = "Infiniti", Model = "Q50", HorsePower = 300 },
                new Car { Id = 16, Brand = "Volvo", Model = "S60", HorsePower = 250 },
                new Car { Id = 17, Brand = "Ford", Model = "Fusion", HorsePower = 175 },
                new Car { Id = 18, Brand = "Toyota", Model = "Camry", HorsePower = 203 },
                new Car { Id = 19, Brand = "Volkswagen", Model = "Jetta", HorsePower = 147 },
                new Car { Id = 20, Brand = "Honda", Model = "Accord", HorsePower = 192 },
                new Car { Id = 21, Brand = "Chevrolet", Model = "Malibu", HorsePower = 160 },
                new Car { Id = 22, Brand = "Hyundai", Model = "Sonata", HorsePower = 191 },
                new Car { Id = 23, Brand = "Kia", Model = "Optima", HorsePower = 185 },
                new Car { Id = 24, Brand = "Mazda", Model = "Mazda6", HorsePower = 187 },
                new Car { Id = 25, Brand = "Nissan", Model = "Altima", HorsePower = 188 },
                new Car { Id = 26, Brand = "Subaru", Model = "Legacy", HorsePower = 182 }
        };


        public List<Car> GetAllCars()
        {
            return new List<Car>(cars);
        }

        public Car? GetCarById(int id)
        {
            return cars.FirstOrDefault(c => c.Id == id);
        }

        public Car AddCar(Car car)
        {
            car.ValidateId();
            car.ValidateBrand();
            car.ValidateModel();
            car.ValidateHorsePower();
            cars.Add(car);
            return car;
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
            return car;
        }

        public Car DeleteCar(int id)
        {
            Car? car = GetCarById(id);
            if (car == null)
            {
                throw new ArgumentException("Car not found");
            }
            cars.Remove(car);
            return car;
        }


    }
}
