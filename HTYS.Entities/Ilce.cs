using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTYS.Entities
{
    [Table("Ilceler")]
    public class Ilce
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }

        public int IlId { get; set; }
        [ForeignKey("IlId")]
        public Il Il { get; set; }

        public ICollection<Semt> Semtler { get; set; }
    }
}