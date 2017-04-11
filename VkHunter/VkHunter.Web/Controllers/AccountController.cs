using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using VkHunter.Common.Helpers;
using VkHunter.Domain.Entities;
using VkHunter.DTO;
using VkHunter.Web.Constants;

namespace VkHunter.Web.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : BaseController
    {
        public AccountController()
        { }

        /// <summary>
        /// Регистрирует нового пользователя
        /// </summary>
        /// <param name="request">Объект с логином и паролем нового пользователя</param>
        /// <returns>Результат регистрации</returns>
        [Authorize]
        [Route("register")]
        [ResponseType(typeof(RegisterRequestDTO))]
        public async Task<IHttpActionResult> PostRegister(RegisterRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                Email = request.UserName,
                UserName = request.UserName
            };

            var result = await UserManager.CreateAsync(user, request.Password);
            return Ok(result);
        }

        /// <summary>
        /// Возвращает токен авторизации
        /// </summary>
        /// <remarks>
        /// Для варианта, когда кроме токена, будет необходимо в ответе вернуть доп инфу о пользователе.
        /// </remarks>
        [AllowAnonymous]
        [Route("login")]
        [ResponseType(typeof(LoginRequestDTO))]
        public async Task<IHttpActionResult> PostLogin(LoginRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", ErrorMessage.IncorrectParameters);
                return BadRequest(ModelState);
            }

            using (var client = HttpHelper.Create())
            {
                var requestParams = new Dictionary<string, string>
                {
                    { "grant_type", "password" },
                    { "username", request.UserName },
                    { "password", request.Password }
                };

                var content = new FormUrlEncodedContent(requestParams);

                var response = await client.PostAsync(@"api/token", content);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return BadRequest(response.StatusCode.ToString());
                }

                var responseData = await response.Content.ReadAsAsync<Dictionary<string, string>>();
                var authToken = responseData["access_token"];

                var responseDTO = new LoginResponseDTO
                {
                    Token = authToken,

                    // Здесь можно добавить дополнительные поля для информации о пользователе
                };

                return Ok(responseDTO);
            }
        }
    }
}
