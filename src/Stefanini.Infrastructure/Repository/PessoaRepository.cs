using Microsoft.EntityFrameworkCore;
using Stefanini.Business;
using Stefanini.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Infrastructure.Repository
{
    public class PessoaRepository : EFRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(SteContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await _context.Pessoa
                .AsNoTracking()
                .Include(p => p.Cidade)
                .ToListAsync();
        }

        public override async Task<Pessoa> GetId(int Id)
        {
            return await _context.Pessoa
                .AsNoTracking()
                .Include(p => p.Cidade)
                .FirstOrDefaultAsync(p=>p.Id == Id);
        }
    }
}
