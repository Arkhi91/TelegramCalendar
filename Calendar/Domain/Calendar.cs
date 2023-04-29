using CalendarApi.DataAccess;

namespace CalendarApi.Domain
{
    public class Calendar
    {
        private readonly Storage storage;

        public Calendar(Storage storage)
        {
            this.storage = storage;
        }

        public Event AddEvent (Event eve) 
        {
            //storage.SaveEvent(@eve);
            return storage.SaveEvent(@eve);
        }
    }
}
