using System;
using Ensenable.Models;
using Npgsql;
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
                        ReleaseDate = dr["release_date"].ToString()
                    });
                }
            }
            return oLista;
        }
    }
}
