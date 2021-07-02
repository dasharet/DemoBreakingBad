using DemoBreakingBad.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace DemoBreakingBad
{
	public partial class App : Application
	{
		static SQLiteHelper db;
		public App()
		{
			InitializeComponent();
			//Starting app with List view
			MainPage = new NavigationPage(new Views.ListCharacterView(false));
		}

		//Create mobile local db with sqlite 
		public static SQLiteHelper SQLiteDB
		{
			get
			{
				if (db == null)
				{
					db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Demo.db3"));
				}
				return db;
			}
		}

		protected override void OnStart()
		{
			
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
