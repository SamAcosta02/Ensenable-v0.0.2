using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ensenable.Models
{
    public class LectureModel
    {
        public int IdLecture { get; set; }

        public int IdActivity { get; set; }

        public int IdCourse { get; set; }

        public string NombreLecture { get; set; }

        public string YtLink { get; set; }

        public string Purpose { get; set; }

        public string PreguntasApoyo { get; set; }

        public string Texto { get; set; }
    }
}
