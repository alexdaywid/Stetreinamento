using Stefanini.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Business.Service
{
    public class PessoaService : BaseService
    {
        public PessoaService(INotificador notificador) : base(notificador)
        {
        }
    }
}
