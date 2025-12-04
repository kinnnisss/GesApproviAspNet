using System;
using System.Collections.Generic;
using System.Linq;
using GestAproAspNet.Data;
using GestAproAspNet.Models;
using Microsoft.EntityFrameworkCore;

namespace GestAproAspNet.Services.Impl
{
    public class ApproviService : IApproviService
    {
        private readonly GesApproviDbContext _context;

        public ApproviService(GesApproviDbContext context)
        {
            _context = context;
        }

        public List<Approvi> GetAll(string? search = null)
        {
            var query = _context.Approvis
                .Include(a => a.Fournisseur)
                .Include(a => a.Transactions)
                    .ThenInclude(t => t.Article)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(a =>
                    a.Reference.Contains(search) ||
                    (a.Fournisseur != null && a.Fournisseur.Nom.Contains(search)));
            }

            return query
                .OrderByDescending(a => a.DateApprovi)
                .ToList();
        }

        public Approvi GetById(int id)
        {
            return _context.Approvis
                .Include(a => a.Fournisseur)
                .Include(a => a.Transactions)
                    .ThenInclude(t => t.Article)
                .FirstOrDefault(a => a.Id == id);
        }

        public void CreateApprovi(Approvi approvi, int articleId, int quantity, decimal unitPrice)
        {
            
            var transaction = new TransactionApproArticle
            {
                ArticleId = articleId,
                Quantite = quantity,
                PrixUnitaire = unitPrice,
                Montant = quantity * unitPrice
            };

            approvi.TotalAmount = transaction.Montant;

            
            approvi.Transactions.Add(transaction);

          
            _context.Approvis.Add(approvi);
            _context.SaveChanges();
        }
    }
}
