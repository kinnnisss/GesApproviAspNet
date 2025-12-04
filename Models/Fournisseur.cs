using System.Collections.Generic;

namespace GestAproAspNet.Models
{
    public class Fournisseur
    {
        public int Id { get; set; }

        public string Nom { get; set; } = string.Empty;

        public string? Telephone { get; set; }

        public string? Email { get; set; }

        public string? Adresse { get; set; }

        public ICollection<Approvi> Approvis { get; set; } = new List<Approvi>();
    }
}
