using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Business.Interface
{
    public interface ICidadeService : IDisposable
    {
        Task<bool> Criar(Cidade cidade);
        Task<bool> Atualizar(Cidade cidade);
        Task<bool> Excluir(Cidade cidade);
    }
}
