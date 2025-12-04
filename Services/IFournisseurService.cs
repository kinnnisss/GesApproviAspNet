using System.Collections.Generic;
using GestAproAspNet.Models;

namespace GestAproAspNet.Services
{
    public interface IFournisseurService
    {
        List<Fournisseur> GetAll();
        Fournisseur GetById(int id);
    }
}
