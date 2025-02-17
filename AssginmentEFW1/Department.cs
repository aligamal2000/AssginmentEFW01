using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssginmentEFW1
{
    public class Department
    {
        [Key]
        public int Dep_Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Instructor")]
        public int? Ins_ID { get; set; }  
        public Instructor? Instructor { get; set; } 

        public DateTime HiringDate { get; set; }

        public ICollection<Student> Students { get; set; }


    }
}
