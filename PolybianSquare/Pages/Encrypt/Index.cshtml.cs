using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PolybianSquare.Pages.Encrypt;

public class Index : PageModel
{
    [BindProperty] public string? OpenText { get; set; }
    public string? EncryptedText { get; set; }

    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {

        EncryptedText = OpenText;
        return Page();
    }
}