using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoBreakingBad.Models;
using DemoBreakingBad.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoBreakingBad.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListCharacterView : ContentPage
	{
		public ListCharacterView(bool update)
		{
			InitializeComponent();

			BindingContext = new ViewModels.ListCharacterViewModel(Navigation, update);
		}

		//Method when the user tap over one of the characters.
		private async void ListView_ItemTapped(Object sender, ItemTappedEventArgs e)
		{
			var Character = e.Item as Character;
			
			await Navigation.PushAsync(
				new CharacterView(
				Character.Isfavorite,
				Character.Name,
				Character.Nickname,
				Character.Occupations,
				Character.Status,
				Character.Portrayed,
				Character.Img));

		}

		//Method for tap unlove
		private async void LoveTapped(Object sender, EventArgs args)
		{
			var te = (TappedEventArgs)args;
			int parameter = (int)te.Parameter;

			var existC = await App.SQLiteDB.GetCharacterByIdAsync(parameter);
			if (existC != null)
			{
				Character chart = new Character()
				{
					Id = existC.Id,
					Char_id = existC.Char_id,
					Name = existC.Name,
					Nickname = existC.Nickname,
					Img = existC.Img,
					Status = existC.Status,
					Occupations = existC.Occupations,
					Portrayed = existC.Portrayed,
					Isfavorite = !existC.Isfavorite,
					Unlove = "",
					Love = ""

				};

				await App.SQLiteDB.SaveCharacterAsync(chart);

				await Navigation.PushAsync(new ListCharacterView(true));

			}

		}

		//Method for tap love/favorite
		private async void UnLoveTapped(Object sender, EventArgs args)
		{
			var te = (TappedEventArgs)args;
			int parameter = (int)te.Parameter;

			var existC = await App.SQLiteDB.GetCharacterByIdAsync(parameter);
			if (existC != null)
			{				
				Character chart = new Character()
				{
					Id = existC.Id,
					Char_id = existC.Char_id,
					Name = existC.Name,
					Nickname = existC.Nickname,
					Img = existC.Img,
					Status = existC.Status,
					Occupations = existC.Occupations,
					Portrayed = existC.Portrayed,
					Isfavorite = !existC.Isfavorite,
					Unlove = "",
					Love = ""

				};

				await App.SQLiteDB.SaveCharacterAsync(chart);

				await Navigation.PushAsync(new ListCharacterView(true));

			}
		}
	}
}