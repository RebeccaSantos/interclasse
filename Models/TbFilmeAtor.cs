using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace interclasse.Models
{
    [Table("tb_filme_ator")]
    public partial class TbFilmeAtor
    {
        [Key]
        [Column("id_filme_ator", TypeName = "int(11)")]
        public int IdFilmeAtor { get; set; }
        [Required]
        [Column("nm_personagem", TypeName = "varchar(100)")]
        public string NmPersonagem { get; set; }
        [Column("id_filme", TypeName = "int(11)")]
        public int IdFilme { get; set; }
        [Column("id_ator", TypeName = "int(11)")]
        public int IdAtor { get; set; }

        [ForeignKey(nameof(IdAtor))]
        [InverseProperty(nameof(TbAtor.TbFilmeAtor))]
        public virtual TbAtor IdAtorNavigation { get; set; }
        [ForeignKey(nameof(IdFilme))]
        [InverseProperty(nameof(TbFilme.TbFilmeAtor))]
        public virtual TbFilme IdFilmeNavigation { get; set; }
    }
}
