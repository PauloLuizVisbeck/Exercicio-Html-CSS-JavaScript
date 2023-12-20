using System.ComponentModel.DataAnnotations;

namespace AulaEntity.Models
{
    public class Compromisso
    {
        public int Id { get; set; }
        public int LocalId { get; set; }
        public Local Local { get; set; }
        public int ContatoId { get; set; }
        public Contato Contato { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
    }
}
