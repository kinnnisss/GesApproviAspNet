using System.Collections.Generic;
using System.Linq;
using GestAproAspNet.Data;
using GestAproAspNet.Models;

namespace GestAproAspNet.Services.Impl
{
    public class ArticleService : IArticleService
    {
        private readonly GesApproviDbContext _context;

        public ArticleService(GesApproviDbContext context)
        {
            _context = context;
        }

        public List<Article> GetAll()
        {
            return _context.Articles
                .OrderBy(a => a.Libelle)
                .ToList();
        }

        public Article GetById(int id)
        {
            return _context.Articles.FirstOrDefault(a => a.Id == id);
        }
    }
}
