using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AT.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Senha { get; set; }

        [BindProperty]
        public string? Mensagem { get; set; }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string validEmail = "admin@admin.com";
            string validSenha = "Admin1234";

            if (Email == validEmail && Senha == validSenha)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Email)
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", principal);

                return RedirectToPage("/Pacotes/Index");
            }

            Mensagem = "Email ou senha inválidos.";
            return Page();
        }
    }
}
