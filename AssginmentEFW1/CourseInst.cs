using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssginmentEFW1
{
    public class CourseInst
    {
        [Key]
        public int InstId { get; set; }
        public int CourseId { get; set; }
        public string? Evaluate { get; set; }
    }
}
