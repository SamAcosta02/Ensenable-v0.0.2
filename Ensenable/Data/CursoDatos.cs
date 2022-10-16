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



    }
}
