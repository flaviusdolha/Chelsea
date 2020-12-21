using System.Collections.Generic;
using Chelsea.Model.Domain.Ticket;
using Chelsea.Model.Service;
using Microsoft.AspNetCore.Mvc;

namespace Chelsea.Controllers
{
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly TicketService _service;
        
        public TicketsController(TicketService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult GetAllTickets(int cardId)
        {
            List<Ticket> list;
            if (cardId != 0) list = _service.GetAllTickets(cardId); 
            else list = _service.GetAllTickets();
            return Ok(list);
        }
        
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult GetOneTicket(int id)
        {
            var ticket = _service.GetTicketWithId(id);
            return Ok(ticket);
        }
    }
}