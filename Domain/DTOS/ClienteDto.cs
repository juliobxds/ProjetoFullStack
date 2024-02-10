﻿namespace ProjetoFullStack.Domain.DTOS {
    public class ClienteDto {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public int EnderecoDtoId { get; set; }
        public EnderecoDto EnderecoDto { get; set; }
    }
}
