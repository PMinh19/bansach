//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.Google;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;

//[Route("api/[controller]")]
//[ApiController]
//public class LoginController : ControllerBase
//{
//    [HttpGet("google")]
//    public IActionResult LoginByGoogle()
//    {
//        var authenticationProperties = new AuthenticationProperties
//        {
//            RedirectUri = Url.Action("GoogleResponse", "Login")
//        };
//        return Challenge(authenticationProperties, GoogleDefaults.AuthenticationScheme);
//    }

//    [HttpGet("google/callback")]
//    public async Task<IActionResult> GoogleResponse()
//    {
//        var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

//        if (!authenticateResult.Succeeded || authenticateResult.Principal == null)
//        {
//            return Unauthorized(new { message = "Google authentication failed." });
//        }

 
//        var claims = authenticateResult.Principal.Identities.FirstOrDefault()?.Claims
//            .Select(claim => new
//            {
//                claim.Issuer,
//                claim.Type,
//                claim.Value
//            });

//        return Ok(new
//        {
//            message = "Đăng nhập Google thành công!",
//            userClaims = claims
//        });
//    }
//}
