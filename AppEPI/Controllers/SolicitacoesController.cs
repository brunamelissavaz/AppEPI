using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppEPI.Data;
using AppEPI.Entidades;
using AppEPI.Services;
using AppEPI.Models;
using Newtonsoft.Json;

namespace AppEPI.Controllers
{
    public class SolicitacoesController : Controller
    {
        private readonly EPIContext _context;
        private readonly SolicitacaoService _solicitacaoService;

        public SolicitacoesController(EPIContext context, SolicitacaoService solicitacaoService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _solicitacaoService = solicitacaoService ?? throw new ArgumentNullException(nameof(solicitacaoService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Solicitacao.ToListAsync());
        }

        [HttpGet]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0090:Use 'new(...)'", Justification = "<Pending>")]
        public IActionResult Cadastro(int? id)
        {
            SolicitacaoViewModel viewModel = new SolicitacaoViewModel();
            viewModel.ListaUFs = _solicitacaoService.ListaUFs();
            viewModel.ListaProdutos = _solicitacaoService.ListaProdutos();
            
            if (id != null)
            {
                var entidade = _context.Solicitacao.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Data = entidade.Data;
                viewModel.Matricula = entidade.Matricula;
                viewModel.Nome = entidade.Nome;
                viewModel.Celular = entidade.Celular;
                viewModel.PostoDeTrabalho = entidade.PostoDeTrabalho;
                viewModel.CodigoUF = entidade.CodigoUF;
                

            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Cadastro(SolicitacaoViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Solicitacao objSolicitacao = new Solicitacao()
                {
                    Codigo = entidade.Codigo,
                    Data = (DateTime)entidade.Data,
                    Matricula = entidade.Matricula,
                    Nome = entidade.Nome,
                    Celular = entidade.Celular,
                    PostoDeTrabalho = entidade.PostoDeTrabalho,
                    CodigoUF = entidade.CodigoUF,
                    Produtos = JsonConvert.DeserializeObject<ICollection<SolicitacaoProduto>>(entidade.JsonProdutos)
                };
                if (entidade.Codigo == null)
                {
                    _context.Solicitacao.Add(objSolicitacao);
                }
                else
                {
                    _context.Entry(objSolicitacao).State = EntityState.Modified;
                }
                _context.SaveChanges();
            }
            else
            {
                entidade.ListaUFs = _solicitacaoService.ListaUFs();
                entidade.ListaProdutos = _solicitacaoService.ListaProdutos();
                return View(entidade);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var ent = new Solicitacao() { Codigo = id };
            _context.Attach(ent);
            _context.Remove(ent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("LevarCategoriaProduto/{CodigoProduto}")]
        public string LevarCategoriaProduto(int CodigoProduto)
        {
            return _context.Produto.Where(x => x.Codigo == CodigoProduto).Select(x => x.Categoria.Descricao).FirstOrDefault();
        }

    }
}
