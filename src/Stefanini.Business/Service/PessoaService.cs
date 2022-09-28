using Stefanini.Business.Interface;
using Stefanini.Business.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Business.Service
{
    public class PessoaService : BaseService, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        public PessoaService(IPessoaRepository pessoaRepository, INotificador notificador) : base(notificador)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<bool> Atualizar(Pessoa pessoa)
        {
            if (!ExecutarValidacao(new PessoaValidator(), pessoa)) return false;

            await _pessoaRepository.Update(pessoa);
            return true;
        }

        public async Task<bool> Criar(Pessoa pessoa)
        {
            if (!ExecutarValidacao(new PessoaValidator(), pessoa)) return false;

            if (_pessoaRepository.Find(p => p.CPF == pessoa.CPF).Result.Any())
            {
                Notificar("Já existe uma pessoa com este CPF informado.");
                return false;
            }

            await _pessoaRepository.Create(pessoa);
            return true;
        }

        public async Task<bool> Excluir(Pessoa pessoa)
        {
            await _pessoaRepository.Delete(pessoa);
            return true;
        }

        public void Dispose()
        {
            _pessoaRepository.Dispose();
        }     
    }
}
