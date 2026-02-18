using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Maquina
{
    public partial class Inventario : Form
    {
        private ProductoRepository repo = new ProductoRepository();

        public Inventario()
        {
            InitializeComponent();
            CargarProductos(); // carga productos al abrir el form
        }

        private void CargarProductos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = repo.GetAll();
        }

        private void txtId_TextChanged(object sender, EventArgs e) { }
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void txtPrecio_TextChanged(object sender, EventArgs e) { }
        private void txtStock_TextChanged(object sender, EventArgs e) { }
        private void txtImagen_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Producto p = new Producto
            {
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Imagen = txtImagen.Text
            };

            repo.Insert(p);
            CargarProductos();
            MessageBox.Show("Producto creado correctamente");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Imagen = txtImagen.Text
            };

            repo.Update(p);
            CargarProductos();
            MessageBox.Show("Producto actualizado correctamente");
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            repo.Delete(id);
            CargarProductos();
            MessageBox.Show("Producto eliminado correctamente");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Maquina maquina = new Maquina(); // usa el nombre real de tu form principal
            maquina.Show();
        }
    }
}
