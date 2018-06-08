using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using MyApp.Model;

namespace MyApp.Util
{
    public class UserUtil
    {
		public static void SetUserLogged(User user)
		{
			App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(user);
		}

		public static User GetUserLogged()
		{
			if (App.Current.Properties.ContainsKey("LOGIN"))
			{
				return JsonConvert.DeserializeObject<User>((string)App.Current.Properties["LOGIN"]);
			}else
			{
				return null;
			}
		}
	}
}
