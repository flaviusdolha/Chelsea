using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Chelsea.Model.Domain;
using Chelsea.Model.Service;
using Microsoft.AspNetCore.Mvc;

namespace Chelsea.Controllers
{
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly CardService _cardService;

        public CardsController(CardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult GetAllCards(int projectId)
        {
            List<Card> list;
            if (projectId != 0) list = _cardService.GetAllCards(projectId);
            else list = _cardService.GetAllCards();
            if (list.Count == 0) return NotFound();
            return Ok(list);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult GetOneCard(int id)
        {
            var card = _cardService.GetCardWithId(id);
            if (card is null) return NotFound();
            return Ok(card);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult> AddCard()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var json = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(body);
                try
                {
                    _cardService.AddCard(json);
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
        public async Task<ActionResult> UpdateCard(int id)
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var json = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(body);
                var card = _cardService.GetCardWithId(id);
                if (card is null) return NotFound();
                try
                {
                    card.Name = json["name"].ToString();
                    _cardService.ModifyCard(card);
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
        public ActionResult RemoveCard(int id)
        {
            var card = _cardService.GetCardWithId(id);
            if (card is null) return NotFound();
            _cardService.RemoveCard(id);
            return Ok();
        }
    }
}