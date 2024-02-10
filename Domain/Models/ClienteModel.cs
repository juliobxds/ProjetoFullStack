namespace ProjetoFullStack.Domain.Models {
    public class ClienteModel {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public int EnderecoModelId { get; set; }
        public virtual EnderecoModel Endereco { get; set; }

    }
}