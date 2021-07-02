using System;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DemoBreakingBad.Models;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DemoBreakingBad.ViewModels
{
	public class ListCharacterViewModel : BaseViewModel, INotifyPropertyChanged
	{

		public ListCharacterViewModel(INavigation navigation, bool update)
		{
			Navigation = navigation;
			Characters = new ObservableCollection<Character>();

			if (!update)
			{
				//API CALL
				Call_api();
			}
			else
			{
				FillList();
			}

		}
		private async void Call_api()
		{
			try
			{
				//Using Api
				var request = new HttpRequestMessage();
				request.RequestUri = new Uri("https://www.breakingbadapi.com/api/characters");
				request.Method = HttpMethod.Get;
				request.Headers.Add("Accept", "application/json");
				var client = new HttpClient();
				HttpResponseMessage response = await client.SendAsync(request);
				if (response.StatusCode == HttpStatusCode.OK)
				{
					//Deserialize
					string content = await response.Content.ReadAsStringAsync();
					var resultado = JsonConvert.DeserializeObject<List<Character>>(content);

					foreach (var item in resultado)
					{
						string occ = "";
						foreach (var ocu in item.Occupation)
						{
							occ += ocu + " , ";
						}

						//Create object for the insertion db.
						Character chart = new Character()
						{
							Char_id = item.Char_id,
							Name = item.Name,
							Img = item.Img,
							Nickname = item.Nickname,
							Occupations = occ,
							Portrayed = item.Portrayed,
							Status = item.Status,
							Isfavorite = false
						};
						var existC = await App.SQLiteDB.GetCharacterByIdAsync(chart.Char_id);
						if (existC == null)
						{
							await App.SQLiteDB.SaveCharacterAsync(chart);
						}
					}

					FillList();
				}
				else
				{
					await App.Current.MainPage.DisplayAlert("Warning", " Conflicts with data ", "OK");
				}
			}
			catch
			{

				await App.Current.MainPage.DisplayAlert("Warning", " Problems with your network ", "OK");
			}
		}

		//Method Update list of the characters.
		private async void FillList()
		{
			var characterList = await App.SQLiteDB.GetCharactersAsync();
			if (characterList != null)
			{
				foreach (var item in characterList)
				{
					Characters.Add(new Character()
					{
						Id = item.Id,
						Char_id = item.Char_id,
						Name = item.Name,
						Nickname = item.Nickname,
						Occupations = item.Occupations,
						Img = item.Img,
						Portrayed = item.Portrayed,
						Status = item.Status,
						Isfavorite = item.Isfavorite,
						Love = item.Isfavorite ? "love.png" : "",
						Unlove = !item.Isfavorite ? "unlove.png" : ""
					});
				}
				//Execute order lit 
				Characters = new ObservableCollection<Character>(Characters.OrderByDescending(x => x.Isfavorite));
			}
		}

		private ObservableCollection<Character> _characters;

		public ObservableCollection<Character> Characters
		{
			get { return _characters; }
			set { _characters = value; OnPropertyChanged(); }
		}

		private Character _selectedCharacter;

		public Character SelectedCharacter
		{
			get { return _selectedCharacter; }
			set { _selectedCharacter = value; OnPropertyChanged(); }
		}

		public INavigation Navigation { get; set; }




	}
}
