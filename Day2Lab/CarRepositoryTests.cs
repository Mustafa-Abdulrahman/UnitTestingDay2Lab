using CarAPI.Entities;

using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using Moq;
using Moq.EntityFrameworkCore;


namespace Day2Lab
{
	public class CarRepositoryTests
	{
		//mock dependencies
		Mock<FactoryContext> mockFactoryContext;

		//use fake object
		OwnerRepository _ownerRepository;
		public CarRepositoryTests()
		{
			//mock dependencies
			mockFactoryContext = new();
			//use fake object 
			_ownerRepository = new(mockFactoryContext.Object);
		}

		[Fact]
		public void GetAllOwners_AskForOwners_listOfOwners()
		{
			//arrange
			//bulid mock data
			List<Owner> owners = new List<Owner>()
			{
				new Owner(){  Id = 3 ,Name="Mustafa"},
				new Owner(){  Id = 4 ,Name="Asmaa"},
				
			};
			//setup called Dbsets
			mockFactoryContext.Setup(o => o.Owners).ReturnsDbSet(owners);

			//act
			var result = _ownerRepository.GetAllOwners();
			//assets
			Assert.NotEmpty(result);

		}
		[Fact]
		public void AddOwner_AddingOwner_true()
		{
			//arrange
			//build mock data
			List<Owner> owners = new List<Owner>()
			{
					new Owner(){  Id = 3 ,Name="Mustafa"},
				new Owner(){  Id = 4 ,Name="Sara"},
			};
			Owner owner = new Owner() { Id = 1, Name = "Mustafa" };
			//setup called Dbsets
			mockFactoryContext.Setup(o => o.Owners).ReturnsDbSet(owners);

			//act
			var result = _ownerRepository.AddOwner(owner);
			//assets
			Assert.True(result);

		}

		
		[Fact]
		public void AddOwner_NotAddingOwnerAlreadyExit_False()
		{
			//arrange
			List<Owner> owners = new List<Owner>()
			{
				new Owner(){  Id = 3 ,Name="Mustafa"},
				new Owner(){  Id = 4 ,Name="Hedra"},
			};
			Owner owner = new Owner() { Id = 1, Name = "Ahmed" };
			//setup called Dbsets
			mockFactoryContext.Setup(o => o.Owners).ReturnsDbSet(owners);

			//act
			var result = _ownerRepository.AddOwner(owner);
			//assets
			Assert.Equal(4, mockFactoryContext.Object.Owners.Count());
		}



	}
}
