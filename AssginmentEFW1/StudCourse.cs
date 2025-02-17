using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssginmentEFW1
{
    public class StudCourse
    {
        [ForeignKey("Student")]
        public int Stud_ID { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Course")]
        public int Course_ID { get; set; }
        public Course Course { get; set; }

        public string Grade { get; set; }

    }

}
