using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssginmentEFW1
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Duration { get; set; }
        [InverseProperty("Course")]

        public string? Description { get; set; }
        [ForeignKey("Topic")]
        public int TopId { get; set; }
        public Topic Topic { get; set; }

        public ICollection<StudCourse> StudCourses { get; set; }
        public ICollection<CourseInst> CourseInsts { get; set; }

    }
}
