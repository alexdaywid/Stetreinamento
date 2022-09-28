namespace Stefanini.Api.Dto
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Id_Cidade { get; set; }
        public CidadeDto? Cidade { get; set; }
        public int Idade { get; set; }
    }
}
