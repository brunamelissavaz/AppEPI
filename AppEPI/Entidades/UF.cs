using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEPI.Entidades
{
    public class UF
    {
        [Key]
        public int? Codigo { get; set; }
        public string Nome { get; set; }
        public ICollection<Solicitacao> Solicitacoes { get; set; }
    }
}
