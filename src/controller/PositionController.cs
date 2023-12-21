using System.Security;
using Bredex1.src.model;
using Bredex1.src.repository;
using Bredex1.src.service;
using Microsoft.AspNetCore.Mvc;

namespace Bredex1.src.controller
{
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly PositionService PositionService;

        public PositionController(PositionService positionService, EFInMemoryDBAccess dBAccess)
        {
            PositionService = positionService;
        }


        [HttpPost("/position")]
        public IActionResult AddNewPosition(Position position) {

            Request.Headers.TryGetValue("ApiKey", out var apiKeyValue);

            try {   

                PositionPersistResponse response = PositionService.PersistNewPosition(apiKeyValue, position);
                return Ok(response);
            }
            catch(VerificationException e) {

                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return BadRequest();
            }


        }

    }
}