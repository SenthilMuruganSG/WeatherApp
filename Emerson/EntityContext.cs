using Emerson_WeatherApp.DataContext;
using Emerson_WeatherApp.Entity;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmersonTestProject
{
    public class EntityContext
    { 
            public void Seed(WeatherDbContext context)
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //context.City.AddRange(
                //    new City() { Id = 1, CityName="Singapore" },
                //    new City() { Id = 2, CityName = "Malaysia" },
                //     new City() { Id = 3, CityName = "Banglore" }
                //);
                //context.Variable.AddRange(
                //    new Variable() { Id = 1, CityId = 1, Name="Temprature", Timestamp=DateTime.Now, Unit="%" , Value="50"}
                    
                //);
                //context.SaveChanges();
            }
        
    }
}
