using System.Collections.Generic;
using Chelsea.Model.Service;
using Microsoft.AspNetCore.Mvc;

namespace Chelsea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly TicketService _service;
        
        public TicketsController(TicketService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public ActionResult GetAllTickets()
        {
            var list = _service.GetAllTickets();
            return Ok(list);
        }
    }
}