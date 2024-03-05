using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCryptoWebApp.Services;

namespace MyCryptoWebApp.Pages.Square;

public class Index : PageModel
{
    private ISquareCryptService _squareCryptService;

    public Index(ISquareCryptService squareCryptService)
    {
        _squareCryptService = squareCryptService;
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

        EncryptedText = await _squareCryptService.Encrypted(OpenText.Trim().ToLower());
        return Page();
    }

    public async Task<IActionResult> OnPostDecryptAsync()
    {
        if (EncryptedMyText == null)
            return Page();

        DecryptedText = await _squareCryptService.Decrypted(EncryptedMyText.Trim().ToLower());
        return Page();
    }
}