using Quiz.Data.Models;

namespace Quiz.Business.Interfaces
{
    public interface IQuestionService
    {
        List<QuestionAnswers> GetQuestions();

        Question GetQuestionById(int questionId);

        Question AddQuestion(Question question);

        void UpdateQuestion(Question question);

        void DeleteQuestion(Question question);

        List<QuestionAnswers> RetrieveAnswers(int[] qnIds);
    }
}
