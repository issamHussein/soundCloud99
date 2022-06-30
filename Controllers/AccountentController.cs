using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.DTO;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountentController : ControllerBase
    {
        
        private readonly IAccountantService accountantService;
        public AccountentController(IAccountantService _accountantService)
        {
            accountantService = _accountantService;

        }


        [HttpGet]
        [Route("GetAllAccountants")]
        public List<Accountant> GetAllAccountants()
        {
            return accountantService.GetAllAccountants();
        }


        [HttpPost]
        [Route("CreateAccountant")]
        public bool CreateAccountant(Accountant accountant)
        {
            return accountantService.CreateAccountant(accountant);
        }



        [HttpPut]
        [Route("UpdateAccountant")]
        public bool UpdateAccountant(Accountant accountant)
        {
            return accountantService.UpdateAccountant(accountant);
        }


        [HttpDelete]
        [Route("DeleteAccountant/{id}")]
        public bool DeleteAccountant(int id)
        {
            return accountantService.DeleteAccountant(id);
        }


        [HttpGet]
        [Route("GetByAccountantName/{accountantName}")]
        public List<Accountant> GetByAccountantName(string accountantName)
        {
            return accountantService.GetByAccountantName(accountantName);
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Auth([FromBody] LoginDTO loginDTO)
        {

            var token = accountantService.auth(loginDTO);
            if (token == null) return Unauthorized();
            else return Ok(token);

        }


        [HttpPost]
        [Route("UploadImage")]
        public Accountant UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0]; //retrive file{Image} from Form which is part of the Request

                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = Path.Combine("C:\\Users\\issam\\Desktop\\soundCloud\\src\\assets\\img", fileName); ///Image/nvjfjgfgdtget53536ywwsyh_Aseel.jpg

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Accountant accountant = new Accountant();
                accountant.Image = fileName;
                return accountant;

            }
            catch (Exception e)
            {
                return null;
            }
        }







        [HttpPost]
        [Route("GetProfitReport")]
        public List<profitReportsDTO> GetProfitReport( profitReportsDTO profitReportsDTO)
        {
            return accountantService.GetProfitReport(profitReportsDTO.dateFrom, profitReportsDTO.dateTo);

        }

        [HttpPost]
        [Route("GetSumProfitReport")]
        public List<profitReportsDTO> GetSumProfitReport(profitReportsDTO profitReportsDTO)
        {
            return accountantService.GetSumProfitReport(profitReportsDTO.dateFrom, profitReportsDTO.dateTo);

        }


        [HttpGet]
        [Route("GetSalaryReport")]
        public List<LossesReportDTO> GetSalaryReport()
        {
            return accountantService.GetSalaryReport();

        }

        [HttpGet]
        [Route("GetSumSalaryReport")]
        public List<LossesReportDTO> GetSumSalaryReport()
        {
            return accountantService.GetSumSalaryReport();

        }

        [HttpGet]
        [Route("GetByAccountantEmail/{email}")]
        public List<Accountant> GetByAccountantEmail(string email)
        {
            return accountantService.GetByAccountantEmail(email);

        }






        [HttpPut]
        [Route("UpdateAccountantByAccountant")]
        public bool UpdateAccountantByAccountant(Accountant accountant)
        {

             Accountant accountant1 = new Accountant();


             accountant1 = accountantService.GetByAccountantID(accountant.AccountantID);

             accountant.Salary = accountant1.Salary;


            return accountantService.UpdateAccountant(accountant);
        }









    }
}
