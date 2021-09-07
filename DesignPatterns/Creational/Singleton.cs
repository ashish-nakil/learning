using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{

	public class SingletonClass
	{
		//private SingletonClass() { }

		private static SingletonClass instance { get; set; } = null;

		//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors#:~:text=A%20static%20constructor%20is%20used,any%20static%20members%20are%20referenced.
		
		//Access specifiers are not allowed for static constructor
		static SingletonClass()
		{
			instance = new SingletonClass();
		}

		public static SingletonClass getInstance()
		{
			return instance;
		}

	}

	// You cant inherit class having private constructor ie it becomes the sealed 
	public class InheritanceClassFromSingleton: SingletonClass
	{
	
	}

	public  class Singleton
    {
		public static void Call()
		{
            var x = SingletonClass.getInstance();
            var y = SingletonClass.getInstance();

			if (x.Equals(y))
				Console.Write("Both are equals");
        }
	}
}
