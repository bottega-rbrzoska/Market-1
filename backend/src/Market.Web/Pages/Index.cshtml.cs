using Market.Infrastructure;
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
