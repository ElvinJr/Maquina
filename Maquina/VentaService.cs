using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina
{
    public class VentaService
    {
        private ProductoRepository repo = new ProductoRepository();

        public bool ProcesarVenta(int productoId, int cantidad)
        {
            var productos = repo.GetAll();
            var producto = productos.Find(p => p.Id == productoId);

            if (producto != null && producto.Stock >= cantidad)
            {
                producto.Stock -= cantidad;
                repo.Update(producto); // método Update en el repo
                return true;
            }
            return false;
        }
    }
}
