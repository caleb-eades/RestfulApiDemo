using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace PulseAPI
{
	public class ExampleController
	{
		public ExampleController ()
		{
		}

		public static string List() {
			List<Example> examples = new List<Example>();
			for (int i = 0; i < 3; i++) {
				Example example = new Example ();
				example.ExampleID = i;
				example.ExampleText = "Example #" + (i + 1);
				examples.Add (example);
			}
			try {
				string result = JsonConvert.SerializeObject (examples);
				return result;
			} catch (FileNotFoundException e) {
				Console.Out.WriteLine (e.Message);
				string error = "{\"error\" : \"" + e.Message + "\"}";
				return error;
			}
			//return examples;
		}
	}
}

