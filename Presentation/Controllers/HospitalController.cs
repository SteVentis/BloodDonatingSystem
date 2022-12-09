using Contracts.HospitalDtos;
using Contracts.IdentityDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public HospitalController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAllHospitals()
        {

            var hospitals = _serviceManager.Hospitals.GetAllHospitals();

            return Ok(hospitals);
        }

        [HttpGet("{id}")]
        public IActionResult GetHospitalById(int id)
        {
            return Ok(_serviceManager.Hospitals.GetHospitalById(id));
        }

        [HttpPost]
        public IActionResult RegisterHospital(HospitalCreateDto hospitalDto)
        {
            RegistrationModelDto registerModelDto = new RegistrationModelDto();
            registerModelDto.Email = hospitalDto.Email;
            registerModelDto.UserName = hospitalDto.UserName;
            registerModelDto.PasswordHash = hospitalDto.PasswordHash;
            registerModelDto.Role_Id = hospitalDto.Role_Id;

            _serviceManager.AuthUsers.Register(registerModelDto);
            _serviceManager.Hospitals.InsertHospital(hospitalDto);

            return Ok();

        }
    }
}
