using Microsoft.EntityFrameworkCore;
using MyPlace.Data;
using NUnit.Framework;

namespace TestsMyPlace
{
    public class Test_RoomService
    {   
        private ApplicationDbContext _context;

        [SetUp]
        public void Setup()
        {
            var option = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestBd").Options;

            _context = new ApplicationDbContext(option, new OperationalStoreOptionsFroTests());
            _context.Rooms.Add(new MyPlace.Models.Room { RoomNumber = 5, RoomSize = 165, IsOcupied = false });
            _context.Rooms.Add(new MyPlace.Models.Room { RoomNumber = 7, RoomSize = 65, IsOcupied = false });
            _context.Rooms.Add(new MyPlace.Models.Room { RoomNumber = 6, RoomSize = 80, IsOcupied = false });
            _context.SaveChanges();
        }

        [TearDown]
        public void Teardown()
        {
            
        }

        [Test]
        public void getByMaxSize()
        {
            var service = new MyPlace.Services.RoomService(_context);
            Assert.AreEqual(2, service.GetAllRoomsByMaxSize(150).Count);
            Assert.AreEqual(1, service.GetAllRoomsByMaxSize(79).Count);
            Assert.AreEqual(3, service.GetAllRoomsByMaxSize(200).Count);
            Assert.AreEqual(2, service.GetAllRoomsByMaxSize(80).Count);
        }
    }
}