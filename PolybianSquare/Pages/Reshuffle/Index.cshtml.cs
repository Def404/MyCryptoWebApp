using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PolybianSquare.Pages.Reshuffle;

public class Index : PageModel
{
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
		
		return Page();
	}

	public async Task<IActionResult> OnPostDecryptAsync()
	{
		if (EncryptedMyText == null)
			return Page();
		
		
		return Page();
	}
}