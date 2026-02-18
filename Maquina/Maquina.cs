using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Maquina; // Importa las clases ProductoRepository y VentaService

namespace Maquina
{
    public partial class Maquina : Form
    {
        private ProductoRepository repo = new ProductoRepository();
        private VentaService ventaService = new VentaService();
        private string productoSeleccionado = ""; // aquí se guarda el Id digitado
        private decimal saldo = 0;

        // Carpeta de recursos dentro del proyecto
        private string rutaRecursosProyecto = Path.Combine(Application.StartupPath, "Resources");

        // Carpeta absoluta en tu PC
        private string rutaRecursosPC = @"C:\Users\UserGPC\Downloads\Clases\Desarrollo de Aplicaciones y Sistemas\Maquina\Maquina\Resources";

        public Maquina()
        {
            InitializeComponent();
        }

        private void pbProducto_Click(object sender, EventArgs e) { }
        private void lblProducto_Click(object sender, EventArgs e) { }
        private void lblPrecio_Click(object sender, EventArgs e) { }
        private void progressBar1_Click(object sender, EventArgs e) { }

        // Botones numéricos
        private void btn0_Click(object sender, EventArgs e) { productoSeleccionado += "0"; lblId.Text = productoSeleccionado; }
        private void btn1_Click(object sender, EventArgs e) { productoSeleccionado += "1"; lblId.Text = productoSeleccionado; }
        private void btn2_Click(object sender, EventArgs e) { productoSeleccionado += "2"; lblId.Text = productoSeleccionado; }
        private void btn3_Click(object sender, EventArgs e) { productoSeleccionado += "3"; lblId.Text = productoSeleccionado; }
        private void btn4_Click(object sender, EventArgs e) { productoSeleccionado += "4"; lblId.Text = productoSeleccionado; }
        private void btn5_Click(object sender, EventArgs e) { productoSeleccionado += "5"; lblId.Text = productoSeleccionado; }
        private void btn6_Click(object sender, EventArgs e) { productoSeleccionado += "6"; lblId.Text = productoSeleccionado; }
        private void btn7_Click(object sender, EventArgs e) { productoSeleccionado += "7"; lblId.Text = productoSeleccionado; }
        private void btn8_Click(object sender, EventArgs e) { productoSeleccionado += "8"; lblId.Text = productoSeleccionado; }
        private void btn9_Click(object sender, EventArgs e) { productoSeleccionado += "9"; lblId.Text = productoSeleccionado; }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (productoSeleccionado.Length > 0)
            {
                productoSeleccionado = productoSeleccionado.Substring(0, productoSeleccionado.Length - 1);
                lblId.Text = productoSeleccionado;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (int.TryParse(productoSeleccionado, out int productoId))
            {
                var producto = repo.GetAll().Find(p => p.Id == productoId);

                if (producto != null)
                {
                    lblProducto.Text = producto.Nombre;
                    lblPrecio.Text = producto.Precio.ToString("C");

                    // Mostrar imagen del producto
                    string rutaImagenProyecto = Path.Combine(rutaRecursosProyecto, producto.Imagen);
                    string rutaImagenPC = Path.Combine(rutaRecursosPC, producto.Imagen);

                    if (File.Exists(rutaImagenProyecto))
                    {
                        pbProducto.Image = Image.FromFile(rutaImagenProyecto);
                        pbProducto.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else if (File.Exists(rutaImagenPC))
                    {
                        pbProducto.Image = Image.FromFile(rutaImagenPC);
                        pbProducto.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pbProducto.Image = null;
                        lblErrores.Text = "Imagen no encontrada: " + producto.Imagen;
                    }

                    if (saldo >= producto.Precio)
                    {
                        bool ventaOk = ventaService.ProcesarVenta(productoId, 1);
                        if (ventaOk)
                        {
                            pbEntrega.BackColor = Color.Green; // entrega exitosa

                            decimal cambio = saldo - producto.Precio; // lo que sobra
                            lblCambio.Text = cambio.ToString("C");

                            saldo = 0; // reinicia el saldo porque ya se devolvió el cambio
                            lblErrores.Text = "";
                        }
                        else
                        {
                            pbEntrega.BackColor = Color.Red;
                            lblErrores.Text = "Stock insuficiente";
                        }
                    }
                    else
                    {
                        pbEntrega.BackColor = Color.Red;
                        lblErrores.Text = "Saldo insuficiente";
                    }
                }
                else
                {
                    lblErrores.Text = "Producto no encontrado";
                }
            }
            else
            {
                lblErrores.Text = "Código inválido";
            }

            productoSeleccionado = "";
            lblId.Text = "";
        }

        private void txtSaldo_TextChanged(object sender, EventArgs e) { }

        private void btnInsertarsaldo_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtSaldo.Text, out decimal monto))
            {
                saldo += monto;
                lblErrores.Text = "";
                lblCambio.Text = "0"; // reinicia el cambio al insertar saldo nuevo
            }
            else
            {
                lblErrores.Text = "Monto inválido";
            }
        }

        private void lblCambio_Click(object sender, EventArgs e) { }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario inv = new Inventario();
            inv.Show();
            this.Hide();
        }

        private void pbEntrega_Click(object sender, EventArgs e) { }
        private void lblErrores_Click(object sender, EventArgs e) { }
        private void lblId_Click(object sender, EventArgs e) { }
    }
}
