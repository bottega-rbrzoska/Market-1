using System;
using Market.Web.Models;
using Market.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Market.Web.Pages.Products
{
    public class Details : PageModel
    {
        private readonly IProductsService _productsService;
        
        public Product Product { get; private set; }

        public Details(IProductsService productsService)
        {
            _productsService = productsService;
        }
        
        public ActionResult OnGet(Guid id)
        {
            Product = _productsService.Get(id);
            if (Product is null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}