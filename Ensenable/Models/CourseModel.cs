using System;
using System.Collections.Generic;
using System.Linq;
using Ensenable.Models;
using System.Threading.Tasks;

namespace Ensenable.Models
{
    public class CourseModel
    {
        public int IdCourse { get; set; }

        public string NameCourse { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string ReleaseDate { get; set; }

        public string IsPublished { get; set; }
    }
}
