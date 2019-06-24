using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Market.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IOptionsSnapshot<AppOptions> _appOptions;

        public IndexModel(IOptionsSnapshot<AppOptions> appOptions)
        {
            _appOptions = appOptions;
        }

        public string ApplicationName => _appOptions.Value.Name;
        
        public void OnGet()
        {
            
        }
    }
}
