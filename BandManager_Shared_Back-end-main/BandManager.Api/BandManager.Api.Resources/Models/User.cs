using System.ComponentModel.DataAnnotations.Schema;

namespace BandManager.Api.Resources.Models
{
    public class User : Entity
    {
        public int BandUserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Enums.RoleTypes Role { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public bool HasCar { get; set; }
        public string HomeAdress { get; set; } = null!;
        public virtual List<Band>? Bands { get; set; }
    }

}
