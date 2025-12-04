using System.Collections.Generic;
using System.Linq;
using GestAproAspNet.Data;
using GestAproAspNet.Models;

namespace GestAproAspNet.Services.Impl
{
    public class FournisseurService : IFournisseurService
    {
        private readonly GesApproviDbContext _context;

        public FournisseurService(GesApproviDbContext context)
        {
            _context = context;
        }

        public List<Fournisseur> GetAll()
        {
            return _context.Fournisseurs
                .OrderBy(f => f.Nom)
                .ToList();
        }

        public Fournisseur GetById(int id)
        {
            return _context.Fournisseurs.FirstOrDefault(f => f.Id == id);
        }
    }
}
