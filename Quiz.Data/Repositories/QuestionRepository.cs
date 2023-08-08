using Quiz.Data.Contexts;
using Quiz.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Data.Repositories
{
    public class QuestionRepository
    {
        private readonly AppDbContext _dbContext;

        public QuestionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Question> GetAllQuestions()
        {
            return _dbContext.Questions.ToList();
        }

        public Question GetQuestionById(int questionId)
        {
            return _dbContext.Questions.FirstOrDefault(u => u.QuestionId == questionId);
        }

        public Question AddQuestion(Question question)
        {
            _dbContext.Questions.Add(question);
            _dbContext.SaveChanges();

            return question;
        }

        public void UpdateQuestion(Question question)
        {
            _dbContext.Update(question);
            _dbContext.SaveChanges();
        }

        public void DeleteQuestion(Question question)
        {
            _dbContext.Questions.Remove(question);
            _dbContext.SaveChanges();
        }
    }
}
