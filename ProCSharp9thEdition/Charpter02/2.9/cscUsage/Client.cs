using System;

namespace Wrox
{
	class Client
	{
		public static void Main()
		{
			MathLib mathobj = new MathLib();
			Console.WriteLine(mathobj.Add(3,5));
			Console.ReadLine();
		}
	}
}