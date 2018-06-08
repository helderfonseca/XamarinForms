using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyApp.Model
{
    public class User
    {

		[JsonProperty("username")]
		public string Username { get; set; }

		[JsonProperty("password")]
		public string Password { get; set; }

	}
}
