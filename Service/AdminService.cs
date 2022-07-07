using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.DTO;
using Tahaluf.SoundCloud.Core.Repository;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.Infra.Service
{
    public class AdminService : IAdminService
    {


        private readonly IAdminRepository adminRepository;

        public AdminService(IAdminRepository _adminRepository)
        {
            adminRepository = _adminRepository;
        }



        public bool CreateAdmin(Admin admin)
        {
            return adminRepository.CreateAdmin(admin);
        }

        public bool DeleteAdmin(int id)
        {
            return adminRepository.DeleteAdmin(id);
        }

        public List<Admin> GetAllAdmin()
        {
            return adminRepository.GetAllAdmin();
        }

        public bool UpdateAdmin(Admin admin)
        {
            return adminRepository.UpdateAdmin(admin);
        }




        public string auth(LoginDTO loginDTO)
        {
            var result = adminRepository.auth(loginDTO);
            if (result == null) return null;
            else
            {
                var TokenHandler = new JwtSecurityTokenHandler();
                var TokenKey = Encoding.UTF8.GetBytes("superSecretKey@345");
                var TokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Email, result.Email),
                        new Claim(ClaimTypes.Role, result.RoleName)
                    }),
                    Expires = DateTime.UtcNow.AddHours(24),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = TokenHandler.CreateToken(TokenDescriptor);
                return TokenHandler.WriteToken(token);
            }

        }

        public List<Admin> GetByAdminEmail(string email)
        {
            return adminRepository.GetByAdminEmail(email);
        }
    }
}
