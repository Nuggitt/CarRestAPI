namespace CarRestAPI
{
    public class Car
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? HorsePower { get; set; }

        public override string ToString()
        {
            return $"Car: {Id}, {Brand}, {Model}, {HorsePower}";
        }

        public void ValidateId()
        {
            if (Id == 0)
            {
                throw new ArgumentNullException("Id is required");
            }
            if (Id < 1)
            {
                throw new ArgumentException("Id must be at least 1");
            }
            
        }

        public void ValidateBrand()
        {
            if (Brand == null)
            {
                throw new ArgumentNullException("Brand is required");
            }
            if (Brand.Length < 1)
            {
                throw new ArgumentException("Brand must be at least 1 characters long");
            }
        }

        public void ValidateModel()
        {
            if (Model == null)
            {
                throw new ArgumentNullException("Model is required");
            }
            if (Model.Length < 1)
            {
                throw new ArgumentException("Model must be at least 1 characters long");
            }
        }

        public void ValidateHorsePower()
        {
            if (HorsePower == null)
            {
                throw new ArgumentNullException("HorsePower is required");
            }
            if (HorsePower < 40)
            {
                throw new ArgumentException("HorsePower must be at least 40 ");
            }
            if (HorsePower > 2000)
            {
                throw new ArgumentException("HorsePower must be at most 1000 ");
            }
        }

        public void Validate()
        {
            ValidateId();
            ValidateBrand();
            ValidateModel();
            ValidateHorsePower();
        }
  

    }
}
