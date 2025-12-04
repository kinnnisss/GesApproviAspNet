using System.Collections.Generic;
using GestAproAspNet.Models;

namespace GestAproAspNet.Services
{
    public interface IArticleService
    {
        List<Article> GetAll();
        Article GetById(int id);
    }
}
