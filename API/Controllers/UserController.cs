using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;


public class UserController : BaseApiController
{
    private readonly DataContext _context;
    public UserController(DataContext context){
        _context = context;
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
        var users = await _context.Users.ToListAsync();
        return users;
    }
    [Authorize] 
    [HttpGet("{id}")] // /api/users/2
    public async Task<ActionResult<AppUser>> GetUserById(int id){
        var user = await _context.Users.FindAsync(id);
        if(user == null){
            return NotFound();
        }
        else{
            return user;
        }
    }
}
 