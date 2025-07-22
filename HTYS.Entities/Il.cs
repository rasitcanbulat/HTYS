using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTYS.Entities
{
    [Table("Iller")]
    public class Il
    {
        [Key]
        public int Id { get; set; }

        public int IlId { get; set; }
        public string Ad { get; set; }
        public ICollection<Ilce> Ilceler { get; set; }
    }
}