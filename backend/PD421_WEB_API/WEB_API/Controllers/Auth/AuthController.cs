using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB_API.BLL.Dtos.Auth;
using WEB_API.BLL.Services.Auth;
using WEB_API.DAL.Entities.Identity;

namespace WEB_API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<UserEntity> userManager,
    IJWTTokenService tokenService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return Ok(new TokenDTO());

            var isValidPassword = await userManager
                .CheckPasswordAsync(user, model.Password);
            if (!isValidPassword)
                return Ok(new TokenDTO());

            user.IsDeleted = false;
            await userManager.UpdateAsync(user);
            var result = await tokenService.CreateTokenAsync(user);

            return Ok(result);
        }
    }
}
