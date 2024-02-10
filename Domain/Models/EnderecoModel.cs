namespace ProjetoFullStack.Domain.Models {
    public class EnderecoModel {
        public int Id { get; set; }
        public string NomeDaRua { get; set; }
        public string NumeroDaRua { get; set; }
        public string Bairro { get; set; }
        public int ClienteModelId { get; set; }
        public virtual ClienteModel Cliente { get; set; } 
    }
}