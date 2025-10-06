using Microsoft.AspNetCore.Mvc;
using AuthService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace IdentityService.Models
{
    public class User
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}