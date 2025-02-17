using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssginmentEFW1
{
    public class CourseInst
    {
        [ForeignKey("Instructor")]
        public int InstId { get; set; }
        public Instructor Instructor { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public string Evaluate { get; set; }

    }
}
