namespace ProjetoFullStack.Domain.DTOS {
    public class EnderecoDto {

        public int Id { get; set; }
        public string NomeDaRua { get; set; }
        public string NumeroDaRua { get; set; }
        public string Bairro { get; set; }
        public int ClienteDtoId { get; set; }
    }
}
