using System;
using Npgsql;
using Ensenable.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ensenable.Data
{
    public class ActivityDatos
    {
        public List<ActivityModel> ListarActivities(int IdCourse)
        {
            var oLista = new List<ActivityModel>();

            var con = new Conexion();

            NpgsqlCommand com = new NpgsqlCommand("fn_list_activities", con.OpenCon());
            com.Parameters.AddWithValue("id_course", IdCourse);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            using (var dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    oLista.Add(new ActivityModel()
                    {
                        IdActivity = Convert.ToInt32(dr["id_activity"]),
                        IdCourse = Convert.ToInt32(dr["id_course"]),
                        NameActivity = dr["name_activity"].ToString(),
                        Instructions = dr["instructions"].ToString(),
                        NumActivity = Convert.ToInt32(dr["num_activity"])
                    });
                }
            }
            return oLista;
        }

        public ActivityModel ObtenerDetallesAct(int IdActivity)
        {
            var oActivity = new ActivityModel();

            var cn = new Conexion();

            NpgsqlCommand cmd = new NpgsqlCommand("fn_get_activity", cn.OpenCon());
            cmd.Parameters.AddWithValue("pid_activity", IdActivity);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    oActivity.IdActivity = Convert.ToInt32(dr["id_activity"]);
                    oActivity.IdCourse = Convert.ToInt32(dr["id_course"]);
                    oActivity.NameActivity = dr["name_activity"].ToString();
                    oActivity.Instructions = dr["instructions"].ToString();
                    oActivity.NumActivity = Convert.ToInt32(dr["num_activity"]);
                }
            }
            return oActivity;
        }

        public bool EditarDetalleActivity(ActivityModel oActivity)
        {
            bool flag = false;
            var con = new Conexion();

            string editar = "CALL sp_modify_activity (" + oActivity.IdActivity + "," + oActivity.IdCourse + ",'" + oActivity.NameActivity + "','" + oActivity.Instructions + "'," + oActivity.NumActivity + ")";
            NpgsqlCommand com = new NpgsqlCommand(editar, con.OpenCon());
            com.ExecuteNonQuery();
            flag = true;
            con.CloseCon();
            return flag;
        }

        public bool CrearActivity(ActivityModel oActivity)
        {
            bool flag = false;
            var con = new Conexion();

            string spcrearact = "CALL sp_create_activity (" + oActivity.IdCourse + ",'" + oActivity.NameActivity + "','" + oActivity.Instructions + "')";
            NpgsqlCommand com = new NpgsqlCommand(spcrearact, con.OpenCon());
            com.ExecuteNonQuery();
            flag = true;
            con.CloseCon();
            return flag;
        }



    }
}
