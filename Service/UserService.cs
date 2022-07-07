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
    public class UserService : IUserService
    {

        private readonly IUsersRepository usersRepository;

        public UserService(IUsersRepository _usersRepository)
        {
            usersRepository = _usersRepository;
        }


        public List<Users> GetAllUsers()
        {
            return usersRepository.GetAllUsers();
        }

        public bool CreateUsers(Users user)
        {
           return usersRepository.CreateUsers(user);
        }

        public bool UpdateUsers(Users user)
        {
            return usersRepository.UpdateUsers(user);
        }

        public bool DeleteUsers(int id)
        {
            return usersRepository.DeleteUsers(id);
        }

        public List<Users> GetByUserName(string userName)
        {
            return usersRepository.GetByUserName(userName);
        }




        public string auth(LoginDTO loginDTO)
        {
            var result = usersRepository.auth(loginDTO);
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

        public List<Users> GetByUserEmail(string email)
        {
            return usersRepository.GetByUserEmail(email);
        }

        public List<profitReportsDTO> GetProfitReport(DateTime dateFrom, DateTime dateTo, int userId)
        {
            return usersRepository.GetProfitReport(dateFrom, dateTo, userId);
        }



        public List<profitReportsDTO> GetSumProfitReport(DateTime dateFrom, DateTime dateTo, int userId)
        {
            return usersRepository.GetSumProfitReport(dateFrom, dateTo, userId);
        }



        public int GetIdByUserEmail(string email)
        {
            return usersRepository.GetIdByUserEmail(email);
        }

    }
}
