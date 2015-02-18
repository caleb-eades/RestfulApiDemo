using Nancy;
using System;
using Nancy.IO;
using System.IO;
using PulseAPI;

namespace Example
{
	public class Program:Nancy.NancyModule
	{
		private static string protocol = "http://";
		private static string host = "localhost";
		private static int port = 8282;
		static void Main(string[] args) {
			Console.WriteLine("Starting server...");
			var server = new Nancy.Hosting.Self.NancyHost(new System.Uri(protocol + host + ":" + port));
			server.Start();
			Console.WriteLine("Nancy server started on " + protocol + host + ":" + port);
			Console.WriteLine("press any key to exit");
			Console.Read();
		}

		public Program()
		{
			Get [""] = _ => {
				return CreateJsonResponse("{\"hello\":\"World!!!\"}");
			};

			Get["/API/Example/List"] = _ => {
				string jsonResponse = ExampleController.List();
				return jsonResponse;//CreateJsonResponse(jsonResponse); 
			};
		}

		private string GetJsonFromRequest(RequestStream stream) {
			StreamReader sr = new StreamReader(stream);
			string jsonRequest = sr.ReadToEnd();
			sr.Close();
			return jsonRequest;
		}

		private Response CreateJsonResponse(string json) {
			Response response = (Response)json;
			response.ContentType = "application/json";
			return response;
		}
	}
}