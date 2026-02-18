using System.Collections.Generic;
using System.Data.SqlClient;

namespace Maquina
{
    public class ProductoRepository
    {
        private Conexion conexion = new Conexion();

        // LISTAR
        public List<Producto> GetAll()
        {
            var productos = new List<Producto>();
            using (SqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Nombre, Precio, Stock, Imagen FROM Productos";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    productos.Add(new Producto
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Precio = reader.GetDecimal(2),
                        Stock = reader.GetInt32(3),
                        Imagen = reader.GetString(4)
                    });
                }
            }
            return productos;
        }

        // INSERTAR
        public void Insert(Producto p)
        {
            using (SqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Productos (Nombre, Precio, Stock, Imagen) VALUES (@Nombre, @Precio, @Stock, @Imagen)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Precio", p.Precio);
                cmd.Parameters.AddWithValue("@Stock", p.Stock);
                cmd.Parameters.AddWithValue("@Imagen", p.Imagen);
                cmd.ExecuteNonQuery();
            }
        }

        // ACTUALIZAR
        public void Update(Producto p)
        {
            using (SqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Productos SET Nombre=@Nombre, Precio=@Precio, Stock=@Stock, Imagen=@Imagen WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Precio", p.Precio);
                cmd.Parameters.AddWithValue("@Stock", p.Stock);
                cmd.Parameters.AddWithValue("@Imagen", p.Imagen);
                cmd.Parameters.AddWithValue("@Id", p.Id);
                cmd.ExecuteNonQuery();
            }
        }

        // ELIMINAR
        public void Delete(int id)
        {
            using (SqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Productos WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
