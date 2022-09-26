using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Business
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public ICollection<Pessoa> Pessoa { get; set; }

    }
}
