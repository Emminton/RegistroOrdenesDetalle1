using RegistroOrden.UI.Registros;
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

namespace RegistroOrden
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistarButton_Click(object sender, RoutedEventArgs e)
        {
            RegistroOrdenes orde = new RegistroOrdenes();
            orde.Show();
        }

        private void RegistrarProductoButton_Click(object sender, RoutedEventArgs e)
        {
            RegistroProductos produ = new RegistroProductos();
            produ.Show();
        }

        private void RegistrarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrarCliente Clien = new RegistrarCliente();
            Clien.Show();
        }
    }
}
