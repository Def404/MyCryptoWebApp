using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PolybianSquare.Services;

namespace PolybianSquare.Pages.Encrypt;

public class Index : PageModel
{
    private ICryptService _cryptService;
    public Index(ICryptService cryptService)
    {
        _cryptService = cryptService;
    }
    [BindProperty] public string? OpenText { get; set; }
    public string? EncryptedText { get; set; }

    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (OpenText == null) 
            return Page();
        
        EncryptedText = _cryptService.Encrypted(OpenText);
        return Page();

    }
}