using AutoMapper;
using BLL.interfacesBLL;
using DAL.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IuserBLL u;
        public UsersController(IuserBLL _u)
        {
            u = _u;
        }
        //GetAllUsers
        [HttpGet("GetAllUsers")]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(u.getAllUserBLL());
        }
        //GetUserByMailAndPassword
        [HttpGet("GetUserByMailAndPassword/{mail}/{password}")]
        public ActionResult<User> GetUserByMailAndPassword(string mail, string password)
        {
            return Ok(u.GetUserByMailAndPaswordBLL(mail, password));
        }
        //AddUser
        [HttpPost("AddUser")]
        public ActionResult<int> AddUser([FromBody] UserDTO user)
        {
            return Ok(u.AddUserBLL(user));
        }
        //UpdateUser
        [HttpPut("UpdateUser")]
        public ActionResult<bool> UpdateUser([FromBody] UserDTO user)
        {
            return Ok(u.UpdateUserBLL(user));
        }
        //DeleteUser
        [HttpDelete("DeleteUser/{id}")]
        public ActionResult<bool> DeleteUser(int id)
        {
            return Ok(u.DeleteUserBLL(id));
        }
        //GetAllTripToUser
        [HttpGet("GetAllTripToUser/{id}")]
        public ActionResult<List<Trip>> GetAllTripToUser(int id)
        {
            return Ok(u.GetAllTripsBLL(id));
        }
    }
}
