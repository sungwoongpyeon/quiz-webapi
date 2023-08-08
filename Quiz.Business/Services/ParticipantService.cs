using Quiz.Business.Interfaces;
using Quiz.Data.Models;
using Quiz.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Business.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly ParticipantRepository _participantRepository;

        public ParticipantService(ParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public List<Participant> GetAllParticipants()
        {
            return _participantRepository.GetAllParticipants();
        }

        public Participant GetParticipantById(int participantId)
        {
            return _participantRepository.GetParticipantById(participantId);
        }

        public Participant GetParticipantByNameAndEmail(string name, string email)
        {
            return _participantRepository.GetParticipantByNameAndEmail(name, email);
        }

        public Participant AddParticipant(Participant participant)
        {
            return _participantRepository.AddParticipant(participant);
        }

        public void UpdateParticipant(Participant participant)
        {
            _participantRepository.UpdateParticipant(participant);
        }

        public void DeleteParticipant(Participant participant)
        {
            _participantRepository.DeleteParticipant(participant);
        }
    }
}
