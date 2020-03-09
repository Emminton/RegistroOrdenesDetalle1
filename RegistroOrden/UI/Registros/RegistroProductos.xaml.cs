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
    /// Interaction logic for RegistroProductos.xaml
    /// </summary>
    public partial class RegistroProductos : Window
    {
        Productos productos = new Productos();
        public RegistroProductos()
        {
            InitializeComponent();
            this.DataContext = productos;
            ProductoIdTex.Text = "0";
        }
        private void Limpiar()
        {
            ProductoIdTex.Text = "0";
            NombreProductoTex.Text = string.Empty;
            PrecioProductoTex.Text = string.Empty;
           
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(NombreProductoTex.Text))
            {
                MessageBox.Show("El Campo NombreProducto no puede estar vacio");
                NombreProductoTex.Focus();
                paso = false;
            }
            else
            {
                foreach (var caracter in NombreProductoTex.Text)
                {

                    if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
                    {
                        paso = false;
                        MessageBox.Show("El Campo NombreProducto solo recibe TEXTO...");
                    }
                    else
                    if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))

                        paso = true;
                }
            }

            if (string.IsNullOrWhiteSpace(PrecioProductoTex.Text) )
            {
                MessageBox.Show("El Campo PrecioProducto no puede estar vacio");
                PrecioProductoTex.Focus();
                paso = false;
            }
            else
            {
                foreach (var caracter in PrecioProductoTex.Text)
                {
                    if (!char.IsDigit(caracter))
                    {
                        paso = false;
                        MessageBox.Show("Escriba solo numeros en el campo PrecioProducto..");
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
        private void Llenar()
        {
            this.DataContext = null;
            this.DataContext = productos;
        }
        private bool ExisteEnLaBaseDeDatosProducto()
        {
            Productos productoss = ProductoBLL.Buscar(productos.ProductoId);
            return (productoss != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if (!Validar())
                return;

            if (productos.ProductoId == 0)
                paso = ProductoBLL.Guardar(productos);
            else
            {
                if (!ExisteEnLaBaseDeDatosProducto())
                {
                    MessageBox.Show("No se puede Modificar un Producto que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ProductoBLL.Modificar(productos);
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
            Productos productoAnterior = ProductoBLL.Buscar(productos.ProductoId);

            Limpiar();
            if (productoAnterior != null)
            {
                productos = productoAnterior;
                Llenar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Producto no Existe...");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductoBLL.Eliminar(productos.ProductoId))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Con Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Erro Al eliminar un Producto");
        }
    }
}
