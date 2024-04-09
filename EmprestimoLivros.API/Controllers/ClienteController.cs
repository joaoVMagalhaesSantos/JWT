using AutoMapper;
using EmprestimoLivros.API.DTOs;
using EmprestimoLivros.API.Interfaces;
using EmprestimoLivros.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteRepository.GetAll();
            var clientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);

            return Ok(clientesDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarCliente(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            _clienteRepository.Incluir(cliente);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente cadastrado com sucesso");
            }
            else
            {
                return BadRequest("Erro ao cadastrar Cliente");
            }
        }

        [HttpPut]
        public async Task<ActionResult> AlterarCliente(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);

            _clienteRepository.Alterar(cliente);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente alterado com sucesso");
            }
            else
            {
                return BadRequest("Erro ao alterar o Cliente");
            }
        }

        [HttpDelete("{id_cliente}")]
        public async Task<ActionResult> ExcluirCliente(int id_cliente)
        {
            var cliente = await _clienteRepository.SelecionarByPk(id_cliente);
            
            if(cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }
            
            _clienteRepository.Excluir(cliente);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente excluido com sucesso");
            }
            else
            {
                return BadRequest("Erro ao excluir o Cliente");
            }
        }

        [HttpGet("{id_cliente}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> SelecionarClientePorID(int id_cliente)
        {
            var cliente = await _clienteRepository.SelecionarByPk(id_cliente);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);

            return Ok(clienteDTO);
        }

        [HttpPatch("{id_cliente}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> AtualizarClienteParcial(int id_cliente, [FromBody] Dictionary<string, object> campos)
        {
            Cliente cliente = await _clienteRepository.SelecionarByPk(id_cliente);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }
            
            foreach(var campo in campos)
            {
                switch(campo.Key) 
                {
                    case "cliNome":

                        cliente.CliNome = campo.Value.ToString();
                        _clienteRepository.Alterar(cliente);
                        if (await _clienteRepository.SaveAllAsync())
                        {
                            break;
                        }
                        else
                        {
                            return BadRequest("Erro ao alterar o Cliente");
                        }
                        
                    case "cliEndereco":
                        cliente.CliEndereco = campo.Value.ToString();
                        _clienteRepository.Alterar(cliente);
                        if (await _clienteRepository.SaveAllAsync())
                        {
                            break;
                        }
                        else
                        {
                            return BadRequest("Erro ao alterar o Cliente");
                        }
                    case "cliCidade":
                        cliente.CliCidade = campo.Value.ToString();
                        _clienteRepository.Alterar(cliente);
                        if (await _clienteRepository.SaveAllAsync())
                        {
                            break;
                        }
                        else
                        {
                            return BadRequest("Erro ao alterar o Cliente");
                        }
                    case "cliBairro":
                        cliente.CliBairro = campo.Value.ToString();
                        _clienteRepository.Alterar(cliente);
                        if (await _clienteRepository.SaveAllAsync())
                        {
                            break;
                        }
                        else
                        {
                            return BadRequest("Erro ao alterar o Cliente");
                        }
                    case "cliNumero":
                        cliente.CliNumero = campo.Value.ToString();
                        _clienteRepository.Alterar(cliente);
                        if (await _clienteRepository.SaveAllAsync())
                        {
                            break;
                        }
                        else
                        {
                            return BadRequest("Erro ao alterar o Cliente");
                        }
                    case "cliTelefoneCelular":
                        cliente.CliTelefoneCelular = campo.Value.ToString();
                        _clienteRepository.Alterar(cliente);
                        if (await _clienteRepository.SaveAllAsync())
                        {
                            break;
                        }
                        else
                        {
                            return BadRequest("Erro ao alterar o Cliente");
                        }
                    case "cliTelefoneFixo":
                        cliente.CliTelefoneFixo = campo.Value.ToString();
                        _clienteRepository.Alterar(cliente);
                        if (await _clienteRepository.SaveAllAsync())
                        {
                            break;
                        }
                        else
                        {
                            return BadRequest("Erro ao alterar o Cliente");
                        }
                    case "cliInativo":
                        cliente.CliInativo = Convert.ToInt32(campo.Value.ToString());
                        _clienteRepository.Alterar(cliente);
                        if (await _clienteRepository.SaveAllAsync())
                        {
                            break;
                        }
                        else
                        {
                            return BadRequest("Erro ao alterar o Cliente");
                        }
                    default
                        : return BadRequest($"Campo '{campo.Key}' não é permitido para atualização.");

                }
            }
            return Ok("Alterado com sucesso");

        }
    }
}
