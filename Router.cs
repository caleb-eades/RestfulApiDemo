using Nancy;
using System;

namespace Example
{
	public class Program:Nancy.NancyModule
	{
		static void Main(string[] args) {
			Console.Write("Starting server...");
			var server = new Nancy.Hosting.Self.NancyHost(new System.Uri("http://localhost:8282"));
			server.Start();
			Console.WriteLine("started!");
			Console.WriteLine("press any key to exit");
			Console.Read();
		}

		public Program()
		{
			Get["/"] = _ => { return "Nancy says hello!"; };
		}
	}
}