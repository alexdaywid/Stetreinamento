using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Business.Validation
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(p => p.Nome).NotEmpty().WithMessage("Nome é obrigatório.");
        }

    }
}
