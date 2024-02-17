using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PolybianSquare.Services;

namespace PolybianSquare.Pages.Decrypt;

public class Index : PageModel
{
    private ICryptService _cryptService;
    public Index(ICryptService cryptService)
    {
        _cryptService = cryptService;
    }

    [BindProperty]
    public string? EncryptedText { get; set; }
    public string? DecryptedText { get; set; }
    
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (EncryptedText == null)
            return Page();
        
        DecryptedText = await _cryptService.Decrypted(EncryptedText);
        return Page();
    }
}