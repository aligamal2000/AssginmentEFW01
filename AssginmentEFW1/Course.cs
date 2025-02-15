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
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Duration { get; set; }
        public string? Description { get; set; }
        public int TopId { get; set; }
    }
}
