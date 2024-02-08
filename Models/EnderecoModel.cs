using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFullStack.Models
{
    public class EnderecoModel
    {
        public int Id { get; set; }
        public string NomeDaRua { get; set; }
        public string NumeroDaRua { get; set; }
        public string Bairro { get; set; }
    }
}