using Npgsql;
namespace Ensenable.Datos
{
    public class Conexion
    {

        NpgsqlConnection con = new NpgsqlConnection();

        static string servidor = "localhost";
        static string db = "ensenable";
        static string user = "postgres";
        static string pass = "simonynico";
        static string port = "5432";
        string CadenaConexion = "server=" + servidor + ";port=" + port + ";user id=" + user + ";password=" + pass + ";database=" + db + ";";


        public NpgsqlConnection OpenCon()
        {
            try
            {
                con.ConnectionString = CadenaConexion;
                con.Open();
            }
            catch (NpgsqlException e)
            {
                string srror = e.Message;
            }
            return con;
        }

        public void CloseCon()
        {
            try
            {
                con.Close();
            }
            catch (NpgsqlException e)
            {
                string srror = e.Message;
            }
        }
    }
}
