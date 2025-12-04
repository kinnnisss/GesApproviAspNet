namespace GestAproAspNet.Models
{
    public class TransactionApproArticle
    {
        public int Id { get; set; }

        public int Quantite { get; set; }

        public decimal PrixUnitaire { get; set; }

        public decimal Montant { get; set; }

        public int ArticleId { get; set; }
        public Article? Article { get; set; }

        
        public int ApproviId { get; set; }
        public Approvi? Approvi { get; set; }
    }
}
