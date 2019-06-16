using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.business.Model
{
    [Table("movimento")]
    public class MovimentoEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("movimento")]
        public String Movimento { get; set; }
    }
}
