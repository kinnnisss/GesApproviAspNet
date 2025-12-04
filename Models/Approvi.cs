using System;
using System.Collections.Generic;

namespace GestAproAspNet.Models
{
    public class Approvi
    {
        public int Id { get; set; }

        public string Reference { get; set; } = string.Empty;

        public DateTime DateApprovi { get; set; }

        public string? Observations { get; set; }

        public decimal TotalAmount { get; set; }

        public StatutApprovi Statut { get; set; } = StatutApprovi.EnAttente;

        public int FournisseurId { get; set; }
        public Fournisseur? Fournisseur { get; set; }

        public ICollection<TransactionApproArticle> Transactions { get; set; }
            = new List<TransactionApproArticle>();
    }
}
