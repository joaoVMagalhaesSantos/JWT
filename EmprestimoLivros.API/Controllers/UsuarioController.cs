using AutoMapper;
using EmprestimoLivros.API.DTOs;
using EmprestimoLivros.API.Interfaces;
using EmprestimoLivros.API.Models;
using EmprestimoLivros.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticate _authenticate;

        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper, IAuthenticate authenticate)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _authenticate = authenticate;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> IncluirUser(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest("Dados invalidos");
            }

            var emailExiste = await _authenticate.UserExist(usuarioDTO.Email);
            if (emailExiste)
            {
                return BadRequest("Esse email ja possui um cadastro");
            }

            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            if (usuarioDTO.Password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioDTO.Password));
                byte[] passwordSalt = hmac.Key;

                usuario.AlterarSenha(passwordHash, passwordSalt);
            }

            _usuarioRepository.Incluir(usuario);

            if (await _usuarioRepository.SaveAllAsync())
            {
                var token = _authenticate.GenerateToken(usuario.Id, usuario.Email);

                return new UserToken
                {
                    Token = token
                };
            }
            else
            {
                return BadRequest("Erro ao cadastrar Cliente");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Selecionar(Login login)
        {
            var existe = await _authenticate.UserExist(login.Email.ToLower());
            if (!existe)
            {
                return Unauthorized("Usuario não existe");
            }

            var result = await _authenticate.AuthenticateAsync(login.Email,login.Password);
            if (!result)
            {
                return Unauthorized("Usuario ou senha invalido");
            }

            var usuario = await _authenticate.GetUserByEmail(login.Email);

            var token = _authenticate.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken
            {
                Token = token
            };
        }


        /*
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAll();
            var usuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);

            return Ok(usuariosDTO);
        }
        
         [HttpPost]
        public async Task<ActionResult> CadastrarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            _usuarioRepository.Incluir(usuario);

            if (await _usuarioRepository.SaveAllAsync())
            {
                return Ok("Cliente cadastrado com sucesso");
            }
            else
            {
                return BadRequest("Erro ao cadastrar Cliente");
            }
        }

        [HttpPut]
        public async Task<ActionResult> AlterarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            _usuarioRepository.Alterar(usuario);

            if (await _usuarioRepository.SaveAllAsync())
            {
                return Ok("Cliente alterado com sucesso");
            }
            else
            {
                return BadRequest("Erro ao alterar o Cliente");
            }
        }

        [HttpDelete("{id_usuario}")]
        public async Task<ActionResult> ExcluirUsuario(int id_usuario)
        {
            var usuario = await _usuarioRepository.SelecionarByPk(id_usuario);

            if (usuario == null)
            {
                return NotFound("Cliente não encontrado");
            }

            _usuarioRepository.Excluir(usuario);

            if (await _usuarioRepository.SaveAllAsync())
            {
                return Ok("Cliente excluido com sucesso");
            }
            else
            {
                return BadRequest("Erro ao excluir o Cliente");
            }
        }

        [HttpGet("{id_usuario}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> SelecionarUsuarioPorID(int id_usuario)
        {
            var usuario = await _usuarioRepository.SelecionarByPk(id_usuario);

            if (usuario == null)
            {
                return NotFound("Cliente não encontrado");
            }

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);

            return Ok(usuarioDTO);
        }
         */

    }
}
