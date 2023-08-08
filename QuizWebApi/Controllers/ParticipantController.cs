using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Business.Interfaces;
using Quiz.Data.Models;

namespace QuizWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        // GET: api/Participant
        [HttpGet]
        public IActionResult GetParticipants()
        {
            var participants = _participantService.GetAllParticipants();

            return Ok(participants);
        }

        // GET: api/Participant/5
        [HttpGet("{id}")]
        public IActionResult GetParticipant(int id)
        {
            var participant = _participantService.GetParticipantById(id);

            if (participant == null)
            {
                return NotFound();
            }

            return Ok(participant);
        }

        // POST: api/Participant
        [HttpPost]
        public IActionResult AddParticipant([FromBody] Participant newParticipant)
        {
            //Check if participant with the same name and email exist 
            Participant participant = _participantService.GetParticipantByNameAndEmail(newParticipant.Name, newParticipant.Email);

            if(participant == null)
            {
                _participantService.AddParticipant(newParticipant);
            }
            else
            {
                newParticipant = participant;
            }

            return Ok(newParticipant);
        }

        // PUT: api/Participant/5
        [HttpPut("{id}")]
        public IActionResult PutParticipant(int id, [FromBody] ParticipantRestult updatedParticipant)
        {
            if (id != updatedParticipant.ParticipantId)
            {
                return BadRequest();
            }

            // get all current details of the record, then update with quiz results
            Participant participant = _participantService.GetParticipantById(id);
            participant.Score = updatedParticipant.Score;
            participant.TimeTaken = updatedParticipant.TimeTaken;

            _participantService.UpdateParticipant(participant);

            return Ok(participant);
        }

        // DELETE: api/Participant/5
        [HttpDelete("{id}")]
        public IActionResult DeleteParticipant(int id)
        {
            var participant = _participantService.GetParticipantById(id);

            if (participant == null)
                return NotFound();

            _participantService.DeleteParticipant(participant);

            return Ok(participant);
        }
    }
}
