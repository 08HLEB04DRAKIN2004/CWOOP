using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace OOP
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_id { get; set; }

        public string description { get; set; }
        public DateTime? date { get; set; }
        public decimal? amount { get; set; }

        [ForeignKey("Client")]
        public int Client_id { get; set; }


    }
}
