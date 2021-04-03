using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjmMultiLista
{
    public partial class Form1 : Form
    {
        private List<Vendedor> listVendedor;
        public Form1()
        {
            InitializeComponent();
            listVendedor = new List<Vendedor>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var vendedor = new Vendedor()
            {
                Codigo = txtCodigoAgregar.Text,
                Nombre = txtNombreAgregar.Text
            };

            listVendedor.Add(vendedor);
            MostrarVendedores();
        }

        private void MostrarVendedores() {
            txtElementos.Text = "Elementos: " + 
                                listVendedor.Count + 
                                Environment.NewLine;

            foreach (var vendedor in listVendedor)
            {
                txtElementos.Text += vendedor.Codigo +
                                        ": " +
                                        vendedor.Nombre +
                                        Environment.NewLine;

                foreach (var venta in vendedor.Ventas)
                {
                    txtElementos.Text += "   - " + 
                                        venta.Fecha.ToShortDateString() +
                                        ": " +
                                        venta.Monto +
                                        Environment.NewLine;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var vendedor = listVendedor.Find(x=> x.Codigo == txtCodigoEliminar.Text);
            if (vendedor != null)
            {
                listVendedor.Remove(vendedor);
                MostrarVendedores();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var test = listVendedor.Select(x => new {  x.Codigo, ElNombre = x.Nombre, NroVentas = x.Ventas.Count  });

            listVendedor.SelectMany(x => x.Ventas.Where(y => y.Fecha.Day > 25));
            listVendedor.Select(x => x.Ventas.Where(y => y.Fecha.Day > 25));

            var vendedor = listVendedor.Find(x => x.Codigo == txtCodigoParaVentas.Text);
            if (vendedor != null)
            {
                var venta = new Venta();
                venta.Monto = Convert.ToDecimal(txtMonto.Text);
                venta.Fecha = dtpFecha.Value;

                vendedor.Ventas.Add(venta);

                MostrarVendedores();
            }
        }
    }
}
