using System.IO.IsolatedStorage;
using CalendarApi.DataAccess;
using CalendarApi.Domain;

namespace CalendarApi.Tests
{
    public class StorageTests
    {
        private Storage _storage;

        [SetUp]
        public void Setup()
        {
            _storage = new Storage();
        }

        [Test]
        public void SaveEvent_WhenEventWithoutID_ShouldSetId()
        {
            //Assert
            var @event = new Event();

            //Act
            _storage.SaveEvent(@event);

            //Assert
            Assert.AreEqual(1, @event.Id);
        }
    }
}