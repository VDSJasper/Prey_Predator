using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prey_Predator.Contracts;

namespace Prey_Predator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAnimalWorld _insectWorld;
        private const int StartAmountLice = 100;
        private const int StartAmountLadies = 10;
        public MainWindow()
        {
            InitializeComponent();
            _insectWorld = new AnimalWorld(bugWorld);
            for (int i = 0; i < StartAmountLice; i++)
            {
                Louse louse = new Louse();
                _insectWorld.AddAnimal(louse);
                if (i < StartAmountLadies)
                { 
                    LadyBug lady = new LadyBug();
                    _insectWorld.AddAnimal(lady);
                }
            }
            DisplayStatistics();
        }

        private void roundButton_Click(object sender, RoutedEventArgs e)
        {
            _insectWorld.ProcessRound();
            DisplayStatistics();
        }

        private void DisplayStatistics()
        {
            roundLabel.Content = _insectWorld.CurrentRoundNumber.ToString();

            int louceCount = 0;
            int ladyCount = 0;

            foreach (Animal bug in _insectWorld.AllAnimals)
            {
                if (bug is Louse)
                { 
                    louceCount++;
                }
                if (bug is LadyBug)
                {
                    ladyCount++;
                }
            }
            louseLabel.Content = louceCount.ToString();
            ladybugLabel.Content = ladyCount.ToString();
        }
    }
}