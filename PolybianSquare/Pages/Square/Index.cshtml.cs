using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PolybianSquare.Services;

namespace PolybianSquare.Pages.Square;

public class Index : PageModel
{
    private ICryptService _cryptService;

    public Index(ICryptService cryptService)
    {
        _cryptService = cryptService;
    }

    [BindProperty] public string? OpenText { get; set; }
    public string? EncryptedText { get; set; }

    [BindProperty] public string? EncryptedMyText { get; set; }
    public string? DecryptedText { get; set; }


    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostEncryptAsync()
    {
        if (OpenText == null)
            return Page();

        EncryptedText = await _cryptService.Encrypted(OpenText);
        return Page();
    }

    public async Task<IActionResult> OnPostDecryptAsync()
    {
        if (EncryptedMyText == null)
            return Page();

        DecryptedText = await _cryptService.Decrypted(EncryptedMyText);
        return Page();
    }
}