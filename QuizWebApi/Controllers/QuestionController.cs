using Microsoft.AspNetCore.Mvc;
using Quiz.Business.Interfaces;
using Quiz.Data.Models;

namespace QuizWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        // GET: api/Question
        [HttpGet]
        public IActionResult GetQuestions()
        {
            var questions = _questionService.GetQuestions();

            return Ok(questions);
        }

        // GET: api/Question/5
        [HttpGet("{id}")]
        public IActionResult GetQuestion(int id)
        {
            var question = _questionService.GetQuestionById(id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // POST: api/Question
        [HttpPost]
        public IActionResult AddQuestion([FromBody] Question question)
        {
            _questionService.AddQuestion(question);

            return Ok(question);
        }

        // PUT: api/Question/5
        [HttpPut("{id}")]
        public IActionResult PutQuestion(int id, [FromBody]Question question)
        {
            if (id != question.QuestionId)
            {
                return BadRequest();
            }

            _questionService.UpdateQuestion(question);

            return Ok(question);
        }

       // POST: api/Question/GetAnswers
       [HttpPost]
       [Route("GetAnswers")]
        public IActionResult RetrieveAnswers(int[] questionIds)
        {
            List<QuestionAnswers> answers = _questionService.RetrieveAnswers(questionIds);
            return Ok(answers);
        }

        // DELETE: api/Question/5
        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            var question = _questionService.GetQuestionById(id);

            if (question == null)
                return NotFound();

            _questionService.DeleteQuestion(question);

            return Ok(question);
        }
    }
}
