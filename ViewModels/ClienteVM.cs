namespace ProjetoFullStack.ViewModels {
    public class ClienteVM {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public virtual EnderecoVM Endereco { get; set; }
    }
}
