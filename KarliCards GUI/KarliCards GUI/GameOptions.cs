using System;
using System.ComponentModel;

namespace KarliCards_GUI
{
    [Serializable]

    
    public class GameOptions : INotifyPropertyChanged
    {
        private ObservableCollection<string> _playerNames =
            new ObservableCollection<string>();
        public List<string> SelectedPlayers { get; set; }

        private bool _playerAgainstComputer = true;
        private int _numberOfPlayers = 2;
        private int _minutedBeforeLoss = 10;
        private ComputerSkillLevel _computerSkill = ComputerSkillLevel.Dumb;

            public int NumberOfplayers
        {
            get { return _numberOfPlayers; }
            set
            {
                _numberOfPlayers = value;
                OnPropertyChanged("NumberOfPlayers");
            }
        }

        public bool PlayAgainstComputer
        {
            get { return _playerAgainstComputer;  }
            set
            {
                _playerAgainstComputer = value;
                OnPropertyChanged("PlayAgainstComputer");
            }
        }

        public int MinutesBeforeLoss
        {
            get { return _minutedBeforeLoss; }
            set
            {
                _minutedBeforeLoss = value;
                OnPropertyChanged("MinutesBeforeLoss");
            }
        }

        public ComputerSkillLevel ComputerSkill
        {
            get { return _computerSkill; }
            set
            {
                _computerSkill = value;
                OnPropertyChanged("ComputerSkill");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    [Serializable]
    public enum ComputerSkillLevel
    {
        Dumb,
        Good,
        Cheats
    }
    
        
}
