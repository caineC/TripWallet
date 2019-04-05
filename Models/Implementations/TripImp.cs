using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripWallet.Models;
using TripWallet.Models.Implementations;
using TripWallet.Models.Intefaces;

namespace TripWallet
{
    public class TripImp : Trip
    {
        private readonly List<Participant> _participants = new List<Participant>();

        public Location[] Locations { get; private set; }
        public Location Destination { get; private set; }
        public Wallet Wallet { get; private set; }
        public bool isActive { get; private set; }
        public Participant[] Participants
        {
            get { return _participants.ToArray(); }
        }

        public TripImp(Location destination)
        {
            Wallet = new WalletImp(this);
            Destination = destination;
        }

        public void ShowParticipants()
        {
            foreach (Participant p in Participants)
                Console.WriteLine(p.Name);
        }


        public bool Register(Participant participant)
        {
            try
            {
                _participants.Add(participant);
                participant.ParticipantPaid += participant_ParticipantPaid;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        void participant_ParticipantPaid(object sender, Models.EventArgs.ParticipantPaidEventInfo e)
        {
            Wallet.Register(new MoneyTransactionImp()
            {
                Location = e.CurrentLocation,
                Payer = sender as Participant,
                Value = e.Value

            });
        }

        public bool Register(Location location)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Participant participant)
        {
            try
            {
                _participants.Remove(participant);
                participant.ParticipantPaid -= participant_ParticipantPaid;
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Remove(Id id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Location location)
        {
            throw new NotImplementedException();
        }

        public bool Change(Destination destination)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDestination()
        {
            throw new NotImplementedException();
        }
    }
}
