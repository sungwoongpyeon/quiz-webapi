using Quiz.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Business.Interfaces
{
    public interface IParticipantService
    {
        List<Participant> GetAllParticipants();

        Participant GetParticipantById(int participantId);

        Participant GetParticipantByNameAndEmail(string name, string email);

        Participant AddParticipant(Participant participant);

        void UpdateParticipant(Participant participant);

        void DeleteParticipant(Participant participant);
    }
}
