using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Student:BaseEntity
    {
        public string StudentName { get; set; }
        public int Age { get; set; }
        [ForeignKey("Grade")]
        public Guid GId { get; set; }
        public Grade Grade { get; set; }
    }
}
