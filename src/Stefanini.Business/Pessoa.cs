namespace Stefanini.Business
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Id_Cidade { get; set; }
        public Cidade Cidade { get; set; }
        public int Idade { get; set; }
    }
}