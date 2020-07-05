using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace interclasse.Models
{
    [Table("tb_diretor")]
    public partial class TbDiretor
    {
        [Key]
        [Column("id_diretor", TypeName = "int(11)")]
        public int IdDiretor { get; set; }
        [Required]
        [Column("nm_diretor", TypeName = "varchar(100)")]
        public string NmDiretor { get; set; }
        [Column("dt_nascimento", TypeName = "datetime")]
        public DateTime DtNascimento { get; set; }
        [Column("id_filme", TypeName = "int(11)")]
        public int IdFilme { get; set; }

        [ForeignKey(nameof(IdFilme))]
        [InverseProperty(nameof(TbFilme.TbDiretor))]
        public virtual TbFilme IdFilmeNavigation { get; set; }
    }
}
