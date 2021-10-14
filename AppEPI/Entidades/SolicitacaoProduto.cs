using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppEPI.Entidades
{
    public class SolicitacaoProduto
    {
        public int CodigoSolicitacao { get; set; }
        public int CodigoProduto { get; set; }
        public string Tamanho { get; set; }
        public string Motivo { get; set; }


        public Solicitacao Solicitacao { get; set; }
        public Produto Produto { get; set; }
    }
}
