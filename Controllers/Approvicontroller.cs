using GestAproAspNet.Models;
using GestAproAspNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestAproAspNet.Controllers
{
    public class ApproviController : Controller
    {
        private readonly IApproviService _approviService;
        private readonly IArticleService _articleService;
        private readonly IFournisseurService _fournisseurService;

        public ApproviController(
            IApproviService approviService,
            IArticleService articleService,
            IFournisseurService fournisseurService)
        {
            _approviService = approviService;
            _articleService = articleService;
            _fournisseurService = fournisseurService;
        }

    
        public IActionResult Index(string? search)
        {
            var approvis = _approviService.GetAll(search);
            return View(approvis);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            LoadDropDowns();

            var vm = new ApproviCreateViewModel();
            return View(vm);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApproviCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                LoadDropDowns();
                return View(model);
            }

            _approviService.CreateApprovi(
                model.Approvi,
                model.ArticleId,
                model.Quantity,
                model.UnitPrice
            );

            return RedirectToAction(nameof(Index));
        }

     
        private void LoadDropDowns()
        {
            ViewBag.Fournisseurs = _fournisseurService.GetAll();
            ViewBag.Articles = _articleService.GetAll();
        }
    }
}
