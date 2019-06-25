using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Market.Application;
using Market.Application.Products.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Market.Web.Pages.Products
{
    public class Create : PageModel
    {
        private readonly IDispatcher _dispatcher;

        [Required(ErrorMessage = "Missing name")]
        [StringLength(50, MinimumLength = 3)]
        [BindProperty]
        public string Name { get; set; }

        [Required] [BindProperty] public string Category { get; set; }

        [Required(ErrorMessage = "Missing description")]
        [StringLength(500, MinimumLength = 3)]
        [BindProperty]
        public string Description { get; set; }

        [Required]
        [Range(1, 1000000)]
        [BindProperty]
        public decimal Price { get; set; }

        public List<SelectListItem> Categories { get; } =
            new List<SelectListItem>
            {
                new SelectListItem {Text = "Phones", Value = "Phones"},
                new SelectListItem {Text = "Notebooks", Value = "Notebooks"},
                new SelectListItem {Text = "Tablets", Value = "Tablets"}
            };

        public Create(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(OnGet));
            }

            var id = Guid.NewGuid();
            await _dispatcher.SendAsync(new CreateProduct(id, Name, Category, Description, Price));

            return RedirectToPage("./Index");
        }
    }
}