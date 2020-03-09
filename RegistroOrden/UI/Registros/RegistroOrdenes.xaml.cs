﻿using RegistroOrden.BLL;
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
    /// Interaction logic for RegistroOrdenes.xaml
    /// </summary>
    public partial class RegistroOrdenes : Window
    {
        Ordenes ordenes = new Ordenes();
       
        public RegistroOrdenes()
        {
            InitializeComponent();
            this.DataContext = ordenes;
            OrdenIdTex.Text = "0";
            FechaDatapiker.SelectedDate = DateTime.Now;

        }

        private void Limpiar()
        {
            OrdenIdTex.Text = "0";            
            FechaDatapiker.SelectedDate = DateTime.Now;
            DescrepcionTex.Text = string.Empty;
            CantidadOdenTex.Text = string.Empty;
            PrecioTex.Text = string.Empty;
            MontoTotalTex.Text = string.Empty;
            ordenes.OrdenesDetalle = new List<OrdenDetalles>();
            ordenes = new Ordenes();
            Llenar();

            //this.OrdenesDetalle = new List<OrdenDetalles>();
            //CargarDataGrid();
        }
        //private void CargarDataGrid()
        //{
        //    DetalleDataGrid.ItemsSource = null;
        //    DetalleDataGrid.ItemsSource = this.OrdenesDetalle;
        //}
        private bool Validar()
        {
            bool paso = true;

            //if (string.IsNullOrWhiteSpace(DescrepcionTex.Text))
            //{
            //    MessageBox.Show("El Campo Nombre no puede estar vacio");
            //    DescrepcionTex.Focus();
            //    paso = false;
            //}
            //else
            //{
            //    foreach (var caracter in DescrepcionTex.Text)
            //    {

            //        if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
            //        {
            //            paso = false;
            //            MessageBox.Show("El Campo DIESCRICION solo recibe TEXTO...");
            //        }
            //        else
            //        if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))

            //            paso = true;
            //    }
            //}          

            //if (string.IsNullOrWhiteSpace(CantidadOdenTex.Text))
            //{
            //    MessageBox.Show("El Campo CANTIDAD no puede estar vacio");
            //    CantidadOdenTex.Focus();
            //    paso = false;
            //}
            //else
            //{
            //    foreach (var caracter in CantidadOdenTex.Text)
            //    {
            //        if (!char.IsDigit(caracter))
            //        {
            //            paso = false;
            //            MessageBox.Show("Escriba solo numeros en el campo CANTIDAD..");
            //        }
            //        else
            //        if (!char.IsDigit(caracter))
            //            paso = true;
            //    }
            //}         

            //if (string.IsNullOrWhiteSpace(PrecioTex.Text))
            //{
            //    MessageBox.Show("El Campo PRECIO no puede estar vacio");
            //    PrecioTex.Focus();
            //    paso = false;
            //}
            //else
            //{
            //    foreach (var caracter in PrecioTex.Text)
            //    {
            //        if (!char.IsDigit(caracter))
            //        {
            //            paso = false;
            //            MessageBox.Show("Escriba solo numeros en el campo PRECIO..");
            //        }
            //        else
            //        if (!char.IsDigit(caracter))
            //            paso = true;
            //    }
            //}
            return paso;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void Llenar()
        {
            this.DataContext = null;
            this.DataContext = ordenes;
        }
        private bool ExisteEnLaBaseDeDatosOrdenDetalle()
        {
            Ordenes ordenes = OrdenesBLL.Buscar(Convert.ToInt32(OrdenIdTex.Text));
            return (ordenes != null);
        }
        //private bool ExisteEnLaBaseDeDatosCliente()
        //{
        //    Clientes clientes = ClienteBLL.Buscar(Convert.ToInt32(ClienteIdTex.Text));
        //    return (clientes != null);
        //}
        //private bool ExisteEnLaBaseDeDatosProducto()
        //{
        //    Productos productos = ProductoBLL.Buscar(Convert.ToInt32(ProductoIdTex.Text));
        //    return (productos != null);
        //}

        private void GuardarButon_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if (!Validar())
                return;

            if (ordenes.OrdenId == 0)
                paso = OrdenesBLL.Guardar(ordenes);
            else
            {
                if (!ExisteEnLaBaseDeDatosOrdenDetalle())
                {
                    MessageBox.Show("No se puede Modificar una persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = OrdenesBLL.Modificar(ordenes);
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
            Ordenes OrdenesAnterior = OrdenesBLL.Buscar(ordenes.OrdenId);

            Limpiar();
            if (OrdenesAnterior != null)
            {
                ordenes = OrdenesAnterior;
                Llenar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Cliente no Existe...");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdenesBLL.Eliminar(ordenes.OrdenId))
            { 
                Limpiar();
          
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Erro Al eliminar una persona");
        }
        private void AgregarOrdenButton_Click(object sender, RoutedEventArgs e)
        {
        //    if (DetalleDataGrid.ItemsSource != null)
        //      this.OrdenesDetalle = (List<OrdenDetalles>)DetalleDataGrid.ItemsSource;
                ////todo: valida campo de detalle

                ////agrega un nuevo detalle con los datos introducidos. 
                ordenes.OrdenesDetalle.Add(new OrdenDetalles(ordenes.OrdenId,Convert.ToInt32(ProductoIdTex.Text),Convert.ToInt32(ClienteIdTex.Text),
                DescrepcionTex.Text, Convert.ToInt32(CantidadOdenTex.Text),
               Convert.ToDecimal(PrecioTex.Text), Convert.ToDecimal(MontoTotalTex.Text)));

            Llenar();

            ProductoIdTex.Clear();
            DescrepcionTex.Clear();
            PrecioTex.Clear();
            CantidadOdenTex.Clear();
            MontoTotalTex.Clear();
            ProductoIdTex.Focus();
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Columns.Count > 0 && DetalleDataGrid.SelectedCells != null)
            {
                ordenes.OrdenesDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Llenar();
            }
        }
        private void CantidadOdenTex_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal monto = 0;
            decimal pago = 0;

            if (!string.IsNullOrWhiteSpace(CantidadOdenTex.Text) && CantidadOdenTex.Text != "-")
            {
                monto = decimal.Parse(CantidadOdenTex.Text);
            }
            if (!string.IsNullOrWhiteSpace(PrecioTex.Text) && PrecioTex.Text != "-")
            {
                pago = decimal.Parse(PrecioTex.Text);
            }

            decimal resultado = monto * pago;

            MontoTotalTex.Text = resultado.ToString();
        }

        private void PrecioTex_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal monto = 0;
            decimal pago = 0;

            if (!string.IsNullOrWhiteSpace(CantidadOdenTex.Text) && CantidadOdenTex.Text != "-")
            {
                monto = decimal.Parse(CantidadOdenTex.Text);
            }
            if (!string.IsNullOrWhiteSpace(PrecioTex.Text) && PrecioTex.Text != "-")
            {
                pago = decimal.Parse(PrecioTex.Text);
            }

            decimal resultado = monto * pago;

            MontoTotalTex.Text = resultado.ToString(); 
        }
        private void ProductoLlenaCampo(Productos productos)
        {
            DescrepcionTex.Text = productos.NombreProducto;
            PrecioTex.Text = Convert.ToString(productos.PrecioProducto);
        }
        private void ProductoIdTex_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ProductoIdTex.Text))
            {
                int id;
                Productos producto = new Productos();
                int.TryParse(ProductoIdTex.Text, out id);

                producto = ProductoBLL.Buscar(id);
                if (producto != null)
                {
                    ProductoLlenaCampo(producto);
                }
                else
                {
                    DescrepcionTex.Text = "No existe Tal Producto";
                    PrecioTex.Text = "No Existe Precio";
                }
            }
        }
    }
}
