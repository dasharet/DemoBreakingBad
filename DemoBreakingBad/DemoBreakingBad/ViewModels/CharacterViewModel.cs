using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DemoBreakingBad.ViewModels
{
    //Properties for the visualization of detail character selected.
    public class CharacterViewModel : BaseViewModel
	{
        public CharacterViewModel()
        {
        
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        private string _img;

        public string Img
        {
            get { return _img; }
            set { _img = value; OnPropertyChanged(); }
        }

        private string _nickname;

        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; OnPropertyChanged(); }
        }

        private string _occupations;

        public string Occupations
        {
            get { return _occupations; }
            set { _occupations = value; OnPropertyChanged(); }
        }

        private string _portrayed;

        public string Portrayed
        {
            get { return _portrayed; }
            set { _portrayed = value; OnPropertyChanged(); }
        }

        private bool _isfavorite;

        public bool Isfavorite
        {
            get { return _isfavorite; }
            set { _isfavorite = value; OnPropertyChanged(); }
        }

        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(); }
        }
    }
}
