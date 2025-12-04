using System;
using System.ComponentModel.DataAnnotations;

namespace GestAproAspNet.Models
{
    public class ApproviCreateViewModel
    {
        public Approvi Approvi { get; set; } = new Approvi
        {
            DateApprovi = DateTime.Today,
            Statut = StatutApprovi.EnAttente
        };

        
        [Required]
        public int ArticleId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }
    }
}
