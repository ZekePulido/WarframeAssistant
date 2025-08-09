using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly WfcdService _wfcdService;

    public HomeController(ILogger<HomeController> logger, WfcdService wfcdService)
    {
        _logger = logger;
        _wfcdService = wfcdService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public async Task<IActionResult> Mods(string search)
    {
        var categoryName = "Mods";
        var items = await _wfcdService.GetItemsByCategoryAsync(categoryName);

        if (!string.IsNullOrEmpty(search))
        {
            items = items
                .Where(item => item.Name != null && item.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        var model = new Dictionary<string, List<WarframeItem>>
        {
            { categoryName, items }
        };

        ViewData["Search"] = search;
        return View(model);
    }

    
    public async Task<IActionResult> Relics(string search)
    {
        ViewData["Search"] = search;

        var items = await _wfcdService.GetItemsByCategoryAsync("Relics");

        if (!string.IsNullOrEmpty(search))
        {
            items = items
                .Where(item => 
                    (item.Name != null && item.Name.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                    (item.Rewards != null && item.Rewards.Any(r => 
                        r.Item != null && 
                        r.Item.Name != null && 
                        r.Item.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
                    ))
                )
                .ToList();
        }

        var model = new Dictionary<string, List<WarframeItem>>
        {
            { "Relics", items }
        };

        return View(model);
    }


}
