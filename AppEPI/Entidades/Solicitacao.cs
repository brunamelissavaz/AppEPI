using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEPI.Entidades
{
    public class Solicitacao
    {
        public Solicitacao()
        {
        }

        [Key]
        public int? Codigo { get; set; }
        public DateTime Data { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string PostoDeTrabalho { get; set; }

        [ForeignKey("UF")]
        public int CodigoUF { get; set; }
        public ICollection<SolicitacaoProduto> Produtos { get; set; }
 
        public ICollection<UF> UFs { get; set; }

        public Solicitacao(int? codigo, DateTime data, string matricula, string nome, string celular, string postoDeTrabalho)
        {
            Codigo = codigo;
            Data = data;
            Matricula = matricula;
            Nome = nome;
            Celular = celular;
            PostoDeTrabalho = postoDeTrabalho;
        }
    }
}
