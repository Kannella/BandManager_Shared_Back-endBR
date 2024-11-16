using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BandManager.Api.Resources.Models
{
    public class Availability : Entity
    {
        // Data em que o usuário não está disponível
        public DateTime AvailabilityDate { get; set; }

        // Chave estrangeira que relaciona a disponibilidade com o usuário (músico)
        public int UserId { get; set; }

        // Referência de navegação para o usuário
        [ForeignKey("UserId")]
        [JsonIgnore]  // Ignora a propriedade User na deserialização JSON
        public User? User { get; set; } = null!;
    }
}
