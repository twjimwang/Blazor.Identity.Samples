using BlazorServer.Identity.Models;
using BlazorServer.Identity.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserService _userService;
    public LoginModel(IHttpContextAccessor httpContextAccessor, IUserService userService)
    {
        _httpContextAccessor = httpContextAccessor;
        _userService = userService;
    }

    [BindProperty]
    public LoginDto LoginDto { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            return Redirect("/");
        }
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        await _userService.LoginAsync(LoginDto);
        return Redirect("/");
    }

}