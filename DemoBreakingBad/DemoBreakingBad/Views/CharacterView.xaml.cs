using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoBreakingBad.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterView : ContentPage
	{		
		//Asing parameters
		public CharacterView(bool Isfavorite,string Name, string Nickname, string Occupations, string Status,  string Portrayed, string Img )
		{			
			InitializeComponent();
			CharacterTitleName.Text = Name;
			CharacterNickname.Text = Nickname;
			CharacterPortrayed.Text = Portrayed;
			CharacterOccupations.Text = Occupations;
			CharacterStatus.Text = Status;
			FavoriteCall.Source = Isfavorite ? "love.png" : "unlove.png";
			MyImageCall.Source = new UriImageSource() { 
			Uri = new Uri(Img)
			};
		}
	}
}