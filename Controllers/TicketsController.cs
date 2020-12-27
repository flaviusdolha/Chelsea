using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
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
            if (list is null) return BadRequest();
            return Ok(list);
        }
        
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult GetOneTicket(int id)
        {
            var ticket = _service.GetTicketWithId(id);
            if (ticket is null) return BadRequest();
            return Ok(ticket);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult> AddTicket()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var json = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(body);
                try
                {
                    _service.AddTicket(json);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        [HttpPut]
        [Route("api/[controller]")]
        public async Task<ActionResult> UpdateTicket()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var json = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(body);
                if (json.ContainsKey("id"))
                {
                    _service.ModifyTicket(json);
                    return Ok();
                }
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public ActionResult RemoveTicket(int id)
        {
            var ticket = _service.GetTicketWithId(id);
            if (ticket is null) return BadRequest();
            _service.RemoveTicket(id);
            return Ok();
        }
    }
}