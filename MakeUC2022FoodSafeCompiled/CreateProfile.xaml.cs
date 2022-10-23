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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HackathonXAMLApp
{
    /// <summary>
    /// Interaction logic for CreateProfile.xaml
    /// </summary>
    public partial class CreateProfile : Window
    {
        public CreateProfile()
        {
            InitializeComponent();
            User user = new User();
        }


        private void VegetarianCB(object sender, RoutedEventArgs e)
        {

        }

        private void VeganCB(object sender, RoutedEventArgs e)
        {

        }
        private void DairyFreeCB(object sender, RoutedEventArgs e)
        {

        }
        private void GlutenFreeCB(object sender, RoutedEventArgs e)
        {

        }
        private void KetoCB(object sender, RoutedEventArgs e)
        {

        }
        private void CrohnsCB(object sender, RoutedEventArgs e)
        {

        }
    }
}
