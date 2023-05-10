using Microsoft.AspNetCore.Mvc;
using VKBackendInternship.Domain.Abstractions.IRepository;
using VKBackendInternship.Domain.DataTransferObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VKBackendInternship.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        // Логины, которые проходят создание, добавляются в список.
        // Всместо него можно создать отдельную таблицу в БД,
        //  куда будут временно записываться логины пользователей.
        private List<string> queue = new List<string>();

        public UserController(IUserService service) 
        { 
            _service = service;
        }
        [HttpPost("create-user")]
        public async Task<ActionResult<string>> CreateUser([FromBody] UserRegistrationRequest request)
        {
            // Проверяем, используется ли логин в создании в данный момент
            if (queue.Where(login => login == request.Login).Count() > 0)
            {
                return BadRequest("Ошибка при создании пользователя");
            }
            // Перед началом создания добавляем логин в список
            queue.Add(request.Login);

            var responce = await _service.CreateUser(request);
            // После создания удаляем из списка
            queue.Remove(request.Login);

            if (responce.Errors.Count == 0)
                return Ok("Пользователь успешно создан");
            return BadRequest(responce.Errors);
        }

        [HttpGet("get-users")]
        public async Task<ActionResult<PaginationList<UserData>>> Get(int page, int size)
        {
            var result = await _service.GetUsers(page, size);
            if(result.Errors.Count == 0)
                return Ok(result.Data);
            return BadRequest(result.Errors);
        }
        [HttpGet("get-user")]
        public async Task<ActionResult<UserData>> Get(string login)
        {
            var result = await _service.GetUser(login);
            if (result.Errors.Count == 0)
                return Ok(result.Data);
            return BadRequest(result.Errors);
        }
        [HttpPut("block-user")]
        public async Task<ActionResult<string>> Put(string login)
        {
            var result = await _service.DeleteUser(login);
            if (result.Errors.Count == 0)
                return Ok("Пользователь заблокирован");
            return BadRequest(result.Errors);
        }
    }
}
