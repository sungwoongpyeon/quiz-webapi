using Quiz.Business.Interfaces;
using Quiz.Data.Models;
using Quiz.Data.Repositories;

namespace Quiz.Business.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly QuestionRepository _questionRepository;

        public QuestionService(QuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public List<QuestionAnswers> GetQuestions()
        {
            List<Question> questions = _questionRepository.GetAllQuestions();

            List<QuestionAnswers> questionAnswersList = questions
                .Select(x => new QuestionAnswers
                {
                    QuestionId = x.QuestionId,
                    QuestionInWord = x.QuestionInWords,
                    ImageName = x.ImageName,
                    Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 }
                })
                .OrderBy(y => Guid.NewGuid())
                .Take(5)
                .ToList();

            return questionAnswersList;
        }

        public Question GetQuestionById(int questionId)
        {
            return _questionRepository.GetQuestionById(questionId);
        }

        public Question AddQuestion(Question question)
        {
            return _questionRepository.AddQuestion(question);
        }

        public void UpdateQuestion(Question question)
        {
            _questionRepository.UpdateQuestion(question);
        }

        public void DeleteQuestion(Question question)
        {
            _questionRepository.DeleteQuestion(question);
        }

        public List<QuestionAnswers> RetrieveAnswers(int[] qnIds)
        {
            List<Question> questions = _questionRepository.GetAllQuestions();

            List<QuestionAnswers> questionAnswersList = (from q in questions
                                                        where qnIds.Contains(q.QuestionId)
                                                        select new QuestionAnswers
                                                        {
                                                            QuestionId = q.QuestionId,
                                                            QuestionInWord = q.QuestionInWords,
                                                            ImageName = q.ImageName,
                                                            Options = new string[] { q.Option1, q.Option2, q.Option3, q.Option4 },
                                                            Answer = q.Answer
                                                        }).ToList();
            return questionAnswersList;
        }
    }
}
