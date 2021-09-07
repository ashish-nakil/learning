using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    //Implementation
    public interface IATCMediator
    {
        void RegisterRunway(Runway runway);
        void RegisterFlight(Flight Flight);
        bool IsLandingSafe();
        void SetLandingStatus(bool landStatus);
    }

    interface Command
    {
        void Land();
    }

    public class ATCMediator : IATCMediator
    {
        private Runway _runway;
        private Flight _flight;
        private bool _landStatus = false;
        public void RegisterRunway(Runway runway)
        {
            _runway = runway;
        }
        public void RegisterFlight(Flight flight)
        {
            _flight = flight;
        }

        public bool IsLandingSafe()
        {
            return _landStatus;
        }
        public void SetLandingStatus(bool landStatus)
        {
            _landStatus = landStatus;
        }
    }

    public class Runway : Command
    {
        private IATCMediator _iATCMediator;
        public Runway(IATCMediator iATCMediator)
        {
            _iATCMediator = iATCMediator;
        }

        public void Land()
        {
            _iATCMediator.SetLandingStatus(true);
            Console.WriteLine("Permission grantted");
        }
    }

    public class Flight : Command
    {
        private IATCMediator _iATCMediator;
        public Flight(IATCMediator iATCMediator)
        {
            _iATCMediator = iATCMediator;
        }
        public void Land()
        {
            if (_iATCMediator.IsLandingSafe())
            {
                _iATCMediator.SetLandingStatus(true);
                Console.WriteLine("Successfully Landed.");
            }
            else
            {
                Console.WriteLine("Waiting for landing.");
            }
        }
    }

    //Caller
    public class Mediator
    {
        public static void Call()
        {
            IATCMediator _mediator = new ATCMediator();
            Flight airIndia7707 = new Flight(_mediator);
            Runway centralwest = new Runway(_mediator);
            _mediator.RegisterRunway(centralwest);
            _mediator.RegisterFlight(airIndia7707);
            centralwest.Land();
            airIndia7707.Land();
            Console.ReadKey();
        }
    }
}
