using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using MyApp.Service;
using MyApp.Util;
using MyApp.Model;
using System.Diagnostics;

namespace MyApp.ViewModel
{
    public class PrincipalViewModel : INotifyPropertyChanged
    {
		private string _nome;
		private string _email;
		private string _dt_nasc;

		public string Nome
		{
			get
			{
				return _nome;
			}
			set
			{
				_nome = value;
				OnPropertyChanged("Nome");
			}
		}

		public string Email
		{
			get
			{
				return _email;
			}
			set
			{
				_email = value;
				OnPropertyChanged("Email");
			}
		}

		public string Dt_nasc
		{
			get
			{
				return _dt_nasc;
			}
			set
			{
				_dt_nasc = value;
				OnPropertyChanged("Dt_Nasc");
			}
		}

		public PrincipalViewModel()
		{
			var userlogged = UserUtil.GetUserLogged();
			var pessoa = ServiceWS.GetPerson(userlogged);
			Debug.WriteLine("Pessoa: " + pessoa.Nome);
			pessoa.Nome = Nome;
			pessoa.Email = Email;
			pessoa.Dt_nasc = Dt_nasc;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string PropertyName)
		{
			if(PropertyName != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
			}
		}
	}
}
