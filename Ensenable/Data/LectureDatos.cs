using System;
using Npgsql;
using Ensenable.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ensenable.Data
{
    public class LectureDatos
    {
        public bool CrearLecture(LectureModel oLecture)
        {
            bool flag = false;
            var con = new Conexion();

            string spcrearlec = "CALL sp_create_lecture (" + oLecture.IdActivity + ",'" + oLecture.NombreLecture + "','" + oLecture.YtLink + "','" + oLecture.Purpose + "','" + oLecture.PreguntasApoyo + "','" + oLecture.Texto + "')";
            NpgsqlCommand com = new NpgsqlCommand(spcrearlec, con.OpenCon());
            com.ExecuteNonQuery();
            flag = true;
            con.CloseCon();
            return flag;
        }

        public LectureModel ObtenerDetallesLecture(int IdLecture)
        {
            var oLecture = new LectureModel();

            var cn = new Conexion();

            NpgsqlCommand cmd = new NpgsqlCommand("fn_get_lecture", cn.OpenCon());
            cmd.Parameters.AddWithValue("id_lecture", IdLecture);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    oLecture.IdLecture = Convert.ToInt32(dr["id_lecture"]);
                    oLecture.IdActivity = Convert.ToInt32(dr["id_activity"]);
                    oLecture.NombreLecture = dr["nombre_lecture"].ToString();
                    oLecture.YtLink = dr["yt_link"].ToString();
                    oLecture.Purpose = dr["purpose"].ToString();
                    oLecture.PreguntasApoyo = dr["preguntas_apoyo"].ToString();
                    oLecture.Texto = dr["texto1"].ToString();
                }
            }
            return oLecture;
        }

        public LectureModel ObtenerDetallesLectureAct(int IdActivity)
        {
            var oLecture = new LectureModel();

            var cn = new Conexion();

            NpgsqlCommand cmd = new NpgsqlCommand("fn_get_lecture_act", cn.OpenCon());
            cmd.Parameters.AddWithValue("id_activity", IdActivity);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    oLecture.IdLecture = Convert.ToInt32(dr["id_lecture"]);
                    oLecture.IdActivity = Convert.ToInt32(dr["id_activity"]);
                    oLecture.NombreLecture = dr["nombre_lecture"].ToString();
                    oLecture.YtLink = dr["yt_link"].ToString();
                    oLecture.Purpose = dr["purpose"].ToString();
                    oLecture.PreguntasApoyo = dr["preguntas_apoyo"].ToString();
                    oLecture.Texto = dr["texto1"].ToString();
                }
            }
            return oLecture;
        }

        public bool EditarDetalleLecture(LectureModel oLecture)
        {
            bool flag = false;
            var con = new Conexion();

            string editar = "CALL sp_modify_lecture (" + oLecture.IdLecture + "," + oLecture.IdActivity + ",'" + oLecture.NombreLecture + "','" + oLecture.YtLink + "','" + oLecture.Purpose + "','" + oLecture.PreguntasApoyo + "','" + oLecture.Texto + "')";
            NpgsqlCommand com = new NpgsqlCommand(editar, con.OpenCon());
            com.ExecuteNonQuery();
            flag = true;
            con.CloseCon();
            return flag;
        }

        public List<LectureModel> ListarEmptyLectures()
        {
            var oLista = new List<LectureModel>();

            var con = new Conexion();

            NpgsqlCommand com = new NpgsqlCommand("fn_list_empty_lectures", con.OpenCon());
            com.CommandType = System.Data.CommandType.StoredProcedure;

            using (var dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    oLista.Add(new LectureModel()
                    {
                        IdLecture = Convert.ToInt32(dr["id_lecture"]),
                        IdActivity = Convert.ToInt32(dr["id_activity"]),
                        NombreLecture = dr["nombre_lecture"].ToString(),
                        YtLink = dr["yt_link"].ToString(),
                        Purpose = dr["purpose"].ToString(),
                        PreguntasApoyo = dr["preguntas_apoyo"].ToString(),
                        Texto = dr["texto1"].ToString()
                    });
                }
            }
            return oLista;
        }
    }

}
