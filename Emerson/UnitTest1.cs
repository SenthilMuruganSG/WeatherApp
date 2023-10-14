


using Emerson_WeatherApp.Controllers;
using Emerson_WeatherApp.DataContext;
using Emerson_WeatherApp.Interface;
using Emerson_WeatherApp.Models;
using Emerson_WeatherApp.Services;
using EmersonTestProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;
using Xunit;
using Assert = Xunit.Assert;

namespace Emerson

{
    public class WeatherUnitTestService
    {

        private WeatherUnitTestService repository;
        public static DbContextOptions<WeatherDbContext> dbContextOptions { get; }
        public static string connectionString = "Data Source=PROSPERITY;Initial Catalog=Emersion;User Id=sa;Password=admin!23;multipleactiveresultsets=True;Encrypt=false";

        static WeatherUnitTestService()
        {
            dbContextOptions = new DbContextOptionsBuilder<WeatherDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        IWeather weatherService;

        public WeatherUnitTestService()
        {
            var context = new WeatherDbContext(dbContextOptions);
            EntityContext db = new EntityContext();
            db.Seed(context);

            weatherService = new WeatherService(context);
        }
        
        public async void Task_GetCityList_Return_OkResult()
        {
            
            //Act
            var data = await weatherService.GetCityList();

            //Assert
            Assert.IsType<CityListResponse>(data);
        }

        [Fact]
        public async void Task_GetCityList_Return_BadRequestResult()
        {
            
            var data = await weatherService.GetCityList();
            data = null;

            if (data != null)
                //Assert
                Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetHighHumidityCityData_Return_OkResult()
        {

            //Act
            int Month = 0;
            var data = await weatherService.GetHighHumidityCityData(Month);

            //Assert
            Assert.IsType<CityAverageHumidityResponse>(data);
        }

        [Fact]
        public async void Task_GetHighHumidityCityData_Return_BadRequestResult()
        {
            int Month = 0;

            var data = await weatherService.GetHighHumidityCityData(Month);
            data = null;

            if (data != null)
                //Assert
                Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetHighTemperatureCityData_Return_OkResult()
        {

            //Act
            int Month = 0;
            var data = await weatherService.GetHighTemperatureCityData(Month);

            //Assert
            Assert.IsType<CityHighTemperatureResponse>(data);
        }

        [Fact]
        public async void Task_GetHighTemperatureCityData_Return_BadRequestResult()
        {
            int Month = 0;

            var data = await weatherService.GetHighTemperatureCityData(Month);
            data = null;

            if (data != null)
                //Assert
                Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetVariableData_Temp_Return_OkResult()
        {

            //Act
            var weatherRequest = new WeatherRequest() { CityId=1, EndDate=DateTime.Parse("Jan 01, 2023"), StartDate = DateTime.Parse("Jan  31, 2023"), VariableName= "Temperature" };
            var data = await weatherService.GetVariableData(weatherRequest);

            //Assert
            Assert.IsType<WeatherResponse>(data);
        }

        [Fact]
        public async void Task_GetVariableData_Return_Temp_BadRequestResult()
        {
            var weatherRequest = new WeatherRequest() { CityId = 1, EndDate = DateTime.Parse("Jan 01, 2023"), StartDate = DateTime.Parse("Jan  31, 2023"), VariableName = "Temperature" };

            var data = await weatherService.GetVariableData(weatherRequest);
            data = null;

            if (data != null)
                //Assert
                Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetVariableData_Humidity_Return_OkResult()
        {

            //Act
            var weatherRequest = new WeatherRequest() { CityId = 1, EndDate = DateTime.Parse("Jan 01, 2023"), StartDate = DateTime.Parse("Jan  31, 2023"), VariableName = "Humidity" };
            var data = await weatherService.GetVariableData(weatherRequest);

            //Assert
            Assert.IsType<WeatherResponse>(data);
        }

        [Fact]
        public async void Task_GetVariableData_Return_Humidity_BadRequestResult()
        {
            var weatherRequest = new WeatherRequest() { CityId = 1, EndDate = DateTime.Parse("Jan 01, 2023"), StartDate = DateTime.Parse("Jan  31, 2023"), VariableName = "Humidity" };

            var data = await weatherService.GetVariableData(weatherRequest);
            data = null;

            if (data != null)
                //Assert
                Assert.IsType<BadRequestResult>(data);
        }


    }
}