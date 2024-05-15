using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Day2Lab
{
	public class OwnersServiceTests
	{

		// Create Mock of Dependencies
		Mock<FactoryContext> contextMock;


		CarRepository _carRepository; 

		public void CarRepositoryTests()
		{
			// Create Mock of Dependencies
			contextMock = new();

			// use fake object as dependency
			_carRepository = new(contextMock.Object);
		}


		[Fact]
		public void GetCarById_AskById_CarObject()
		{
			// Arrange
			// Build the mock data
			List<Car> cars = new List<Car>()
			{
				new Car() { Id = 2 },
				new Car() { Id = 4 },
				new Car() { Id = 6 }
			};

			// setup called Dbsets
			contextMock.Setup(o => o.Cars).ReturnsDbSet(cars);

			// Act
			Car result = _carRepository.GetCarById(4);

			// Assert
			Assert.NotNull(result);
		}

	
	
		[Fact]
		public void GetAllCar_AskForCars_CheckIfEmpty()
		{
			// Arrange
			// Build the mock data
			List<Car> cars = new List<Car>();

			// setup called Dbsets
			contextMock.Setup(o => o.Cars).ReturnsDbSet(cars);

			// Act
			var result = _carRepository.GetAllCars();

			// Assert
			Assert.Empty(result);
		}
	
		

		public void AddCar_CheckIdAddedSuccessfuly_ReturnTrue()
		{
			// Arrange
			
			var cars = new List<Car>();

			// setup called Dbsets
			contextMock.Setup(c => c.Cars).ReturnsDbSet(cars);
			Car car = new Car() { Id = 10,Price=600000,Velocity=30 };
			// Act
			bool result = _carRepository.AddCar(car);

			// Assert
			Assert.True(result);
		}

		
		[Fact]
		public void Remove_CarRemovedSuccessfully()
		{
			// Arrange
		

			// Create a mock car
			Car car = new Car() { Id = 2 };

			// setup called Dbsets
			var cars = new List<Car>() { car };
			contextMock.Setup(c => c.Cars).ReturnsDbSet(cars);

			// Act
			bool result = _carRepository.Remove(2);

			// Assert
			Assert.True(result);
		}
		
		
		
	}
}
