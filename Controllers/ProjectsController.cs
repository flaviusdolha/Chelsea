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
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _projectService;
        private readonly CardService _cardService;
        private readonly TicketService _ticketService;
        
        public ProjectsController(ProjectService projectService, CardService cardService, TicketService ticketService)
        {
            _projectService = projectService;
            _cardService = cardService;
            _ticketService = ticketService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult GetAllProjects(int ownerId)
        {
            List<Project> list;
            if (ownerId != 0) list = _projectService.GetAllProjects(ownerId);
            else list = _projectService.GetAllProjects();
            if (list.Count == 0) return NotFound();
            return Ok(list);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult GetOneProject(int id)
        {
            var project = _projectService.GetProjectWithId(id);
            if (project is null) return NotFound();
            return Ok(project);
        }

        [HttpGet]
        [Route("api/dashboard/project/{id}")]
        public ActionResult GetOneProjectFull(int id)
        {
            var project = _projectService.GetProjectWithId(id);
            if (project is null) return NotFound();
            var cards = _cardService.GetAllCards(project.Id);
            var cardsOnProject = new List<object>();
            foreach (var card in cards)
            {
                var tickets = _ticketService.GetAllTickets(card.Id);
                var obj = new { card, tickets };
                cardsOnProject.Add(obj);
            }
            var fullProject = new { project, cards = cardsOnProject };
            return Ok(fullProject);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult> AddProject()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var json = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(body);
                try
                {
                    _projectService.AddProject(json);
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
        public async Task<ActionResult> UpdateProject(int id)
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var json = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(body);
                var project = _projectService.GetProjectWithId(id);
                if (project is null) return NotFound();
                try
                {
                    project.Name = json["name"].ToString();
                    _projectService.ModifyProject(project);
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
        public ActionResult RemoveProject(int id)
        {
            var project = _projectService.GetProjectWithId(id);
            if (project is null) return NotFound();
            _projectService.RemoveProject(id);
            return Ok();
        }
    }
}