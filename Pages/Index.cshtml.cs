using LocalHomepage.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Text.Json;

namespace LocalHomepage.Pages
{
    public class IndexModel : PageModel
    {
        private static readonly string NavListPath = "./nav.json";

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (!Path.Exists(NavListPath))
            {
                _logger.LogWarning("{NavListPath} not found, try create one.", NavListPath);

                var url = $"http://{Request.Host}";

                var tempItems = new List<NavigationItem>
                {
                    new()
                    {
                        Header = "LocalHomepage",
                        Title = "LocalHomepage",
                        Url = url,
                        Description = string.Empty,
                    }
                };

                var json = JsonSerializer.Serialize(tempItems) ?? string.Empty;

                System.IO.File.WriteAllText(NavListPath, json);
            }

            var content = System.IO.File.ReadAllText(NavListPath);
            var items = JsonSerializer.Deserialize<IList<NavigationItem>>(content);

            if (items == null)
            {
                _logger.LogWarning("{NavListPath} file is invalid, cannot be deserialized.", NavListPath);
            }
            else
            {
                ViewData["NavItems"] = items;
            }
        }
    }
}
