using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Business.Interface
{
    public interface IPessoaService : IDisposable
    {
        Task<bool> Criar(Pessoa pessoa);
        Task<bool> Atualizar(Pessoa pessoa);
        Task<bool> Excluir(Pessoa pessoa);
    }
}
