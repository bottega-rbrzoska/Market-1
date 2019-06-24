using System;
using System.Collections.Generic;
using Market.Web.Models;
using Market.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Market.Web.Pages.Products
{
    public class Index : PageModel
    {
        private readonly IProductsService _productsService;
        
        public IEnumerable<Product> Products { get; private set; }

        public Index(IProductsService productsService)
        {
            _productsService = productsService;
        }
        
        public void OnGet()
        {
            Products = _productsService.Browse();
        }

        public ActionResult OnPostDelete(Guid id)
        {
            _productsService.Delete(id);

            return RedirectToAction(nameof(OnGet));
        }
    }
}