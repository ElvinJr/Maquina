using System.Data.SqlClient;

public class Conexion
{
    private string connectionString =
        @"Server=DESKTOP-VE5IE91\SQLEXPRESS01;Database=Maquina;Trusted_Connection=True;";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}
