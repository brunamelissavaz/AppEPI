using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppEPI.Models
{
    public class SolicitacaoViewModel
    {
        public int? Codigo { get; set; }
        [Required(ErrorMessage = "Informe a Data da Solicitação!")]
        public DateTime? Data { get; set; }
        [Required(ErrorMessage = "Informe o Número da Matricula!")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "Informe seu Nome Completo!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe seu Celular/ Telefone!")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Informe o Posto de trabalho!")]
        public string PostoDeTrabalho { get; set; }

        public int CodigoUF { get; set; }
        public IEnumerable<SelectListItem> ListaUFs { get; set; }
        public IEnumerable<SelectListItem> ListaProdutos { get; set; }
        public string JsonProdutos { get; set; }





    }
}
