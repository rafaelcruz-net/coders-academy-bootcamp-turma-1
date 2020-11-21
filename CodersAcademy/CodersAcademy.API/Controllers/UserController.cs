using AutoMapper;
using CodersAcademy.API.Model;
using CodersAcademy.API.Repository;
using CodersAcademy.API.ViewModel.Request;
using CodersAcademy.API.ViewModel.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository UserRepository { get; set; }
        private IMapper Mapper { get; set; }
        private AlbumRepository AlbumRepository { get; set; }

        public UserController(UserRepository userRepository, IMapper mapper, AlbumRepository albumRepository)
        {
            this.UserRepository = userRepository;
            Mapper = mapper;
            AlbumRepository = albumRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await this.UserRepository.GetUserAsync(id);

            if (user == null)
                return NotFound();

            var result = this.Mapper.Map<UserResponse>(user);

            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await this.UserRepository.GetAllAsync();

            var result = this.Mapper.Map<List<UserResponse>>(users);

            return Ok(result);

        }


        [HttpPost("authenticate")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var password = Convert.ToBase64String(Encoding.UTF8.GetBytes(request.Password));
            var user = await this.UserRepository.AuthenticateAsync(request.Email, password);

            if (user == null)
            {
                return Unauthorized(new
                {
                    Message = "Email/Senha inválidos"
                });
            }

            var result = this.Mapper.Map<UserResponse>(user);

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var user = this.Mapper.Map<User>(request);

            user.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Password));
            user.Photo = $"https://robohash.org/{Guid.NewGuid()}.png?bgset=any";

            await this.UserRepository.CreateAsync(user);

            var result = this.Mapper.Map<UserResponse>(user);

            return Created($"{result.Id}", result);
        }

        [HttpPost("{id}/favorite-music/{musicId}")]
        public async Task<IActionResult> SaveUserFavoriteMusic(Guid id, Guid musicId)
        {
            var music = await this.AlbumRepository.GetMusicAsync(musicId);

            var user = await this.UserRepository.GetUserAsync(id);

            if (user == null)
                return UnprocessableEntity(new { Message = "User not found" });

            if (music == null)
                return UnprocessableEntity(new { Message = "Music not found" });

            user.AddFavoriteMusic(music);

            await this.UserRepository.UpdateAsync(user);

            return Ok();

        }


        [HttpDelete("{id}/favorite-music/{musicId}")]
        public async Task<IActionResult> RemoveUserFavoriteMusic(Guid id, Guid musicId)
        {
            var music = await this.AlbumRepository.GetMusicAsync(musicId);

            var user = await this.UserRepository.GetUserAsync(id);

            if (user == null)
                return UnprocessableEntity(new { Message = "User not found" });

            if (music == null)
                return UnprocessableEntity(new { Message = "Music not found" });

            user.RemoveFavoriteMusic(music);

            await this.UserRepository.UpdateAsync(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(Guid id)
        {
            var user = await this.UserRepository.GetUserAsync(id);

            if (user == null)
                return UnprocessableEntity(new { Message = "User not found" });

            await this.UserRepository.RemoveAsync(user);

            return NoContent();
        }


    }
}
