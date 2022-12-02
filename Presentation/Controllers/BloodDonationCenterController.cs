using Contracts.BloodDonationCenterDtos;
using Microsoft.AspNetCore.Mvc;
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
    public class BloodDonationCenterController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public BloodDonationCenterController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAllBloodDonationCenters()
        {
            var bloodDonationCenters = _serviceManager.BloodDonationCenters.GetAllBloodDonationCenters();

            return Ok(bloodDonationCenters);
        }

        [HttpGet("{id}")]
        public IActionResult GetBloodDonationCenterById(int id)
        {
            var blooddonationCenter = _serviceManager.BloodDonationCenters.GetBloodDonationCenterById(id);

            return Ok(blooddonationCenter);
        }
    }
}
