using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using MyApp.Model;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MyApp.Service
{
    public class ServiceWS
    {
		private static string EnderecoBase = "http://10.72.42.38/restapp/public";

		public static User GetUser(User user)
		{
			try
			{
				var URL = EnderecoBase + "/v1/login";

				FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
				{
					new KeyValuePair<string,string>("username", user.Username),
					new KeyValuePair<string,string>("password", user.Password)
				});
				//StringContent param = new StringContent(string.Format("?username={0}&password={1}",user.Username,user.Password));

				HttpClient cliente = new HttpClient();
				HttpResponseMessage resposta = cliente.PostAsync(URL, param).GetAwaiter().GetResult();

				//Debug.WriteLine("Erro: "+resposta);
				if (resposta.StatusCode == HttpStatusCode.OK)
				{
					
					var conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
					
					var util = JsonConvert.DeserializeObject<User>(conteudo);
					Debug.WriteLine("Resposta: " + util.Username);
					return util;
 
				}

				return null;
			}
			catch (Exception ex)
			{
				//(App.Current.MainPage).DisplayAlert("Erro", ex.Message, "OK");
				throw ex;
			}		
		}

		public static PessoaFisica GetPerson(User user)
		{
			try
			{
				var URL = EnderecoBase + "/v1/getPersonByUserName/" + user.Username;

				HttpClient cliente = new HttpClient();
				HttpResponseMessage resposta = cliente.GetAsync(URL).GetAwaiter().GetResult();

				if (resposta.StatusCode == HttpStatusCode.OK)
				{
					string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
					var pessoa = JsonConvert.DeserializeObject<PessoaFisica>(conteudo);
					Debug.WriteLine("Resp: " + pessoa);
					return pessoa;
				}

				return null;
			}
			catch(Exception ex)
			{
				//(App.Current.MainPage).DisplayAlert("Erro", ex.Message, "OK");
				throw ex;
			}

		}

	}
}
