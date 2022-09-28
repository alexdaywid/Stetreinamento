using Stefanini.Business.Interface;
using Stefanini.Business.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Business.Service
{
    public class CidadeService : BaseService , ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IPessoaRepository _pessoaRepository;
        public CidadeService(ICidadeRepository cidadeRepository, IPessoaRepository pessoaRepository, INotificador notificador) : base(notificador)
        {
            _cidadeRepository = cidadeRepository;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<bool> Atualizar(Cidade cidade)
        {
            if (!ExecutarValidacao(new CidadeValidator(), cidade)) return false;

            await _cidadeRepository.Update(cidade);
            return true;
        }

        public async Task<bool> Criar(Cidade cidade)
        {
            if (!ExecutarValidacao(new CidadeValidator(), cidade)) return false;

            await _cidadeRepository.Create(cidade);
            return true;
        }

        public void Dispose()
        {
            _cidadeRepository.Dispose();
        }

        public async Task<bool> Excluir(Cidade cidade)
        {
            if (!ExecutarValidacao(new CidadeValidator(), cidade)) return false;

            if(_pessoaRepository.GetAll().Result.Where(p=>p.Id_Cidade == cidade.Id).Any())
            {
                Notificar("Endereço associado a uma pessoa não é possivel excluir");
                return false;
            }
            await _cidadeRepository.Delete(cidade);
            return true;
        }
    }
}
