using Quiz.Data.Contexts;
using Quiz.Data.Models;

namespace Quiz.Data.Repositories
{
    public class ParticipantRepository
    {
        private readonly AppDbContext _dbContext;

        public ParticipantRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Participant> GetAllParticipants()
        {
            return _dbContext.Participants.ToList();
        }

        public Participant GetParticipantById(int participantId)
        {
            return _dbContext.Participants.FirstOrDefault(u => u.ParticipantId == participantId);
        }

        public Participant AddParticipant(Participant participant)
        {
            _dbContext.Participants.Add(participant);
            _dbContext.SaveChanges();

            return participant;
        }

        public void UpdateParticipant(Participant participant)
        {
            _dbContext.Update(participant);
            _dbContext.SaveChanges();
        }

        public Participant GetParticipantByNameAndEmail(string name, string email)
        {
            return _dbContext.Participants.FirstOrDefault(x => x.Name.ToLower() == name.ToLower()
            && x.Email.ToLower() == email.ToLower());
        }

        public void DeleteParticipant(Participant participant)
        {
            _dbContext.Participants.Remove(participant);
            _dbContext.SaveChanges();
        }
    }
}
