using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using MyApp.Model;
using MyApp.Service;
using Newtonsoft.Json;
using MyApp.Util;

namespace MyApp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
		private string _username;
		private string _password;

		public string Username {
			get {
					return _username;
				}
			set {
					_username = value;
					OnPropertyChanged("Username");
				}
		}

		public string Password {
			get {
					return _password;
				}
			set {
					_password = value;
					OnPropertyChanged("Password");
				}
		}

		public Command EntrarCommand { get; set; }

		public LoginViewModel()
		{
			EntrarCommand = new Command(Entrar);
		}

		private void Entrar()
		{
			var user = new User();
			user.Username = Username;
			user.Password = Password;
			
			var loggeduser = ServiceWS.GetUser(user);

			if (loggeduser == null)
			{
				//(Page)
				((Page)App.Current.MainPage).DisplayAlert("Erro", "Acesso negado.", "OK");
			}
			else 
			{
				//((Page)App.Current.MainPage).DisplayAlert("Aceito", loggeduser.Login, "OK");
				UserUtil.SetUserLogged(loggeduser);
				App.Current.MainPage = new NavigationPage(new View.PrincipalPage()) { BarBackgroundColor = Color.FromHex("#C032") };
			}
			/*if(loggeduser == "")
			{
				//UserUtil.SetUserLogged(loggeduser);

				((Page)App.Current.MainPage).DisplayAlert("Erro", "Failed", "OK");
			}*/


		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string PropertyName)
		{
			if (PropertyName != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
			}
		}
	}
}
