using AppEPI.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEPI.Models;


namespace AppEPI.Services
{
    public class SolicitacaoService
    {
        private readonly EPIContext _context;

        public SolicitacaoService(EPIContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> ListaProdutos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem() 
            { 
                Value = string.Empty,
                Text = string.Empty 
            });
            foreach (var item in _context.Produto.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao.ToString()
                });
            }
            return lista;
        }
        public IEnumerable<SelectListItem> ListaUFs()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });
            foreach (var item in _context.UF.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome.ToString()
                });
            }
            return lista;
        }
                    
    }
}
