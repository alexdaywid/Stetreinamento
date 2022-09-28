using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Stefanini.Api.Dto;
using Stefanini.Business;
using Stefanini.Business.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stefanini.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : MainController
    {
        public readonly IPessoaRepository _pessoaRepository;
        public readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaRepository pessoaRepository, IPessoaService pessoaService, IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaService = pessoaService;
            _mapper = mapper;
        }
        // GET: CidadeController
        [HttpGet]
        public async Task<IEnumerable<PessoaDto>> ObterTodos()
        {
            var pessoa = await _pessoaRepository.GetAll();
            return _mapper.Map<IEnumerable<PessoaDto>>(pessoa);

        }
       
        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaDto>> ObterPorId(int id)
        {
            var pessoa = await _pessoaRepository.GetId(id);

            if (pessoa == null) {
                NotificarErro("Pessoa não encontrada");
                return CustomResponseNotFound();
            } 
            return Ok(_mapper.Map<PessoaDto>(pessoa));
        }

        // POST api/<PessoaController>
        [HttpPost]
        public async Task<ActionResult<PessoaDto>> Criar(PessoaDto pessoaDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pessoaService.Criar(_mapper.Map<Pessoa>(pessoaDto));

            return CustomResponse("Criado com sucesso");
        }

        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaDto>>Atualizar(int id, PessoaDto pessoaDto)
        {
            if (id != pessoaDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(pessoaDto);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pessoaService.Atualizar(_mapper.Map<Pessoa>(pessoaDto));

            return CustomResponse("Atualizado com sucesso.");
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(int id )
        {
            var pessoa = await _pessoaRepository.GetId(id);

            if (pessoa == null)
            {
                NotificarErro("Pessoa não encontrada");
                return CustomResponseNotFound();
            }

            await _pessoaService.Excluir(pessoa);

            return CustomResponse("Pessoa excluído com sucesso");
        }
    }
}
