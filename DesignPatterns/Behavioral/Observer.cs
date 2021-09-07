using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    //Implementation
    public interface Subject
    {
        void RegisterObserver(IObserver o);
        void DeRegisterObserver(IObserver o);
        void NotifyAll();
    }
    public interface IObserver
    {
        void update(int runs, int wickets,double overs);
    }
    public class ICC : Subject
    {
        public int _runs;

        public int _wickets;

        public double _overs;

        public List<IObserver> subscribers = new List<IObserver>();
        public ICC(int runs, int wickets, double overs)
        {
            _runs = runs;
            _wickets = wickets;
            _overs = overs;
        }

        public void RegisterObserver(IObserver o)
        {

            subscribers.Add(o);
        }
        public void DeRegisterObserver(IObserver o)
        {

            subscribers.Remove(o);
        }

        public void NotifyAll()
        {
            foreach (IObserver subscriber in subscribers)
            {
                subscriber.update(_runs, _wickets, _overs);
            }
        }
    }
    public class ESPN : IObserver
    {
        public void update(int runs, int wickets, double overs)
        {
            Console.WriteLine($"ESPN : {runs}/{wickets} Overs:{overs}");
        }
    }
    public class StarSports : IObserver
    {
        public void update(int runs, int wickets, double overs)
        {
            Console.WriteLine($"StarSports : {runs}/{wickets} Overs:{overs}");
        }
    }

    //Caller
    public class Observer
    {
        public static void Call()
        {
            ICC icc = new ICC(10, 2, 1.5);
            icc.RegisterObserver(new StarSports());
            icc.RegisterObserver(new ESPN());
            icc.NotifyAll();
            Console.WriteLine("new score");
            icc.DeRegisterObserver(new StarSports());
            icc.NotifyAll();
            Console.ReadKey();
        }
    }
}
