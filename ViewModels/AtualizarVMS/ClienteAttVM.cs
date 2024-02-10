namespace ProjetoFullStack.ViewModels.AtualizarVMS {
    public class ClienteAttVM {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public virtual EnderecoAttVM Endereco { get; set; }
    }
}
