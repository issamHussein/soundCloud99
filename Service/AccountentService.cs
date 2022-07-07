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
    public class AccountentService: IAccountantService
    {
        private readonly IAccountantRepository accountantRepository;

        public AccountentService(IAccountantRepository _accountantRepository)
        {
            accountantRepository = _accountantRepository;
        }

        public bool CreateAccountant(Accountant accountant)
        {
            return accountantRepository.CreateAccountant(accountant);
        }

        public bool DeleteAccountant(int id)
        {
            return accountantRepository.DeleteAccountant(id);
        }

        public List<Accountant> GetAllAccountants()
        {
            return accountantRepository.GetAllAccountants();
        }

        public List<Accountant> GetByAccountantName(string accountantName)
        {
            return accountantRepository.GetByAccountantName(accountantName);
        }

        public bool UpdateAccountant(Accountant accountant)
        {
            return accountantRepository.UpdateAccountant(accountant);
        }




        public string auth(LoginDTO loginDTO)
        {
            var result = accountantRepository.auth(loginDTO);
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


        public List<profitReportsDTO> GetProfitReport(DateTime dateFrom, DateTime dateTo)
        {
            return accountantRepository.GetProfitReport(dateFrom, dateTo);
        }
        public List<profitReportsDTO> GetSumProfitReport(DateTime dateFrom, DateTime dateTo)
        {
            return accountantRepository.GetSumProfitReport(dateFrom, dateTo);
        }
        public List<LossesReportDTO> GetSalaryReport()
        {
            return accountantRepository.GetSalaryReport();
        }

        public List<LossesReportDTO> GetSumSalaryReport()
        {
            return accountantRepository.GetSumSalaryReport();

        }
        public List<Accountant> GetByAccountantEmail(string email)
        {
            return accountantRepository.GetByAccountantEmail(email);
        }


        public Accountant GetByAccountantID(int accId)
        {
            return accountantRepository.GetByAccountantID(accId);

        }






    }
}
