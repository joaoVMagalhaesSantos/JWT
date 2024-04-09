using AutoMapper;
using EmprestimoLivros.API.DTOs;
using EmprestimoLivros.API.Interfaces;
using EmprestimoLivros.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : Controller
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public LivroController(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            var livros = await _livroRepository.GetAll();
            var livrosDTO = _mapper.Map<IEnumerable<LivroDTO>>(livros);


            return Ok(livrosDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarLivro(LivroDTO livroDTO)
        {
            var livro = _mapper.Map<Livro>(livroDTO);
            _livroRepository.Incluir(livro);

            if (await _livroRepository.SaveAllAsync())
            {
                return Ok("Livro cadastrado com sucesso");
            }
            else
            {
                return BadRequest("Erro ao cadastrar Livro");
            }
        }

        [HttpPut]
        public async Task<ActionResult> AlterarLivro(LivroDTO livroDTO)
        {
            var livro = _mapper.Map<Livro>(livroDTO);
            _livroRepository.Alterar(livro);
            if (await _livroRepository.SaveAllAsync())
            {
                return Ok("Livro cadastrado com sucesso");
            }
            else
            {
                return BadRequest("Erro ao cadastrar Livro");
            }
        }


        [HttpDelete("{id_livro}")]
        public async Task<ActionResult> ExcluirLivro(int id_livro)
        {
            var livro = await _livroRepository.SelecionarByPK(id_livro);

            if(livro == null)
            {
                return BadRequest("Livro não encontrado");
            }

            _livroRepository.Excluir(livro);

            if (await _livroRepository.SaveAllAsync())
            {
                return Ok("Livro excluido com sucesso");
            }
            else
            {
                return BadRequest("Erro ao excluir Livro");
            }

        }


        [HttpGet("{id_livro}")]
        public async Task<ActionResult<IEnumerable<Livro>>> SelecionarLivroPorID(int id_livro)
        {
            var livro = await _livroRepository.SelecionarByPK(id_livro);
            if(livro == null)
            {
                return NotFound("Livro não encontrado");
            }
            
            var livroDTO = _mapper.Map<LivroDTO>(livro);
            return Ok(livroDTO);
            
        }

        [HttpPatch("{id_livro}")]
        public async Task<ActionResult<IEnumerable<Livro>>> AtualizarLivroParcial(int id_livro, [FromBody] Dictionary<string, object> campos)
        {
            var livro = await _livroRepository.SelecionarByPK(id_livro);

            if(livro == null)
            {
                return NotFound("Livro não encontrado");
            }

            foreach(var campo in campos)
            {
                switch (campo.Key)
                {
                    case "livroNome":
                        livro.LivroNome = campo.Value.ToString();
                        _livroRepository.Alterar(livro);
                        if(await _livroRepository.SaveAllAsync())
                        {
                            break;
                        }
                        else
                        {
                            return BadRequest("Erro ao alterar Livro");
                        }
                    case "livroAutor":
                        livro.LivroAutor = campo.Value.ToString();
                        _livroRepository.Alterar(livro);
                        if (await _livroRepository.SaveAllAsync())
                        {
                            break;
                        }
                        else
                        {
                            return BadRequest("Erro ao alterar Livro");
                        }
                    case "livroEditora":
                        livro.LivroEditora = campo.Value.ToString();
                        _livroRepository.Alterar(livro);
                        if (await _livroRepository.SaveAllAsync())
                        {
                            break;
                        }
                        else
                        {
                            return BadRequest("Erro ao alterar Livro");
                        }
                    case "livroAnoPublicacao":
                        livro.LivroAnoPublicacao = Convert.ToDateTime(campo.Value.ToString());
                        _livroRepository.Alterar(livro);
                        if (await _livroRepository.SaveAllAsync())
                        {
                            break;
                        }
                        else
                        {
                            return BadRequest("Erro ao alterar Livro");
                        }
                    case "livroEdicao":
                        livro.LivroEdicao = campo.Value.ToString();
                        _livroRepository.Alterar(livro);
                        if (await _livroRepository.SaveAllAsync())
                        {
                            break;
                        }
                        else
                        {
                            return BadRequest("Erro ao alterar Livro");
                        }
                    default
                        : return BadRequest($"Campo '{campo.Key}' não é permitido para atualização.");
                }
            }
            return Ok("Alterado com sucesso");
        }
    }
}
