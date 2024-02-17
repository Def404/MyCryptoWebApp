using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PolybianSquare.Pages.Decrypt;

public class Index : PageModel
{
    [BindProperty]
    public string? EncryptedText { get; set; }
    public string? DecryptedText { get; set; }
    
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        DecryptedText = EncryptedText;
        return Page();
    }
}