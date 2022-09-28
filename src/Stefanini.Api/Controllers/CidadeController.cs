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
    public class CidadeController : MainController
    {
        public readonly ICidadeRepository _cidadeRepository;
        public readonly ICidadeService _cidadeService;
        private readonly IMapper _mapper;

        public CidadeController(ICidadeRepository cidadeRepository, ICidadeService cidadeService, IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _cidadeRepository = cidadeRepository;
            _cidadeService = cidadeService;
            _mapper = mapper;
        }
        // GET: CidadeController
        [HttpGet]
        public async Task<IEnumerable<CidadeDto>> ObterTodos()
        {
            var cidade = await _cidadeRepository.GetAll();
            return _mapper.Map<IEnumerable<CidadeDto>>(cidade);

        }
       
        // GET api/<CidadeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CidadeDto>> ObterPorId(int id)
        {
            var cidade = await _cidadeRepository.GetId(id);

            if (cidade == null) {
                NotificarErro("Cidade não encontrada");
                return CustomResponseNotFound();
            } 
            return Ok(_mapper.Map<CidadeDto>(cidade));
        }

        // POST api/<CidadeController>
        [HttpPost]
        public async Task<ActionResult<CidadeDto>> Criar(CidadeDto cidadeDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cidadeService.Criar(_mapper.Map<Cidade>(cidadeDto));

            return CustomResponse("Criado com sucesso");
        }

        // PUT api/<CidadeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CidadeDto>>Atualizar(int id, CidadeDto cidadeDto)
        {
            if (id != cidadeDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cidadeService.Atualizar(_mapper.Map<Cidade>(cidadeDto));

            return CustomResponse("Atualizado com sucesso");
        }

        // DELETE api/<CidadeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(int id )
        {
            var cidade = await _cidadeRepository.GetId(id);

            if (cidade == null)
            {
                NotificarErro("Cidade não encontrada");
                return CustomResponseNotFound();
            }

            await _cidadeService.Excluir(cidade);

            return CustomResponse("Cidade excluído com sucesso");
        }
    }
}
