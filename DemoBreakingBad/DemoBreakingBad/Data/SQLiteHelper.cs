using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using DemoBreakingBad.Models;
using System.Threading.Tasks;

namespace DemoBreakingBad.Data
{
	public class SQLiteHelper
	{
		SQLiteAsyncConnection db;
		
		//Tool sqlite for the storage
		public SQLiteHelper(string dbPath)
		{
			db = new SQLiteAsyncConnection(dbPath);
			db.CreateTableAsync<Character>().Wait();
		}

		//Save a character, validation if already exist. 
		//Update a character, if already exist.
		public Task<int> SaveCharacterAsync(Character character)
		{		
			if (character.Id != 0 )
			{
				return db.UpdateAsync(character);
			}
			else
			{
				return db.InsertAsync(character);
			}
		}

		//Return all characters.
		public Task<List<Character>> GetCharactersAsync()
		{
			return db.Table<Character>().ToListAsync();
		}

		//Return one character if exist.
		public Task<Character> GetCharacterByIdAsync(int idCharacter)
		{
			return db.Table<Character>().Where(x => x.Char_id == idCharacter).FirstOrDefaultAsync();
		}
	}
}
