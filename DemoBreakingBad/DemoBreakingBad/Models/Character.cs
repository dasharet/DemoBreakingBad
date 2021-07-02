using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DemoBreakingBad.Models
{
    //Base model of the character object.
	public class Character
	{
        [PrimaryKey,AutoIncrement]
		public int Id { get; set; }
        public int Char_id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Birthday { get; set; }
        [Ignore]
        public List<string> Occupation { get; set; }
        public string Occupations { get; set; }
        public string Img { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        [MaxLength(50)]
        public string Nickname { get; set; }
        [MaxLength(50)]
        public string Portrayed { get; set; }
		public bool Isfavorite { get; set; }
        public string Love { get; set; }
        public string Unlove { get; set; }

    }
}
