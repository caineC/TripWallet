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
    class Program
    {
        static void Main(string[] args)
        {
            Participant p1 = new ParticipantImp(Id.CreateId(1,1),"Jas",100,0);
            Participant p2 = new ParticipantImp(Id.CreateId(1, 2),"Zbyś", 152, 0);

            
            User Iam = new UserImp(Id.CreateId(1,1),"Jas",100,0);
            Trip trip = Iam.CreateTrip();

            trip.Register(p1);
            trip.Register(p2);

            Console.WriteLine(trip.Wallet.TripBudget + " <-- Trip Budget!");
            Console.WriteLine(trip.Wallet.TotalMoneySpent + " <-- Trip Total money spent!");
            Console.WriteLine(trip.Participants.Length + " <-- Participants count!");


            trip.ShowParticipants();

            p1.Pay(16);
            p2.Pay(55);

            foreach (var transaction in trip.Wallet.MoneyTransactions)
                Console.WriteLine(transaction.Value);


            Console.WriteLine(trip.Wallet.TripBudget + " <-- Trip Budget!");
            Console.WriteLine(trip.Wallet.TotalMoneySpent + " <-- Trip Total money spent!");


            Console.ReadKey();
        }
    }
}
