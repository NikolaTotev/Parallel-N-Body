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

namespace Parallel_N_Body
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string SimImage { get; set; }
        private string defaultSimImage = "Grouping.png";
        public MainWindow()
        {
            InitializeComponent();

            I_SimWindow.Source = new BitmapImage(new Uri(defaultSimImage, UriKind.RelativeOrAbsolute));
        }

        private void Tb_ParticleCount_OnTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Tb_ParticleCount_OnGotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_ParticleCount_OnLostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_Theta_OnLostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_Theta_OnGotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Tb_Theta_OnTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Btn_Generate_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Btn_Partition_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Btn_Reset_Click(object sender, RoutedEventArgs e)
        {
        }
        
        private void Rb_PairwiseSelector_OnChecked(object sender, RoutedEventArgs e)
        {
        }

        private void Rb_BHSelector_OnChecked(object sender, RoutedEventArgs e)
        {
        }

        private void Cb_ParallelSelector_OnChecked(object sender, RoutedEventArgs e)
        {
        }
    }
}
