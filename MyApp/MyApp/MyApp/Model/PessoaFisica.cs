using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace MyApp.Model
{
    public class PessoaFisica
    {
		[JsonProperty("nome")]
		public string Nome { get; set; }
		//public string ShortName { get; set; }
		//public string Neighborhood { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("dt_nasc")]
		public string Dt_nasc { get; set; }
		//public string Cellphone { get; set; }
	}
}
