using System.Collections.Generic;
using GestAproAspNet.Models;

namespace GestAproAspNet.Services
{
    public interface IApproviService
    {
        List<Approvi> GetAll(string? search = null);
        Approvi GetById(int id);

        
        void CreateApprovi(Approvi approvi, int articleId, int quantity, decimal unitPrice);
    }
}
