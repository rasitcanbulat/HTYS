using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTYS.Entities
{
    [Table("Semtler")]
    public class Semt
    {
        [Key]
        public int Id { get; set; }

        [Column("Ad")]
        public string Ad { get; set; }

        public int IlceId { get; set; }
        [ForeignKey("IlceId")]
        public Ilce Ilce { get; set; }
    }
}