using System.Collections.Generic;

namespace GestAproAspNet.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Libelle { get; set; } = string.Empty;

        public string? Code { get; set; }

        public decimal? PrixDefaut { get; set; }

        public ICollection<TransactionApproArticle> Transactions { get; set; }
            = new List<TransactionApproArticle>();
    }
}
