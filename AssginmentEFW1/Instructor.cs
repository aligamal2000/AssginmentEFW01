using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssginmentEFW1
{
    public class Instructor
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public decimal Bonus { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }
        public decimal HourRate { get; set; }
        [ForeignKey("Department")]
        public int? Dept_ID { get; set; } 
        public Department? Department { get; set; }

        public ICollection<CourseInst>? CourseInsts { get; set; }
    }
}
