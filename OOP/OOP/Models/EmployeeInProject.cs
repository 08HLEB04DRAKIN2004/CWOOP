using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OOP.Domain.Entity;

namespace OOP
{
    public class EmployeeInProject

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int assignment_id { get; set; }

        [ForeignKey("project_id")]
        public int project_id{ get; set; }

        [ForeignKey("employee_id")]
        public int employee_id{ get; set; }

        [ForeignKey("role_id")]
        public int  role_id {  get; set; } 
    
    }
}