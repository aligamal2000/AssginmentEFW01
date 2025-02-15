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
        [Key]
        public int stud_ID { get; set; }

        public int Course_ID { get; set; }

        public string? Grade { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Course? Course { get; set; }
    }

}
