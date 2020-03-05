using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;

namespace KarliCards_GUI
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        private GameOptions _gameOptions;
        public Options()
        {
            if (_gameOptions == null)
            {
                if (File.Exists("GameOptions.xml"))
                {
                    using (var stream = File.OpenRead("GameOptions.xml"))
                    {
                        var serializer = new XmlSerializer(typeof(GameOptions));
                        _gameOptions = serializer.Deserialize(stream) as GameOptions;
                    }
                }
                else
                    _gameOptions = new GameOptions();
            }
            DataContext = _gameOptions;
            InitializeComponent();
        }

        private void DumbAIRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            _gameOptions.ComputerSkill = ComputerSkillLevel.Dumb;
        }

        private void GoodAIRadioButton_Checked(object sender, RoutedEventArgs e)
        {

            _gameOptions.ComputerSkill = ComputerSkillLevel.Good;
        }

        private void CheatAIRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            _gameOptions.ComputerSkill = ComputerSkillLevel.Cheats;
        }

        private void timeAllowedTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            timeAllowedTextBox.SelectAll();
        }

        private void timeAllowedTextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var control = sender as TextBox;
            if (control == null)
                return;

            Keyboard.Focus(control);
            e.Handled = true;
        }
    }
}
