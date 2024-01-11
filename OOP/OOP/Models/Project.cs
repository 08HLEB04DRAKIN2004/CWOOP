using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace OOP
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int project_id { get; set; }

        [Required]
        public string title { get; set; }

        public string description_ { get; set; }
        public string status_ { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }

        [ForeignKey("Order")]
        public int Order_id { get; set; }
    }
}
