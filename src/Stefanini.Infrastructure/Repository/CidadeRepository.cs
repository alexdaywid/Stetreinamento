using Stefanini.Business;
using Stefanini.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Infrastructure.Repository
{
    public class CidadeRepository : EFRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(SteContext context) : base(context)
        {
        }
    }
}
