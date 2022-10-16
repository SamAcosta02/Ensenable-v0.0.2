using System;
using Npgsql;
using Ensenable.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ensenable.Data
{
    public class CursoDatos
    {
        public List<CourseModel> ListarCursos()
        {
            var oLista = new List<CourseModel>();

            var con = new Conexion();

            NpgsqlCommand com = new NpgsqlCommand("fn_listar_cursos", con.OpenCon());
            com.CommandType = System.Data.CommandType.StoredProcedure;

            using (var dr = com.ExecuteReader())
            {
                while(dr.Read())
                {
                    oLista.Add(new CourseModel()
                    {
                        IdCourse = Convert.ToInt32(dr["id_course"]),
                        NameCourse = dr["name_course"].ToString(),
                        Subject = dr["subject"].ToString(),
                        Description = dr["description"].ToString(),
                        Author = dr["author"].ToString(),
                        ReleaseDate = dr["release_date"].ToString(),
                        IsPublished = dr["is_published"].ToString()
                    });
                }
            }
            return oLista;
        }

        public bool CrearCurso(CourseModel oCurso)
        {
            bool flag = false;
            var con = new Conexion();

            string spcrearcurso = "CALL sp_create_course ('" + oCurso.NameCourse + "','" + oCurso.Subject + "','" + oCurso.Description + "','" + oCurso.Author + "')";
            NpgsqlCommand com = new NpgsqlCommand(spcrearcurso, con.OpenCon());
            com.ExecuteNonQuery();
            flag = true;
            con.CloseCon();
            return flag;
        }

        public CourseModel ObtenerDetalles(int IdCourse)
        {
            var oCourse = new CourseModel();

            var cn = new Conexion();

            NpgsqlCommand cmd = new NpgsqlCommand("fn_ObtenerDetalles", cn.OpenCon());
            cmd.Parameters.AddWithValue("id_course", IdCourse);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    oCourse.IdCourse = Convert.ToInt32(dr["id_course"]);
                    oCourse.NameCourse = dr["name_course"].ToString();
                    oCourse.Subject = dr["subject"].ToString();
                    oCourse.Description = dr["description"].ToString();
                    oCourse.Author = dr["author"].ToString();
                    oCourse.ReleaseDate = dr["release_date"].ToString();
                    oCourse.IsPublished = dr["is_published"].ToString();
                }
            }
            return oCourse;
        }

        public bool EditarDetalleCurso(CourseModel oCourse)
        {
            bool flag = false;
            var con = new Conexion();

            string editar = "CALL sp_modify_course (" + oCourse.IdCourse + ",'" + oCourse.NameCourse + "','" + oCourse.Subject + "','" + oCourse.Description + "','" + oCourse.Author + "')";
            NpgsqlCommand com = new NpgsqlCommand(editar, con.OpenCon());
            com.ExecuteNonQuery();
            flag = true;
            con.CloseCon();
            return flag;
        }

    }
}
