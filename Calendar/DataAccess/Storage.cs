using CalendarApi.Domain;

namespace CalendarApi.DataAccess
{
    public class Storage
    {
        public Event SaveEvent(Event @event) 
        {
            var id = 1;
            @event.Id = id;
            return @event;
        }

    }
}
