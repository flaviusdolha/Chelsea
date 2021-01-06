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
        private readonly TicketService _ticketService;
        
        public TicketsController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }
        
        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult GetAllTickets(int cardId)
        {
            List<Ticket> list;
            if (cardId != 0) list = _ticketService.GetAllTickets(cardId); 
            else list = _ticketService.GetAllTickets();
            if (list.Count == 0) return NotFound();
            return Ok(list);
        }
        
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult GetOneTicket(int id)
        {
            var ticket = _ticketService.GetTicketWithId(id);
            if (ticket is null) return NotFound();
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
                    _ticketService.AddTicket(json);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult> UpdateTicket(int id)
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var json = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(body);
                var ticket = _ticketService.GetTicketWithId(id);
                if (ticket is null) return NotFound();
                try
                {
                    _ticketService.ModifyTicket(json, ticket);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public ActionResult RemoveTicket(int id)
        {
            var ticket = _ticketService.GetTicketWithId(id);
            if (ticket is null) return NotFound();
            _ticketService.RemoveTicket(id);
            return Ok();
        }
    }
}