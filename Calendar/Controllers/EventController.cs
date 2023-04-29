using CalendarApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly Calendar calendar;

        public EventController(Calendar calendar)
        {
            this.calendar = calendar;
        }

        [HttpPost(Name = "PostEvent")]
        public Event Post(Event eve)
        {
            return calendar.AddEvent(eve);
        }
    }
}