using RegistroOrden.BLL;
using RegistroOrden.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroOrden.UI.Registros
{
    /// <summary>
    /// Interaction logic for RegistrarCliente.xaml
    /// </summary>
    public partial class RegistrarCliente : Window
    {
        Clientes clientes = new Clientes();
        public RegistrarCliente()
        {
            InitializeComponent();
            this.DataContext = clientes;
            ClienteIdTex.Text = "0";
        }
        private void Limpiar()
        {
            ClienteIdTex.Text = "0";
            NombreTex.Text = string.Empty;
            DireccionTex.Text = string.Empty;
            CedulaTex.Text = string.Empty;
         
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(NombreTex.Text))
            {
                MessageBox.Show("El Campo Nombre no puede estar vacio");
                NombreTex.Focus();
                paso = false;
            }
            else
            {
                foreach (var caracter in NombreTex.Text)
                {

                    if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
                    {
                        paso = false;
                        MessageBox.Show("El Campo nombre solo recibe TEXTO...");
                    }
                    else
                    if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))

                        paso = true;
                }
            }

            if (string.IsNullOrWhiteSpace(DireccionTex.Text))
            {
                MessageBox.Show("El Campo Direccion Debe LLenarse..");
                DireccionTex.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulaTex.Text))
            {
                MessageBox.Show("El Campo Cadula no puede estar vacio");
                CedulaTex.Focus();
                paso = false;
            }
            else
            {
                foreach (var caracter in CedulaTex.Text)
                {
                    if (!char.IsDigit(caracter))
                    {
                        paso = false;
                        MessageBox.Show("Escriba solo numeros en el campo CEDULA..");
                    }
                    else
                    if (!char.IsDigit(caracter))
                        paso = true;
                }
            }
            return paso;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void LLenar()
        {
            this.DataContext = null;
            this.DataContext = clientes;
        }
        private bool ExisteEnLaBaseDeDatosCliente()
        {
            Clientes clientess = ClienteBLL.Buscar(clientes.ClienteId);
            return (clientess != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {          
            bool paso = false;
            if (!Validar())
                return;

            if (clientes.ClienteId == 0)
                paso = ClienteBLL.Guardar(clientes);
            else
            {
                if (!ExisteEnLaBaseDeDatosCliente())
                {
                    MessageBox.Show("No se puede Modificar una persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ClienteBLL.Modificar(clientes);
            }
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes clientesAnterior = ClienteBLL.Buscar(clientes.ClienteId);

            Limpiar();
            if (clientesAnterior != null)
            {
                clientes = clientesAnterior;
                LLenar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Cliente no Existe...");
            }
        }
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(ClienteBLL.Eliminar(clientes.ClienteId))
            {

                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            
            } else
                MessageBox.Show("Erro Al eliminar una persona");
        }
    }
}
