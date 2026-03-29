using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppRentAcar.Models;

namespace WebAppRentAcar.Common
{
    public class CarsTypeConfiguration : IEntityTypeConfiguration<Car>
    {
        private readonly ICollection<Car> Cars=new List<Car>()
        {
             new Car { Id = 1, Brand = "BMW", Model = "320d", Year = 2018, Passengers = 5, Description = "Diesel, automatic, navigation", PricePerDay = 120m },
            new Car { Id = 2, Brand = "Audi", Model = "A4", Year = 2019, Passengers = 5, Description = "Petrol, automatic, leather seats", PricePerDay = 130m },
            new Car { Id = 3, Brand = "Mercedes", Model = "C220", Year = 2020, Passengers = 5, Description = "Diesel, automatic, premium interior", PricePerDay = 150m },
            new Car { Id = 4, Brand = "VW", Model = "Golf 7", Year = 2017, Passengers = 5, Description = "Petrol, manual, economical", PricePerDay = 80m },
            new Car { Id = 5, Brand = "Toyota", Model = "Corolla", Year = 2021, Passengers = 5, Description = "Hybrid, automatic, low consumption", PricePerDay = 110m },
            new Car { Id = 6, Brand = "Ford", Model = "Focus", Year = 2018, Passengers = 5, Description = "Diesel, manual, comfortable", PricePerDay = 90m },
            new Car { Id = 7, Brand = "Honda", Model = "Civic", Year = 2019, Passengers = 5, Description = "Petrol, automatic, sporty", PricePerDay = 115m },
            new Car { Id = 8, Brand = "Hyundai", Model = "i30", Year = 2020, Passengers = 5, Description = "Petrol, manual, reliable", PricePerDay = 85m },
            new Car { Id = 9, Brand = "Kia", Model = "Ceed", Year = 2021, Passengers = 5, Description = "Petrol, automatic, modern", PricePerDay = 95m },
            new Car { Id = 10, Brand = "Skoda", Model = "Octavia", Year = 2019, Passengers = 5, Description = "Diesel, automatic, spacious", PricePerDay = 105m },
            new Car { Id = 11, Brand = "Nissan", Model = "Qashqai", Year = 2020, Passengers = 5, Description = "SUV, petrol, automatic", PricePerDay = 140m },
            new Car { Id = 12, Brand = "Mazda", Model = "CX-5", Year = 2021, Passengers = 5, Description = "SUV, petrol, premium feel", PricePerDay = 145m },
            new Car { Id = 13, Brand = "Peugeot", Model = "3008", Year = 2018, Passengers = 5, Description = "SUV, diesel, stylish", PricePerDay = 135m },
            new Car { Id = 14, Brand = "Renault", Model = "Megane", Year = 2017, Passengers = 5, Description = "Diesel, manual, budget", PricePerDay = 75m },
            new Car { Id = 15, Brand = "Opel", Model = "Astra", Year = 2018, Passengers = 5, Description = "Petrol, manual, practical", PricePerDay = 80m },
            new Car { Id = 16, Brand = "Tesla", Model = "Model 3", Year = 2022, Passengers = 5, Description = "Electric, autopilot, premium", PricePerDay = 200m },
            new Car { Id = 17, Brand = "Volvo", Model = "XC60", Year = 2021, Passengers = 5, Description = "SUV, hybrid, safety features", PricePerDay = 180m },
            new Car { Id = 18, Brand = "Jeep", Model = "Compass", Year = 2020, Passengers = 5, Description = "SUV, 4x4, off-road capable", PricePerDay = 150m },
            new Car { Id = 19, Brand = "Dacia", Model = "Duster", Year = 2019, Passengers = 5, Description = "SUV, budget, reliable", PricePerDay = 70m },
            new Car { Id = 20, Brand = "Seat", Model = "Leon", Year = 2021, Passengers = 5, Description = "Petrol, sporty, modern", PricePerDay = 100m }
        };
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(Cars);
        }
    }
}
