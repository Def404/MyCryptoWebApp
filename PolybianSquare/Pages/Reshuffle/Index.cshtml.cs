using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PolybianSquare.Services;

namespace PolybianSquare.Pages.Reshuffle;

public class Index : PageModel
{
	private IReshuffleCryptService _reshuffleCryptService;

	public Index(IReshuffleCryptService reshuffleCryptService)
	{
		_reshuffleCryptService = reshuffleCryptService;
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

		EncryptedText = await _reshuffleCryptService.Encrypted(OpenText.Trim().ToLower());
		
		return Page();
	}

	public async Task<IActionResult> OnPostDecryptAsync()
	{
		if (EncryptedMyText == null)
			return Page();

		DecryptedText = await _reshuffleCryptService.Decrypted(EncryptedMyText.Trim().ToLower());
		
		return Page();
	}
}