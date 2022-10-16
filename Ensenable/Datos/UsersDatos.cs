using Microsoft.AspNetCore.Mvc;
using Ensenable.Models;
using Npgsql;
using System.Data;
using Microsoft.AspNetCore.Components.Routing;

    
namespace Ensenable.Datos
{
    public class UsersDatos
    {
        public List<UsersModel> Listar()
        {
            var oLista = new List<UsersModel>();
            var con = new Conexion();

            NpgsqlCommand cmd = new NpgsqlCommand("fn_view_users", con.OpenCon());
            cmd.CommandType = CommandType.StoredProcedure;

            using(var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    oLista.Add(new UsersModel()
                    {
                        id_user = Convert.ToInt32(dr["id_user"]),
                        user_name = dr["user_name"].ToString(),
                        user_firstlastname = dr["user_firstlastname"].ToString(),
                        user_secondlastname = dr["user_secondlastname"].ToString(),
                        user_email = dr["user_email"].ToString(),
                        user_password = dr["user_password"].ToString(),
                        user_role = Convert.ToInt32(dr["user_role"]),
                        user_status = dr["user_status"].ToString()
                    });
                }
            }
            return oLista;
        }

        public bool Insertar(UsersModel oUser)
        {
            bool flag;
            var con = new Conexion();
            string spinsert = "CALL sp_insert_user('" + oUser.user_name + "','" + oUser.user_firstlastname + "','" + oUser.user_secondlastname + "','" + oUser.user_email + "','" + oUser.user_password + "','" + oUser.user_role + "','" + oUser.user_status + "')";
            NpgsqlCommand cmd = new NpgsqlCommand(spinsert, con.OpenCon());
            cmd.ExecuteNonQuery();
            flag = true;
            con.CloseCon();
            return flag;
        }


        public bool Eliminar(int id_user)
        {
            bool flag;
            var con = new Conexion();

            string spdelete = "CALL sp_delete_user('"+ id_user + "')";
            NpgsqlCommand cmd = new NpgsqlCommand(spdelete, con.OpenCon());
            cmd.ExecuteNonQuery();
            flag = true;
            con.CloseCon();
            return flag;
        }


        public bool Editar(UsersModel oUser)
        {
            bool flag;
            var con = new Conexion();

            string spupdate = "CALL sp_update_user('" + oUser.id_user + "','" + oUser.user_name + "','" + oUser.user_firstlastname + "','" + oUser.user_secondlastname + "','" + oUser.user_email + "','" + oUser.user_password + "','" + oUser.user_role + "','" + oUser.user_status + "')";
            NpgsqlCommand cmd = new NpgsqlCommand(spupdate, con.OpenCon());
            cmd.ExecuteNonQuery();
            flag = true;
            con.CloseCon();
            return flag;
        }


        public UsersModel Obtener(int id_user)
        {
            var oUser = new UsersModel();

            var con = new Conexion();

            NpgsqlCommand cmd = new NpgsqlCommand("fn_view_user", con.OpenCon());
            cmd.Parameters.AddWithValue("id_user",  id_user);
            cmd.CommandType = CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    oUser.id_user = Convert.ToInt32(dr["id_user"]);
                    oUser.user_name = dr["user_name"].ToString();
                    oUser.user_firstlastname = dr["user_firstlastname"].ToString();
                    oUser.user_secondlastname = dr["user_secondlastname"].ToString();
                    oUser.user_email = dr["user_email"].ToString();
                    oUser.user_password = dr["user_password"].ToString();
                    oUser.user_role = Convert.ToInt32(dr["user_role"]);
                    oUser.user_status = dr["user_status"].ToString();
                }
            }
            return oUser;
        }

        public int ValidarLogin(string user_email, string user_password)
        {

            var con = new Conexion();
            int bandera = 0;

            NpgsqlCommand cmd = new NpgsqlCommand("fn_validate_user_login", con.OpenCon());
            cmd.Parameters.AddWithValue("user_email", user_email);
            cmd.Parameters.AddWithValue("user_password", user_password);
            cmd.CommandType = CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    bandera = Convert.ToInt32(dr["bandera"]);
                }
            }
            return bandera;
        }

        public int ValidarRegis(string user_email)
        {

            var con = new Conexion();
            int bandera = 0;

            NpgsqlCommand cmd = new NpgsqlCommand("fn_validate_user_regis", con.OpenCon());
            cmd.Parameters.AddWithValue("user_email", user_email);
            cmd.CommandType = CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    bandera = Convert.ToInt32(dr["bandera"]);
                }
            }
            return bandera;
        }


        public UsersModel getUserInfo(string user_email)
        {
            var oUser = new UsersModel();
            var oLista = Listar();
            foreach (var item in oLista)
            {
                if (item.user_email == user_email)
                {
                    oUser = item;
                    break;
                }
            }
            return oUser;
        }
    }
}
