using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Behavioral;
using DesignPatterns.Creational;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creational
               
                Singleton.Call();

            #endregion


            #region Behavioural 
                //Mediator
                //Mediator.Call();

                //Observer
                //Observer.Call();

                //Command 
                CommandPattern.Call();

            #endregion

        }
    }
}
